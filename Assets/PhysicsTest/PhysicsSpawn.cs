using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSpawn : MonoBehaviour {
	public Transform[] prefab;
	public int count = 1000;
	Transform holder;
	Transform tran;

	void Start(){
		Debug.Log (" 1 ~ 5까지 Physics함수 테스트(Renderer 제거상태)");
	}


	void Update(){

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Spawn (0);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Spawn (1);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Spawn (2);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Spawn (3);
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Spawn (4);
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			Spawn (5);		}
		
	}

	void Spawn(int _idx){
		if (_idx < 0 || _idx >= prefab.Length)
			return;

		if (holder != null) {
			DestroyImmediate (holder.gameObject);
		}

		if (!transform.Find ("holder")) {
			holder = new GameObject ("holder").transform;
		}
		holder.SetParent (transform);

		for (int i = 0; i < count; i++) {
			tran = Instantiate (prefab [_idx], Random.onUnitSphere * 5f, Quaternion.identity) as Transform;
			tran.SetParent (holder);
		}
	}

}
