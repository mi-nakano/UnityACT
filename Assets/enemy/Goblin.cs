using UnityEngine;
using System.Collections;

public class Goblin : AbstractEnemy {
	private const float SPEED = 0.03F;
	private const float ROTATE_SPEED = 0.1F;
	private const float SEARCH_DISTANCE = 8F;
	private const float ATTACK_DISTANCE = 1F;
	private const int DELAY = 20;

	private GoblinHand hand;
	private bool consious;
	private bool isAttacked;
	private int counter;

	// Use this for initialization
	void Start () {
		Init ();
	}

	protected void Init(){
		MAX_HP = 20;
		base.Init ();
		hand = GetComponentInChildren<GoblinHand> ();
		consious = false;
		isAttacked = false;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsDead()){
			Dead ();
			return;
		}

		Vector3 heading = player.position - transform.position;
		heading.y = 0;
		if (consious == false && heading.magnitude < SEARCH_DISTANCE) {
			print ("Goblin become consiousness!");
			consious = true;
		}
		if (consious == true) {
			Think(heading);
		}
	}

	private void Think (Vector3 heading){
		Animation animation = (Animation) GetComponent<Animation>();
		if (animation.IsPlaying ("attack01")) {
			if (hand.IsFirstHited()){
				print ("GoblinHand hit player");
			}
			return;
		}
		if (isAttacked) {
			Delay ();
			return;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (heading), ROTATE_SPEED);
		if (heading.magnitude < ATTACK_DISTANCE) {
			print ("Goblin attack!");
			animation.Play("attack01");
			isAttacked = true;
		} else {
			controller.Move(heading.normalized * SPEED);
			animation.Play("run");
		}
	}

	private void Delay(){
		counter ++;
		if (counter > DELAY) {
			isAttacked = false;
			counter = 0;
		}
	}

}
