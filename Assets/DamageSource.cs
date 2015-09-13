using UnityEngine;
using System.Collections;

public class DamageSource {

	private int power;
	private Vector3 direction;

	public DamageSource(int power, Vector3 direcktion){
		this.power = power;
		this.direction = direction;
	}

	public int GetPower(){
		return power;
	}

	public Vector3 GetDirection(){
		return direction;
	}
}
