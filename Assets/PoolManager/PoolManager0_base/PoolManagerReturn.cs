using UnityEngine;
using System.Collections;

namespace PoolManager0{
	public class PoolManagerReturn: MonoBehaviour {
		void OnEnable(){
			Invoke ("Destroy", 5f);
		}

		void Destroy(){
			gameObject.SetActive (false);
		}

		void OnDisable(){
			CancelInvoke ();
		}
	}
}
