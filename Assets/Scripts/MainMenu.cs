using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenu : MonoBehaviour {

	public Text highScoreText,sshighScoreText;

	public AudioSource click;
	// Use this for initialization
	void Start () 
	{
		highScoreText.text =((int)PlayerPrefs.GetFloat ("HighScore")).ToString();
		sshighScoreText.text = ((int)PlayerPrefs.GetFloat ("HighScore")).ToString();

			}
	



	public void Play()
	{
		click.Play ();
		SceneManager.LoadScene ("scene1");
	}

}


