using UnityEngine;
using System.Collections;

public class Bruce : AbstractEnemy {
	public int MAX_HP;
	public AbstractEnemyAttack LSpear;
	public AbstractEnemyAttack RSpear;

	private int COUNT = 200;

	private Animation animation;
	private int counter;

	
	override protected void Init(){
		base.Init ();
		hp = MAX_HP;
		animation = (Animation)GetComponent<Animation> ();
		counter = 0;
	}

	override protected void Alive () {
		if (counter == 0) {
			Attack ();
			counter ++;
		} else if(animation.IsPlaying("spin")){
		} else {
			animation.Play("wait");
			counter ++;
			if (counter > COUNT) counter = 0;
		}
	}

	private void Attack(){
		animation.Play ("spin");
		LSpear.Activate ();
		RSpear.Activate ();
	}

	override protected void Death (){
		throw new System.NotImplementedException ();
	}
}
