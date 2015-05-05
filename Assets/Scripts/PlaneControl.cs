using UnityEngine;
using System.Collections;

public class PlaneControl : MonoBehaviour
{
	speedPowerUp speedPowerScript;
	HealthPowerUp healthPowerScript;
	bulletsPowerUp bulletsPowerScript;
	struckByLightning LightningScript;
	RainEffect rainScript;
	ScrollingScript backGroundScrollScript;
	PoolScript activateBullet;
	PoolScript activateCoin;
	PoolScript activateBird;
	PoolScript activateDragon;
	PoolScript activatePowerUp1;
	PoolScript activatePowerUp2;
	PoolScript activatePowerUp3;
	PoolScript activateCloud;
	
	public AudioClip CoinBlip;
	public AudioClip smallExplosionSound;
	public AudioClip LargeExplosionSound;
	public AudioClip hitWallSound;
	
	
	public AudioClip shootBulletSound;
	
	
	private GUIStyle currentStyle = null;
	public GUIStyle LabelStyle;
	public GUIText LoseText;

	public Texture2D BackBtn;
	public Texture2D Diamond;
	
	public float PlayerSpeed;
	public float maxHealth;
	public float currHealth;
	public float healthBarLength;
	
	public static bool gameEnded;
	public bool raining = false;
	public bool IsDragon = false;
	public bool invincible = false;
	bool UpFlag = false;
	public int score;
	
	public GameObject smallExplosion;
	public GameObject LargeExplosion;
	public GameObject fire;
	public GameObject bonusEffect;
	public GameObject grassQuad;
	
	public int InitialEnemySpeed;
	public int scoreIncreaseRatio;
	public static int diamonds;
	public int coinSpeed;
	public int bulletLevel = 0;
	public float coinSleep;
	private int TimeInt = 0;
	public float oldBackGroundSpeed;
	public float upForce;
	public  Camera MainCameraObject;
	private Vector3 cameraBounds;
	
	public int SpeedControl;
	
	void Start ()
	{
		GlobalData.BeginnerScore = 0;
		
		if (PlayerPrefs.GetInt ("Diamonds") > 0)
			LoadInformation.LoadAllInformation ();
		else 
			diamonds = 0;

		Debug.Log("el score elly betdwar 3aleeh ba3d el load = " + GlobalData.BeginnerScore);
		
		backGroundScrollScript = GameObject.Find ("Sky Quad").GetComponent<ScrollingScript> ();
		
		gameEnded = false;
		healthBarLength = (Screen.width / 2);
		
		oldBackGroundSpeed = backGroundScrollScript.Speed;
		
		activateBullet = GameObject.Find ("BulletPool").GetComponent<PoolScript> ();
		activateCoin = GameObject.Find ("coinPool").GetComponent<PoolScript> ();
		activateBird = GameObject.Find ("BirdPool").GetComponent<PoolScript> ();
		activateDragon = GameObject.Find ("DragonPool").GetComponent<PoolScript> ();
		activateCloud = GameObject.Find ("CloudPool").GetComponent<PoolScript> ();
		activatePowerUp1 = GameObject.Find ("PowerUpPool1").GetComponent<PoolScript> ();
		activatePowerUp2 = GameObject.Find ("PowerUpPool2").GetComponent<PoolScript> ();
		activatePowerUp3 = GameObject.Find ("PowerUpPool3").GetComponent<PoolScript> ();
		
		speedPowerScript = GameObject.Find ("PlayerPlane").GetComponent<speedPowerUp> ();
		healthPowerScript = GameObject.Find ("PlayerPlane").GetComponent<HealthPowerUp> ();
		bulletsPowerScript = GameObject.Find ("PlayerPlane").GetComponent<bulletsPowerUp> ();
		LightningScript = GameObject.Find ("PlayerPlane").GetComponent<struckByLightning> ();
		rainScript = GameObject.Find ("PlayerPlane").GetComponent<RainEffect> ();
		
		
		
		StartCoroutine (CoinControl ());
		StartCoroutine (BirdControl ());
		StartCoroutine (PowerUpControl ());
		StartCoroutine (CloudControl ());
		
		cameraBounds = MainCameraObject.camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		

		
	}
	
	private int counter = 0;
	
