﻿using UnityEngine;
using System.Collections;

public class AbstractPlayer : MonoBehaviour {
	protected int hp;
	protected CharacterController controller;
	protected Animator animator;
	protected AnimatorStateInfo state;


	protected void Init(){
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	protected void Routine(){
		state = animator.GetCurrentAnimatorStateInfo (0);
	}

	public void Damage(int power){
		if (state.IsTag("damage")){
			print(power + " damage to player, but nodamage");
			return;
		}
		print (power + " damage to Player!");
		animator.SetTrigger ("damage_trig");
		hp -= power;
		hp = Mathf.Max (0, hp);
	}
}
