using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UnityChanController : MonoBehaviour {
	
	private Animator animator;
	private int runId;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		runId = Animator.StringToHash ("is_running");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow)) {
			animator.SetBool(runId, true);
		}else{
			animator.SetBool(runId, false);
		}
	}
}
