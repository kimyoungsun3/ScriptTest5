using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterial2{
	public class ClickChangeColor : MonoBehaviour {
		MaterialData materialData;
		public Color c1, c2;
		public const int LIFE_MAX = 10;
		public int life = LIFE_MAX;

		void OnMouseDown(){
			if (materialData == null) {
				materialData = PoolMaterial.ins.RegisterMaterial (GetComponent<Renderer> ());
			}
			life--;
			Color _c = Color.Lerp (c1, c2, (float)(LIFE_MAX - life) / LIFE_MAX);
			materialData.SetColor (_c);
		}
	}
}
