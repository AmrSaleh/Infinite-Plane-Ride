using UnityEngine;
using System.Collections;

public class bulletsPowerUp : MonoBehaviour {

	public GameObject bulletPowerUpEffect;
	
	PlaneControl planeScriptObject;
	public AudioClip bulletPowerUpSound;


	private GameObject bulletFKT;
	private bool isRunning = false;
	private float endTime;
	public float duration = 5.0f;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
		
	}
	
	public void startEffect ()
	{
		if (isRunning) {
			return;
		}
		isRunning = true;
		
		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
		
		if (GlobalData.SFX == true) {
			AudioSource.PlayClipAtPoint (bulletPowerUpSound, transform.position);
			//				Debug.Log("ana 3amlt soot");
		}	
		bulletFKT = Instantiate (bulletPowerUpEffect, transform.position, transform.rotation)as GameObject;
		
		planeScriptObject.bulletLevel = 1;
		//			makeEffects();
		
		
		endTime = Time.time + duration;

		
		
	}

	public void endPowerup ()
	{
		
		isRunning = false;

		planeScriptObject.bulletLevel=0;
		
		Destroy (bulletFKT);
		
	}
	void Update ()
	{
		if (Time.time > endTime && isRunning) {
			endPowerup ();
		} else if (isRunning) {
			bulletFKT.transform.position = transform.position;
		}
	}
}
