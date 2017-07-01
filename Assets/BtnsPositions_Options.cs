using UnityEngine;
using System.Collections;

public class BtnsPositions_Options : MonoBehaviour {

	public Texture OnTexture;
	public Texture OffTexture;
	public Texture OnTextureDim;
	public Texture OffTextureDim;
	
	public GameObject SFXOn;
	public GameObject SFXOff;
	public GameObject MusicOn;
	public GameObject MusicOff;


	void Start () 
	{

		if (GlobalData.SFX) 
		{
			SFXOn.GetComponent<Renderer>().material.mainTexture = OnTexture;
			SFXOff.GetComponent<Renderer>().material.mainTexture = OffTextureDim;
		}
		else 
		{
			SFXOn.GetComponent<Renderer>().material.mainTexture = OnTextureDim;
			SFXOff.GetComponent<Renderer>().material.mainTexture = OffTexture;	
		}

		if (GlobalData.Music) 
		{
			MusicOn.GetComponent<Renderer>().material.mainTexture = OnTexture;
			MusicOff.GetComponent<Renderer>().material.mainTexture = OffTextureDim;
		}
		else 
		{
			MusicOn.GetComponent<Renderer>().material.mainTexture = OnTextureDim;
			MusicOff.GetComponent<Renderer>().material.mainTexture = OffTexture;	
		}


//		Vector3 cameraBounds = camera.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));

		
//		Play.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Play.transform.localScale.z);
//		Options.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Options.transform.localScale.z);
//		Quit.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Quit.transform.localScale.z);
//		
//		
//
//		Play.transform.position= new Vector3 ( 0, cameraBounds.y - cameraBounds.y *1/2, Play.transform.position.z);
//		Options.transform.position= new Vector3 ( 0, Play.transform.position.y - 2*Play.transform.localScale.y, Options.transform.position.z);
//		Quit.transform.position= new Vector3 ( 0, Options.transform.position.y - 2*Options.transform.localScale.y, Quit.transform.position.z);

	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Menu");		
		}
		
	}

}
