using UnityEngine;
using System.Collections;

public class SaveInformation
{
	public static void SaveAllInformation ()
	{
		PlayerPrefs.SetInt ("Diamonds", PlaneControl.diamonds);
		PlayerPrefs.SetInt ("BeginnerScore", GlobalData.BeginnerScore);

		Debug.Log ("no of diamonds abl mamoot" + PlaneControl.diamonds);
	}
}
