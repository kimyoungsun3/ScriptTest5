using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class ObjectLayerAlive : ObjectLayer {
	void Start(){
		render = GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (render != null) {
			render.sortingOrder = -(int)(transform.position.y * 100f);
		}
	}
}
