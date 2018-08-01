using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PerlinNoise{
	public class PerlinNoise : MonoBehaviour {
		public int width = 256;
		public int height = 256;
		public float scale = 20f;
		public float offsetX = 100f;
		public float offsetY = 100f;
		Material material;
		Texture2D texture;

		void Start () {
			offsetX = Random.Range (0f, 99999f);
			offsetY = Random.Range (0f, 99999f);

			material = GetComponent<Renderer> ().material;
			texture = new Texture2D (width, height);
			material.mainTexture = texture;
		}

		void Update(){
			GenerateTexture ();
		}

		Texture2D GenerateTexture(){
			Color _color;
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					_color = CalculateColor (x, y);
					texture.SetPixel(x, y, _color);
				}
			}

			texture.Apply ();
			return texture;
		}

		Color CalculateColor(int x, int y){
			float _xCoord = (float)x / width * scale + offsetX;
			float _yCoord = (float)y / height * scale + offsetY;

			float _c = Mathf.PerlinNoise (_xCoord, _yCoord);
			return new Color (_c, _c, _c);
		}



	}
}