using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour {
	private const float SPEED = 0.1F; 

	private CharacterController controller;
	private Animator animator;
	private AnimatorStateInfo state;
	private int runId;
	private Vector3 moveVector;
	private bool push_attack;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		runId = Animator.StringToHash ("is_running");
		controller.Move (new Vector3 (0, -20, 0));		// Set on ground
		moveVector = Vector3.zero;
	}
		
	// Update is called once per frame
	void Update () {
		state = animator.GetCurrentAnimatorStateInfo (0);
		setMoveVector();
		if (moveVector.Equals (Vector3.zero)) {		// stop
			animator.SetBool (runId, false);
		} else {									// running
			animator.SetBool (runId, true);	
			controller.Move (moveVector * SPEED);
			transform.rotation = Quaternion.LookRotation(moveVector);
		}
		if (Input.GetKey(KeyCode.Space)) {
			push_attack = true;
		} else {
			push_attack = false;
		}

		if (push_attack) {
			animator.SetBool("attacking", true);
			Debug.Log("attack");
		}

		if (state.IsTag ("attack")) {
			animator.SetBool ("attacking", false);
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
