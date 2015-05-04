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
			SFXOn.renderer.material.mainTexture = OnTexture;
			SFXOff.renderer.material.mainTexture = OffTextureDim;
		}
		else 
		{
			SFXOn.renderer.material.mainTexture = OnTextureDim;
			SFXOff.renderer.material.mainTexture = OffTexture;	
		}

		if (GlobalData.Music) 
		{
			MusicOn.renderer.material.mainTexture = OnTexture;
			MusicOff.renderer.material.mainTexture = OffTextureDim;
		}
		else 
		{
			MusicOn.renderer.material.mainTexture = OnTextureDim;
			MusicOff.renderer.material.mainTexture = OffTexture;	
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
