using UnityEngine;
using System.Collections;

public class OptionsScript : MonoBehaviour {
	
	public Texture OnTexture;
	public Texture OffTexture;
	public Texture OnTextureDim;
	public Texture OffTextureDim;

	public GameObject SFXOn;
	public GameObject SFXOff;
	public GameObject MusicOn;
	public GameObject MusicOff;
//	GameObject mc;

	void OnTouchDown ()
	{

//		mc = GameObject.FindGameObjectWithTag ("bgmusic");

//		Debug.Log (mc);
				if (this.gameObject.tag == "SFXOn") {
						GetComponent<Renderer>().material.mainTexture = OnTexture;
						SFXOff.GetComponent<Renderer>().material.mainTexture = OffTextureDim;
						GlobalData.SFX = true;
				} else if (this.gameObject.tag == "SFXOff") {
						GetComponent<Renderer>().material.mainTexture = OffTexture;
						SFXOn.GetComponent<Renderer>().material.mainTexture = OnTextureDim;
						GlobalData.SFX = false;
				} else if (this.gameObject.tag == "MusicOn") {
						GetComponent<Renderer>().material.mainTexture = OnTexture;
						MusicOff.GetComponent<Renderer>().material.mainTexture = OffTextureDim;
						GlobalData.Music = true;
//			mc.GetComponent<musicControl>().Test();
				} else if (this.gameObject.tag == "MusicOff") {
						GetComponent<Renderer>().material.mainTexture = OffTexture;
						MusicOn.GetComponent<Renderer>().material.mainTexture = OnTextureDim;
						GlobalData.Music = false;		
//			mc.GetComponent<musicControl>().Test();
		}
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
