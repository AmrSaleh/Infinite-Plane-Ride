using UnityEngine;
using System.Collections;

public class ScrollingScript : MonoBehaviour
{
		float old;
		public float Speed;
		private Vector2 savedOffset;
		public Texture texture0;
		public Texture texture1;
		public Texture texture2;
		public Texture texture3;
	
		void Start ()
		{
				savedOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset ("_MainTex");
		}
	
		void Update ()
		{
				old += Time.deltaTime * Speed;
				float x = Mathf.Repeat (old, 1);
				Vector2 Offset = new Vector2 (x, 0f);
				GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", Offset);
		}
	
		void OnDisable ()
		{
				GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
		}

		public void changeBackground (int bgNum)
		{
				bgNum = bgNum % 4;

				if (bgNum == 0) {
						GetComponent<Renderer>().material.mainTexture = texture0;
				} else if (bgNum == 1) {
						GetComponent<Renderer>().material.mainTexture = texture1;
				} else if (bgNum == 2) {
						GetComponent<Renderer>().material.mainTexture = texture2;
				} else if (bgNum == 3) {
						GetComponent<Renderer>().material.mainTexture = texture3;
				}

		}
	
}