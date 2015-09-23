using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class UnityChanController : AbstractPlayer {
	public int HP = 100;
	public GameObject Bullet;
	public GameObject Camera;
	public GameObject HPText;

	private const float SPEED = 0.1F;
	private const float DISTANCE = 0.5F;

	private AudioSource audio;
	private Vector3 moveVector;
	private int runId, attackId;
	private Text hptext;


	// Use this for initialization
	void Start () {
		base.Init ();
		audio = GetComponent<AudioSource> ();
		runId = Animator.StringToHash ("is_running");
		attackId = Animator.StringToHash ("is_attacking");
		controller.Move (new Vector3 (0, -20, 0));		// Set on ground
		moveVector = Vector3.zero;
		hp = HP;
		hptext = HPText.GetComponent<Text> ();
	}
		
	// Update is called once per frame
	void Update () {
		base.Routine ();
		if (state.IsTag ("movable")) {
			Move();
		}

		if (Input.GetKeyDown (KeyCode.Space) && (animator.GetBool(attackId) == false)) {
			animator.SetBool (attackId, true);
			// shoot bullets
			Vector3 bulletPos = new Vector3(transform.position.x, controller.center.y, transform.position.z);
			bulletPos += transform.forward * DISTANCE;
			Instantiate (Bullet, bulletPos, transform.rotation);
		}
		hptext.text = "HP:" + hp;
	}

	private void Move(){
		SetMoveVector ();
		if (moveVector.Equals (Vector3.zero)) {		// stop
			animator.SetBool (runId, false);
		} else {									// running
			animator.SetBool (runId, true);	
			Vector3 forward = Camera.transform.TransformDirection(Vector3.forward);
			Vector3 right = Camera.transform.TransformDirection(Vector3.right);
			Vector3 direction = forward * moveVector.z + right * moveVector.x;
			direction = direction.normalized;
			controller.Move (direction * SPEED);
			transform.rotation = Quaternion.LookRotation (direction);
		}
	}
	
	private void SetMoveVector(){
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

	override protected void Damage(DamageSource source){
		base.Damage (source);
		audio.PlayDelayed(0.3f);
	}

}
