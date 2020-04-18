using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterial3
{
	public class MonitorObject2 : MonoBehaviour
	{
		MaterialData materialData;
		Renderer renderer;
		private void Start()
		{
			renderer = GetComponent<MeshRenderer>();
			PoolMaterial.ins.RegisterMaterial(renderer);
		}

		private void OnMouseEnter()
		{
			materialData = PoolMaterial.ins.GetMaterial(renderer);
			materialData.SetColor(renderer, Color.green);
		}

		private void OnMouseExit()
		{
			materialData.Release();
		}
	}
}