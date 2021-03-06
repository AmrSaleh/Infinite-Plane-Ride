﻿using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Texture PlayTexture;
	public Texture OptionsTexture;
	public Texture QuitTexture;
	public Texture HallTexture;




	void Start ()
	{
		Debug.Log ("menu SCript : start");
		if (this.gameObject.tag == "PlayBtn")
			GetComponent<Renderer>().material.mainTexture = PlayTexture;
		else if (this.gameObject.tag == "OptionsBtn")
			GetComponent<Renderer>().material.mainTexture = OptionsTexture;
		else if (this.gameObject.tag == "QuitBtn")
			GetComponent<Renderer>().material.mainTexture = QuitTexture;
		else if (this.gameObject.tag == "hallOfFame")
			GetComponent<Renderer>().material.mainTexture = HallTexture;
	}
	
	void OnTouchDown ()
	{
		Debug.Log ("menu SCript : onTouchDown");
		if (this.gameObject.tag == "PlayBtn")
			Application.LoadLevel("_MainScene");
		else if (this.gameObject.tag == "OptionsBtn")
			Application.LoadLevel("Options");
		else if (this.gameObject.tag == "QuitBtn")
//			Application.Quit();
			Application.LoadLevel("Ach.");
		else if (this.gameObject.tag == "hallOfFame")
			Application.LoadLevel("HallOfFame");
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
