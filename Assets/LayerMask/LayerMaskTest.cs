using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerMaskTest : MonoBehaviour {
	public LayerType[] layers;
	public Dictionary<int, Color> dic = new Dictionary<int, Color>();
	public float distance = 100f;

	LayerMask maskAll;
	Ray ray;
	RaycastHit hit;
	Color color;


	void Start () {
		Debug.Log ("클릭하면 레이어 마스크 정보");
		int _layer, _maskFilter;
		for (int i = 0; i < layers.Length; i++) {
			_maskFilter = layers [i].mask.value;
			_layer = (int)Mathf.Log (_maskFilter, 2);
			Debug.Log (_layer + " => " + _maskFilter);

			maskAll.value |= _maskFilter;
			dic.Add (_layer, layers [i].color);
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, distance, maskAll)) {
				if (dic.TryGetValue (hit.collider.gameObject.layer, out color)) {
					hit.collider.GetComponent<Renderer> ().material.color = color;
				}
			}
		}
		
	}

	[System.Serializable]
	public class LayerType{
		public LayerMask mask;
		public Color color;
	}
}
