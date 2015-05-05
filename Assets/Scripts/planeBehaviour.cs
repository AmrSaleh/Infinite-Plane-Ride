using UnityEngine;
using System.Collections;

public class planeBehaviour : MonoBehaviour
{

		public GameObject canon1;
		public float speed;
		//		public float maxRotationAngle;
		//		public float rotaionStep;
		//		private bool barrelRoll = false;
		//		private bool rollRight = false;
		//		private float minY = -3.5f; // Bottom of the screen 
		//		private float maxY = 3.5f; // Top of the screena
		public GameObject actualPlaneBody;
		public GameObject rotor;
		public GameObject smallExplosion; // drag your explosion prefab here
		public GameObject LargeExplosion; // drag your explosion prefab here
		public GameObject burning;
		public GameObject smoke;
		public float maxHealth = 100;
		public float currHealth = 100;
		public float healthBarLength;
		private GUIStyle currentStyle = null;
		private bool gameEnded;
		PoolScript activateBullet;
		PoolScript activateCoin;
		PoolScript activateEnemy;
		public AudioClip CoinBlip;
		public GUIText ScoreText;
		public GUIText LoseText;
		private static int score;
		public int InitialSpeed;
		public GameObject GO ;

		// Use this for initialization
		void Start ()
		{

				gameEnded = false;
				healthBarLength = (Screen.width / 2);
				activateBullet = GameObject.Find ("BulletPool").GetComponent<PoolScript> ();
				Debug.Log (" plane start called");
				activateCoin = GameObject.Find ("coinPool").GetComponent<PoolScript> ();
				activateEnemy = GameObject.Find ("EnemyPool").GetComponent<PoolScript> ();


				StartCoroutine (CoinControl ());
				StartCoroutine (EnemyControl ());
				SetScoreText ();
				LoseText.text = "";
				Debug.Log (" plane start ended");
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (gameEnded)
						return;
				if (other.gameObject.tag == "target") {
						//			other.gameObject.SetActive (false);
						adjustCurrentHealth (-10);


						GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
//			expl.transform.parent=this.transform; 
//			expl. transform.localScale = new Vector3(0.1F, 0, 0);
		
						//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
//			Destroy(expl, 3); // delete the explosion after 1 seconds

						if (currHealth == 10) {
//				expl = Instantiate (burning, actualPlaneBody.transform.position, actualPlaneBody.transform.rotation) as GameObject;
//				expl.transform.position = actualPlaneBody.transform.position;
//				expl.transform.parent = actualPlaneBody.transform;

				
//				expl = Instantiate (smoke, actualPlaneBody.transform.position, actualPlaneBody.transform.rotation) as GameObject;
//				expl.transform.position = actualPlaneBody.transform.position;
//				expl.transform.parent = actualPlaneBody.transform;
						}

						if (currHealth == 0) {
								LoseText.text = "Game Over";
								expl = Instantiate (LargeExplosion, other.transform.position, other.transform.rotation) as GameObject;



//				rigidbody2D.fixedAngle= false;
//				rigidbody2D.AddTorque(5000);
//				rigidbody2D.AddForce (new Vector2 (-1 * 10*speed, 1 * speed));
			

								splitScript script = (splitScript)actualPlaneBody.GetComponent (typeof(splitScript));
								script.start ();
								this.collider2D.enabled = false;

								Destroy (rotor);

								gameEnded = true;
						}
		
				} else if (other.gameObject.tag == "coin") {
						other.gameObject.SetActive (false);
						AudioSource.PlayClipAtPoint (CoinBlip, transform.position);
						score++;
						Debug.Log (score);
						SetScoreText ();
				}
		
		}

