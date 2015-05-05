using UnityEngine;
using System.Collections;

public class HealthPowerUp : MonoBehaviour {

	public GameObject healthEffect;

	PlaneControl planeScriptObject;

	public int gainedHealth = 20;
	private GameObject healthFKT;
	private bool isRunning = false;
	public AudioClip healthPowerUpSound;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();

	}
	
	public void startEffect ()
	{


		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		

		if (GlobalData.SFX == true) {
			AudioSource.PlayClipAtPoint (healthPowerUpSound, transform.position);
			//				Debug.Log("ana 3amlt soot");
		}	
		healthFKT = Instantiate (healthEffect, transform.position, transform.rotation)as GameObject;

		planeScriptObject. adjustCurrentHealth(gainedHealth);
		//			makeEffects();

		
		
		
		
	}
	
	void Update ()
	{
		if(healthFKT!= null)
			healthFKT.transform.position = transform.position;
			

	}
}
