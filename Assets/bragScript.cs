using UnityEngine;
using System.Collections;

public class bragScript : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTouchDown ()
	{
		Util.Log("onBragClicked");       

		if (!FB.IsLoggedIn) {
			Debug.Log("please Log in first");
			return;}

		FB.Feed(                                                                                                                 
		        linkCaption: "I got " + score + " in Paper Plane Ride! Can you beat it?",               
		        picture:"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTstdJk9SxEoA2SMQ-79aZW2XH_Gxzp3I_WisaLa8W0s8_hW7bEaglVCQ",// "http://www.friendsmash.com/images/logo_large.jpg",                                                     
		        linkName: "Checkout my Paper Plane Ride greatness!",                                                                 
		        link: "http://apps.facebook.com/" + FB.AppId + "/?challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")       
		        );    
		
	}
}
