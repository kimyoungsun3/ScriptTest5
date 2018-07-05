using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayTest2 : MonoBehaviour {
	const int SIZE = 2;	// ok
	Coord[] array = new Coord[SIZE];
	List<Coord> list = new List<Coord>();
	float[] t = new float[10];

	void Start(){
		Debug.Log ("Coord[] array, List<Coord> list Test");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log ("Array Test");
			Coord _c;

			Display (1, array);
			Display (2, list);

			for (int i = 0, iMax = array.Length; i < iMax ; i++) {
				_c = new Coord (i+1, (i+1) * 10);
				array [i] = _c;
				list.Add(_c);
			}

			Display (3, array);
			Display (4, list);

			for (int i = 0, iMax = array.Length; i < iMax ; i++) {
				//_c = new Coord (i, i * 10);
				array [i].x += 1;
				//list [i].x += 1;	//error
			}

			Display (5, array);
			Display (6, list);
		}
	}

	//void Display<T>(int _branch, T[] _array) where T : struct{
	//	for (int i = 0; i < _array.Length; i++) {
	//		Debug.Log(_branch + " [" + i + "] => " + _array [i]);
	//	}
	//}

	void Display(int _branch, Coord[] _array){
		for (int i = 0; i < _array.Length; i++) {
			Debug.Log(_branch + " [" + i + "] => " + _array [i].x + ", " + _array[i].y);
		}
	}

	void Display(int _branch, List<Coord> _list){
		for (int i = 0; i < _list.Count; i++) {
			Debug.Log(_branch + " [" + i + "] => " + _list [i].x + ", " + _list[i].y);
		}
	}

	public struct Coord{
		public int x, y;
		public Coord(int _x, int _y){
			x = _x;
			y = _y;
		}
	}
}
