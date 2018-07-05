using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInOut : MonoBehaviour {

	public Image image;	
	Coroutine cor;
	public float during = 2f;
	float speed;
	float[] t = new float[10];

	void Start(){
		Debug.Log ("1,2,3 fade In/ out ");
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			if (cor != null)
				StopCoroutine (cor);
			cor = StartCoroutine( CoFade (1) );
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			if (cor != null)
				StopCoroutine (cor);
			cor = StartCoroutine( CoFade (0) );
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			if (cor != null)
				StopCoroutine (cor);
			cor = StartCoroutine( CoChangeMap () );
		}
	}

	IEnumerator CoChangeMap(){
		yield return CoFade (1);
		yield return new WaitForSeconds (2f);
		yield return CoFade (0);
	}


	IEnumerator CoFade(float _alpha){
		speed = 1f / during;
		Color _color = image.color;

		//t [0] = Time.realtimeSinceStartup;
		while (_color.a != _alpha) {
			_color.a = Mathf.MoveTowards(_color.a, _alpha, speed * Time.deltaTime);
			image.color = _color;
			yield return null;
		}
		//t [1] = Time.realtimeSinceStartup;
		//Debug.Log (t [1] - t [0]);
	}
}
