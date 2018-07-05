using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour {
	public GameObject prefab;
	int count;
	//public int loopCreate = 2;
	public int loopEnd = 4;

	void Awake(){
		Debug.Log ("Life Cycle 파악용, 실행하면 프리펩을 소환한다.");
		Debug.Log ("Awake()" + this);
	}

	void OnEnable(){
		Debug.Log ("OnEnable()" + this);
	}

	void Start () {
		Debug.Log ("Start()" + this);		
	}

	void FixedUpdate(){
		Debug.Log ("FixedUpdate()" + this);
	}

	void Update () {
		Debug.Log ("Update()" + this);	
		count++;

		GameObject _obj = Instantiate (prefab, transform.position, transform.rotation);
		_obj.name = _obj.name + count;

		if (count > loopEnd) {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPaused = true;
			#else
			Application.Quit ();
			#endif
		}
	}

	void LateUpdate(){
		Debug.Log ("LateUpdate()" + this);
	}
}
