using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_DragAndDropTest
{
	[RequireComponent(typeof(UISprite))]
	public class DragDropCursor : MonoBehaviour
	{
		public static DragDropCursor instance;
		Transform trans;
		UISprite sprite;
		Camera cam;
		Plane plane;
		Ray ray;
		Vector3 pos;
		float z;

		void Awake(){				instance = this;	}
		private void OnDestroy(){	instance = null;	}
		private void Start()
		{
			trans	= transform;
			sprite	= GetComponent<UISprite>();
			cam		= Camera.main;
			plane	= new Plane(-cam.transform.forward, Vector3.zero);
			z		= trans.position.z;
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButton(0))
			{
				ray = cam.ScreenPointToRay(Input.mousePosition);
				float _distance;
				if (plane.Raycast(ray, out _distance))
				{
					pos = ray.GetPoint(_distance);
					pos.z = z;
					trans.position = pos;
				}
			}
		}
	}
}