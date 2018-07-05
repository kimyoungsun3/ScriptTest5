using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {
	public Transform target;
	public Transform unitPrefab;
	Transform trans;

	void Start(){
		trans = transform;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C)) {
			Transform _tran = Instantiate (unitPrefab, Random.insideUnitSphere * 10f, Quaternion.identity) as Transform;
			_tran.GetComponent<Unit> ().SetInit (target);
			_tran.SetParent (trans);
		}
	}
}
