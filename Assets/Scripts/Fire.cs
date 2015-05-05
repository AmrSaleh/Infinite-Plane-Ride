﻿using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public GameObject plane;
	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		
		guiTexture.pixelInset = new Rect(Screen.width/2, 0, Screen.width/2, Screen.height);
	}
	void OnMouseDown(){
//		Debug.Log ("shooot");
		plane.GetComponent<PlaneControl> ().shootBullet ();
	}
}
