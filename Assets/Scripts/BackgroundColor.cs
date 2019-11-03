using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {

	 Color bgcolor; Color current; public Camera camera1;

		public void Start () { InvokeRepeating ("Change_color", 0.0f, 5.0f); }

		void Change_color()
		{
			current = new Color (Random.value, Random.value, Random.value);
			bgcolor = new Color (Random.value, Random.value, Random.value);
			camera1.backgroundColor = Color.Lerp (current, bgcolor, 5.0f);
		}
	}
/*	void Update()
	{
		if (timeLeft <= Time.deltaTime)
		{
			// transition complete
			// assign the target color
			//renderer.material.color = targetColor;
			extra = targetColor;
			// start a new transition
			targetColor = new Color(Random.value, Random.value, Random.value);
			timeLeft = 5.0f;
		}
		else
		{
			// transition in progress
			// calculate interpolated color
			camera.backgroundColor = Color.Lerp(extra, targetColor, Time.deltaTime / timeLeft);

			// update the timer
			timeLeft -= Time.deltaTime;
		}
	}*/