	void FixedUpdate ()
	{
		if (gameEnded) {
			return;
		}
		if (!IsDragon) {
			counter++;
			if (counter >= 20) 
			{
				score += (scoreIncreaseRatio);
				if (score >= 1000 && GlobalData.ExpertScore == 0)
				{
					GlobalData.ExpertScore = 1;
					Debug.Log("enta 3adeet 1000 fel score");
				}
				else if (score >= 500 && GlobalData.IntermediateScore == 0)
				{
					GlobalData.IntermediateScore = 1;
					Debug.Log("enta 3adeet 500 fel score");
				}
				else if (score >= 50 && GlobalData.BeginnerScore == 0)
				{
					GlobalData.BeginnerScore = 1;
					Debug.Log("enta 3adeet 50 fel score");
				}
				counter = 0;
			}
		}
	}
	
	Vector2 tempVector2 = Vector2.zero;
	
	public void move_plane (int moveVertical)
	{
		rigidbody2D.AddForce (PlayerSpeed * Vector2.up);
		float minYSpeed = 0;
		float maxYSpeed = 3;
		float y = Mathf.Clamp (rigidbody2D.velocity.y, minYSpeed, maxYSpeed);
		tempVector2.Set (rigidbody2D.velocity.x, y);
		rigidbody2D.velocity = tempVector2;
	}
	
	public GUITexture jumpTexture;
	public GUITexture fireTexture;
	int count;
	Touch touch;
	
	void Update ()
	{
		DragonControl ();
	}
	
	GameObject currentBullet = null;
	Vector3 tempVec3 = new Vector3 (0, 0, 0);
	Vector2 tempVec2 = new Vector3 (0, 0);
	
	public void shootBullet ()
	{
		if (GlobalData.SFX == true) {
			AudioSource.PlayClipAtPoint (shootBulletSound, transform.position);
			//				Debug.Log("ana 3amlt soot");
		}	
		currentBullet = null;
		if (bulletLevel == 0) {
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -90);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (1000, 0);
			currentBullet.rigidbody2D.AddForce (tempVec2);
		} else if (bulletLevel == 1) {
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -90);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (1000, 0);
			currentBullet.rigidbody2D.AddForce (tempVec2);
			
