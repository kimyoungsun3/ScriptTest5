using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _SinCos
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] SinCos prefab;
		public float a = 2f;
		public float b = 2f;
		public float speed = 90f;

		void Start()
		{
			for(int i = 0; i < 20; i++)
			{
				SinCos _scp = Instantiate(prefab, transform.position + Vector3.right * i, transform.rotation) as SinCos;
				_scp.SetData(this);
			}
		}
	}
}