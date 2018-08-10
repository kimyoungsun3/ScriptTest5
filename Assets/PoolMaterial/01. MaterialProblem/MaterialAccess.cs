using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterialsProblem{
	public class MaterialAccess : MonoBehaviour {
		Renderer renderer;

		void Start () {
			renderer = GetComponent<Renderer> ();	
		}

		void Update () {
			if (Input.GetMouseButtonDown (0)) {
				renderer.material.color = Color.green;
			}
		}
	}
}