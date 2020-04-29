using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameShoot
{
	public class CameraController : MonoBehaviour
	{
		public static CameraController ins;
		[SerializeField] float duration = 0.2f;
		//[SerializeField] float shakeSize = 0.1f;
		[SerializeField] float shootAngle = 10f;
		Vector3 originalPos;
		Quaternion origianlRot;

		private void Awake()
		{
			ins = this;
		}

		private void Start()
		{
			originalPos = transform.position;
			origianlRot = transform.rotation;
		}

		//public void Shake()
		//{
		//	StopAllCoroutines();
		//	StartCoroutine("Co_Shake", duration);
		//}


		//IEnumerator Co_Shake(float _until)
		//{
		//	float _percent = 0;
		//	Vector3 _offset = Vector3.zero;
		//	while (_percent < _until)
		//	{
		//		_percent += Time.deltaTime;
		//		_offset.Set(Random.Range(-shakeSize, shakeSize), Random.Range(-shakeSize, shakeSize), 0);
		//		transform.position = originalPos + _offset;
		//		yield return null;
		//	}
		//	transform.position = originalPos;
		//}

		public void ShakeUp()
		{
			StopAllCoroutines();
			StartCoroutine("Co_ShakeUp", duration);
		}

		IEnumerator Co_ShakeUp(float _until)
		{
			float _percent = 0;
			Vector3 _offset = Vector3.zero;
			Quaternion _newRot = transform.rotation * Quaternion.Euler(shootAngle, 0, 0);
			transform.rotation = _newRot;
			while (_percent < _until)
			{
				_percent += Time.deltaTime;
				transform.rotation = Quaternion.Slerp(_newRot, origianlRot, _percent / _until);
				yield return null;
			}
			transform.rotation = origianlRot;
		}
	}
}