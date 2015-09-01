using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	private const int SPEED = 10;
	private const int ALIVE_TIME = 100;

	private int counter;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward.normalized * SPEED;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter ++;
		if (counter > ALIVE_TIME) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter (Collision col) {
		string tag = col.gameObject.tag;
		if (tag.Equals ("Stage")) {
			print ("colision to Stage object");
			Destroy(gameObject);
		}
	}
}
