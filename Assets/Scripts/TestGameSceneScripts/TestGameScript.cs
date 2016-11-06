using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestGameScript : MonoBehaviour {

	private Text timerText;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.fixedTime;

		timerText.text = timer + "";
	}
}
