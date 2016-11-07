using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Menu controller.
/// Author: Yuyang He
/// </summary>
public class MenuController : MonoBehaviour
{
	/// <summary>
	/// Menu state.
	/// </summary>
	public enum MenuState
	{
		IntroductionButton,
		IntroductionGoBackButton,
		StartNewGameButton,
		ShowCreditsButton,
		CreditsGoBackButton,
		QuitButton,
		QuitConfirmButton,
		QuitGoBackButton,
	}

	private MenuState currentState = MenuState.IntroductionButton;

	// water blur shader for show detailed texted
	public GameObject shader;
	// buttons
	public GameObject introductionButton;
	public GameObject startGameButton;
	public GameObject showCreditsButton;
	public GameObject quitButton;
	// after clicking buttons, the details
	public GameObject introduction;
	public GameObject credits;
	public GameObject quitConfirmBox;
	public GameObject loadingText;

	// the following text is used for highting for keyboard control
	public Text introductionButtonText;
	public Text introductionGoBackButtonText;
	public Text startNewGameButtonText;
	public Text showCreditsButtonText;
	public Text creditsGoBackButtonText;
	public Text quitButtonText;
	public Text quitConfirmButtonText;
	public Text quitGoBackButtonText;

	public void Start ()
	{
		introductionButtonText.color = Color.white;
	}

