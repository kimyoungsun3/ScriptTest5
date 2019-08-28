using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour {
	public Transform prefab;
	//public List<Transform> list = new List<Transform>();
	void Start () {
		InvokeRepeating("Spawner", 0, 1f);	
	}

	void Spawner()
	{
		Vector3 _pos = new Vector3(
			Random.Range(-5f, 5f),
			Random.Range(-5f, 5f), 
			0);
		Transform _t = Instantiate(prefab, _pos, Quaternion.identity) as Transform;
		_t.SetParent(transform);

		if(loop++ > 20)
		{
			CancelInvoke("Spawner");
		}
	}
	int loop = 0;
}
