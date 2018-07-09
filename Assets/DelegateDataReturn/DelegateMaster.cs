using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateDataReturn{
	public class DelegateMaster : MonoBehaviour {


		IEnumerator Start () {
			Debug.Log ("Step 1 > Any keyHit is pass");
			bool _wait = true;
			GetComponent<DelegateSub> ().InitFirst (
				delegate(string _key){
					Debug.Log ("Step 1 HitKey:" + _key);
					_wait = false;
				}
			);

			while (_wait)
				yield return null;
			
			Debug.Log ("Step 2 > Any key Hit is pass");
			_wait = true;
			GetComponent<DelegateSub> ().InitFirst (
				delegate(string _key){
					Debug.Log ("Step 2 HitKey:" + _key);
					_wait = false;
				}
			);
			while (_wait)
				yield return null;
		}
	}
}