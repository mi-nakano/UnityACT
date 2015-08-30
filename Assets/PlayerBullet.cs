using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	public int speed = 3;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
