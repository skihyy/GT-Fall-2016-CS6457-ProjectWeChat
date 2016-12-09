using UnityEngine;
using System.Collections;

public class zombieMove : MonoBehaviour {
	GameObject pp1;
	GameObject pp2;
	GameObject pp3;
	GameObject pp4;
	GameObject pp5;
	GameObject pp6;
	GameObject pp7;
	GameObject pp8;
	public int patrolid;
	public int id;
	GameObject followcube;
	cube c;
	GameObject[] citizens;
	int ischasing;
	Animator anim;
	bool isPatrol;
	public bool attacking;
	Vector3 target;
	GameObject targetCitizen;
	AudioSource audio;
	public AudioClip find;
	public AudioClip hit;
	ParticleSystem Ps;

	// Use this for initialization
	void Start(){
		//gameObject.SetActive(false);
		//string cube = "Cube" + id;
		//GameObject.Find (cube).SetActive(false);
	}
	void Awake () {

		//citizens = GameObject.FindGameObjectsWithTag ("citizens");
		pp1 = GameObject.Find ("zombiePoint1");
		pp2 = GameObject.Find ("zombiePoint2");
		pp3 = GameObject.Find ("zombiePoint3");
		pp4 = GameObject.Find ("zombiePoint4");
		pp5 = GameObject.Find ("zombiePoint5");
		pp6 = GameObject.Find ("zombiePoint6");
		pp7 = GameObject.Find ("zombiePoint7");
		pp8 = GameObject.Find ("zombiePoint8");
		patrolid = 1;
		ischasing = -1;
		string name = "Cube" + id;
		followcube = GameObject.Find (name);
		c = followcube.GetComponent<cube> ();
		anim=GetComponent<Animator> ();
		isPatrol = true;
		attacking = false;
		target = transform.position;
		audio = GetComponent<AudioSource> ();
		audio.Play ();
		Ps = GetComponent<ParticleSystem> ();
		Ps.Play ();

	}

	void findPlayerInRange(){
		citizens = GameObject.FindGameObjectsWithTag ("citizen");
		int currentnear = -1;
		float mindis = 10000;
		float dis;
		for (int i = 0; i < citizens.Length; i++) {
			if (citizens [i].GetComponent<CitizenHealth> ().currentHealth > 0) {
				dis = Vector3.Distance (transform.position, citizens [i].transform.position);
				if (dis < 10) {
					if (dis < mindis) {
						currentnear = i;
						mindis = dis;
					}
				}
			}
		}
		if (currentnear == -1) {
			c.setSpeed (0);
			anim.SetFloat ("attack",0.0f);
			anim.SetFloat ("run",0.0f);
			isPatrol=true;
			if (ischasing != -1) {
				targetCitizen.GetComponent<CitizenMove>().chasingZombies[id]=0;
			}
			ischasing = -1;
			attacking = false;
			target = followcube.transform.position;
		}

		else if (currentnear != -1 ) {
			anim.SetFloat ("run",0.2f);
			c.setSpeed(1);
			ischasing=citizens[currentnear].GetComponent<CitizenMove>().id;
			citizens[currentnear].GetComponent<CitizenMove>().chasingZombies[id]=1;
			target=citizens[currentnear].transform.position;
			isPatrol=false;
			targetCitizen = citizens [currentnear];
		}


	}

	void Update () {

		findPlayerInRange ();
		if (Vector3.Distance (transform.position, followcube.transform.position) > 5) {
			c.setSpeed (2);
		} 
		if (isPatrol) {
			patrol ();
		} else {
			c.des = target;
		}
		if (!attacking) {

			Transform tempt = followcube.transform;
			Vector3 tempp = tempt.position;
			tempp.y = transform.position.y;
			tempt.position = tempp;
			transform.LookAt (tempt);
			//transform.LookAt (followcube.transform);
		}
	}

	void patrol(){
		switch (patrolid) {
		case 1:
			c.des = pp1.transform.position;
			break;
		case 2:
			c.des = pp2.transform.position;
			break;
		case 3:
			c.des = pp3.transform.position;
			break;
		case 4:
			c.des = pp4.transform.position;
			break;
		case 5:
			c.des = pp5.transform.position;
			break;
		case 6:
			c.des = pp6.transform.position;
			break;
		case 7:
			c.des = pp7.transform.position;
			break;
		case 8:
			c.des = pp8.transform.position;
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (isPatrol) {

			if (other.gameObject == pp1) {
				//Debug.Log ("enter");
				patrolid = 2;
			} else if (other.gameObject == pp2) {
				patrolid = 3;
			} else if (other.gameObject == pp3) {
				patrolid = 4;
			} else if (other.gameObject == pp4) {
				patrolid = 5;
			}else if (other.gameObject == pp5) {
				patrolid = 6;
			} else if (other.gameObject == pp6) {
				patrolid = 7;
			} else if (other.gameObject == pp7) {
				patrolid = 8;
			}else if (other.gameObject == pp8) {
				patrolid = 1;
			}



		} else if(other.gameObject.tag == "citizen") {
			if (other.gameObject.GetComponent<CitizenHealth> ().currentHealth < 0) {
				/*anim.SetFloat ("attack",0.0f);
				c.setSpeed (1);
				isPatrol = true;
				attacking = false;*/
				return;
			}
			anim.SetFloat ("attack",0.2f);
			//c.setSpeed (2);
			attacking = true;
			//Debug.Log ("attacking");
		}

	}

	/*void OnTriggerStay(Collider other) {
		if (other.gameObject.tag=="citizen"){
			if (other.gameObject.GetComponent<CitizenHealth> ().currentHealth < 0) {
				
				return;
			}
			anim.SetFloat ("attack",0.2f);
			//c.setSpeed (2);
			attacking = true;

	    }
    }*/


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject.tag == "citizen")
		{
			c.setSpeed (0);
			anim.SetFloat("attack",0.0f);
			attacking = false;

		}
	}

	void hitSound(){
		audio.clip = hit;
		audio.Play ();
		targetCitizen.GetComponent<CitizenHealth>().takeDamage();
	}
	void hitParticle(){
		
	}

}
