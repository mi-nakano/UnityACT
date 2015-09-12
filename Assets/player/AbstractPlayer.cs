using UnityEngine;
using System.Collections;

public class AbstractPlayer : MonoBehaviour {
	protected int hp;

	public void Damage(int power){
		print (power + " damage to Player!");
		hp -= power;
	}
}
