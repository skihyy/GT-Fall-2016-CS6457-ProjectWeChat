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
    float timeLeft;
    AudioSource[] audios;

    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        //GameObject.Find("BattleShip");
        timeLeft = 45f;
        animator = this.gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = true;
        //agent.updateRotation = true;
        audios = this.gameObject.GetComponents<AudioSource>();
        if (this.gameObject.name == ("SoldierPrefab1"))
        {
            audios[0].PlayDelayed(timeLeft);
            audios[1].PlayDelayed(timeLeft+7);
        }

        if (this.gameObject.name == ("SoldierPrefab2"))
        {
            audios[0].PlayDelayed(timeLeft+4.3f);
            audios[1].PlayDelayed(timeLeft + 11);
        }

        if (this.gameObject.name == ("SoldierPrefab3"))
        {
            audios[0].PlayDelayed(timeLeft + 12.5f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft < 0)
        {
            objectToActivate.SetActive(true);
            //objectToActivate2.SetActive(true);
            //rend.enabled = true;
            animator.enabled = true;
            agent.SetDestination(wayPoints[nextWayPoint].position);
            //transform.position = agent.nextPosition;
            agent.Resume();
            Vector3 targetDir = wayPoints[nextWayPoint].position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 5 * Time.deltaTime, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                nextWayPoint = (nextWayPoint + 1) % wayPoints.Length;
            }

            
        }

        else
        {
            animator.enabled = false;
            //rend.enabled = false;
            objectToActivate.SetActive(false);
        }
    }
}
