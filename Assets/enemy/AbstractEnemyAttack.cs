using UnityEngine;
using System.Collections;

public class AbstractEnemyAttack : MonoBehaviour {

	protected bool isColide;
	protected bool isHited;

	// Use this for initialization
	void Start () {
		Init ();
	}

	virtual public void Init(){
		isColide = false;
		isHited = false;
	}

	protected bool isCollideToPlayer (Collision col){
		if (col.gameObject.tag.Equals ("Player"))
			return true;
		return false;
	}

	public bool IsFirstHited(){
		if (isColide == true && isHited == false) {
			isHited = true;
			return true;
		}
		return false;
	}
}
