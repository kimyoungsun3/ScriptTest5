using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CollisionDetect2{
	public class CollisionDetect : MonoBehaviour {

		//void Start(){
		//실행중 -> 선택.
		void OnDrawGizmosSelected(){
			//Debug.Log (this);
			Text _text 		= GetComponentInChildren<Text> ();
			Collider _col 	= GetComponent<Collider> ();
			Rigidbody _rig 	= GetComponent<Rigidbody> ();

			System.Text.StringBuilder _strBuf = new System.Text.StringBuilder ();
			if (_col != null) {
				if(_col.isTrigger){
					_strBuf.Append ("<C>T");
					_text.color = Color.green;
				}else{
					_strBuf.Append ("<C>");
				}
			}

			if (_rig != null) {
				//_strBuf.Append ("\n");
				_strBuf.Append (" ");
				_strBuf.Append (_rig.isKinematic?"<R>K":"<R>");
			}
			//_strBuf.Append ("\n");
			//_strBuf.Append (name);
			_text.text = _strBuf.ToString () ;
		}
		void OnTriggerEnter(Collider _col){
			Debug.Log ("[Trigger]" + name + " -> " + _col.name);
		}

		void OnCollisionEnter(Collision _col){
			Debug.Log ("[Collision]" + name + " -> " + _col.gameObject.name);
		}
	}
}
