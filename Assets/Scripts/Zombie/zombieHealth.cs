using UnityEngine;
using System.Collections;

public class zombieHealth : MonoBehaviour {
	Animator anim;
	public int health;
	bool isDead;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		health = 100;
		isDead = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void takeDamage(int value){
		if (isDead) {
			return;
		}
		health -= value;
		if (health <= 0) {
			death ();
		}
	}
	void death(){
		isDead = true;
		GetComponent<zombieMove> ().enabled = false;
		anim.SetTrigger ("dead");
		Destroy (gameObject, 2f);
	}
}
