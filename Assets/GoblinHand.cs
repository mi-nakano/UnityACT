using UnityEngine;
using System.Collections;

public class GoblinHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col) {
		print ("Colide goblinHand");
	}
}
