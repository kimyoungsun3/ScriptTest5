using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
		int start = 0;
		StartCoroutine(Fun(delegate() {
			Debug.Log(start++);
			return start;
		}));        
	}

	IEnumerator Fun(System.Func<int> _on)
    {
		int _count = 0;
		if (_on != null) {
			_count = _on ();
		}

		if (_count < 10) {
			yield return null;
			StartCoroutine (Fun (_on));
		} else {
			gameObject.SetActive (false);
		}
    }

	// Update is called once per frame
	void Update () {
        Debug.Log("=================");
	}
}
