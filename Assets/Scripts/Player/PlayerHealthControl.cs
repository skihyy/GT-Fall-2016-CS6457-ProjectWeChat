using UnityEngine;
using System.Collections;

public class PlayerHealthControl : MonoBehaviour {

	private int health = 100;
	private Animator playerAnimator;
	private float timer = 0f; // test for death
	private PlayerMovementControl playerMovementControl;

	public void Awake()
	{
		playerAnimator = GetComponent<Animator> ();
		playerAnimator.SetBool ("Die", false);
		playerMovementControl = GetComponent<PlayerMovementControl> ();
	}

	public void takeDamage(int amount)
	{
		health -= amount;

		Debug.Log (health + "");

		if (0 >= health) {
			Die ();
		}
	}

	public void Update()
	{
		timer += Time.deltaTime;

		if (3f <= timer) {
			if(!playerAnimator.GetBool("Die"))
			{
				Die ();
			}
		}
	}

	private void Die()
	{
		if(!playerAnimator.GetBool("Die"))
		{
			playerAnimator.SetBool ("Die", true);
			playerMovementControl.enabled = false;
			this.enabled = false;
		}
	}
}
