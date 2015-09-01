using UnityEngine;
using System.Collections;

public class Goblin : MonoBehaviour {
	private const int SPEED = 2;
	private const float SEARCH_DISTANCE = 8F;

	private Transform player;
	private bool consious;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		consious = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (consious == false && Vector3.Distance(player.position, gameObject.transform.position) < SEARCH_DISTANCE) {
			print ("Goblin become consiousness!");
			consious = true;
		}
	}
}
