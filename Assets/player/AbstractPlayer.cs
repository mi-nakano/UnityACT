using UnityEngine;
using System.Collections;

public class AbstractPlayer : MonoBehaviour {
	protected int hp;
	protected CharacterController controller;
	protected Animator animator;


	protected void Init(){
		controller = GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();
	}

	public void Damage(int power){
		print (power + " damage to Player!");
		animator.SetTrigger ("damage_trig");
		hp -= power;
		hp = Mathf.Max (0, hp);
	}
}
