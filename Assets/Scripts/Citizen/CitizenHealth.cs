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

	public void takeDamage(){
		currentHealth -= 100;
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

		callcube.SetActive (true);
		Vector3 temp_1 = transform.position;
		temp_1.y -= 3;
		callcube.transform.position =transform.position;


		Vector3 temp = transform.position;
		temp.x +=1;
		callzombie.SetActive (true);
		callzombie.transform.position = temp;

		Destroy (gameObject, 2f);
	}

}
