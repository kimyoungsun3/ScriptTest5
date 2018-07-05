using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlower : MonoBehaviour {
	int progressID;
	Renderer renderer;
	Material material;
	public float showTime = 3f;
	float t, d = 1;
	float speed;
	bool bLoop = false;

	void Start () {
		progressID = Shader.PropertyToID("_Progress");
		renderer = GetComponent<Renderer> ();
		material = new Material(renderer.sharedMaterial);	
		renderer.sharedMaterial = material;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			bLoop = !bLoop;
		}

		speed = 1f / showTime;
		if (bLoop) {
			t += d * speed * Time.deltaTime;
			if (t > 1f) {
				d = -1f;
				t = 1f;
			} else if (t < 0f) {
				d = 1f;
				t = 0;
			}
			material.SetFloat (progressID, t);		
		}
	}
}
