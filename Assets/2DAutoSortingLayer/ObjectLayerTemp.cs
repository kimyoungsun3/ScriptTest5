using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ObjectLayerTemp : ObjectLayer {	
	void Update(){
		//Debug.Log (Application.isPlaying + ":" + render);
		if (Application.isPlaying) 
		{	
			Destroy (this);
		}
		else
		{
			if (render == null) 
			{
				render = GetComponent<SpriteRenderer> ();
			}
			render.sortingOrder = -(int)(transform.position.y * 100f);
		}
	}
}
