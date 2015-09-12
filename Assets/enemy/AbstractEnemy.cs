using UnityEngine;
using System.Collections;

abstract public class AbstractEnemy : MonoBehaviour {
	public int MAX_HP;
	protected int hp;
	protected GameObject player;
	protected CharacterController controller;

	protected void Init(){
		hp = MAX_HP;
		player = GameObject.FindGameObjectWithTag ("Player");
		controller = GetComponent<CharacterController> ();
	}

	protected void DamageToPlayer(int damage){
		player.SendMessage ("Damage", damage);
	}

	protected bool IsDead(){
		if (hp <= 0) {
			return true;
		}
		return false;
	}

	protected void Dead(){
		Destroy (gameObject);
	}
}

