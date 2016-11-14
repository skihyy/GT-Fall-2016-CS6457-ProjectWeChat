using UnityEngine;
using System.Collections;

public class zombietest: MonoBehaviour {
	GameObject pp1;
	GameObject pp2;
	GameObject pp3;
	GameObject pp4;
	public int patrolid;
	public int id;
	GameObject followcube;
	cube c;
	// Use this for initialization
	void Awake () {
		//citizens = GameObject.FindGameObjectsWithTag ("citizens");
		pp1 = GameObject.Find ("zombiePoint1");
		pp2 = GameObject.Find ("zombiePoint2");
		pp3 = GameObject.Find ("zombiePoint3");
		pp4 = GameObject.Find ("zombiePoint4");
		patrolid = 1;
		string name = "Cube" + id;
		followcube = GameObject.Find (name);
		c = followcube.GetComponent<cube> ();
	}


	void Update () {
		//testPlayerinRange();
		patrol();
		transform.LookAt (followcube.transform);
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
		default:
			break;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//Debug.Log ("enter");
		//if (isPatrol) {
	   if (other.gameObject==pp1) {
			//Debug.Log ("enter");
			patrolid = 2;
		}
		else if(other.gameObject==pp2){
			patrolid = 3;
		}
		else if(other.gameObject==pp3){
			patrolid = 4;
		}
		else if(other.gameObject==pp4){
			patrolid = 1;
		}
		//} 
	}
}
