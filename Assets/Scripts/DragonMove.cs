using UnityEngine;
using System.Collections;

public class DragonMove : MonoBehaviour
{
		private GameObject plane;

		void Start ()
		{
				plane = GameObject.FindWithTag ("Player");
		}
	
		void Update ()
		{
				if (PlaneControl.gameEnded) {
						this.gameObject.SetActive (false);
						return;		
				}
				if (plane.transform.position.y > transform.position.y) {
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						this.GetComponent<Rigidbody2D>().AddForce (Vector2.up * 50);
				} else if (plane.transform.position.y < transform.position.y) {
						GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						this.GetComponent<Rigidbody2D>().AddForce (-Vector2.up * 50); 
				} 

		}


}
