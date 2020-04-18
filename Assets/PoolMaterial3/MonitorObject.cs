using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterial3
{
	public class MonitorObject : MonoBehaviour
	{
		MeshRenderer renderer;
		Color originalColor;
		private void Start()
		{
			renderer = GetComponent<MeshRenderer>();
			originalColor = renderer.material.color;
		}

		private void OnMouseEnter()
		{
			renderer.material.color = Color.green;
		}

		private void OnMouseExit()
		{
			renderer.material.color = originalColor;
		}
	}
}