using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest : MonoBehaviour {
	//int SIZE = 2; 		// error
	//const int SIZE = 2;	// ok
	static int SIZE = 2;	//ok
	//					2	//ok
	int[, ] array = new int[SIZE, SIZE];
	bool[, ] array2 = new bool[SIZE, SIZE];
	static int SIZE2= 1000;	//ok

	// Use this for initialization
	void Start () {
		Debug.Log ("Clean and Create speed test");
		Display<int> (1, array);
		Display<bool> (1, array2);
		for (int x = 0; x < array.GetLength (0); x++) {
			for (int y = 0; y < array.GetLength (1); y++) {
				array [x, y] = Random.Range (0, 100);
				array2 [x, y] = true;
			}
		}
		Display<int> (2, array);
		Display<bool> (2, array2);
		System.Array.Clear (array, 0, array.GetLength (0) * array.GetLength (1));
		System.Array.Clear (array2, 0, array2.GetLength (0) * array2.GetLength (1));
		Display<int> (3, array);
		Display<bool> (3, array2);
	}

	float[] t = new float[10];
	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			int[, ] _array2 = new int[SIZE2, SIZE2];
			int _size;

			t [0] = Time.realtimeSinceStartup;
			for (int i = 0; i < 100; i++) {
				int[, ] _array = new int[SIZE2, SIZE2];
			}

			t [1] = Time.realtimeSinceStartup;
			_size = _array2.GetLength (0) * _array2.GetLength (1);
			for (int i = 0; i < 100; i++) {
				System.Array.Clear (_array2, 0, _size);
			}


			t [2] = Time.realtimeSinceStartup;
			for (int i = 0; i < 100; i++) {
				int[, ] _array = new int[SIZE2, SIZE2];
			}

			t [3] = Time.realtimeSinceStartup;
			_size = _array2.GetLength (0) * _array2.GetLength (1);
			for (int i = 0; i < 100; i++) {
				System.Array.Clear (_array2, 0, _size);
			}


			t [4] = Time.realtimeSinceStartup;
			for (int i = 0; i < 100; i++) {
				int[, ] _array = new int[SIZE2, SIZE2];
			}

			t [5] = Time.realtimeSinceStartup;
			_size = _array2.GetLength (0) * _array2.GetLength (1);
			for (int i = 0; i < 100; i++) {
				System.Array.Clear (_array2, 0, _size);
			}

			t [6] = Time.realtimeSinceStartup;
			for (int i = 0; i < 100; i++) {
				int[, ] _array = new int[SIZE2, SIZE2];
			}

			t [7] = Time.realtimeSinceStartup;
			_size = _array2.GetLength (0) * _array2.GetLength (1);
			for (int i = 0; i < 100; i++) {
				System.Array.Clear (_array2, 0, _size);
			}

			t [8] = Time.realtimeSinceStartup;
			Debug.Log ("cr : " + (t [1] - t [0]));
			Debug.Log ("cl : " + (t [2] - t [1]));
			Debug.Log ("cr : " + (t [3] - t [2]));
			Debug.Log ("cl : " + (t [4] - t [3]));
			Debug.Log ("cr : " + (t [5] - t [4]));
			Debug.Log ("cl : " + (t [6] - t [5]));
			Debug.Log ("cr : " + (t [7] - t [6]));
			Debug.Log ("cl : " + (t [8] - t [7]));
		}
	}

	void Display<T>(int _branch, T[,] _array){
		for (int x = 0; x < _array.GetLength (0); x++) {
			for (int y = 0; y < _array.GetLength (1); y++) {
				Debug.Log(_branch + " " + x + " , " + y + " => " + _array [x, y]);
			}
		}
	}
}