			currentBullet = null;
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -45);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (500, 500);
			currentBullet.rigidbody2D.AddForce (tempVec2);
			
			currentBullet = null;
			currentBullet = (GameObject)activateBullet.ActivateObject ();
			if (currentBullet == null)
				return;
			tempVec3.Set (0, 0, -144);
			currentBullet.transform.eulerAngles = tempVec3;
			tempVec2.Set (transform.position.x + 1, transform.position.y);
			currentBullet.transform.position = tempVec2;
			tempVec2.Set (500, -500);
			currentBullet.rigidbody2D.AddForce (tempVec2);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (gameEnded)
			return;
		//		if(currHealth<=30){
		//			GameObject expl3 = Instantiate (fire) as GameObject;
		//			expl3.transform.position = new Vector3 (transform.position.x,transform.position.y+1f,expl3.transform.position.z);	
		//			expl3.transform.parent=transform;
		//		}
		if ((other.gameObject.tag == "target") && !invincible) {
			if (raining) {
				LightningScript.startEffect ();
			}
			adjustCurrentHealth (-10);
			
			if (GlobalData.SFX == true)
				AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
			
			//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
			if (other.gameObject.tag == "target") {
				other.gameObject.SetActive (false);
				
			}
			
			if (currHealth == 0) {
				//								LoseText.text = "Game Over";
				//				expl = Instantiate (LargeExplosion, other.transform.position, other.transform.rotation) as GameObject;
				
				//				splitScript script = (splitScript)actualPlaneBody.GetComponent (typeof(splitScript));
				//				script.start ();
				//				this.collider2D.enabled = false;
				
				//								GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
				//								this.collider2D.enabled = false;
				//								Destroy (this.gameObject);	
				//								SaveInformation.SaveAllInformation ();
				//								gameEnded = true;
			}
			
			GameObject expl2 = Instantiate (smallExplosion, transform.position, transform.rotation) as GameObject;
			
		}
		
		//		else if (other.gameObject.tag == "Tree") 
		//		{
		//
		//			GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
		//
		//		
		//			this.collider2D.enabled = false;
		//			Destroy(this.gameObject);
		//
		//			 currHealth = 0;
		//			LoseText.text = "Game Over";
		//			gameEnded = true;
		//
		//		}
		else if (other.gameObject.tag == "coin") {
			Instantiate (bonusEffect, transform.position, transform.rotation);
			other.gameObject.SetActive (false);
			if (GlobalData.SFX == true) {
				AudioSource.PlayClipAtPoint (CoinBlip, transform.position);
				//				Debug.Log("ana 3amlt soot");
			}	
			
			//			score+=10;
			//			SetScoreText ();
			diamonds++;
			//						setDiamondsText ();
		} else if ((other.gameObject.tag == "speedPowerUp")) {
			
			speedPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "healthPowerUp")) {
			
			healthPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "bulletPowerUp")) {
			
			bulletsPowerScript.startEffect ();
			other.gameObject.SetActive (false);
		} else if ((other.gameObject.tag == "Cloud") && !invincible) {
			
			rainScript.startEffect ();
			//			other.gameObject.SetActive (false);
		}
		
		
		
	}
	
	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "generalWall") {
			
			if (GlobalData.SFX == true) {
				AudioSource.PlayClipAtPoint (hitWallSound, transform.position);
				//				Debug.Log("ana 3amlt soot");
			}	
			if (transform.position.y < 0) {
				rigidbody2D.AddForce (Vector2.up * 500);
			}
			
			if (!invincible) {
				adjustCurrentHealth (-10);
				
				//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
				//			other.gameObject.SetActive(false);
				
				if (currHealth == 0) {
					//								LoseText.text = "Game Over";
					//				expl = Instantiate (LargeExplosion, other.transform.position, other.transform.rotation) as GameObject;
					
					//				splitScript script = (splitScript)actualPlaneBody.GetComponent (typeof(splitScript));
					//				script.start ();
					//				this.collider2D.enabled = false;
					
					//					GameObject expl = Instantiate (LargeExplosion, transform.position, transform.rotation) as GameObject;
				}
				
				GameObject expl2 = Instantiate (smallExplosion, transform.position, transform.rotation) as GameObject;
			}
		}
		
	}
	
	void OnGUI ()
	{
		if (currentStyle == null) {
			
			currentStyle = new GUIStyle (GUI.skin.box);
			currentStyle.normal.background = MakeTex (2, 2, new Color (0f, 1f, 0f, 0.5f));
		}
		GUI.Box (new Rect (10, 10, healthBarLength, 20), currHealth + "%", currentStyle);
//		GUI.Box (new Rect (10,  - this.transform.position.y*21 +Screen.width/4.5f, healthBarLength, 20), currHealth + "%", currentStyle);
		
		if (GUI.Button (new Rect (Screen.width - 60, 75, 50, 30), BackBtn)) {
			Application.LoadLevel ("Menu");
		}
		
		GUI.Label (new Rect (20, 20, /*Screen.width / 32*/ Screen.width, Screen.height / 8), "Score: " + score.ToString (), LabelStyle);
		GUI.Label (new Rect (18, 68, 30, 30), Diamond);
		GUI.Label (new Rect (45, 50, 50, Screen.height / 8), diamonds.ToString (), LabelStyle);
		
	}
	
	public void adjustCurrentHealth (int addedValue)
	{
		currHealth += addedValue;
		if (currHealth <= 0) {
			currHealth = 0;
			if (GlobalData.SFX == true)
				AudioSource.PlayClipAtPoint (LargeExplosionSound, transform.position);
			//						LoseText.text = "Game Over";
			Instantiate (LargeExplosion, transform.position, transform.rotation);
			this.collider2D.enabled = false;
			SaveInformation.SaveAllInformation ();
			Debug.Log("el score elly betdwar 3aleeh ba3d el save = " + GlobalData.BeginnerScore);
			gameEnded = true;
			Destroy (this.gameObject);
			
		}
		if (currHealth > maxHealth)
			currHealth = maxHealth;
		if (maxHealth < 1)
			maxHealth = 0;
		
		healthBarLength = (Screen.width / 2) * (currHealth / maxHealth);
	}
	
	private Texture2D MakeTex (int width, int height, Color col)
	{
		Color[] pix = new Color[width * height];
		for (int i = 0; i < pix.Length; ++i) {
			pix [i] = col;
		}
		Texture2D result = new Texture2D (width, height);
		result.SetPixels (pix);
		result.Apply ();
		return result;
	}
	
	IEnumerator CoinControl ()
	{
		coinSpeed = SpeedControl + 100;
		coinSleep = 0.1f;
		var RandomSleep = Random.Range (2, 3);
		var RandomShape = Random.Range (0, 3);
		var RandomCoinCount = Random.Range (3, 7);
		var RandomNumber = Random.Range (-4, 4);
		while (true) {
			RandomSleep = Random.Range (2, 3);
			yield return new WaitForSeconds (RandomSleep);
			
			RandomShape = Random.Range (0, 3);
			RandomCoinCount = Random.Range (3, 7);
			
			
			RandomNumber = Random.Range (-4, 4);
			GameObject currentCoin;
			
			if (RandomShape > 0 && RandomShape <= 1) {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (2, 4);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							tempVec2.Set (12, RandomNumber);
							currentCoin.transform.position = tempVec2;
							tempVec2.Set (-coinSpeed, 0);
							currentCoin.rigidbody2D.AddForce (tempVec2);
							
						}
						
					}
					yield return new WaitForSeconds (coinSleep);
				}
			} else if (RandomShape > 1 && RandomShape <= 2) {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (1, 3);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							tempVec2.Set (12, RandomNumber);
							currentCoin.transform.position = tempVec2;
							tempVec2.Set (-coinSpeed, 0);
							currentCoin.rigidbody2D.AddForce (tempVec2);
							
						}
					}
					yield return new WaitForSeconds (coinSleep);
				}
			} else {
				
				
				for (int i = 0; i < RandomCoinCount; i++) {
					RandomNumber = Random.Range (-3, -1);
					if (!IsDragon) {
						currentCoin = (GameObject)activateCoin.ActivateObject ();
						
						if (currentCoin != null) {
							tempVec2.Set (12, RandomNumber);
							currentCoin.transform.position = tempVec2;
							tempVec2.Set (-coinSpeed, 0);
							currentCoin.rigidbody2D.AddForce (tempVec2);
							
						}
					}
					yield return new WaitForSeconds (coinSleep);
				}
			}	
			
			
			
			
			//						currentCoin = (GameObject)activateCoin.ActivateObject ();
			//			
			//						if (currentCoin != null) 
			//						{
			//								currentCoin.transform.position = new Vector2 (9, RandomNumber);
			//								currentCoin.rigidbody2D.AddForce (new Vector2 (-coinSpeed, 0));
			//						}
			//						
		}					
	}
	
	int bgNum = 0;
	
	IEnumerator BirdControl ()
	{
		var RandomNumber = Random.Range (-2, 4);
		InitialEnemySpeed = SpeedControl + 20;
		GameObject currentBird;
		while (true) {
			
			//						InitialEnemySpeed += 5;
			
			RandomNumber = Random.Range (-2, 4);
			
			// lama el dragon yetla3
			if ((TimeInt % 10 == 0) && (TimeInt > 0)) {
				if (speedPowerScript.isRunning) {
					speedPowerScript.endPowerup ();
				}
				bgNum++;
				bgNum = bgNum % 4;
				backGroundScrollScript.changeBackground (bgNum);
				grassQuad.GetComponent<ScrollingScript> ().changeBackground (bgNum);
				oldBackGroundSpeed = backGroundScrollScript.Speed;
				counter = 0;
				TimeInt = 0;
				IsDragon = true;
				
			}
			
			if (!IsDragon) {	
				if (TimeInt == 0) {
					backGroundScrollScript.Speed = oldBackGroundSpeed;
					grassQuad.GetComponent<ScrollingScript> ().Speed = oldBackGroundSpeed + 0.1f;
				}						
				
				TimeInt ++;
				currentBird = null;
				currentBird = (GameObject)activateBird.ActivateObject ();
				
				if (currentBird != null) {
					tempVec2.Set (12, RandomNumber);
					currentBird.transform.position = tempVec2;
					tempVec2.Set (-InitialEnemySpeed, 0);
					currentBird.rigidbody2D.AddForce (tempVec2);
				}
			}
			yield return new WaitForSeconds (1.0f);
			
		}				
	}
	
	void DragonControl ()
	{
		
		GameObject currentDragon;
		
		if (IsDragon) {
			backGroundScrollScript.Speed = 0f;
			grassQuad.GetComponent<ScrollingScript> ().Speed = 0f;
			currentDragon = (GameObject)activateDragon.ActivateObject ();
			if (currentDragon != null) {
				tempVec2.Set (cameraBounds.x - currentDragon.renderer.bounds.size.x / 2, -2.820957f);
				currentDragon.transform.position = tempVec2;
			}
			
		}
		
		
		
	}
	
	public int powerUpSpeed;
	
	IEnumerator PowerUpControl ()
	{
		powerUpSpeed = SpeedControl + 100;
		GameObject currentPowerUp;
		var RandomNumber = Random.Range (-2, 4);
		var RandomPowerUp = Random.Range (0, 3);
		while (true) {
			
			if (!IsDragon) {
				
				RandomNumber = Random.Range (-2, 4);
				
				currentPowerUp = null;
				
				RandomPowerUp = Random.Range (0, 3);
				
				if (RandomPowerUp > 0 && RandomPowerUp <= 1)
					currentPowerUp = (GameObject)activatePowerUp1.ActivateObject ();
				else if (RandomPowerUp > 1 && RandomPowerUp <= 2)
					currentPowerUp = (GameObject)activatePowerUp2.ActivateObject ();
				else
					currentPowerUp = (GameObject)activatePowerUp3.ActivateObject ();
				
				if (currentPowerUp != null) {
					tempVec2.Set (12, RandomNumber);
					currentPowerUp.transform.position = tempVec2;
					tempVec2.Set (-powerUpSpeed, 0);
					currentPowerUp.rigidbody2D.AddForce (tempVec2);
				}
			}
			yield return new WaitForSeconds (3.0f);
		}		
	}
	
	public float cloudSpeed;
	
	IEnumerator CloudControl ()
	{
		cloudSpeed = SpeedControl + 50;
		GameObject currentCloud;
		while (true) {
			currentCloud = null;
			if (!IsDragon) {
				currentCloud = (GameObject)activateCloud.ActivateObject ();
				if (currentCloud != null) {
					tempVec2.Set (10, 4.0f);
					currentCloud.transform.position = tempVec2;
					tempVec2.Set (-cloudSpeed, 0);
					currentCloud.rigidbody2D.AddForce (tempVec2);
				}
			}
			yield return new WaitForSeconds (3.0f);
		}			
	}
	
	public void adjustSpeedOfCurrentActiveObjects (int coin, int bird, int cloud, int power)
	{
		Debug.Log ("here");
		//		for(int i =0 ; i <activateBullet.objects.Length;i++){if(activateBullet.objects[i].activeInHierarchy)
		//			activateBullet.objects[i].rigidbody2D.velocity=Vector2.zero;
		//			activateBullet.objects[i].rigidbody2D.AddForce(new Vector2 (-bullet, 0));}
		for (int i =0; i <activateCoin.objects.Length; i++) {
			if (activateCoin.objects [i].activeInHierarchy)
				activateCoin.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-coin, 0);
			activateCoin.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		for (int i =0; i <activateBird.objects.Length; i++) {
			if (activateBird.objects [i].activeInHierarchy)
				activateBird.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-bird, 0);
			activateBird.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		//		for(int i =0 ; i <activateDragon.objects.Length;i++){if(activateDragon.objects[i].activeInHierarchy)
		//			activateDragon.objects[i].rigidbody2D.velocity=Vector2.zero;
		//			activateDragon.objects[i].rigidbody2D.AddForce(new Vector2 (-dragon, 0));}
		for (int i =0; i <activateCloud.objects.Length; i++) {
			if (activateCloud.objects [i].activeInHierarchy)
				activateCloud.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-cloud, 0);
			activateCloud.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		for (int i =0; i <activatePowerUp1.objects.Length; i++) {
			if (activatePowerUp1.objects [i].activeInHierarchy)
				activatePowerUp1.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-power, 0);
			activatePowerUp1.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		for (int i =0; i <activatePowerUp2.objects.Length; i++) {
			if (activatePowerUp2.objects [i].activeInHierarchy)
				activatePowerUp2.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-power, 0);
			activatePowerUp2.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		for (int i =0; i <activatePowerUp3.objects.Length; i++) {
			if (activatePowerUp3.objects [i].activeInHierarchy)
				activatePowerUp3.objects [i].rigidbody2D.velocity = Vector2.zero;
			tempVec2.Set (-power, 0);
			activatePowerUp3.objects [i].rigidbody2D.AddForce (tempVec2);
		}
		
		Debug.Log ("there");
	}
}
