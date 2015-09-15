using UnityEngine;
using System.Collections;

public class GoblinHand : AbstractEnemyAttack {

	void OnCollisionEnter (Collision col) {
		if (isCollideToPlayer (col)) {
			isColide = true;
		}
	}

	void OnCollisionExit(Collision col){
		if (isCollideToPlayer (col)) {
			Init();
		}
	}
}
