using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolMaterial1;

namespace PoolMaterialsSolves3{
	public class MaterialAccess : MonoBehaviour {
		Renderer renderer;
		Material originalMaterial;
		void Start () {
			renderer 			= GetComponent<Renderer> ();
			originalMaterial 	= renderer.sharedMaterial;
			PoolMaterial.ins.RegisterMaterial ( originalMaterial );
		}

		void Update () {
			if (Input.GetMouseButtonDown (0)) {
				StopAllCoroutines ();
				StartCoroutine (CoChange(2f));
			}
		}

		IEnumerator CoChange(float _time){
			//Debug.Log (1);
			float _percent = 0;
			float _speed = 1f / _time;
			MaterialData _newMaterialData 	= PoolMaterial.ins.GetMaterial (originalMaterial);
			Material _newMaterial 			= _newMaterialData.mat;
			renderer.sharedMaterial 		= _newMaterial;
			//Color _c1 = Color.clear;
			//Color _c2 = originalMaterial.color;

			while(_percent < 1f){
				_percent += Time.deltaTime * _speed;
				_newMaterial.mainTextureOffset = (Time.time * Vector3.right);
				yield return null;
			}
			_newMaterialData.Release ();
			renderer.sharedMaterial = originalMaterial;
		}
	}
}