using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow3 : MonoBehaviour {
	Transform trans;

	public Transform target;
	public float distance = 10f;
	public float height = 5f;
	float wantedRotationAngle, wantedHeight;
	float currentRotationAngle, currentHeight;
	Quaternion currentRotation;
	Vector3 pos;

	void Start () {
		trans = transform;	

	}

	void LateUpdate () {
		if (target == null) {
			return;
		}
		//-------------------------------------
		Fun1();
		//Fun2();	//안됨....

	}
	void Fun2(){
		if(Input.GetAxisRaw("Vertical") != 0)			
			currentRotation = Quaternion.Euler (target.eulerAngles.x, 0, 0);
		else if(Input.GetAxisRaw("Horizontal")!= 0)	
			currentRotation = Quaternion.Euler (0, target.eulerAngles.y, 0);
		//currentRotation = Quaternion.Euler (target.eulerAngles.x, target.eulerAngles.y, 0);
		//currentHeight 			= target.position.y + height;

		//Set the position of the camera on the x-z plane to;
		//distance meters behind the target
		trans.position = target.position;
		trans.position -= currentRotation * Vector3.forward * distance;

		//pos.Set (trans.position.x, currentHeight, trans.position.z);
		//trans.position = pos;
		trans.LookAt (target);
	}

	void Fun1(){
		currentRotation = Quaternion.Euler (target.eulerAngles.x, target.eulerAngles.y, 0);
		//currentHeight 			= target.position.y + height;

		//Set the position of the camera on the x-z plane to;
		//distance meters behind the target
		trans.position = target.position;
		trans.position -= currentRotation * Vector3.forward * distance;

		//pos.Set (trans.position.x, currentHeight, trans.position.z);
		//trans.position = pos;
		trans.LookAt (target);

		Debug.Log(Vector3.Distance(trans.position, target.position));
	}
}
