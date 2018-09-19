using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Algorim{
	public class BubbleSort : MonoBehaviour {
		public float[] data = { 5, 7, 3, 4, 9, 1 };

		void Start () {
			SSUtil.BubbleSort<float> (data);
		}
	}
}