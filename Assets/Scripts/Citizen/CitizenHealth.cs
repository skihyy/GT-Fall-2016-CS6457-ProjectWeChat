using UnityEngine;
using System.Collections;

public class CitizenHealth : MonoBehaviour {

	public int currentHealth = 100;
	public AudioClip deathClip;
	GameObject callzombie;
	GameObject callcube;
	private AudioSource citizenAudio;
	private CitizenMove citizenMove;
	private LocomotionSimpleAgent locomotionSimpleAgent;
	private Animator anim;
	private bool isDead;
	int id;

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		citizenAudio = GetComponent<AudioSource> ();
		citizenMove = GetComponent<CitizenMove> ();
		locomotionSimpleAgent = GetComponent<LocomotionSimpleAgent> ();
		anim = GetComponent<Animator> ();
		id = GetComponent<CitizenMove> ().id;
		string zombiename = "Zombie" + id;
		string cubename = "Cube" + id;
		callzombie = GameObject.Find (zombiename);
		callcube = GameObject.Find (cubename);
		callzombie.SetActive (false);
		callcube.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		
	}

//	public void takeDamage(){
//		currentHealth -= 20;
//		if (currentHealth <= 0 && !isDead) {
//			die ();
//		} else {
//			citizenAudio.Play ();
//		}
//	}

	public void takeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0 && !isDead) {
			die ();
		} else {
			citizenAudio.Play ();
		}
	}

	public void die(){
		isDead = true;
		citizenAudio.clip = deathClip;
		citizenAudio.PlayOneShot (deathClip);
		citizenMove.enabled = false;
		locomotionSimpleAgent.enabled = false;
		anim.SetTrigger ("Die");
		Vector3 temp = callcube.transform.position;
		temp.x = transform.position.x;
		temp.z = transform.position.z;
		callcube.SetActive (true);
		callcube.transform.position = temp;


		temp = callzombie.transform.position;
		temp.x = transform.position.x+1;
		temp.z = transform.position.z;
		callzombie.SetActive (true);

		callzombie.transform.position = temp;

		Destroy (gameObject, 2f);
	}

}
