using UnityEngine;
using System.Collections;

public class Goblin : MonoBehaviour {
	private const float SPEED = 0.05F;
	private const float SEARCH_DISTANCE = 8F;
	private const float ATTACK_DISTANCE = 1F;

	private Transform player;
	private CharacterController controller;
	private bool consious;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		controller = GetComponent<CharacterController> ();
		consious = false;
	}
	
	// Update is called once per frame
	void Update () {
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
		transform.rotation = Quaternion.LookRotation (heading);
		if (heading.magnitude < ATTACK_DISTANCE) {
			print ("Goblin attack!");
		} else {
			controller.Move(heading.normalized * SPEED);
		}
	}
}
