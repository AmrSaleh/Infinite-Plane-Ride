using UnityEngine;
using System.Collections;

public class BtnsPositions : MonoBehaviour {

	public GameObject Play;
	public GameObject Options;
	public GameObject HallOfFame;
	public GameObject Quit;

	void Start () 
	{
		Debug.Log ("btns positions start");
		Vector3 cameraBounds = GetComponent<Camera>().ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));

//		Debug.Log ("width: "+cameraBounds.x);
//		Debug.Log ("height: "+cameraBounds.y);

		Play.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Play.transform.localScale.z);
		Options.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Options.transform.localScale.z);
		Quit.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, Quit.transform.localScale.z);
		HallOfFame.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, HallOfFame.transform.localScale.z);

//		Debug.Log ("width: "+ cameraBounds.y * 2/3);

		Play.transform.position= new Vector3 ( 0, cameraBounds.y - cameraBounds.y * 0.25f, Play.transform.position.z);
		Options.transform.position= new Vector3 ( 0, Play.transform.position.y - 2*Play.transform.localScale.y, Options.transform.position.z);
		HallOfFame.transform.position= new Vector3 ( 0, Options.transform.position.y - 2*Options.transform.localScale.y, Quit.transform.position.z);
		Quit.transform.position= new Vector3 ( 0, HallOfFame.transform.position.y - 2*HallOfFame.transform.localScale.y, HallOfFame.transform.position.z);
	
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();		
		}
		
	}
	

}
