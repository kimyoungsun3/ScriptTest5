using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {
	//public RectTransform target;
	public Transform target;
	public RectTransform targetMini;
	Vector2 pos;
	RectTransform rectTransform;
	Rect rect;
    Camera camera;

    void Start () {
        rectTransform   = transform.GetComponent<RectTransform> ();
		rect            = rectTransform.rect;
        camera          = Camera.main;
    }

	void Update () {
		pos = camera.WorldToViewportPoint (target.position);

		targetMini.anchoredPosition = new Vector2(
			pos.x * rect.size.x, 
			- (1f - pos.y) * rect.size.y
		);		
	}
}
