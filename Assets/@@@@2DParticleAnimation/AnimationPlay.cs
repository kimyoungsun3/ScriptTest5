using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour {
	

	void Start(){
		Debug.Log ("key 1 animation player");
	}



	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Animation ani = GetComponent<UnityEngine.Animation> ();
			ani.Play (ani.clip.name);
			//yield return new WaitForSeconds (ani.clip.length);
		}		
	}
}
