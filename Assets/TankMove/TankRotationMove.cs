using UnityEngine;
using System.Collections;

public class TankRotationMove : MonoBehaviour {
	public float rotateSpeed = 180f;
	public float moveSpeed = 2f;

	public GameObject tankUp;
	public bool bBeforeRotation = false;
	Quaternion beforeRotation;


	// Update is called once per frame
	void Update () {
		float _h = Input.GetAxis ("Horizontal");
		float _v = Input.GetAxis ("Vertical");

		if (_v != 0) {
			//Vector3.forward   -> transform.forward로 이동함.
			//transform.forward -> t + t -> 이상한 방향으로 이동함. 
			transform.Translate (Vector3.forward * _v * moveSpeed * Time.deltaTime);
		}

		if (_h != 0f) {
			transform.Rotate (0f, _h * rotateSpeed * Time.deltaTime, 0f);
		}

		//if (Input.GetKeyDown (KeyCode.P)) {
		if(Input.GetMouseButtonDown(0)){
			//Debug.Log ("down");
			beforeRotation = tankUp.transform.rotation;
			bBeforeRotation = true;
		//} else if (Input.GetKeyUp (KeyCode.P)) {
		}else if(Input.GetMouseButtonUp(0)){
			//Debug.Log ("up");
			bBeforeRotation = false;
		}

		if (bBeforeRotation) {
			//Debug.Log ("rotate");
			tankUp.transform.rotation = beforeRotation;
		}
	}
}
