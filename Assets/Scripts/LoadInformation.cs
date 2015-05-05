using UnityEngine;
using System.Collections;

public class LoadInformation 
{
	public static void LoadAllInformation ()
	{
		PlaneControl.diamonds = PlayerPrefs.GetInt ("Diamonds");
		GlobalData.BeginnerScore = PlayerPrefs.GetInt ("BeginnerScore");
	}
}
