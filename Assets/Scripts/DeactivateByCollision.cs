using UnityEngine;
using System.Collections;

public class DeactivateByCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) 
	{
		if (other.tag == "leftWall") 
		{
			gameObject.SetActive(false);
		}
		
	}
}
