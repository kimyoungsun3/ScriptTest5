using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
	public int MAX_OBSTACLE = 10;
	public int MAX_ENEMY = 10;
	public GameObject prefabObstacle;
	public GameObject prefabEnemy;
	float distance;

	void Start(){
		distance = GetComponent<SphereCollider> ().bounds.extents.x;
		GameObject _go;
		//Debug.Log (distance);
		for (int i = 0; i < MAX_OBSTACLE; i++) {
			_go = Instantiate (prefabObstacle, transform.position + Random.onUnitSphere * distance, Quaternion.identity);
			_go.transform.SetParent (transform);
		}

		for (int i = 0; i < MAX_ENEMY; i++) {
			_go = Instantiate (prefabEnemy, transform.position + Random.onUnitSphere * distance, Quaternion.identity);
			_go.transform.SetParent (transform);
		}
	}
}
