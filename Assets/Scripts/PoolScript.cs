using UnityEngine;
using System.Collections;

public class PoolScript : MonoBehaviour {

	public GameObject[] objects = null;
	
	public GameObject ObjectToInstantiate;
	public int PoolSize;
	private bool initialized = false;

	
	void Start () 
	{
//		initialize ();
//		Debug.Log (" pool start called");
	}
	
	public object ActivateObject ()
	{
		if (initialized == false) 
			initialize ();

//			Debug.Log (" Activate pool called");
			for (int i = 0; i < PoolSize; i++) 
			{
				if (objects[i].activeInHierarchy == false)
				{
					objects[i].SetActive(true);
					return objects[i];
				}
			}
		return null;	
		
	}



	void initialize()
	{
		objects = new GameObject[PoolSize];

		for (int i = 0; i < PoolSize; i++) 
		{
			objects[i] = Instantiate (ObjectToInstantiate) as GameObject;
			objects[i].transform.parent = gameObject.transform;
			objects[i].SetActive(false);

			initialized = true;
		}
	}
}
