using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CitizenMove : MonoBehaviour {

	public int[] chasingZombies;
	public Transform[] patrolPoint;
	public int id;
	private UnityEngine.AI.NavMeshAgent navMeshAgent;
	private bool isSeen;
	private int nextPatrolPoint = 0;
	// Use this for initialization
	void Start () {
		chasingZombies = new int[10];
		navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 10; i++) {
			if (chasingZombies [i] == 1) {
				isSeen = true;
				break;
			}
		}

		if (isSeen) {
			RunAway ();
			//Debug.Log ("RunAway");
		} else {
			Patrol ();
		}
	}

	void RunAway(){
		Vector3 citizenPosition = gameObject.transform.position;
		Vector3 zombiePosition;
		float distance;
		float minDistance = float.MaxValue;
		Vector3 minDistancePosision = new Vector3(0,0,0);
		float secMinDistance = float.MaxValue;
		Vector3 secMinDistancePosition = new Vector3(0,0,0);
		Vector3 direction;
		//Vector3 destination;

		//Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
		if (chasingZombies [0] == 1) {
			zombiePosition = GameObject.Find ("Zombie0").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [1] == 1) {
			zombiePosition = GameObject.Find ("Zombie1").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [2] == 1) {
			zombiePosition = GameObject.Find ("Zombie2").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [3] == 1) {
			zombiePosition = GameObject.Find ("Zombie3").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [4] == 1) {
			zombiePosition = GameObject.Find ("Zombie4").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [5] == 1) {
			zombiePosition = GameObject.Find ("Zombie5").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [6] == 1) {
			zombiePosition = GameObject.Find ("Zombie6").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [7] == 1) {
			zombiePosition = GameObject.Find ("Zombie7").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [8] == 1) {
			zombiePosition = GameObject.Find ("Zombie8").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		if (chasingZombies [9] == 1) {
			zombiePosition = GameObject.Find ("Zombie9").transform.position;
			distance = Vector3.Distance (citizenPosition, zombiePosition);
			if (distance <= minDistance) {
				secMinDistance = minDistance;
				minDistance = distance;
				secMinDistancePosition = minDistancePosision;
				minDistancePosision = zombiePosition;
			} else if (distance <= minDistance) {
				secMinDistance = distance;
				secMinDistancePosition = zombiePosition;
			}
		}

		//player
//		distance = Vector3.Distance (gameObject.transform.position, player.position);
//		if (distance <= minDistance) {
//			secMinDistance = minDistance;
//			minDistance = distance;
//			secMinDistancePosition = minDistancePosision;
//			minDistancePosision = player.position;
//		} else if (distance <= minDistance) {
//			secMinDistance = distance;
//			secMinDistancePosition = player.position;
//		}

		if (secMinDistance == float.MaxValue) {
			direction = Vector3.Normalize (citizenPosition - minDistancePosision);
			navMeshAgent.SetDestination (citizenPosition + 10 * direction);
			navMeshAgent.Resume ();
		} else {
			direction = Vector3.Normalize (2 * citizenPosition - minDistancePosision - secMinDistancePosition);
			navMeshAgent.SetDestination (citizenPosition + 10 * direction);
			navMeshAgent.Resume ();
		}

	}

	void Patrol(){
		navMeshAgent.destination = patrolPoint[nextPatrolPoint].position;
		navMeshAgent.Resume ();

		 if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending) {
			nextPatrolPoint = (nextPatrolPoint + 1) % patrolPoint.Length;
			nextPatrolPoint = Random.Range (0, patrolPoint.Length - 1);
		}
	}

}
