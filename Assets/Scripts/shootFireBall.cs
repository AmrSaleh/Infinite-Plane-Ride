using UnityEngine;
using System.Collections;

public class shootFireBall : MonoBehaviour
{

	public AudioClip fireballSound;
		public GameObject fireBall;
		public GameObject hitEffect;
		public GameObject player;
		PlaneControl planeScriptObject;
		private float startTime;
		private float endTime;
		public float duration = 0.005f;
		private bool isRunning = false;
		private GameObject rain, hit, black;
		Transform target;

		void Start ()
		{
				planeScriptObject = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
				endTime = Time.time + duration;
				target = GameObject.FindWithTag ("Player").transform;
//				StartCoroutine (Shooting ());
		}
	
		public void startEffect ()
		{
				if (isRunning) {
						return;
				}
				isRunning = true;
		
				//			AudioSource.PlayClipAtPoint (smallExplosionSound, transform.position);
		
				//			GameObject expl = Instantiate (smallExplosion, other.transform.position, other.transform.rotation) as GameObject;
		if (GlobalData.SFX == true)
			AudioSource.PlayClipAtPoint (fireballSound, transform.position);
				hit = Instantiate (fireBall, transform.position, transform.rotation) as GameObject;
				hit.GetComponent<Rigidbody2D>().AddForce (-transform.right.normalized * 500);
				endTime = Time.time + duration;
		}

		public void endPowerup ()
		{
				isRunning = false;
				Destroy (hit);
		}

		int x = 0;
		void Update ()
		{
				x++;
				if (x > 100) {
						endPowerup ();
						startEffect ();
						x = 0;
				}
		}

		bool StartEffect_Flag = true;
		Vector3 tempVector3 = Vector3.zero;

		void FixedUpdate ()
		{
				if (PlaneControl.gameEnded)
						return;

				if (transform.position.x > target.position.x + 1) {
						var newRotation = Quaternion.LookRotation (transform.position - target.position, Vector3.up);
						newRotation.x = 0.0f;
						newRotation.y = 0.0f;
						transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 8);
						Debug.DrawLine (transform.position, target.position);

				} else {
						tempVector3.Set (0, 0, 0.5f);
						transform.Rotate (tempVector3);		
				}

				while (StartEffect_Flag) {
						startEffect ();
						StartEffect_Flag = false;
				} 
		}
}
