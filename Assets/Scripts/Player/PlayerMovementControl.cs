using UnityEngine;
using System.Collections;

/// <summary>
/// Player movement control.
/// <author>Yuyang He</author>
/// </summary>
public class PlayerMovementControl : MonoBehaviour
{
	private Animator playerAnimator;
	public Transform eyePosition;

	// sounds & foot effect
	private AudioSource screamSoundSource;
	private AudioSource footStepSource;
	private ParticleSystem playerFootParticleSystem;
	private float footSoundTimer = 0f;

	// speed
	private float vSpeed = 0f;
	private float hSpeed = 0f;

	//used for attack
	private bool canHit = false;
	private static string CITIZEN_TAG = "citizen";

	// use for detect which state animation is in
	private AnimatorStateInfo currentSateInfo;
	private static string NORMAL_STATE = "BaseLayer.DefaultTree";
	private static string JUMP_OR_ATTACK_STATE = "BaseLayer.jump_attack";
	private static int NORMAL_STATE_HASH = Animator.StringToHash (NORMAL_STATE);
	private static int JUMP_OR_ATTACK_STATE_HASH = Animator.StringToHash (JUMP_OR_ATTACK_STATE);

	/// <summary>
	/// For collider dection
	/// </summary>
	private RaycastHit hitInfo;

	void Awake ()
	{
		AudioSource[] audioSources = GetComponents<AudioSource> ();
		screamSoundSource = audioSources [0];
		footStepSource = audioSources [1];
		playerAnimator = GetComponent<Animator> ();
		playerAnimator.SetBool ("JumpOrAttack", false);
		playerFootParticleSystem = GetComponentInChildren<ParticleSystem> ();
		playerFootParticleSystem.startColor = Color.grey;
	}

	void Update ()
	{
		currentSateInfo = playerAnimator.GetCurrentAnimatorStateInfo (0);

		if (NORMAL_STATE_HASH == currentSateInfo.fullPathHash) {
			vSpeed = Input.GetAxis ("Vertical");
			hSpeed = Input.GetAxis ("Horizontal");

			playerAnimator.SetFloat ("VSpeed", vSpeed);
			playerAnimator.SetFloat ("HSpeed", hSpeed);

			if (Input.GetKeyDown (KeyCode.Space)) {
				playerAnimator.SetBool ("JumpOrAttack", true);
			}
		} else if (JUMP_OR_ATTACK_STATE_HASH == currentSateInfo.fullPathHash) {
			// fall back on the ground
			if (!playerAnimator.IsInTransition (0)) {
				playerAnimator.SetBool ("JumpOrAttack", false);
				playerFootParticleSystem.Emit (100);
			}
		
			Ray ray = new Ray (eyePosition.position, Vector3.down);

			if (Physics.Raycast (ray, out hitInfo)) {
				if (1.75f < hitInfo.distance) {
					playerAnimator.MatchTarget (hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask (Vector3.up, 0), 0.35f, 0.5f);
				}
			}

		} else {
			Debug.Log (currentSateInfo.fullPathHash);
		}

		footSoundTimer += Time.deltaTime;
	}

	/// <summary>
	/// Enable the player to attack others. It is an animation event.
	/// </summary>
	public void EnableHit()
	{
		canHit = true;
	}

	/// <summary>
	/// Disable the player to attack others. It is an animation event.
	/// </summary>
	public void DisableHit()
	{
		canHit = false;
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="collider">Collider.</param>
	public void OnTriggerEnter(Collider collider)
	{
		//Debug.Log (CITIZEN_TAG == collider.gameObject.tag);

		// 3 requirements
		// 1 - citizen detected
		// 2 - zombie is jumping
		// 3 - zombie is in the hitable mode
		if (CITIZEN_TAG == collider.gameObject.tag && JUMP_OR_ATTACK_STATE_HASH == currentSateInfo.fullPathHash && canHit) {
			CitizenHealth citizenHealthController = collider.gameObject.GetComponent<CitizenHealth> ();
			citizenHealthController.takeDamage (200);
			DisableHit ();

			//Debug.Log (citizenHealthController.currentHealth);
		}
	}

	/// <summary>
	/// Steps the on ground. Play foot step sound.
	/// </summary>
	public void StepOnGround()
	{
		// don't play sound too frequently
		if (0.15f > footSoundTimer) {
			return;
		}

		footStepSource.pitch = Random.Range (0.65f, 1.2f);
		footStepSource.volume = Random.Range (0.3f, 0.6f);
		footStepSource.Play ();
		footSoundTimer = 0f;
	}

	/// <summary>
	/// Player screaming when jumping.
	/// </summary>
	public void Scream()
	{
		screamSoundSource.pitch = Random.Range (0.8f, 1.2f);
		screamSoundSource.volume = Random.Range (0.15f, 0.35f);
		screamSoundSource.Play ();
	}
}
