using UnityEngine;
using System.Collections;

abstract public class AbstractEnemy : MonoBehaviour {
	protected int hp;
	protected bool isDead;
	protected int deadCounter;
	protected int DEAD_COUNT = 30;
	protected GameObject player;
	protected CharacterController controller;


	void Start () {
		Init ();
	}

	virtual protected void Init(){
		isDead = false;
		deadCounter = 0;
		player = GameObject.FindGameObjectWithTag ("Player");
		controller = GetComponent<CharacterController> ();
	}

	void Update(){
		Routine ();
	}

	virtual protected void Routine(){
		if (isDead) {
			Dead ();
		} else {
			Alive ();
		}
	}

	abstract protected void Alive ();

	virtual protected void Dead(){
		deadCounter ++;
		if (deadCounter > DEAD_COUNT) {
			Destroy(gameObject);
		}
	}

	protected void Damage(DamageSource damageSource){
		print (damageSource.GetPower () + " damage to enemy");
		hp -= damageSource.GetPower ();
		if(hp <= 0){
			hp = 0;
			isDead = true;
		}
	}
	
	protected void DamageToPlayer(DamageSource damageSource){
		player.SendMessage ("Damage", damageSource);
	}
	protected void DamageToPlayer(int power, Vector3 direction){
		DamageToPlayer (new DamageSource (power, direction));
	}
}

