using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace _test2_test02{
	public class ETCTest : MonoBehaviour {
		[System.Serializable]
		public class SpritesSlotItem{
			public Sprite sprite;
			public int probability = 1;
		}
		public SpritesSlotItem[] sprites;

		// Use this for initialization
		void Start () {
			int _seed = transform.position.GetHashCode ();
			Random.InitState (_seed);

			Debug.Log (_seed + ":" + Random.value);
			for (int i = 0; i < 10; i++) {
				Debug.Log (i + " => " + Random.value);
			}

			if (sprites.Length != 0) {
				sprites.Sum (x => x.probability);
			}
		}

	}
}
