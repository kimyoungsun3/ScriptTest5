using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraInfo2{
	public class CameraInfo : MonoBehaviour {
		public int sw, sh;
		public float saspect;

	
		public float caspect, csize;

		// Use this for initialization
		void Update () {
			sw 		= Screen.width;
			sh 		= Screen.height;
			saspect = (float)sw / (float)sh;

			caspect = Camera.main.aspect;
			csize = Camera.main.orthographicSize;		
		}
	}
}
