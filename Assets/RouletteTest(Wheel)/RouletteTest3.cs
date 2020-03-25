using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RouletteTest
{
	public class RouletteTest3 : MonoBehaviour
	{
		public int pieceCount = 4;
		public Transform body;
		bool isRoulette;
		//float speed = 360;
		//float duration = 4f;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && !isRoulette)
			{
				StartCoroutine(Co_Roulette());
			}
		}

		IEnumerator Co_Roulette()
		{
			body.rotation = Quaternion.identity;
			isRoulette = true;

			//1.회전하기....
			int _selectNum = (int)Random.Range(0, pieceCount);
			float _pieceAngle = 360 / pieceCount;
			float _merageAngle = _pieceAngle / 4;
			float _selectAngle = _selectNum * _pieceAngle + _pieceAngle / 2 + Random.Range(-_merageAngle, +_merageAngle);

			float _p1 = 360 * ((int)Random.Range(3, 9));
			float _p0 = _p1 - 360;
			float _p2 = _p1 + _selectAngle;
			Debug.Log(_selectNum + ":" + _pieceAngle + ":" + _merageAngle + ":" + _selectAngle + ":" + _p0 + ":" + _p1 + ":" + _p2);

			float _percent = 0;
			float _angleSpeed1 = 360 * 2;
			float _angle = 0;
			float _speed;
			while (_angle + 3 < _p2)
			{
				//720 ~
				//720 ~ 360
				//360 ~   0
				if (_angle < _p0)
				{
					_speed = _angleSpeed1;
					_angle += _speed * Time.deltaTime;
				}
				else if (_angle < _p2)
				{
					_speed = _p2 - _angle;
					_angle += _speed * Time.deltaTime;
				}

				body.rotation = Quaternion.Euler(Vector3.forward * _angle);
				//_speed = Mathf.Lerp(speed, 0, _percent);
				//Debug.Log(_percent + " " + _speed);
				yield return null;
			}

			//2. 인지하기....
			//yield return new WaitForSeconds(2f);
			/**/
			yield return null;

			//3. 메세지 출력하기...
			isRoulette = false;
		}
	}
}
 