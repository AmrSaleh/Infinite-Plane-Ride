
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;
using System;

//using Newtonsoft.Json;

public class touchCube : MonoBehaviour
{

	public float ChallengeDisplayTime;
		void OnTouchDown ()
		{
			Debug.Log ("invite pressed ");

		if (!FB.IsLoggedIn) {
			Debug.Log("please Log in first");
			return;
		}


			FB.AppRequest (
			"Paper Plane Ride is great! Check it out.",//message: 
			null,//to:
			null,// filters :
			null,//excludeIds :
			null,//maxRecipients
			"",//data
			"Play Paper Plane Ride with me!",//title: 
			appRequestCallback//callback: 
			);


		/*  public static void AppRequest(
            string message,
            string[] to = null,
            List<object> filters = null,
            string[] excludeIds = null,
            int? maxRecipients = null,
            string data = "",
            string title = "",
            FacebookDelegate callback = null)
		*/
	
	}

		private void appRequestCallback (FBResult result)
		{                                                                                                                              
				Util.Log ("appRequestCallback");                                                                                         
				if (result != null) {                                                                                                                          
						var responseObject = Json.Deserialize (result.Text) as Dictionary<string, object>;                                      
						object obj = 0;                                                                                                        
						if (responseObject.TryGetValue ("cancelled", out obj)) {                                                                                                                      
								Util.Log ("Request cancelled");                                                                                  
						} else if (responseObject.TryGetValue ("request", out obj)) {                
								AddPopupMessage ("Request Sent", ChallengeDisplayTime);
								Util.Log ("Request sent");                                                                                       
						}                                                                                                                      
				}                                                                                                                          
		}

		private string popupMessage;
		private float popupTime;
		private float popupDuration;

		public void AddPopupMessage (string message, float duration)
		{
				popupMessage = message;
				popupTime = Time.realtimeSinceStartup;
				popupDuration = duration;
		}

		void OnTouchUp ()
		{
		}
	
		void OnTouchStay ()
		{
		}
	
		void OnTouchExit ()
		{
		}
}
