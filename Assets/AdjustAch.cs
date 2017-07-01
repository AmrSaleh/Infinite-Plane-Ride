using UnityEngine;
using System.Collections;

public class AdjustAch : MonoBehaviour {

	public GameObject BeginnerScore;

	public Texture BeginnerTexture;

	void Start () 
	{
		Vector3 cameraBounds = GetComponent<Camera>().ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
		BeginnerScore.transform.localScale = new Vector3 ( cameraBounds.x/2, cameraBounds.y*1/4, BeginnerScore.transform.localScale.z);
		BeginnerScore.transform.position= new Vector3 ( 0, cameraBounds.y - cameraBounds.y * 0.25f, BeginnerScore.transform.position.z);

		BeginnerScore.GetComponent<Renderer>().material.mainTexture = BeginnerTexture;

		Debug.Log("Ana fel start beta3 el scene");
	}
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("Menu");
		}
		
	}
}
