using UnityEngine;
using System.Collections;

public class RainEffect : MonoBehaviour {

	public GameObject rainEffect;
	public GameObject hitCloud;
	public GameObject blackScreen;
	PlaneControl planeScriptObject;

	private AudioSource myAudioSource;
	public AudioClip hitCloudSound;
	//	private float startTime;
	private float endTime;
	public float duration = 5.0f;
	private bool isRunning = false;
	// Use this for initialization
	private GameObject rain,hit,black;
	
	void Start ()
	{
		planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
		myAudioSource = gameObject.AddComponent<AudioSource>();
		myAudioSource.clip = hitCloudSound;
		myAudioSource.volume = 1.0F;

	}
	
	public void startEffect ()
	{
		if (isRunning) {
			return;
		}
		isRunning = true;

		if (GlobalData.SFX == true) {
			myAudioSource.Play();
			//				Debug.Log("ana 3amlt soot");
		}	
		//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
		//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
		
		rain = Instantiate (rainEffect) as GameObject;
		black = Instantiate (blackScreen) as GameObject;
		hit = Instantiate (hitCloud, transform.position,transform.rotation) as GameObject;

		planeScriptObject.raining = true;

		

		//			makeEffects();
		endTime = Time.time + duration;
		
		
		
		
	}
	
	public void endPowerup ()
	{
		
		isRunning = false;
		planeScriptObject.raining = false;
		Destroy (rain);
		Destroy (black);

		if(myAudioSource.isPlaying)
			myAudioSource.Stop();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > endTime && isRunning) {
			endPowerup ();
		} 
	}
}
