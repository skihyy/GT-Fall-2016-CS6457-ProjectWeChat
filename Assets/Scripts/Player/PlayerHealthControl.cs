using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthControl : MonoBehaviour {

	public int health = 100;
	private Animator playerAnimator;
	//private float timer = 0f; // test for death
	private PlayerMovementControl playerMovementControl;
	public Text healthText;

	public void Awake()
	{
		playerAnimator = GetComponent<Animator> ();
		playerAnimator.SetBool ("Die", false);
		playerMovementControl = GetComponent<PlayerMovementControl> ();
	}

	public void takeDamage(int amount)
	{
		health -= amount;

		healthText.text = health + "";

		Debug.Log (health + "");

		if (0 >= health) {
			Die ();
			healthText.text = "0";
		}
	}

//	public void Update()
//	{
//		timer += Time.deltaTime;
//
//		if (1f <= timer) {
//
//			Debug.Log (healthText.text);
//
//			health -= 50;
//			timer = 0f;
//			healthText.text = health + "";
//		}
//		if (0 >= health) {
//			Die ();
//			healthText.text = "0";
//		}
//	}

	private void Die()
	{
		if(!playerAnimator.GetBool("Die"))
		{
			playerAnimator.SetBool ("Die", true);
			playerMovementControl.enabled = false;
			this.enabled = false;
			SceneManager.LoadScene ("GameOverMenu");
		}
	}
}
