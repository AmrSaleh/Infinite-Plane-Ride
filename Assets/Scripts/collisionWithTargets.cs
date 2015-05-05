using UnityEngine;
using System.Collections;

public class collisionWithTargets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "target") {
			//			other.gameObject.SetActive (false);
			Destroy(other.gameObject);
			
		}

	}


}
