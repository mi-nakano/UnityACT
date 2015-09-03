using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : AbstractPlayer {
	private const float SPEED = 0.1F;
	private const float DISTANCE = 0.5F;

	private CharacterController controller;
	private Animator animator;
	private AnimatorStateInfo state;
	private Vector3 moveVector;
	private int runId, attackId;

	public GameObject Bullet;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		runId = Animator.StringToHash ("is_running");
		attackId = Animator.StringToHash ("is_attacking");
		controller.Move (new Vector3 (0, -20, 0));		// Set on ground
		moveVector = Vector3.zero;
	}
		
	// Update is called once per frame
	void Update () {
		state = animator.GetCurrentAnimatorStateInfo (0);
		if (state.IsTag ("movable")) {
			move();
		}

		if (Input.GetKeyDown (KeyCode.Space) && (animator.GetBool(attackId) == false)) {
			animator.SetBool (attackId, true);
			// shoot bullets
			Vector3 bulletPos = new Vector3(transform.position.x, controller.center.y, transform.position.z);
			bulletPos += transform.forward * DISTANCE;
			Instantiate (Bullet, bulletPos, transform.rotation);
		}
	}

	private void move(){
		setMoveVector ();
		if (moveVector.Equals (Vector3.zero)) {		// stop
			animator.SetBool (runId, false);
		} else {									// running
			animator.SetBool (runId, true);	
			controller.Move (moveVector * SPEED);
			transform.rotation = Quaternion.LookRotation (moveVector);
		}
	}
	
	private void setMoveVector(){
		moveVector = Vector3.zero;
		if (Input.GetKey(KeyCode.UpArrow)) {
			moveVector.z += 1;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			moveVector.z -= 1;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			moveVector.x += 1;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			moveVector.x -= 1;
		}
		moveVector.Normalize();
	}

}
