using UnityEngine;
using System.Collections;

public class shooting : MonoBehaviour {

	public GameObject bullet;
	public GameObject canon1;
	public GameObject canon2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	Vector2 tempVector2 = Vector2.zero;
	void Update () {
	
		if (Input.GetButtonDown ("Fire1")) {
						GameObject mybullet = (GameObject)Instantiate (bullet, canon1.transform.position, bullet.transform.rotation);
			tempVector2.Set(1000,0);
			mybullet.GetComponent<Rigidbody2D>().AddForce(tempVector2);
//			mybullet =(GameObject) Instantiate (bullet, canon2.transform.position, canon2.transform.rotation);
//			mybullet.rigidbody2D.AddForce(new Vector2(0,500));
		}
	}
}
