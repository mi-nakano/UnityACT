using UnityEngine;
using System.Collections;

public class GoblinHand : MonoBehaviour {
	bool isColide;
	bool isHited;

	// Use this for initialization
	void Start () {
		Init ();
	}

	public void Init(){
		isColide = false;
		isHited = false;
	}

	void OnCollisionEnter (Collision col) {
		string tag = col.gameObject.tag;
		if (!tag.Equals ("Player")) return;
		isColide = true;
	}

	void OnCollisionExit(Collision col){
		if (!tag.Equals ("Player")) return;
		isColide = false;
		isHited = false;
	}

	public bool IsFirstHited(){
		if (isColide == true && isHited == false) {
			isHited = true;
			return true;
		}
		return false;
	}
}
