using UnityEngine;
using System.Collections;

public class Goblin : AbstractEnemy {
	private const float SPEED = 0.03F;
	private const float ROTATE_SPEED = 0.1F;
	private const float SEARCH_DISTANCE = 8F;
	private const float ATTACK_DISTANCE = 1F;
	private const int DELAY = 20;

	private bool consious;
	private bool isAttacked;
	private int counter;

	// Use this for initialization
	void Start () {
		init ();
	}

	protected void init(){
		MAX_HP = 20;
		base.init ();
		consious = false;
		isAttacked = false;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead()){
			dead ();
			return;
		}

		Vector3 heading = player.position - transform.position;
		heading.y = 0;
		if (consious == false && heading.magnitude < SEARCH_DISTANCE) {
			print ("Goblin become consiousness!");
			consious = true;
		}
		if (consious == true) {
			think(heading);
		}
	}

	private void think (Vector3 heading){
		Animation animation = (Animation) GetComponent<Animation>();
		if (animation.IsPlaying ("attack01")) {
			return;
		}
		if (isAttacked) {
			delay ();
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

	private void delay(){
		counter ++;
		if (counter > DELAY) {
			isAttacked = false;
			counter = 0;
		}
	}

}
