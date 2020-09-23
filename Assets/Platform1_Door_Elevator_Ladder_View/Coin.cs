using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	public class Coin : MonoBehaviour
	{
		public float speedTurn = 30f;
		void Update()
		{
			transform.Rotate(Vector3.up * speedTurn * Time.deltaTime);
		}

		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				Debug.Log("Hit");
				Ui_Score.ins.SetScore(+1);
				Destroy(gameObject);
			}
		}
	}
}
