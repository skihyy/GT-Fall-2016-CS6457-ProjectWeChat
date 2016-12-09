using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {
	public Vector3 des;
	UnityEngine.AI.NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		des = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination (des);
	}


	public void setSpeed(int state){
		if (state == 0) {
			nav.speed = 0.35f;
		} else if (state == 1) {
			nav.speed = 3.5f;
		} else if (state == 2) {
			nav.speed = 0.0f;
		}

	}
}
