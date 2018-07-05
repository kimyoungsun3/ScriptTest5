using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTest03 : MonoBehaviour {
	public static SceneTest03 ins;

	void Awake(){
		ins = this;
	}

	void Start () {
		Debug.Log (this);	
	}
}
