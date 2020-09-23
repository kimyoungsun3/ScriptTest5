using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platform_Door_Elevator
{
	public class Platform_CameraMode2 : MonoBehaviour
	{
		public eCamearView cameraViewEnter;
		public eCamearView cameraViewExit;

		private void Start()
		{
			//GetComponent<MeshRenderer>().enabled = false;
		}


		private void OnTriggerEnter(Collider _col)
		{
			if(cameraViewEnter != eCamearView.None && _col.CompareTag("Player"))
			{
				Player _player = _col.GetComponent<Player>();
				if(_player != null)
				{
					_player.SetToCameraView(cameraViewEnter);
				}
			}
		}

		private void OnTriggerExit(Collider _col)
		{
			if (cameraViewExit != eCamearView.None && _col.CompareTag("Player"))
			{
				Player _player = _col.GetComponent<Player>();
				if (_player != null)
				{
					_player.SetToCameraView(cameraViewExit);
				}
			}
		}


	}
}