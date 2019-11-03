using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour {

	public Text survivedTime;
	public Text highScoreText;
	public Image BackImg;

	public Text settimerInactive;

	private float transition =0.0f;

	private bool isShowned = false;
	public static bool adShown = false;
	public AudioSource click;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isShowned)
			return;
		transition += Time.deltaTime;
		//BackImg.color = Color.Lerp (new Color(15,90,87,0),Color.,transition);
		highScoreText.text =((int)PlayerPrefs.GetFloat ("HighScore")).ToString();
		
	}

	public void ToggleEndMenu(Text Time)
	{
		gameObject.SetActive (true);
		adShown = true;
		survivedTime.text = Time.text;
		isShowned = true;
		settimerInactive.gameObject.SetActive (false);
	}

	public void Restart()
	{
		click.Play ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	public void ToMenu()
	{
		click.Play ();
		SceneManager.LoadScene ("Menu");
	}

}
