using UnityEngine;
using System.Collections;

abstract public class AbstractEnemy : MonoBehaviour {
	public int MAX_HP;
	protected int hp;
	protected Transform player;
	protected CharacterController controller;

	protected void init(){
		hp = MAX_HP;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		controller = GetComponent<CharacterController> ();
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

