using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public Image currentHealth;
	public Text ratioText;

	public float hitpoint = 150;
	private float maxhitpoint = 150;
	private PlayerMovement pm;

	private GameObject gbar;
	// Use this for initialization
	void Start () {
		pm = GetComponent<PlayerMovement> ();
		UpdateHealthBar ();
		gbar = GameObject.FindGameObjectWithTag("HealthBar");
	}
	
	// Update is called once per frame
	void Update()
	{
		TakeDamage (8f * Time.deltaTime);
	}



	 void UpdateHealthBar () {
		float ratio = hitpoint / maxhitpoint;
		currentHealth.rectTransform.localScale = new Vector3 (ratio,1,1);
		ratioText.text = (ratio*100).ToString("0") + "%";
	}


	void TakeDamage(float damage)
	{
		hitpoint -= damage;
		if (hitpoint < 0 || pm.dead) {
			hitpoint = 0;
			pm.playerDead = true;
			currentHealth.enabled = false;
			ratioText.enabled = false;
			gbar.SetActive (false);
			return;
			//Debug.Log ("gfcgcnnnc");
		}

		UpdateHealthBar ();
	}

	public void HealDamage(float heal)
	{
		//Debug.Log ("Inside heal");
		hitpoint += heal;
		//Debug.Log (hitpoint);
		if (hitpoint > maxhitpoint)
			hitpoint = maxhitpoint;

		UpdateHealthBar ();
	}
}
