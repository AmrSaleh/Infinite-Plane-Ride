using UnityEngine;
using System.Collections;

//public class musicControl : MonoBehaviour {

public  class musicControl  : MonoBehaviour
{

	  void Awake () {

		if (GlobalData.Music == true) 
		{
			if (!(GetComponent<AudioSource>().isPlaying))
				GetComponent<AudioSource>().Play ();
		} 
		else 
		{
//			audio.volume = 0.0F;
			GetComponent<AudioSource>().Pause();
		}
	
	}		
}
