using UnityEngine;
using System.Collections;

public class MoveUpScript : MonoBehaviour {

	public GameObject plane;

	void Start ()
	{

	}
	
	void OnTouchDown ()
	{
		if (PlaneControl.gameEnded)
			return;
		plane.GetComponent<PlaneControl> ().move_plane (1);
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
