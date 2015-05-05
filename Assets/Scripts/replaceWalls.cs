using UnityEngine;
using System.Collections;

public class replaceWalls : MonoBehaviour
{

		public GameObject UpperWall;
		public GameObject LowerWall;
		public GameObject RightWall;
		public GameObject LeftWall;
		public GameObject MoveUpBtn;
		public GameObject ShootBtn;
		Vector3 tempVector3 = Vector3.zero;

		void Start ()
		{
	
				Vector3 cameraBounds = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height + UpperWall.renderer.bounds.extents.y, 0));
				tempVector3.Set (UpperWall.transform.position.x, cameraBounds.y + UpperWall.renderer.bounds.extents.y, UpperWall.transform.position.z);
				UpperWall.transform.position = tempVector3;
				tempVector3.Set (LowerWall.transform.position.x, -(cameraBounds.y + LowerWall.renderer.bounds.extents.y), LowerWall.transform.position.z);
				LowerWall.transform.position = tempVector3;
				tempVector3.Set ((cameraBounds.x + RightWall.renderer.bounds.extents.x + 3), RightWall.transform.position.y, RightWall.transform.position.z);
				RightWall.transform.position = tempVector3;
				tempVector3.Set (-(cameraBounds.x + LeftWall.renderer.bounds.extents.x + 3), LeftWall.transform.position.y, LeftWall.transform.position.z);
				LeftWall.transform.position = tempVector3;

				tempVector3.Set (cameraBounds.x, 2 * cameraBounds.y, MoveUpBtn.transform.localScale.z);
				MoveUpBtn.transform.localScale = tempVector3;
				tempVector3.Set (cameraBounds.x, 2 * cameraBounds.y, ShootBtn.transform.localScale.z);
				ShootBtn.transform.localScale = tempVector3;


				tempVector3.Set (-(cameraBounds.x - MoveUpBtn.transform.localScale.x / 2), MoveUpBtn.transform.position.y, MoveUpBtn.transform.position.z);
				MoveUpBtn.transform.position = tempVector3;
				tempVector3.Set ((cameraBounds.x - ShootBtn.transform.localScale.x / 2), ShootBtn.transform.position.y, ShootBtn.transform.position.z);
				ShootBtn.transform.position = tempVector3;

		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.LoadLevel ("Menu");		
				}
		}
	

}