		void FixedUpdate ()
		{
				if (gameEnded) {
//			burning.transform.pare =this.transform.position;
//			smoke.transform.position=transform.position;
		
						return;
				}
//		if (transform.position.y > maxY)
//			transform.position = new Vector3 (transform.position.x, 3.5f, 0);
//		
//		if (transform.position.y < minY)
//			transform.position = new Vector3 (transform.position.x, -3.5f, 0);
				float moveHorizontal = Input.GetAxis ("Horizontal");
				float moveVertical = Input.GetAxis ("Vertical");

//				if (barrelRoll) {
//						if (rollRight) {
//								if ((transform.eulerAngles.y + rotaionStep < 90) && (transform.eulerAngles.y + rotaionStep > 80)) {
//										barrelRoll = false;
//										speed = speed - 30;
//								}
//								gameObject.transform.Rotate (new Vector3 (rotaionStep, 0, 0));
//						} else {
//								if ((transform.eulerAngles.y + rotaionStep < 90) && (transform.eulerAngles.y + rotaionStep > 80)) {
//										barrelRoll = false;
//										speed = speed - 30;
//								}
//								gameObject.transform.Rotate (new Vector3 (-rotaionStep, 0, 0));
//						}
//				} else {
//						if (moveHorizontal == 0.0) {
//				
//								if (transform.eulerAngles.y > 90 + rotaionStep) {
//										gameObject.transform.Rotate (new Vector3 (rotaionStep, 0, 0));
//								} else if (transform.eulerAngles.y < 90 - rotaionStep) {
//										gameObject.transform.Rotate (new Vector3 (-rotaionStep, 0, 0));
//								}
//				
//								//						transform.eulerAngles = new Vector3 (0, 90, 270);
//						} else if (moveHorizontal > 0) {
//				
//								if (transform.eulerAngles.y > 90 - maxRotationAngle) {
//										gameObject.transform.Rotate (new Vector3 (rotaionStep, 0, 0));
//								}
//				
//				
//								//						transform.eulerAngles = new Vector3 (0, 90 - maxRotationAngle, 270);
//						} else {
//				
//								if (transform.eulerAngles.y < 90 + maxRotationAngle) {
//										gameObject.transform.Rotate (new Vector3 (-rotaionStep, 0, 0));
//								}
//				
//								//						transform.eulerAngles = new Vector3 (0, 90 + maxRotationAngle, 270);
//						}
//				}

			

				gameObject.rigidbody2D.AddForce (new Vector2 (moveHorizontal * speed, moveVertical * speed));
//		gameObject.rigidbody2D.AddForce (new Vector2 (0, moveVertical * speed));

		}

		void Update ()
		{

				if (Input.GetButtonDown ("Fire1")) {
						Debug.Log ("fire");
						GameObject currentBullet = (GameObject)activateBullet.ActivateObject ();
						if (currentBullet == null)
								return;
		
						Debug.Log ("fire");
						currentBullet.transform.position = new Vector2 (canon1.transform.position.x, canon1.transform.position.y);
						currentBullet.rigidbody2D.AddForce (new Vector2 (1000, 0));
				}
//				if (Input.GetKeyDown ("space")) {
//
//						if (!barrelRoll) {
//								speed = speed + 30;
//						}
//						barrelRoll = true;
//						
//						if (transform.eulerAngles.y >= 90) {
//								rollRight = false;
//						} else {
//								rollRight = true;
//						}
//
//
//				} 
		}

		void OnGUI ()
		{

				if (currentStyle == null) {

						currentStyle = new GUIStyle (GUI.skin.box);
						currentStyle.normal.background = MakeTex (2, 2, new Color (0f, 1f, 0f, 0.5f));
				}
				GUI.Box (new Rect (10, 10, healthBarLength, 20), currHealth + "%", currentStyle);
	
		}

		void adjustCurrentHealth (int addedValue)
		{
				currHealth += addedValue;
				if (currHealth < 0)
						currHealth = 0;
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
				while (true) {
						var RandomNumber = Random.Range (-4, 4);
						var RandomSleep = Random.Range (1, 4);
						GameObject currentCoin;
			
						currentCoin = (GameObject)activateCoin.ActivateObject ();
			
						if (currentCoin == null)
								yield return new WaitForSeconds (RandomSleep);
			
						Debug.Log ("coin");
						currentCoin.transform.position = new Vector2 (9, RandomNumber);
						currentCoin.rigidbody2D.AddForce (new Vector2 (-350, 0));
			
						yield return new WaitForSeconds (RandomSleep);
				}				
		}

		IEnumerator EnemyControl ()
		{
		
				while (true) {
						InitialSpeed += 5;
			
						var RandomNumber = Random.Range (-4, 4);

						GameObject currentEnemy;
			
						currentEnemy = (GameObject)activateEnemy.ActivateObject ();
						
						currentEnemy.transform.position = new Vector2 (9, RandomNumber);
						currentEnemy.rigidbody2D.AddForce (new Vector2 (-InitialSpeed, 0));
			

						yield return new WaitForSeconds (1.0f);
				}				
		}

		void SetScoreText ()
		{
				ScoreText.text = "Score: " + score.ToString ();
		}

}
