using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private const float SMOOTHING = 3F;
	private Vector3 offset = new Vector3 (1.8F, -1F, 1.8F);
	private GameObject player;
	private float angle;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		angle = 0F;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			angle += SMOOTHING;
		}
		if (Input.GetKey (KeyCode.S)) {
			angle -= SMOOTHING;
		}
		Vector3 targetCamPos = player.transform.position - new Vector3(transform.forward.x * offset.x,
		                                                               offset.y,
		                                                               transform.forward.z * offset.z);
		transform.position = targetCamPos;
		transform.Rotate(new Vector3(0, 1, 0), angle);
		angle = 0F;
	}
}
