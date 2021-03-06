using UnityEngine;
using System.Collections;

abstract public class AbstractEnemy : MonoBehaviour {
	static Vector3 GRAVITY = new Vector3 (0, -9.81F, 0);

	protected int hp;
	protected bool isDead;
	protected int deadCounter;
	protected int DEAD_COUNT = 300;
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

	protected void Move(Vector3 heading, float speed){
		controller.Move(heading.normalized * speed + GRAVITY);
	}

	abstract protected void Death ();

	virtual protected void Dead(){
		deadCounter ++;
		if (deadCounter > DEAD_COUNT) {
			Destroy(gameObject);
		}
	}

	protected void Damage(DamageSource damageSource){
		if (isDead)
			return;
		print (damageSource.GetPower () + " damage to enemy");
		hp -= damageSource.GetPower ();
		if(hp <= 0){
			hp = 0;
			isDead = true;
			Death();
		}
	}
	
	protected void DamageToPlayer(DamageSource damageSource){
		player.SendMessage ("Hit", damageSource);
	}
	protected void DamageToPlayer(int power, Vector3 direction){
		DamageToPlayer (new DamageSource (power, direction));
	}
}

