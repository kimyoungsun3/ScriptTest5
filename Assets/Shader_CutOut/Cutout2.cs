using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutout2 : MonoBehaviour {
	public float duration = 0.5f;
	int cutoffID;
	float speed, percent;
	//Renderer renderer;
	Material material;
	Coroutine co;
	void Start () {
		cutoffID = Shader.PropertyToID("_Cutoff");
		material = GetComponent<Renderer> ().material;

		co = StartCoroutine (CoDie ());
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (co != null) {
				StopCoroutine (co);
			}
			co = StartCoroutine (CoDie ());
		}
	}

	IEnumerator CoDie () {
		speed 	= 1f / duration;
		percent = 0;
		material.SetFloat (cutoffID, 0);
		while (percent <= 1f) {
			percent += speed * Time.deltaTime;
			material.SetFloat (cutoffID, percent);
			yield return null;
		}
	}
}
