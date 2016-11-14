using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{
	public GameObject cameraObject;
	public GameObject backgroundShader;
	public GameObject pauseMenuCanvas;

	private bool isCurrentPaused = false;

	public void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (isCurrentPaused)
			{				
				pauseMenuCanvas.SetActive (false);
				backgroundShader.SetActive (false);
				Time.timeScale = 1;
			}
			else
			{				
				pauseMenuCanvas.SetActive (true);
				backgroundShader.SetActive (true);

				backgroundShader.transform.position = cameraObject.transform.position;

				Time.timeScale = 0;
			}

			isCurrentPaused = !isCurrentPaused;
		}
	}
}
