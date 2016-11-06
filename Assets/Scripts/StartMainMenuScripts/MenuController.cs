using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu controller.
/// Author: Yuyang He
/// </summary>
public class MenuController : MonoBehaviour
{
	/*
	/// <summary>
	/// Use for keyboard control.
	/// </summary>
	public enum MenuState
	{
		StartNewGame,
		ShowCredits,
		CreditsGoBack,
		Quit,
		QuitConfirm,
		QuitGoBack
	}


	/// <summary>
	/// Current keyboard state.
	/// </summary>
	public MenuState currentState;

	private Color highLightColor = new Color (255, 255, 255);
	private Color defaultColor = new Color (255, 77, 77);*/

	public GameObject loadingImage;
	public GameObject startGameButton;
	public GameObject showCreditsButton;
	public GameObject credits;
	public GameObject quitButton;
	public GameObject quitConfirmBox;

	public Text startGameText;
	public Text showCreditsText;
	public Text creditsGoBackText;
	public Text quitText;
	public Text confirmQuirText;
	public Text quitGoBackText;

	/*
	public void Awake ()
	{
		currentState = MenuState.StartNewGame;
	}

	public void FixedUpdate ()
	{
		switch (currentState)
		{
			case MenuState.StartNewGame:
				print ("StartNewGame");
				StartNewGameHandler ();
				break;
			case MenuState.ShowCredits:
				print ("ShowCredits");
				ShowCreditsHandler ();
				break;
			case MenuState.CreditsGoBack:
				print ("CreditsGoBack");
				CreditsGoBackHandler ();
				break;
			case MenuState.Quit:
				print ("Quit");
				QuitHandler ();
				break;
			case MenuState.QuitConfirm:
				print ("QuitConfirm");
				QuitConfirmHandler ();
				break;
			case MenuState.QuitGoBack:
				print ("QuitGoBack");
				QuitGoBackHandler ();
				break;

		}
	}
	*/

	/// <summary>
	/// Starts the new game. This will load a loading image.
	/// </summary>
	/// <param name="level">Level index.</param>
	public void StartNewGame (int level)
	{
		loadingImage.SetActive (true);
		SceneManager.LoadScene (level);
	}

	/// <summary>
	/// Shows the credits.
	/// </summary>
	/// <param name="isShow">Is show.</param>
	public void ShowCredits (bool isHidden)
	{
		startGameButton.SetActive (isHidden);
		showCreditsButton.SetActive (isHidden);
		quitButton.SetActive (isHidden);
		credits.SetActive (!isHidden);
	}

	/// <summary>
	/// Shows the quit confirm.
	/// </summary>
	public void ShowQuitConfirm (bool isHidden)
	{
		startGameButton.SetActive (isHidden);
		showCreditsButton.SetActive (isHidden);
		quitButton.SetActive (isHidden);
		quitConfirmBox.SetActive (!isHidden);
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void QuitGame ()
	{
		UnityEditor.EditorApplication.isPlaying = false; // debug in editor

		Application.Quit ();
	}

	/*
	/// <summary>
	/// Highlights the text or de-highlight it based on the input.
	/// </summary>
	/// <returns>The text.</returns>
	/// <param name="text">Text.</param>
	/// <param name="isHighLighting">Is high lighting.</param>
	private void HighlightText (Text text, bool isHighLighting)
	{
		if (isHighLighting)
		{
			text.color = highLightColor;
		}
		else
		{
			text.color = defaultColor;
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void StartNewGameHandler ()
	{
		HighlightText (startGameText, true);
		// enter is pressed
		if (Input.GetKeyDown (KeyCode.Return))
		{
			StartNewGame (1);
		}
		// up is pressed
		else if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			currentState = MenuState.ShowCredits;
			HighlightText (startGameText, false);
		}
		// down is pressed
		else if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentState = MenuState.Quit;
			HighlightText (startGameText, false);
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void ShowCreditsHandler ()
	{
		HighlightText (showCreditsText, true);
		if (Input.GetKeyDown (KeyCode.Return))
		{
			ShowCredits (false);
		}
		// if press "down"
		else if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			currentState = MenuState.Quit;
			HighlightText (showCreditsText, false);
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentState = MenuState.StartNewGame;
			HighlightText (showCreditsText, false);
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void CreditsGoBackHandler ()
	{
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Escape))
		{
			ShowCredits (true);
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void QuitHandler ()
	{
		HighlightText (quitText, true);
		// enter is pressed
		if (Input.GetKeyDown (KeyCode.Return))
		{
			ShowQuitConfirm (false);
		}
		// up is pressed
		else if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			currentState = MenuState.StartNewGame;
			HighlightText (quitText, false);
		}
		// down is pressed
		else if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentState = MenuState.ShowCredits;
			HighlightText (quitText, false);
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void QuitConfirmHandler ()
	{
		HighlightText (confirmQuirText, true);
		// enter is pressed
		if (Input.GetKeyDown (KeyCode.Return))
		{
			QuitGame ();
		}
		// up is pressed
		else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentState = MenuState.QuitGoBack;
			HighlightText (confirmQuirText, false);
		}
	}

	/// <summary>
	/// Handle current highlighting state keyboard input.
	/// </summary>
	private void QuitGoBackHandler ()
	{
		HighlightText (quitGoBackText, true);
		// enter is pressed
		if (Input.GetKeyDown (KeyCode.Return))
		{
			ShowQuitConfirm (true);
		}
		// up is pressed
		else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.UpArrow))
		{
			currentState = MenuState.QuitConfirm;
			HighlightText (quitGoBackText, false);
		}
	}
	*/
}
