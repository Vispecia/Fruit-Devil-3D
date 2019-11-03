using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	private PlayerMovement pm;
	public Text timer;
	private float score;
	//private float startTime;
	// Use this for initialization
	void Start () {

		pm = GetComponent<PlayerMovement> ();
		//startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<HealthBar> ().hitpoint == 0 || pm.playerDead) {
			if ((int)PlayerPrefs.GetFloat ("HighScore") < (int)score) {
				PlayerPrefs.SetFloat ("HighScore", score);
				return;
			}
			return;
		}

		if (!pm.playerDead) {
			timer.text = ((int)score).ToString ();
			score += Time.deltaTime;
		}


		/*if (GetComponent<HealthBar> ().hitpoint == 0) {
			return;
		}

		float t = Time.time - startTime;

		string min = ((int)t / 60).ToString ();
		string sec = (t % 60).ToString ("f2");

		timer.text = min + ":" + sec;*/
	}
}
