using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parallel10
{
	public class Parallax : MonoBehaviour
	{
		Transform trans, camTrans;
		private float lengthX, startPosX;
		Camera camera;
		public float parallaxEffect;

		void Start()
		{
			camTrans	= Camera.main.transform;
			trans		= transform;

			startPosX	= trans.position.x;
			lengthX		= GetComponent<SpriteRenderer>().bounds.size.x;
			Debug.Log(startPosX + ":" + lengthX);
		}

		// Update is called once per frame
		void Update()
		{
			float _temp = (camTrans.position.x * (1 - parallaxEffect));
			float _dist = (camTrans.position.x * parallaxEffect);

			trans.position = new Vector3(startPosX + _dist, trans.position.y, trans.position.z);

			Debug.Log(_temp 
				+ ":" + (startPosX - lengthX)
				+ ":" + (startPosX + lengthX));
			if (_temp > startPosX + lengthX) startPosX += lengthX; 
			else if (_temp < startPosX - lengthX) startPosX -= lengthX;

		}
	}
}
