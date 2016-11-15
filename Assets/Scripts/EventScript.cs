using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EventScript : MonoBehaviour {
	float time;
	public RawImage message;
	enum State{hunt,survive,escape,gameover};
	State state; 
	public Text timer;
	bool nextState;
	// Use this for initialization
	void Start () {
		time = 30f;
		nextState = false;
		message.texture = (Texture) Resources.Load ("hunt");
		state = State.hunt;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime ();
		outTimer ();
		stateChange ();
	}
	void fadeImage(){
		message.CrossFadeAlpha (0, 2f, true);
	}
	void updateTime(){
		time -= Time.deltaTime;
		time = Mathf.Max (0, time);
		float seconds = Mathf.Floor(time % 60);
		float minutes = Mathf.Floor (time / 60);
		timer.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
	}
	void outTimer(){
		if(time == 0)
			nextState = true;
	}
	void stateChange(){
		switch (state) {
		case State.hunt:
			if (nextState) {
				time = 180f;
				state = State.survive;
				message.texture = (Texture) Resources.Load ("Survive");
				message.CrossFadeAlpha (255, .1f, true);
				nextState = false;
			}
			message.CrossFadeAlpha (0, 5f, true);
			break;
		case State.survive:
			if (nextState) {
				time = 300f;
				state = State.escape;
				message.texture = (Texture) Resources.Load ("Escape");
				message.CrossFadeAlpha (255, .1f, true);
				nextState = false;
			}
			fadeImage ();
			break;
		case State.gameover:
			fadeImage ();
			//
			break;
		}
	}
}
