using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBGTest2 : MonoBehaviour {
	public bool bScrolling, bParalax;

	public float backgroundSize;
	public float paralaxSpeed;

	Transform trans;
	Transform cameraTrans;
	Transform[] layers;
	float viewZone, bgSize;
	int leftIndex, rightIndex;
	float lastCameraX;

	void Start () {
		trans = transform;
		cameraTrans = Camera.main.transform;
		lastCameraX = cameraTrans.position.x;
		layers = new Transform[trans.childCount];
		for (int i = 0, iMax = layers.Length; i < iMax; i++) {
			layers [i] = trans.GetChild (i);
		}
		//Debug.Log (viewZone);
		//viewZone = 5;
		viewZone = Camera.main.aspect * Camera.main.orthographicSize + .5f;
		bgSize = layers [0].GetComponent<SpriteRenderer> ().bounds.extents.x;

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}


	void Update () {
		if (bParalax) {
			float _deltaX = cameraTrans.position.x - lastCameraX;
			trans.position += Constant.V3_RIGHT * _deltaX * paralaxSpeed;
		}
		lastCameraX = cameraTrans.position.x;

		if (bScrolling) {
			float _posX = cameraTrans.position.x;

			Debug.DrawLine (
				new Vector3((layers [leftIndex].transform.position.x - bgSize + viewZone), 0, 0),
				new Vector3((layers [rightIndex].transform.position.x + bgSize - viewZone), 0, 0),
				Color.green);
			//Debug.Log( _posX + ", " + (layers [leftIndex].transform.position.x + viewZone) + ", " + (layers [rightIndex].transform.position.x - viewZone));
			if (_posX < (layers [leftIndex].transform.position.x - bgSize + viewZone)) {
				ScrollLeft ();
			}

			if (_posX > (layers [rightIndex].transform.position.x + bgSize - viewZone)) {
				ScrollRight ();
			}
		}
	}

	void ScrollLeft(){
		Debug.Log (" << ");
		//int _lastRight = rightIndex;
		layers [rightIndex].position = Constant.V3_RIGHT * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
		//Debug.Log ("ScrollLeft:" + leftIndex + ", " + rightIndex);
	}

	void ScrollRight(){
		Debug.Log (" >> ");
		//int _lastRight = rightIndex;
		layers [leftIndex].position = Constant.V3_RIGHT * (layers [rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex >= layers.Length) {
			leftIndex = 0;
		}
		//Debug.Log ("ScrollRight:" + leftIndex + ", " + rightIndex);
	}


}
