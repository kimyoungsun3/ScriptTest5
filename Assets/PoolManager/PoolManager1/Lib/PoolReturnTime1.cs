using UnityEngine;
using System.Collections;


public class PoolReturnTime1 : MonoBehaviour {
	//지정된 시간이 되면 풀에 돌려주기.
	public float lifeTime;

	void OnEnable(){
		CancelInvoke ();
		Invoke ("PoolReturn", lifeTime);
	}

	void OnDisalbe(){
		CancelInvoke ();
	}

	void PoolReturn(){
		gameObject.SetActive (false);
	}

}
