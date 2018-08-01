using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Painter{
	public class Painter : MonoBehaviour {
		Texture2D texture;
		public int width = 256;
		public int height = 256;

		int[] buffer;

		// Use this for initialization
		void Start () {
			texture = new Texture2D (width, height);
			GetComponent<Renderer> ().material.mainTexture = texture;
			buffer = new int[width * height];
		}

		Ray ray;
		RaycastHit hit;
		//Vector3 hitPoint;
		//Bounds bounds;
		void Update(){
			if (Input.GetMouseButton (0)) {
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, 100f)) {
					CalculateColor (hit.lightmapCoord);


					//hitPoint = hit.point;
					//bounds = hit.collider.bounds;
					//Debug.Log (
					///hit.barycentricCoordinate
					//+ ":" + hit.lightmapCoord
					//+ ":" + hit.textureCoord
					//+ ":" + hit.textureCoord2
					//);
				}
			} else if (Input.GetMouseButtonDown (1)) {
				Clear ();
			}
		}

		Color color = new Color(1f, 0f, 0f);
		Color colorClear = new Color(1f, 1, 1f);
		void CalculateColor(Vector2 _point){
			int x = (int)(_point.x * width);
			int y = (int)(_point.y * height);
			//Debug.Log (x + ":" + y);
			texture.SetPixel( x, y, color);
			texture.Apply ();
		}

		void Clear(){
			//texture.SetPixels(0, 0, width, height, new Color[]{new Color(1, 1,1)});
			//texture.SetPixel(new Color[]{new Color(1f, 1f,1f)});	
			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {					
					texture.SetPixel(x, y, colorClear);
				}
			}
			texture.Apply ();
		}
	}
}
