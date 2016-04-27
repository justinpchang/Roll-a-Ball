using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 positionOffset;
	private Vector3 rotationOffset;

	void Start () {
		positionOffset = transform.position - player.transform.position;
		//rotationOffset = transform.rotation - player.transform.rotation;
	}
		
	void LateUpdate () {
		transform.position = player.transform.position + positionOffset;
		transform.rotation = player.transform.rotation;
	}

}
