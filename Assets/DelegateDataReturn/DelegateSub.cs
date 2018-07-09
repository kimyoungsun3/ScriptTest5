using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DelegateDataReturn{
	public class DelegateSub : MonoBehaviour {

		public void InitFirst(System.Action<string> _cb){
			GetComponent<DelegateSub2> ().InitFirst (_cb);
		}
	}
}
