using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class exitArea : MonoBehaviour {
	float timeLeft;
	ParticleSystem ps;
	bool played=false;
	// Use this for initialization
	void Start () {
		timeLeft = 50f;
		ps = this.gameObject.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0&&!played) {
			ps.Play ();
			played = true;
		}
	}

	void OnTriggerEnter (Collider other)
	{  
		if (timeLeft < 0) {
			if (other.gameObject.name == "Player") {
				//DO 
				StartCoroutine(Wait());
				SceneManager.LoadScene("GameWinMenu");
			}
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(5);
	}

}
