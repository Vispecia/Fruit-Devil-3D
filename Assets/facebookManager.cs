using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
public class facebookManager : MonoBehaviour {

	public Text userIdText;
	public AudioSource click;
	void Awake()
	{
		if (!FB.IsInitialized)
		{
			FB.Init ();
		} 
		else
		{
			FB.ActivateApp ();
		}
	}


	public void LogIn()
	{
		click.Play ();
		FB.LogInWithReadPermissions (callback:OnLogIn);
	}
	public void Logout()
	{
		FB.LogOut ();
	}
	private void OnLogIn(ILoginResult result)
	{
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = token.UserId;
		} else
			Debug.Log ("Cancelled");
	}

	public void Share()
	{
		click.Play ();
		FB.ShareLink (contentTitle:"Fruit Devil 3D",
			contentURL: new System.Uri("https://play.google.com/store/apps/details?id=com.Vteam.FruitDevil3D"),
			contentDescription:"Beat my Score",
			callback:OnShare);
	}

	private void OnShare(IShareResult result)
	{
		if (result.Cancelled || !string.IsNullOrEmpty (result.Error)) {
		   
			Debug.Log ("ShareLink error:" + result.Error);
		} else if (!string.IsNullOrEmpty (result.PostId)) {
			Debug.Log (result.PostId);
		} else
			Debug.Log ("Share successful");
	}
}
