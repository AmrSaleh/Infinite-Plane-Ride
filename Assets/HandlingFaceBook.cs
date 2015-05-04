using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System;

public class HandlingFaceBook : MonoBehaviour {

	public GUISkin MenuSkin;
	public Rect LoginButtonRect;

	private static Dictionary<string, object>   profile = null;
	private static List<object>                 friends = null;
	private Texture profilePic;
	private string first_name;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	void Awake ()
	{
		
		// Initialize FB SDK              
		enabled = false;                  
		FB.Init (SetInit, OnHideUnity);  
	}
	
	private void SetInit ()
	{                                                                                            
		Util.Log ("SetInit");                                                                  
		enabled = true; // "enabled" is a property inherited from MonoBehaviour                  
		if (FB.IsLoggedIn) {                                                                                        
			Util.Log ("Already logged in");                                                    
			OnLoggedIn ();                                                                        
		}                                                                                        
	}
	
	private void OnHideUnity (bool isGameShown)
	{                                                                                            
		Util.Log ("OnHideUnity");                                                              
		if (!isGameShown) {                                                                                        
			// pause the game - we will need to hide                                             
			Time.timeScale = 0;                                                                  
		} else {                                                                                        
			// start the game back up - we're getting focus again                                
			Time.timeScale = 1;                                                                  
		}                                                                                        
	}
	
	void OnGUI ()
	{
		
		GUILayout.Box ("", MenuSkin.GetStyle ("panel_welcome"));
		
		if (!FB.IsLoggedIn) {                                                                                                                
			GUI.Label ((new Rect (179, 11, 287, 160)), "Login to Facebook", MenuSkin.GetStyle ("text_only"));             
			if (GUI.Button (LoginButtonRect, "", MenuSkin.GetStyle ("button_login"))) {                                                                                                            
				FB.Login ("email,publish_actions", LoginCallback);                                                        
			}                                                                                                            
		}    
		
		if (FB.IsLoggedIn) {
			string panelText = "Welcome ";
			
			
			panelText += (!string.IsNullOrEmpty (first_name))
				? string.Format ("{0}!", first_name) : "Player!";
			
			if (profilePic != null) 
				GUI.DrawTexture ((new Rect (8, 10, 150, 150)), profilePic);
			
			
			GUI.Label ((new Rect (179, 11, 287, 160)), panelText, MenuSkin.GetStyle ("text_only"));
		}
	}
	
	void LoginCallback (FBResult result)
	{                                                                                          
		Util.Log ("LoginCallback");                                                          
		
		if (FB.IsLoggedIn) {                                                                                      
			OnLoggedIn ();                                                                      
		}                                                                                      
	}
	
	void OnLoggedIn ()
	{
		Util.Log ("Logged in. ID: " + FB.UserId);
		
		// Reqest player info and profile picture                                                                           
		FB.API ("/me?fields=id,first_name,friends.limit(100).fields(first_name,id),email", Facebook.HttpMethod.GET, APICallback);  
		LoadPictureAPI (Util.GetPictureURL ("me", 128, 128), MyPictureCallback);    
	}
	
	void APICallback (FBResult result)
	{                                                                                                                              
		Util.Log ("APICallback");  
		Debug.Log ("result : " + result.Text);
		if (result.Error != null) {                                                                                                                          
			Util.LogError (result.Error);                                                                                           
			// Let's just try again                                                                                                
			FB.API ("/me?fields=id,first_name,friends.limit(100).fields(first_name,id),email", Facebook.HttpMethod.GET, APICallback);     
			return;                                                                                                                
		}                                                                                                                          
		
		//		profile = Util.DeserializeJSONData(result.Text); 
		profile = Json.Deserialize (result.Text) as Dictionary<string, object>;
		//		GameStateManager.Username = profile["first_name"];                                                                         
		friends = Util.DeserializeJSONFriends (result.Text);  
		
		first_name = profile ["first_name"].ToString (); 
		
		foreach (KeyValuePair<string, object> entry in profile) {
			Debug.Log (entry.Key + " , " + entry.Value + "\n");
			// do something with entry.Value or entry.Key
		}
	}
	
	void MyPictureCallback (Texture texture)
	{                                                                                                                              
		Util.Log ("MyPictureCallback");                                                                                          
		
		if (texture == null) {                                                                                                                          
			// Let's just try again
			LoadPictureAPI (Util.GetPictureURL ("me", 128, 128), MyPictureCallback);                               
			return;                                                                                                                
		}                         
		
		//		GameStateManager.UserTexture = texture;   
		profilePic = texture;
		//		profilePic.width = (int)(this.renderer.bounds.extents.x*2);
		//		profilePic.height = (int)(this.renderer.bounds.extents.y*2);
		
		
		
		//		renderer.material.mainTexture = profilePic;
		
	}      
	
	
	delegate void LoadPictureCallback (Texture texture);
	
	IEnumerator LoadPictureEnumerator (string url, LoadPictureCallback callback)
	{
		WWW www = new WWW (url);
		yield return www;
		callback (www.texture);
	}
	
	void LoadPictureAPI (string url, LoadPictureCallback callback)
	{
		FB.API (url, Facebook.HttpMethod.GET, result =>
		        {
			if (result.Error != null) {
				Util.LogError (result.Error);
				return;
			}
			
			var imageUrl = Util.DeserializePictureURLString (result.Text);
			
			StartCoroutine (LoadPictureEnumerator (imageUrl, callback));
		});
	}
	
	void LoadPictureURL (string url, LoadPictureCallback callback)
	{
		StartCoroutine (LoadPictureEnumerator (url, callback));
		
	}
	
	
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("Menu");		
		}
	}
}
