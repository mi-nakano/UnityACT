using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private const float SMOOTHING = 100F;
	private Vector3 offset = new Vector3 (1.8F, -1F, 1.8F);
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetCamPos = player.transform.position - new Vector3(transform.forward.x * offset.x,
		                                                               offset.y,
		                                                               transform.forward.z * offset.z);
		transform.position = Vector3.Lerp (transform.position, targetCamPos, SMOOTHING * Time.deltaTime);	
	}
}
