using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {
    GameObject hand;
    
    // Use this for initialization
    void Start () {
        hand = GameObject.Find("mixamorig:RightHand");
        

        transform.parent = hand.transform;
        transform.localEulerAngles = new Vector3(-80, 0, 90);
        transform.localScale = new Vector3(0.08f, 0.08f, 0.06f);
        transform.localPosition= new Vector3(-0.093f, 0.174f, 0.04f);
       
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
