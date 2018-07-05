using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletChild : MonoBehaviour {
	public GameObject parentGameObject;

	//----------------------------
	void OnBecameInvisible(){
		parentGameObject.SetActive (false);
	}
}
