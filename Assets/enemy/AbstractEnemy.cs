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

	protected void Damage(DamageSource damageSource){
		print (damageSource.GetPower () + " damage to enemy");
		hp -= damageSource.GetPower ();
		hp = Mathf.Max (0, hp);
	}
	
	protected void DamageToPlayer(DamageSource damageSource){
		player.SendMessage ("Damage", damageSource);
	}
	protected void DamageToPlayer(int power, Vector3 direction){
		DamageToPlayer (new DamageSource (power, direction));
	}

	protected bool IsDead(){
		if (hp <= 0) {
			return true;
		}
		return false;
	}

	protected void Dead(){
		print ("Dead");
		Destroy (gameObject);
	}
}

