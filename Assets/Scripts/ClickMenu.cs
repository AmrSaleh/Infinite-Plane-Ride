using UnityEngine;
using System.Collections;

public class ClickMenu : MonoBehaviour {
	
//	public Texture btnTexture;
//	void OnGUI() 
//	{
//		if (GUI.Button (new Rect (100, 100, 50, 50), btnTexture))
//						Application.LoadLevel ("_MainScene");
//
//		
//	}

	void OnMouseDown() 
	{
		Application.LoadLevel("_MainScene");
	}
	

}
