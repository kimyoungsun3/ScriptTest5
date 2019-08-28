using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TT : MonoBehaviour {
	public float moveTime = 0.3f;
	public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);

	private bool isMoving;
	private Transform moveParent;

	// Use this for initialization
	void Start () {
		moveParent = new GameObject("MoveParent").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow))
			Move(Vector3.forward);
		else if (Input.GetKeyDown(KeyCode.DownArrow))
			Move(Vector3.back);
		else if (Input.GetKeyDown(KeyCode.RightArrow))
			Move(Vector3.right);
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
			Move(Vector3.left);
	}

	void Move(Vector3 _dir)
	{
		if (!isMoving)
		{
			StartCoroutine(Co_Move(_dir));
		}
	}

	IEnumerator Co_Move(Vector3 _dir)
	{
		isMoving = true;
		Vector3 _basePoint = transform.position + _dir / 2f + Vector3.down / 2f;
		Vector3 _axis = Vector3.Cross(Vector3.up, _dir).normalized;

		moveParent.position = _basePoint;
		moveParent.rotation = Quaternion.identity;
		transform.SetParent(moveParent);

		Quaternion _startQ = moveParent.rotation;
		Vector3 _endEuler = moveParent.rotation.eulerAngles + _axis * 90f;
		Quaternion _endQ = Quaternion.Euler(_endEuler);

		float _time = 0;
		while (_time < 1f)
		{
			_time += Time.deltaTime / moveTime;
			moveParent.rotation = Quaternion.Lerp(_startQ, _endQ, curve.Evaluate(_time));
			yield return null;
		}

		transform.SetParent(null);
		isMoving = false;
	}
}
