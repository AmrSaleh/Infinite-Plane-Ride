using UnityEngine;
using System.Collections;

public class QuitBtn : MonoBehaviour {

	public Texture QuitTexture;

	void Start ()
	{
		GetComponent<Renderer>().material.mainTexture = QuitTexture;
	}
	
	void OnTouchDown ()
	{
		if (this.gameObject.tag == "QuitBtn")
			Application.LoadLevel("Options");
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
