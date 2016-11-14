using UnityEngine;
using System.Collections;

public class PlayerMovementControl : MonoBehaviour
{

	private Animator playerAnimator;
	private CapsuleCollider playerCapsuleCollider;
	public Transform eyePosition;

	private float vSpeed = 0f;
	private float hSpeed = 0f;

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
		playerAnimator = GetComponent<Animator> ();
		playerCapsuleCollider = GetComponent<CapsuleCollider> ();
		playerAnimator.SetBool ("JumpOrAttack", false);
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
			if (!playerAnimator.IsInTransition (0)) {
				playerCapsuleCollider.height = playerAnimator.GetFloat ("ColliderHeight");
				playerAnimator.SetBool ("JumpOrAttack", false);
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

		if (.25f > transform.position.y) {
			transform.position.Set (transform.position.x, .25f, transform.position.z);
		}
	}
}
