using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlay : MonoBehaviour {
	

	void Start(){
		Debug.Log ("key 1 animation player");
	}



	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			Animation ani = GetComponent<Animation> ();
			Debug.Log (ani + ":" + ani.clip.name + ":" + ani.isPlaying);
			if (!ani.isPlaying) {
				ani.Play (ani.clip.name);
			}
			Debug.Log (ani + ":" + ani.clip.name + ":" + ani.isPlaying);
			//ani.Sample ();
			//ani.Play("smoke");
			//yield return new WaitForSeconds (ani.clip.length);
		}		
	}
}
