using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorTest : MonoBehaviour {
	public XXX[] arrayX;
	public List<XXX> listX = new List<XXX>();
	public Queue<XXX> queueX = new Queue<XXX> ();
	public Dictionary<string, GameObject> dicX = new Dictionary<string, GameObject>();
	public Dictionary<string, List<XXX>> dicXList = new Dictionary<string, List<XXX>>();
	public Dictionary<string, Queue<XXX>> dicXQueue = new Dictionary<string, Queue<XXX>>();

	public XXX2[] arrayX2;
	public List<XXX2> listX2 = new List<XXX2>();

	void Start(){
		//Debug.Log ("Start > ");
		Debug.Log("1, 2, [], Dictionary가 공유한 것을 이동...");

		StartCoroutine (CoStart ());
	}

	IEnumerator CoStart(){
		yield return null;
		for (int i = 0, iMax = arrayX.Length; i < iMax; i++) {
			dicX.Add (arrayX [i].name, arrayX [i].go);
			//Debug.Log ("CoStart > ");
			yield return null;
		}
	}

	void Update(){
		//Debug.Log ("Update > ");
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			for (int i = 0, iMax = arrayX.Length; i < iMax; i++) {
				arrayX [i].go.transform.position += Vector3.left;
			}
		}else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			foreach(string _name in dicX.Keys){
				dicX[_name].transform.position += Vector3.right;
			}
		}
	}



	[System.Serializable]
	public class XXX{
		public string name;
		public GameObject go;
	}

	[System.Serializable]
	public class XXX2{
		public string name;
		public List<GameObject> list;
	}
}
