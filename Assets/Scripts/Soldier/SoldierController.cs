using UnityEngine;
using System.Collections;

public class SoldierController : MonoBehaviour {

    public GameObject objectToActivate;
    public GameObject objectToActivate2;
    public GameObject BattleShip;
    public Transform[] wayPoints;
    Animator animator;
    Renderer rend;
    public NavMeshAgent agent;
    private int nextWayPoint;
    public float timeLeft;
    AudioSource[] audios;
    GameObject[] zombies;
    bool isPatrol;
    bool attacking;
    int ischasing;
    GameObject targetZombie;
	GameObject targetPlayer;
    Transform chaseTarget;
    float shootTime = 0.0f;
    float shootBetween = 3.5f;

    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        //GameObject.Find("BattleShip");
        timeLeft = 40f;
        animator = this.gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        //agent.updateRotation = true;
        audios = this.gameObject.GetComponents<AudioSource>();
        if (this.gameObject.name == ("SoldierPrefab1"))
        {
            audios[1].PlayDelayed(timeLeft);
            audios[2].PlayDelayed(timeLeft+14);
        }

        if (this.gameObject.name == ("SoldierPrefab2"))
        {
            audios[1].PlayDelayed(timeLeft+4.3f);
            audios[2].PlayDelayed(timeLeft + 16);
        }

        if (this.gameObject.name == ("SoldierPrefab3"))
        {
            audios[1].PlayDelayed(timeLeft + 18f);

        }
    }

	void findPlayerInRange (){
		targetPlayer = GameObject.FindGameObjectWithTag ("Player");
		float dis;

		dis = Vector3.Distance (transform.position, targetPlayer.transform.position);
		if (dis < 20) {
			Vector3 targetDir = targetPlayer.transform.position - transform.position;
			Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, 5 * Time.deltaTime, 0.0F);
			transform.rotation = Quaternion.LookRotation (newDir);
			agent.SetDestination (targetPlayer.transform.position);
			agent.Resume ();

			if (Time.time >= shootTime)
			{
				//print("check");
				//agent.Stop();
				targetPlayer.GetComponent<PlayerHealthControl>().takeDamage(20);
				shootTime = Time.time + shootBetween;
				audios[0].Play();
			}


		} else {
			patrol ();
		}


	}

    void findZombieInRange()
    {
        zombies = GameObject.FindGameObjectsWithTag("zombie");
        int currentnear = -1;
        float mindis = 10000;
        float dis;
        //print(zombies.Length);
            for (int i = 0; i < zombies.Length; i++)
        {
            //print(zombies[i].name);
            //print(zombies[i].GetComponent<zombieHealth>().health);
            if (zombies[i].GetComponent<zombieHealth>().health > 0)
            {
                dis = Vector3.Distance(transform.position, zombies[i].transform.position);
                if (dis < 10)
                {
                    if (dis < mindis)
                    {
                        currentnear = i;
                        mindis = dis;
                    }
                }
            }
        }
        if (currentnear == -1)
        {
			findPlayerInRange ();
        }

        else if (currentnear != -1)
        {
            targetZombie = zombies[currentnear];
            //chaseTarget = zombies[currentnear].transform;
            Vector3 targetDir = targetZombie.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 5 * Time.deltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            agent.SetDestination(targetZombie.transform.position);
            agent.Resume();

            if (Time.time >= shootTime)
            {
                //print("check");
                //agent.Stop();
                targetZombie.GetComponent<zombieHealth>().takeDamage(40);
                shootTime = Time.time + shootBetween;
                audios[0].Play();
            }
        }


    }

    void patrol()
    {
        agent.SetDestination(wayPoints[nextWayPoint].position);
        transform.position = agent.nextPosition;
        agent.Resume();
        Vector3 targetDir = wayPoints[nextWayPoint].position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 5 * Time.deltaTime, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            objectToActivate.SetActive(true);
            animator.enabled = true;
            findZombieInRange();

            



        }

        else
        {
            animator.enabled = false;
            //rend.enabled = false;
            objectToActivate.SetActive(false);
        }
    }
}
