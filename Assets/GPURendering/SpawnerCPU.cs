using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPURendering{
	public class SpawnerCPU : MonoBehaviour {
		public int instances = 1000;
		public Vector3 maxPos = new Vector3 (200, 200, 200);
		public GameObject prefab;

		// Use this for initialization
		void Start () {
			for (int i = 0; i < instances; i++) {
				Vector3 pos = new Vector3 (Random.Range (-maxPos.x, maxPos.x),
					Random.Range (-maxPos.y, maxPos.y),
					Random.Range (-maxPos.z, maxPos.z));
				Instantiate (prefab, pos, Quaternion.identity);
			}
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}