	/// <summary>
	/// Keyboard listener for controlling the menu.
	/// </summary>
	public void Update ()
	{		
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			DealUp ();
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			DealDown ();
		}
		else if (Input.GetKeyDown (KeyCode.Escape))
		{
			DealEscape ();
		}
		else if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter))
		{
			DealReturn ();
		}
	}

	/// <summary>
	/// Clicks the and show.
	/// </summary>
	/// <returns>The and show.</returns>
	/// <param name="id">Identifier of button.</param>
	public void ClickAndShow (int id)
	{
		// 0 is a go back button
		// go back to main menu
		if (0 == id)
		{
			shader.SetActive (false);

			introduction.SetActive (false);
			credits.SetActive (false);
			quitConfirmBox.SetActive (false);

			introductionButton.SetActive (true);
			startGameButton.SetActive (true);
			showCreditsButton.SetActive (true);
			quitButton.SetActive (true);

			currentState = MenuState.IntroductionButton;
		}
		else
		{
			shader.SetActive (true);

			introductionButton.SetActive (false);
			startGameButton.SetActive (false);
			showCreditsButton.SetActive (false);
			quitButton.SetActive (false);

			switch (id)
			{
			// 1 is introduction button
				case 1:
					currentState = MenuState.IntroductionGoBackButton;
					introduction.SetActive (true);
					break;
			// 2 is credits button
				case 2:
					currentState = MenuState.CreditsGoBackButton;
					credits.SetActive (true);
					break;
			// 3 is quit button
				case 3:
					currentState = MenuState.QuitConfirmButton;
					quitConfirmBox.SetActive (true);
					break;
			}
		}
	}

	/// <summary>
	/// Starts the new game. This will load a loading image.
	/// </summary>
	/// <param name="level">Level index.</param>
	public void StartNewGame (int level)
	{
		loadingText.SetActive (true);
		SceneManager.LoadScene (level);
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void QuitGame ()
	{
		UnityEditor.EditorApplication.isPlaying = false; // debug in editor

		Application.Quit ();
	}

	/// <summary>
	/// Deals up arrow key pressed.
	/// </summary>
	private void DealUp ()
	{
		ChangeColor (Color.red);
		switch (currentState)
		{
			case MenuState.IntroductionButton:
				currentState = MenuState.QuitButton;
				break;
			case MenuState.StartNewGameButton:
				currentState = MenuState.IntroductionButton;
				break;
			case MenuState.ShowCreditsButton:
				currentState = MenuState.StartNewGameButton;
				break;
			case MenuState.QuitButton:
				currentState = MenuState.ShowCreditsButton;
				break;
			case MenuState.QuitConfirmButton:
				currentState = MenuState.QuitGoBackButton;
				break;
			case MenuState.QuitGoBackButton:
				currentState = MenuState.QuitConfirmButton;
				break;
		}
		ChangeColor (Color.white);
	}

	/// <summary>
	/// Deals down arrow key pressed.
	/// </summary>
	private void DealDown ()
	{
		ChangeColor (Color.red);
		switch (currentState)
		{
			case MenuState.IntroductionButton:
				currentState = MenuState.StartNewGameButton;
				break;
			case MenuState.StartNewGameButton:
				currentState = MenuState.ShowCreditsButton;
				break;
			case MenuState.ShowCreditsButton:
				currentState = MenuState.QuitButton;
				break;
			case MenuState.QuitButton:
				currentState = MenuState.IntroductionButton;
				break;
			case MenuState.QuitConfirmButton:
				currentState = MenuState.QuitGoBackButton;
				break;
			case MenuState.QuitGoBackButton:
				currentState = MenuState.QuitConfirmButton;
				break;
		}
		ChangeColor (Color.white);
	}

	/// <summary>
	/// Deals esc key pressed.
	/// </summary>
	private void DealEscape ()
	{
		ChangeColor (Color.red);
		switch (currentState)
		{
			case MenuState.IntroductionGoBackButton:
				
				ClickAndShow (0);
				currentState = MenuState.IntroductionButton;
				break;
			case MenuState.CreditsGoBackButton:
				
				ClickAndShow (0);
				currentState = MenuState.ShowCreditsButton;
				break;
			case MenuState.QuitConfirmButton:				
				ClickAndShow (0);
				break;
			case MenuState.QuitGoBackButton:
				
				ClickAndShow (0);
				currentState = MenuState.QuitButton;
				break;
		}
		ChangeColor (Color.white);
	}

	/// <summary>
	/// Deals enter key pressed.
	/// </summary>
	private void DealReturn ()
	{
		ChangeColor (Color.red);
		switch (currentState)
		{
			// only 0 needs to change state
			// otherwise, this will be changed in the ClickAndShow()
			case MenuState.IntroductionButton:
				ClickAndShow (1);
				break;
			case MenuState.IntroductionGoBackButton:				
				ClickAndShow (0);
				currentState = MenuState.IntroductionButton;
				break;
			case MenuState.StartNewGameButton:
				StartNewGame (1);
				break;
			case MenuState.ShowCreditsButton:
				ClickAndShow (2);
				break;
			case MenuState.CreditsGoBackButton:				
				ClickAndShow (0);
				currentState = MenuState.ShowCreditsButton;
				break;
			case MenuState.QuitButton:
				ClickAndShow (3);
				break;
			case MenuState.QuitConfirmButton:
				QuitGame ();
				break;
			case MenuState.QuitGoBackButton:				
				ClickAndShow (0);
				currentState = MenuState.QuitButton;
				break;
		}
		ChangeColor (Color.white);
	}

	/// <summary>
	/// Gets the state text.
	/// </summary>
	/// <returns>The state text.</returns>
	/// <param name="isCurrentState">Is current state.</param>
	private void ChangeColor (Color color)
	{
		switch (currentState)
		{
			case MenuState.IntroductionButton:
				introductionButtonText.color = color;
				break;
			case MenuState.IntroductionGoBackButton:
				introductionGoBackButtonText.color = color;
				break;
			case MenuState.StartNewGameButton:
				startNewGameButtonText.color = color;
				break;
			case MenuState.ShowCreditsButton:
				showCreditsButtonText.color = color;
				break;
			case MenuState.CreditsGoBackButton:
				creditsGoBackButtonText.color = color;
				break;
			case MenuState.QuitButton:
				quitButtonText.color = color;
				break;
			case MenuState.QuitConfirmButton:
				quitConfirmButtonText.color = color;
				break;
			case MenuState.QuitGoBackButton:
				quitGoBackButtonText.color = color;
				break;
		}
	}

	/// <summary>
	/// Get a copy of given state, not reference.
	/// </summary>
	/// <returns>The state.</returns>
	/// <param name="state">State.</param>
	private MenuState GetState (MenuState state)
	{
		switch (state)
		{
			case MenuState.IntroductionButton:
			default:
				return MenuState.IntroductionButton;
			case MenuState.IntroductionGoBackButton:
				return MenuState.IntroductionGoBackButton;
			case MenuState.StartNewGameButton:
				return MenuState.StartNewGameButton;
			case MenuState.ShowCreditsButton:
				return MenuState.ShowCreditsButton;
			case MenuState.CreditsGoBackButton:
				return MenuState.CreditsGoBackButton;
			case MenuState.QuitButton:
				return MenuState.QuitButton;
			case MenuState.QuitConfirmButton:
				return MenuState.QuitConfirmButton;
			case MenuState.QuitGoBackButton:
				return MenuState.QuitGoBackButton;
		}
	}
}
