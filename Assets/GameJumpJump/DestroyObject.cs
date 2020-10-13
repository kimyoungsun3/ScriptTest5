using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTTTT2
{
	public class DestroyObject : MonoBehaviour
	{
		private void OnTriggerEnter(Collider _col)
		{
			if (_col.CompareTag("Obstacle"))
			{
				Destroy(_col.gameObject);
			}
		}
	}
}