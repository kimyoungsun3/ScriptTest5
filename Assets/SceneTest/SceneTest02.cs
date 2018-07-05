using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTest02 : MonoBehaviour {
	public static SceneTest02 ins;

	void Awake(){
		ins = this;
	}

	void Start () {
		Debug.Log (this);	
	}
}
