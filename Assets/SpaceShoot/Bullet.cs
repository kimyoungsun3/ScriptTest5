using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 3f;
	[HideInInspector] public Boss boss;

	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider _col){
		//Debug.Log (1);
		if (_col.CompareTag ("Obstacle")) {
			OnDestroy ();
		}
	}

	public void OnDestroy(){
		//Debug.Log (name);
		if(boss != null)
			boss.callback -= OnDestroy;
		Destroy (gameObject);
	}
}
