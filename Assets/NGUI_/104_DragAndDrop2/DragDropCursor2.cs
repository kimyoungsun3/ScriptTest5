using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_DragAndDropTest2
{
	[RequireComponent(typeof(UISprite))]
	public class DragDropCursor2 : MonoBehaviour
	{
		public static DragDropCursor2 instance;
		Transform trans;
		UISprite sprite;
		[SerializeField]Camera cam;
		Plane plane;
		Ray ray;
		Vector3 pos;
		float z;
		//DragDropSlotItem beforeSlot;

		void Awake(){				instance = this;	}
		private void OnDestroy(){	instance = null;	}
		private void Start()
		{
			trans	= transform;
			sprite	= GetComponent<UISprite>();
			if(cam == null)
				cam = NGUITools.FindCameraForLayer(gameObject.layer);
			plane	= new Plane(-cam.transform.forward, Vector3.zero);
			z		= trans.position.z;

			Clear();
		}

		// Update is called once per frame
		void Update()
		{
			if (sprite.enabled && Input.GetMouseButton(0))
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

		public void Clear()
		{
			if(instance != null)
			{
				SetSpriteName(null, "");
			}
		}

		DragDropSlotItem beforeSlot;
		public DragDropSlotItem GetBeforeSlot() { return beforeSlot; }

		public void SetSpriteName(DragDropSlotItem _beforeSlot, string _spriteName)
		{
			if(instance != null && sprite)
			{
				beforeSlot = _beforeSlot;
				if (string.IsNullOrEmpty(_spriteName))
				{
					sprite.enabled = false;
				}
				else
				{
					sprite.enabled = true;
					sprite.spriteName = _spriteName;
					sprite.MakePixelPerfect();
				}
			}
		}
	}
}