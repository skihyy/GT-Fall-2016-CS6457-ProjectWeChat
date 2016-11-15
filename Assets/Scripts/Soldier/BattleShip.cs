using UnityEngine;
using System.Collections;

public class BattleShip : MonoBehaviour {

    public GameObject objectToActivate;
    public Transform battleShip;
    public Transform Position1;
    public Transform Position2;
    public Vector3 newPosition;
    float timeLeft;
    public float smooth;// Use this for initialization
    AudioSource[] audios;

    void Start () {
        smooth = 0.2f; 
        //Soldier appears after 30s
        timeLeft= 20f;
        audios = this.gameObject.GetComponents<AudioSource>();

        audios[0].PlayDelayed(timeLeft);
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;

        if (timeLeft<0) {
            objectToActivate.SetActive(true);
            battleShip.position = Vector3.Lerp(battleShip.position, Position2.position, smooth * Time.deltaTime);
        }
        else
        {
            objectToActivate.SetActive(false);
        }
    }

    private IEnumerator ActivationRoutine()
    {
        //Turn My game object that is set to false(off) to True(on).
        objectToActivate.SetActive(false);

        //Wait for 14 secs.
        yield return new WaitForSeconds(2);

        //Turn My game object that is set to false(off) to True(on).
        objectToActivate.SetActive(true);
    }
}
