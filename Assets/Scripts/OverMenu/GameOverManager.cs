using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameWinManager : MonoBehaviour {

	public enum MenuState{
		Menu,
		Quit,
	};
	private MenuState currentState = MenuState.Menu;

	public GameObject menuButton;
	public GameObject quitButton;
	public Text menuText;
	public Text quitText;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)
			|| Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) { 
			ChangeButton ();
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (currentState == MenuState.Menu) {
				LoadMenu ();
			} else {
				Quit ();
			}
		}
	}


	private void ChangeButton(){
		if (currentState == MenuState.Quit) {
			currentState = MenuState.Menu;
			menuText.color = Color.white;
			quitText.color = Color.black;
		} else {
			currentState = MenuState.Quit;
			quitText.color = Color.white;
			menuText.color = Color.black;
		}
	}
	public void LoadMenu(){
		//Debug.Log ("Hello");
		SceneManager.LoadScene ("Menu_Scene");
	}

	public void Quit(){
		// UnityEditor.EditorApplication.isPlaying = false; // debug in editor
		Application.Quit ();
	}
}
