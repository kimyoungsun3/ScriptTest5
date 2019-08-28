using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCube : MonoBehaviour {

	public float moveTime = 1f;
	public AnimationCurve cure = AnimationCurve.Linear(0, 0, 1f, 1f);
	private bool isMoving;
	private Transform moveParent;
	void Start () {
		moveParent = (new GameObject("BasePoint")).transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			Move(Vector3.forward); 
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			Move(Vector3.back);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Move(Vector3.left);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Move(Vector3.right);
		}
	}

	private void Move(Vector3 _direction)
	{
		if(!isMoving)
			StartCoroutine(CoMove(_direction));		
	}

	IEnumerator CoMove(Vector3 _direction)
	{
		isMoving = true;
		Vector3 _basePoint	= transform.position + _direction / 2 + Vector3.down / 2;
		Vector3 _axis		= Vector3.Cross(_direction, Vector3.up).normalized;
		moveParent.position = _basePoint;
		moveParent.rotation = Quaternion.identity;
		transform.SetParent(moveParent);
		Debug.Log("_axis:" + _axis);

		Quaternion _startQ	= moveParent.rotation;
		Vector3 _endEuler	= moveParent.rotation.eulerAngles - _axis * 90f;
		Quaternion _endQ = Quaternion.Euler(_endEuler);
		float _time = 0;
		while(_time < 1f)
		{
			_time += Time.deltaTime / moveTime;
			moveParent.rotation = Quaternion.Lerp(_startQ, _endQ, _time);
			yield return null;
		}

		transform.SetParent(null);
		isMoving = false;
	}
}
