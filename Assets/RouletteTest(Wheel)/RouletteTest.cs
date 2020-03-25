using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RouletteTest
{
	public class RouletteTest : MonoBehaviour
	{
		public int pieceCount = 8;
		public Transform body;
		bool isRoulette;
		[SerializeField] float speed = 360;
		[SerializeField] float duration = 4f;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && !isRoulette)
			{	
				StartCoroutine(Roulette());
			}
		}

		IEnumerator Roulette()
		{
			body.rotation = Quaternion.identity;

			isRoulette = true;

			//1.회전하기....
			float _percent = 0;
			float _speed = speed;
			while(_percent < 1)
			{
				_percent += Time.deltaTime / duration;
				//_speed = Mathf.Lerp(speed, 0, _percent);
				//Debug.Log(_percent + " " + _speed);
				body.Rotate(Vector3.forward * _speed * Time.deltaTime);
				yield return null;
			}

			//2. 인지하기....
			//yield return new WaitForSeconds(2f);

			//3. 메세지 출력하기...
			isRoulette = false;
		}
	}
}
