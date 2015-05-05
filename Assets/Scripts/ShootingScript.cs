using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject plane;
	
	void Start ()
	{
		//		plane.rigidbody2D.AddForce(new Vector2 (0.0f, 1 * speed));	
	}
	
	void OnTouchDown ()
	{if (PlaneControl.gameEnded)
		return;
		plane.GetComponent<PlaneControl> ().shootBullet ();
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
