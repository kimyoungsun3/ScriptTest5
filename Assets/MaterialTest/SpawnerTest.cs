using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTest : MonoBehaviour {
	public GameObject prefabGo;

	void Start () {
		for (int i = 0; i < 100; i++) {
			Instantiate (prefabGo, transform.position + Random.onUnitSphere, Quaternion.identity);
		}
	}


}
