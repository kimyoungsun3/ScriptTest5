using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputeTest {
	public class ComputerMaster : MonoBehaviour {
		public int ARRAY_SIZE = 1024;

		const int threadGroupSize = 1024;
		public ComputeShader compute;
		ComputeBuffer computeBuffer;
		int kernel = 0;

		BoidData[] array;
		//public List<int> aaa = new List<int>();


		// Use this for initialization
		void Start() {
			array = new BoidData[ARRAY_SIZE];
			for (int i = 0; i < ARRAY_SIZE; i++)
			{
				array[i].data = Random.Range(0, 10);
			}

			computeBuffer = new ComputeBuffer(ARRAY_SIZE, sizeof(int));
			computeBuffer.SetData(array);
			Debug.Log(compute);
			kernel = compute.FindKernel("CSMain");
		}

		

		// Update is called once per frame
		void Update() {

			if(compute != null)
			{
				compute.SetBuffer(kernel, "array", computeBuffer);
				compute.SetInt("size", ARRAY_SIZE);

				int _threadGroup = Mathf.CeilToInt(ARRAY_SIZE / (float)threadGroupSize);
				Debug.Log(kernel + ":" + _threadGroup);
				compute.Dispatch(0, 1, 1, 1);
				//compute.Dispatch(kernel, _threadGroup, 1, 1);
				//computeBuffer.GetData(array);

				Debug.Log(array[0].data);
			}

		}
	}

	public struct BoidData
	{
		public int data;
	}

}