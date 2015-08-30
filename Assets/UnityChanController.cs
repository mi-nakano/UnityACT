using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour {

	private CharacterController controller;
	private Animator animator;
	private int runId;

	private Vector3 moveVector;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
		runId = Animator.StringToHash ("is_running");
		moveVector = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			moveVector = new Vector3(0, 0, 0.1F);
			controller.Move(moveVector);
			animator.SetBool(runId, true);
		}else{
			animator.SetBool(runId, false);
		}
	}
}
