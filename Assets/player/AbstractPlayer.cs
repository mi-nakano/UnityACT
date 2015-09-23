using UnityEngine;
using System.Collections;

public class AbstractPlayer : MonoBehaviour {
	protected int hp;
	protected CharacterController controller;
	protected Animator animator;
	protected AnimatorStateInfo state;


	// Use this for initialization
	void Start(){
		Init ();
	}

	// Update is called once per frame
	void Update(){
		Routine ();
	}

	virtual protected void Init(){
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	virtual protected void Routine(){
		state = animator.GetCurrentAnimatorStateInfo (0);
	}

	public void Hit(DamageSource source){
		int power = source.GetPower ();
		if (state.IsTag("damage")){
			print(power + " damage to player, but nodamage");
			return;
		}
		Damage (source);
	}

	virtual protected void Damage(DamageSource source){
		int power = source.GetPower ();
		print (power + " damage to Player!");
		controller.transform.rotation = Quaternion.LookRotation (source.GetDirection());
		animator.SetTrigger ("damage_trig");
		hp -= power;
		hp = Mathf.Max (0, hp);
	}
}
