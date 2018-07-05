using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructTest : MonoBehaviour {
	List<Coord> list = new List<Coord>();
	Coord[] array = new Coord[4];
	public GameObject prefabCube;
	
	void Start () {
		InitData ();
	}

	public void InitData(){
		//struct 알아보기...
		Coord _c1 = list [0];
		Coord _c2 = list [0];
		_c1.x += 1;
		_c2.x -= 1;
		Debug.Log(list[0].x + ":" + _c1.x + ":" + _c2.x);

		//------------------------------
		Coord _c;
		int _x;

		Transform holder;
		string holderName = "holder";
		if (transform.Find (holderName)) {
			DestroyImmediate (transform.Find (holderName).gameObject);
		}
		holder = new GameObject (holderName).transform;
		holder.SetParent (transform);


		for (int i = 0; i < array.Length; i++) {
			GameObject _go = Instantiate (prefabCube);
			_go.transform.SetParent (holder);
			_go.name = "cube" + i;

			_x = i;
			_c = new Coord (_x, _x + 1, _x + 2, _go);

			Debug.Log ("b:" + _c.x);
			list.Add (_c);
			array [i] = _c;

			_c.x++;
			Debug.Log ("a:" + _c.x + ", " + list [i].x + ", " + array [i].x);
		}

		for (int i = 0; i < array.Length; i++) {
			Debug.Log (i + "(list) -> " + list [i].x
				+ ", " + list [i].y
				+ ", " + list [i].go);

			Debug.Log (i + "(array) -> " + array [i].x
				+ ", " + array [i].y
				+ ", " + array [i].go.name);
		}


	}


	[System.Serializable]
	public struct Coord{
		public int x, y;
		public GameObject go;
		int z;

		public Coord(int _x){
			x = _x;
			y = 0;
			z = 0;
			go = null;
		}

		public Coord(int _x, int _y){
			x = _x;
			y = _y;
			z = 0;
			go = null;
		}

		public Coord(int _x, int _y, int _z, GameObject _go){
			x = _x;
			y = _y;
			z = _z;
			go = _go;
		}
	}
}
