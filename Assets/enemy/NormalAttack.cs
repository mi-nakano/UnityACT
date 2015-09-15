using UnityEngine;
using System.Collections;

public class NormalAttack : AbstractEnemyAttack {
	
	void OnCollisionEnter (Collision col) {
		if (!isActive() || !isCollideToPlayer (col))
			return;
		isColide = true;
	}
	
	void OnCollisionExit(Collision col){
		if (!isActive ())
			return;
		if (isCollideToPlayer (col)) {
			Init();
		}
	}
}
