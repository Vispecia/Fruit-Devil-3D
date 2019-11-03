using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeath : MonoBehaviour {

	public bool dead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			dead = true;
		}
	}
}
