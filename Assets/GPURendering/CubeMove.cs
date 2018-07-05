using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GPURendering{
	public class CubeMove : MonoBehaviour {
		public float speed;
		Transform trans;
		Vector3 dir;

		void Start(){
			trans = transform;

			int r = Random.Range (0, 3);
			if (r <= 0) {
				dir = Vector3.forward;
			}else if( r <= 1){
				dir = Vector3.up;
			}else{
				dir = Vector3.down;
			}
		}

			
		// Update is called once per frame
		void Update () {
			transform.Translate (dir * speed * Time.deltaTime);
			
		}
	}
}

