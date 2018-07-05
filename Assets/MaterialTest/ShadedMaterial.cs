using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadedMaterial : MonoBehaviour {
	public Material mat;
	public List<Renderer> lists = new List<Renderer>();
	void Start(){
		Debug.Log ("1, 2, 3, 4, 5");
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ChangeTest01 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ChangeTest02 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ChangeTest03 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ChangeTest04 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ChangeTest05 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			ChangeTest06 ();
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			ChangeTest07 ();
		}
	}

	void ChangeTest01(){
		Debug.Log (".material <- mat setting");
		for (int i = 0, iMax = lists.Count; i < iMax; i++) {
			lists [i].material = mat;
		}
	}

	void ChangeTest02(){
		Debug.Log (".sharedMaterial <- mat setting(1개만 변경)");
		if (lists.Count > 0){
			lists [0].sharedMaterial = mat;
			lists [1].sharedMaterial = mat;
			mat.color = Color.red;		//인스펙터의 색이 바뀜...
		}
	}

	void ChangeTest03(){
		Debug.Log (".sharedMaterial <- mat setting(전부 변경)");
		for (int i = 0, iMax = lists.Count; i < iMax; i++) {
			lists [i].sharedMaterial = mat;
		}
	}
	void ChangeTest04(){
		Debug.Log (".sharedMaterial <- 색변경 <- .shardMaterial(1개만 변경)");
		if (lists.Count > 0) {
			Material _mat = lists [0].sharedMaterial;
			_mat.color = Color.blue;
			//lists [0].sharedMaterial = _mat;
		}
	}

	void ChangeTest05(){
		Debug.Log (".sharedMaterial <- 색변경 <- .material");
		if (lists.Count > 0) {
			Material _mat = lists [0].material;
			_mat.color = Color.blue;
			lists [0].sharedMaterial = _mat;
		}
	}

	void ChangeTest06(){
		Debug.Log (".sharedMaterial <- 색변경 <- .shardMaterial <- .material (접근만)");
		if (lists.Count > 0) {
			Material _mat;
			_mat = lists [0].material;
			_mat = lists [0].sharedMaterial;
			_mat.color = Color.blue;
			lists [0].sharedMaterial = _mat;
		}
	}

	void ChangeTest07(){
		Debug.Log (".색변경 <- .material (접근만) <- 색변경 <- .material (접근만)");
		if (lists.Count > 0) {
			Material _mat 	= lists [0].material;
			Material _mat2 	= lists [0].material;
			Material _mat3 	= lists [1].material;

			string _str = (_mat == _mat2) ?"Same" : "different";
			Debug.Log (1 + _str);

			_mat.color = Color.red;
			//_mat2.color = Color.green;

			_str = (_mat == _mat2) ?"Same" : "different";
			Debug.Log (2 + _str);

			_str = (_mat3 == _mat2) ?"Same" : "different";
			Debug.Log (3 + _str);

		}
	}

}
