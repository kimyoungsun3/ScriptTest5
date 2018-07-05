using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererOnOff : MonoBehaviour {
	public GameObject pointShow;
	SpriteRenderer renderer;
	GameObject point;
	bool bShow;

	void Start () {
		renderer = GetComponent<SpriteRenderer> ();

		Debug.Log (" R > renderer on/Off");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			renderer.enabled = !renderer.enabled;
			bShow = !renderer.enabled;

			if (!renderer.enabled && point == null) {
				point = Instantiate (pointShow, transform.position, Quaternion.identity);
				point.transform.SetParent (Camera.main.transform);
			}
		}	
	}

	void OnDrawGizmos(){
		if (renderer != null && bShow) {
			Gizmos.color = Color.red;
			Gizmos.DrawRay (transform.position, transform.right);
			Gizmos.color = Color.green;
			Gizmos.DrawRay (transform.position, transform.up);
			Gizmos.color = Color.blue;
			Gizmos.DrawRay (transform.position, transform.forward);

			//Gizmos.color = Color.grey;

		}
	}
}
