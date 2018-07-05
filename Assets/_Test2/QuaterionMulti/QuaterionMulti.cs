using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddd3 : MonoBehaviour {
	public enum KEY_DIRECTION
	{
		X,
		Y,
		Z
	};
	public Transform target;
	public Transform target2;
	public Transform target3, target4, target5, target6;
	public Vector3 vq1 = new Vector3(0, 30, 0); 
	public Vector3 vq2 = new Vector3(0,  0, 0);
	public KEY_DIRECTION key = KEY_DIRECTION.Y; 
	public float speed = 30f;
	public Quaternion q1, q2;
	public Vector3 o1, o2;
	public TextMesh[] tm;

	SubData sd3, sd6;
	void Start(){
		sd3 = target3.GetComponent<SubData> ();
		sd6 = target3.GetComponent<SubData> ();
	}

	int d = 0;
	float t = 0;
	void SetVector(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			d = 1;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			d = -1;
		} else if (Input.GetKeyDown (KeyCode.Space)) {
			d = 0;
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			key = KEY_DIRECTION.X;
		} else if (Input.GetKeyDown (KeyCode.X)) {
			key = KEY_DIRECTION.Y;
		} else if (Input.GetKeyDown (KeyCode.C)) {
			key = KEY_DIRECTION.Z;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			if ((Time.time - t) <= 0.4f) {
				vq2 = new Vector3(0, 0, 0);
				d = 0;
			}
			t = Time.time;
		}

		switch (key) {
		case KEY_DIRECTION.X:	
			vq2.x += d * speed * Time.deltaTime;	break;
		case KEY_DIRECTION.Y:
			vq2.y += d * speed * Time.deltaTime;	break;
		case KEY_DIRECTION.Z:	
			vq2.z += d * speed * Time.deltaTime;	break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		SetVector ();

		tm [0].text = "" + vq1;
		tm [1].text = "" + vq2;		

		//Debug.Log ("1. Euler + Euler");
		if (target != null) {
			target.rotation = Quaternion.Euler (vq1 + vq2);
		}

		q1 = Quaternion.Euler (vq1);
		q2 = Quaternion.Euler (vq2);
		//Debug.Log ("2. Q1 * Q2");
		if (target2 != null) {
			target2.rotation = q1 * q2;
		}
		//Debug.Log ("3. Q2 * Q1");
		if (target3 != null) {
			target3.rotation = q2 * q1;

			//Debug.Log (vq2 +":"+ q2);
			//if (sd3 != null) {
			//	sd3.SetRotationInfo (q2);
			//}
		}

		//Debug.Log ("4. Euler - Euler");
		if (target4 != null) {
			target4.rotation = Quaternion.Euler (vq1 - vq2);
		}
		//Debug.Log ("5. Q1 - Q2");
		if (target5 != null) {
			target5.rotation = q1 * Quaternion.Inverse( q2);
		}
		//Debug.Log ("6. Q2 - Q1");
		if (target6 != null) {
			target6.rotation = q2 * Quaternion.Inverse( q1);

			//if (sd6 != null) {
			//	sd6.SetRotationInfo (q2);
			//}
		}

		

		o1 = q1.eulerAngles;
		o2 = q2.eulerAngles;
		//oo = transform.eulerAngles;
	}
}
