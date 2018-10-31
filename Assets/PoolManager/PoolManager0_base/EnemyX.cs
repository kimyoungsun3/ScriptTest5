using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EnemyXData d1 = new EnemyXData ();
		EnemyXData d2 = new EnemyXData ();
		EnemyXData d3 = new EnemyXData ();
		//Debug.Log (d1.count);
		//Debug.Log (d2.count);
		//Debug.Log (d3.count);
		Debug.Log (EnemyXData.count);
	}

	[System.Serializable]
	public class EnemyXData{
		public static int count  = 0;
		public EnemyXData(){
			count ++;
		}
	}
}
