﻿using UnityEngine;
using System.Collections;

//public class musicControl : MonoBehaviour {

public  class musicControl  : MonoBehaviour
{

	  void Awake () {

		if (GlobalData.Music == true) 
		{
			if (!(audio.isPlaying))
				audio.Play ();
		} 
		else 
		{
//			audio.volume = 0.0F;
			audio.Pause();
		}
	
	}		
}
