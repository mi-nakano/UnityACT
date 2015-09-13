using UnityEngine;
using System.Collections;

public class Bruce : AbstractEnemy {
	public int MAX_HP;

	override protected void Init(){
		hp = MAX_HP;
	}

	override protected void Alive () {
	}

	override protected void Death (){
		throw new System.NotImplementedException ();
	}
}
