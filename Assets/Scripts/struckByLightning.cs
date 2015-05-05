using UnityEngine;
using System.Collections;

public class struckByLightning : MonoBehaviour {

	public GameObject LightningEffect;
	
	PlaneControl planeScriptObject;
	
	
	private GameObject struckFKT;
	private bool isRunning = false;
//	private float endTime;
//	public float duration = 5.0f;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
		
	}
	
	public void startEffect ()
	{
//		if (isRunning) {
//			return;
//		}
//		isRunning = true;
		
		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
		
		
		struckFKT = Instantiate (LightningEffect)as GameObject;
		struckFKT.transform.position = new Vector3(transform.position.x,transform.position.y,-4f);

		planeScriptObject.adjustCurrentHealth(-20);
		//			makeEffects();
		
		
//		endTime = Time.time + duration;
		
		
		
	}
	
//	public void endPowerup ()
//	{
//		
//		isRunning = false;
//		
//		planeScriptObject.bulletLevel=0;
//		
//		Destroy (bulletFKT);
//		
//	}

//	void Update ()
//	{
//		if (Time.time > endTime && isRunning) {
//			endPowerup ();
//		} else if (isRunning) {
//			struckFKT.transform.position = transform.position;
//		}
//	}
}
