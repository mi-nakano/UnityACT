using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	private const int POWER = 10;
	private const int SPEED = 10;
	private const int ALIVE_TIME = 100;

	private int counter;

	// Use this for initialization
	void Start () {
		tag = "PlayerBullet";
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
		GameObject obj = col.gameObject;
		string tag = obj.tag;
		if (tag.Equals ("Stage")) {
			print ("colision to Stage object");
			Destroy (gameObject);
		} else if (tag.Equals ("Enemy")) {
			print ("colision to Enemy object");
			obj.SendMessage("Damage", new DamageSource(POWER, transform.forward));
			Destroy (gameObject);
		}
	}
}
