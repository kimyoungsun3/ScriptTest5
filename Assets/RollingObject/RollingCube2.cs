using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingCube2 : MonoBehaviour {

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

		if (nextDirection != Vector3.zero && !isMoving)
		{
			Move(nextDirection);
		}

	}

	private void Move(Vector3 _direction)
	{
		Debug.Log(0 + ":" + _direction);
		if (!isMoving)
		{
			Debug.Log(1);
			beforeDirection = _direction;
			nextDirection = Vector3.zero;
			Vector3 _basePoint = transform.position + _direction / 2 + Vector3.down / 2;
			Vector3 _baseAxis = Vector3.Cross(Vector3.up, _direction).normalized;
			moveParent.position = _basePoint;
			moveParent.rotation = Quaternion.identity;
			transform.SetParent(moveParent);

			startQ	= moveParent.rotation;
			Vector3 endEuler = moveParent.rotation.eulerAngles + _baseAxis * 90f;
			endQ	= Quaternion.Euler(endEuler);
			time = 0f;
			StartCoroutine("Co_Move");
		}
		else
		{
			Debug.Log(21);
			if (beforeDirection == _direction)
			{
				Debug.Log(" >> " + Quaternion.Angle(moveParent.rotation, endQ));
				//일정각 이하일 경우 계속 돌도록 한다....
				if(Quaternion.Angle(moveParent.rotation, endQ) <= limitAngle)
				{
					nextDirection = _direction;
				}
				return;
			}


			Debug.Log(22);
			StopCoroutine("Co_Move");

			Quaternion _q = startQ;
			startQ	= endQ;
			endQ	= _q;
			time	= 1f - time;
			Debug.Log(23);
			StartCoroutine("Co_Move");
		}
		
	}

	[SerializeField] float limitAngle = 10f;
	Vector3 nextDirection;
	Vector3 beforeDirection;
	Quaternion startQ;
	Quaternion endQ;
	float time;
	IEnumerator Co_Move()
	{
		isMoving	= true;
		//Debug.Log("_axis:" + _axis);		
		Debug.Log(31);
		while (time < 1f)
		{
			time += Time.deltaTime / moveTime;
			//Debug.Log(startQ + ":" + endQ + ":" + time);
			//Debug.Log(cure);
			//Debug.Log(cure.Evaluate(time));
			moveParent.rotation = Quaternion.Lerp(startQ, endQ, cure.Evaluate( time ));
			Debug.Log(32);
			yield return null;
		}

		Debug.Log(33);
		transform.SetParent(null);
		isMoving = false;
	}
}
