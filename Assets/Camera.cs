using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private const float SMOOTHING = 5F;
	private GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetCamPos = player.transform.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, SMOOTHING * Time.deltaTime);	
	}
}
