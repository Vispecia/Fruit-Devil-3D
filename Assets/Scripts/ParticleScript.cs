using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

	private ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {

		//gameObject.GetComponent<ParticleSystem> ().Play ();
		if (!ps.isPlaying) 
		{
			gameObject.GetComponent<ParticleSystem> ().Play ();
			gameObject.GetComponent<ParticleSystem> ().enableEmission = true;
		}
		
	}
}
