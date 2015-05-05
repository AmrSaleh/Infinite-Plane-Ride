using UnityEngine;
using System.Collections;

public class OptionsSceneBtns : MonoBehaviour {

	public Texture2D BackBtn;
	public Texture2D OnBtn;
	public Texture2D OffBtn;

	
	public GUIStyle bollastyle;
	
	void OnGUI () {

		if(GUI.Button(new Rect(10, 10, 100, 50), BackBtn)) 
		{
			Application.LoadLevel("Menu");
		}

		if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 -25,200,50), OnBtn)) {
			GlobalData.SFX = true;
		}

		if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 +40,200,50), OffBtn)) 
		{
			GlobalData.SFX = false;
		}
	}
}
