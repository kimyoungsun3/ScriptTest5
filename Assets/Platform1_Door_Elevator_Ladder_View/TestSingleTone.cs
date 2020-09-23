using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestSingleTone : MonoBehaviour {
	//change...
	public static TestSingleTone ins;
	private void Awake()
	{
		ins = this;

		Debug.Log("this:" + this);
	}

	public int xxx;

	void Start () {
		Debug.Log(gameObject.name + " ins:" + ins);
	}
	
}
