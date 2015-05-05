using UnityEngine;
using System.Collections;

public class bulletCollisionScript : MonoBehaviour
{

		private PlaneControl PlaneControlScript;
		public GameObject hit;
		public static int HitCount;
	public AudioClip enemyHitSound;
	public AudioClip dragonDieSound;
		void Start ()
		{
				PlaneControlScript = GameObject.Find ("PlayerPlane").GetComponent<PlaneControl> ();
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "target") 
				{
						other.gameObject.SetActive (false);
						PlaneControlScript.score += 10;
						checkScore();
						Instantiate (hit, transform.position, transform.rotation);
			if (GlobalData.SFX == true) {
				AudioSource.PlayClipAtPoint (enemyHitSound, transform.position);
				//				Debug.Log("ana 3amlt soot");
			}	
						this.gameObject.SetActive (false);
				}
		
				else if (other.gameObject.tag == "Dragon") 
				{
			if (GlobalData.SFX == true) {
				AudioSource.PlayClipAtPoint (enemyHitSound, transform.position);
				//				Debug.Log("ana 3amlt soot");
			}	
						if (HitCount == 2) 
						{
								HitCount = 0;
								other.gameObject.SetActive (false);
								PlaneControlScript.score += 10;
								checkScore();
								PlaneControlScript.IsDragon = false;
				if (GlobalData.SFX == true) 
					AudioSource.PlayClipAtPoint (dragonDieSound, transform.position);
						} 
						else 
						{
								HitCount++;
								Instantiate (hit, transform.position, transform.rotation);
						}
						this.gameObject.SetActive (false);
				}
		
				else if (other.gameObject.tag == "rightWall") 
				{
						this.gameObject.SetActive (false);
				}
				else if (other.gameObject.tag == "generalWall") 
				{
						this.gameObject.SetActive (false);
				}
		
		}

	void checkScore()
	{
		if (PlaneControlScript.score >= 1000 && GlobalData.ExpertScore == 0)
		{
			GlobalData.ExpertScore = 1;
			Debug.Log("enta 3adeet 1000 fel score");
		}
		else if (PlaneControlScript.score >= 500 && GlobalData.IntermediateScore == 0)
		{
			GlobalData.IntermediateScore = 1;
			Debug.Log("enta 3adeet 500 fel score");
		}
		else if (PlaneControlScript.score >= 50 && GlobalData.BeginnerScore == 0)
		{
			GlobalData.BeginnerScore = 1;
			Debug.Log("enta 3adeet 50 fel score");
		}
	}
}
