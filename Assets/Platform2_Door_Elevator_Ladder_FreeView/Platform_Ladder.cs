using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform2_Door_Elevator_Ladder_FreeView
{
	public class Platform_Ladder : MonoBehaviour
	{

		Transform trans;
		private void Start()
		{
			trans = transform;

		}

		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				Player _player = _col.GetComponent<Player>();
				if (_player != null)
				{
					_player.SetLadder(true);
				}
			}
		}

		private void OnTriggerExit(Collider _col)
		{
			if (_col.CompareTag("Player"))
			{
				Player _player = _col.GetComponent<Player>();
				if (_player != null)
				{
					_player.SetLadder(false);
				}
			}
		}
	}
}