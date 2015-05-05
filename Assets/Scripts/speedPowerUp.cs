using UnityEngine;
using System.Collections;

public class speedPowerUp : MonoBehaviour
{
//
	private AudioSource speedPowerUpSoundSource;
		public AudioClip speedPowerUpClip;

		public GameObject shieldEffect;
		public GameObject speedEffect;
		PlaneControl planeScriptObject;
		ScrollingScript backGroundScrollScript;
		private float oldBackGroundSpeed;
		private int oldEnemiesSpeed, oldCoinSpeed;
		private int oldBottleSpeed;
		private int oldDragonSpeed;
		private float oldCoinSleep;
		private int oldScoreIncreaseRatio;
		public int newScoreIncreaseRatio = 3;
		public int newEnemySpeed = 1000;
		public int newCoinSpeed = 700;
	public int newCloudSpeed = 1000;
		public float newCoinSleep = 0.04f;
		public int newBottleSpeed = 1000;
		public int newDragonSpeed = 500;
		public float newBgSpeed = 5.0f;
	public float oldCloudSpeed;
//	private float startTime;
		private float endTime;
		public float duration = 5.0f;
		public bool isRunning = false;
		// Use this for initialization
		private GameObject shield, speed;
	public GameObject grassQuad;

		void Start ()
		{
				planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
				backGroundScrollScript = GameObject.Find ("Sky Quad").GetComponent<ScrollingScript> ();
		speedPowerUpSoundSource = gameObject.AddComponent<AudioSource>();
		speedPowerUpSoundSource.clip = speedPowerUpClip;
		speedPowerUpSoundSource.volume = 1.0F;
		}

		public void startEffect ()
		{
				if (isRunning) {
						return;
				}
				isRunning = true;
		if (GlobalData.SFX == true) {
			speedPowerUpSoundSource.Play();
			//				Debug.Log("ana 3amlt soot");
		}	
//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
			
//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
					
				shield = Instantiate (shieldEffect, transform.position, transform.rotation)as GameObject;
				speed = Instantiate (speedEffect, transform.position, transform.rotation)as GameObject;
				oldBackGroundSpeed = backGroundScrollScript.Speed;
				oldCoinSpeed = planeScriptObject.coinSpeed;
				oldCoinSleep = planeScriptObject.coinSleep;
				oldEnemiesSpeed = planeScriptObject.InitialEnemySpeed;
//				oldDragonSpeed = planeScriptObject.dragonSpeed;
				oldBottleSpeed = planeScriptObject.powerUpSpeed;
				oldScoreIncreaseRatio = planeScriptObject.scoreIncreaseRatio;
		oldCloudSpeed = planeScriptObject.cloudSpeed;

				planeScriptObject.invincible = true;
		planeScriptObject.cloudSpeed = newCloudSpeed;
				backGroundScrollScript.Speed = newBgSpeed;
		grassQuad.GetComponent<ScrollingScript> ().Speed = newBgSpeed + 0.1f;
				planeScriptObject.coinSpeed = newCoinSpeed;
				planeScriptObject.coinSleep = newCoinSleep;
				planeScriptObject.InitialEnemySpeed = newEnemySpeed;
//				planeScriptObject.dragonSpeed = newDragonSpeed;
				planeScriptObject.powerUpSpeed = newBottleSpeed;
				planeScriptObject.scoreIncreaseRatio = newScoreIncreaseRatio;
//			makeEffects();
				endTime = Time.time + duration;

				
		planeScriptObject.adjustSpeedOfCurrentActiveObjects (newCoinSpeed,newEnemySpeed,newCloudSpeed,newBottleSpeed);

				
		}

		public void endPowerup ()
		{
//				if (!isRunning)
//					return;

//		Debug.Log ("ana da5lt");
				isRunning = false;
				backGroundScrollScript.Speed = oldBackGroundSpeed;
		grassQuad.GetComponent<ScrollingScript> ().Speed = oldBackGroundSpeed + 0.1f;
				planeScriptObject.coinSpeed = oldCoinSpeed;
				planeScriptObject.coinSleep = oldCoinSleep;
				planeScriptObject.InitialEnemySpeed = oldEnemiesSpeed;
				planeScriptObject.invincible = false;
				planeScriptObject.cloudSpeed = oldCloudSpeed;
//				planeScriptObject.dragonSpeed = oldDragonSpeed;
				planeScriptObject.powerUpSpeed = oldBottleSpeed;
				planeScriptObject.scoreIncreaseRatio = oldScoreIncreaseRatio;

		if(speedPowerUpSoundSource.isPlaying)
		speedPowerUpSoundSource.Stop();
//		audio.Stop();
//		Debug.Log ("abl el destroy");
				Destroy (shield);
				Destroy (speed);
//		Debug.Log ("ba3d el destroy");
		}

		// Update is called once per frame
	Vector2 tempVector2 = Vector2.zero;
		void Update ()
		{
				if ((Time.time > endTime && isRunning) || (planeScriptObject.IsDragon && isRunning)) {
						endPowerup ();
				} else if (isRunning) {
						shield.transform.position = transform.position;
						tempVector2.Set(transform.position.x - 1, transform.position.y);
						speed.transform.position = tempVector2;
				}
		}
}
