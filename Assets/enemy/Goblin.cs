using UnityEngine;
using System.Collections;

public class Goblin : AbstractEnemy {
	private const float SPEED = 0.03F;
	private const float ROTATE_SPEED = 0.1F;
	private const float SEARCH_DISTANCE = 8F;
	private const float ATTACK_DISTANCE = 1F;

	private bool consious;

	// Use this for initialization
	void Start () {
		init ();
	}

	protected void init(){
		base.init ();
		hp = 20;
		consious = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead()){
			Destroy(gameObject);
			return;
		}

		Vector3 heading = player.position - transform.position;
		if (consious == false && heading.magnitude < SEARCH_DISTANCE) {
			print ("Goblin become consiousness!");
			consious = true;
		}
		if (consious == true) {
			think(heading);
		}
	}

	private void think (Vector3 heading){
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (heading), ROTATE_SPEED);
		if (heading.magnitude < ATTACK_DISTANCE) {
			print ("Goblin attack!");
		} else {
			controller.Move(heading.normalized * SPEED);
		}
	}

}
