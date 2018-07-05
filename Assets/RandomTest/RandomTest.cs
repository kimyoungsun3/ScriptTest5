using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour {
	int seed = 0, seed2 = 1;
	System.Random r0, r1, r2;

	void Start () {
		r0 = new System.Random (seed);
		r1 = new System.Random (seed);
		r2 = new System.Random (seed2);



		for (int i = 0; i < 10; i++) {
			Debug.Log (
				        seed  + " -> " + r0.Next (0, 100)
				+ " " + seed  + " -> " + r1.Next (0, 100)
				+ " " + seed2 + " -> " + r2.Next (0, 100)
			);
		}
	}
}
