using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ObjectLayerTemp : ObjectLayer
{
	//private void Awake()
	//{
	//	Debug.Log("Awake");
	//	Destroy(this);
	//}

	//private void Start()
	//{
	//	Debug.Log("Start");
	//}

	void Update(){
		Debug.Log ("Update >> " + Application.isPlaying + ":" + render);
		if (Application.isPlaying) 
		{
			Debug.Log("Destroy");
			DestroyImmediate (this);
		}
		else
		{
			if (render == null) 
			{
				Debug.Log("GetComponent");
				render = GetComponent<SpriteRenderer> ();
				if(render == null)
				{
					render = GetComponentInChildren<SpriteRenderer>();
				}
			}
			Debug.Log("render.sortingOrder");
			render.sortingOrder = -(int)(transform.position.y * 100f);
		}
	}
}
