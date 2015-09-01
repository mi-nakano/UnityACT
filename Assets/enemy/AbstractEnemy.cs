using UnityEngine;
using System.Collections;

abstract public class AbstractEnemy : MonoBehaviour
{
	protected int hp;
	protected Transform player;
	protected CharacterController controller;

	// Use this for initialization
	void Start () {
	}

	protected void init(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		controller = GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
	}

	protected bool isDead(){
		if (hp <= 0) {
			return true;
		}
		return false;
	}

	protected void dead(){
		Destroy (gameObject);
	}
}

