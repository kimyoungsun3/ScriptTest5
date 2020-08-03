using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthBar{
	public class UnitAndPixelInfo : MonoBehaviour {
		public float halfY;
		public float halfU;
		public float halfH;
		public float orthographicSize;
		public float pixel;
		public Sprite sprite;

		public Texture2D spriteTexture2D;
		public Vector4 border;
		public Bounds bounds;
		public bool packed;
		public float pixelsPerUnit;
		public Rect rect, textureRect;
		public Vector2 textureRectOffset;
		void Start () {

			sprite = GetComponent<SpriteRenderer> ().sprite;
			spriteTexture2D = sprite.associatedAlphaSplitTexture;
			border = sprite.border;
			bounds = sprite.bounds;
			pixelsPerUnit = sprite.pixelsPerUnit;
			packed = sprite.packed;
			rect = sprite.rect;
			textureRect = sprite.textureRect;
			textureRectOffset = sprite.textureRectOffset;
			//sprite.

			halfY 			= transform.lossyScale.y/2f;
			halfU 			= halfY / pixelsPerUnit;
			halfH 			= Screen.height/2f;
			orthographicSize = Camera.main.orthographicSize;
			pixel 			= (halfH * halfU) / orthographicSize;
		}
	}
}