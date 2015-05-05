using UnityEngine;
using System.Collections;

public class Up : MonoBehaviour {

	public GameObject plane;
	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
		transform.localScale = Vector3.zero;
		
		guiTexture.pixelInset = new Rect(0, 0, Screen.width/2, Screen.height);
	}

	void OnMouseDown(){
//		Debug.Log ("Upppp");
		plane.GetComponent<PlaneControl> ().move_plane (1);
		}
}
