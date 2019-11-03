using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerMovement player;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;
	private float ydistanceToMove;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerMovement> ();
		lastPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		distanceToMove = player.transform.position.z - lastPlayerPosition.z;
		ydistanceToMove = player.transform.position.y - lastPlayerPosition.y;
		//camera position
		transform.position = new Vector3(transform.position.x,transform.position.y+ydistanceToMove,transform.position.z + distanceToMove);

		lastPlayerPosition = player.transform.position;

	}
}
