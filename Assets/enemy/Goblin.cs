﻿using UnityEngine;
using System.Collections;

public class Goblin : AbstractEnemy {
	private const int MAX_HP = 20;
	private const float SPEED = 0.03F;
	private const int POWER = 10;
	private const float ROTATE_SPEED = 0.1F;
	private const float SEARCH_DISTANCE = 8F;
	private const float ATTACK_DISTANCE = 1F;
	private const int DELAY = 20;

	private Animation animation;
	private AudioSource audio;
	private GoblinHand hand;
	private bool consious;
	private bool isAttacked;
	private int counter;


	override protected void Init(){
		base.Init ();
		hp = MAX_HP;
		animation = (Animation)GetComponent<Animation> ();
		audio = gameObject.GetComponent<AudioSource>();
		hand = GetComponentInChildren<GoblinHand> ();
		consious = false;
		isAttacked = false;
		counter = 0;
	}

	override protected void Alive () {
		Vector3 heading = player.transform.position - transform.position;
		heading.y = 0;
		if (consious == false && heading.magnitude < SEARCH_DISTANCE) {
			print ("Goblin become consiousness!");
			consious = true;
		}
		if (consious == true) {
			Think(heading);
		}
	}

	private void Think (Vector3 heading){
		if (animation.IsPlaying ("attack01")) {
			if (hand.IsFirstHited()){
				print ("GoblinHand hit player");
				DamageToPlayer(POWER, heading);
			}
			return;
		}
		if (isAttacked) {
			hand.Init();
			Delay ();
			return;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (heading), ROTATE_SPEED);
		if (heading.magnitude < ATTACK_DISTANCE && IsFacedToPlayer(heading)) {
			print ("Goblin attack!");
			animation.Play("attack01");
			isAttacked = true;
		} else {
			controller.Move(heading.normalized * SPEED);
			animation.Play("run");
		}
	}

	private bool IsFacedToPlayer(Vector3 heading){
		float angle = Vector3.Angle(heading, transform.forward);
		if(angle < 5f){
			return true;
		}
		return false;
	}

	private void Delay(){
		counter ++;
		if (counter > DELAY) {
			isAttacked = false;
			counter = 0;
		}
	}

	override protected void Death(){
		animation.Play ("dead");
		audio.Play ();
	}

}
