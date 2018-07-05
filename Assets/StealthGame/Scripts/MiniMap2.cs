using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap2 : MonoBehaviour {
	//public Transform center;
	public Transform bottonLeft, topRight;
	Vector3 bottomPos, topPos, distanceV;
	List<GameObject> targets;

	public RectTransform pointPrefab;
	RectTransform[] targetMinis;
	Vector2 pos;
	RectTransform rectTransform;
	Rect rect;
	LayerMask playerMask;

	void Start () {	
		playerMask = LayerMask.NameToLayer ("Player");
		bottomPos = bottonLeft.position;
		topPos = topRight.position;
		distanceV = topPos - bottomPos;	
		//Debug.Log (bottomPos + ":" + bottonLeft.position);
		//Debug.Log (topPos + ":" + topRight.position);
		//Debug.Log (distanceV);

		targets = new List<GameObject>(GameObject.FindGameObjectsWithTag ("Enemy"));
		targets.Add (GameObject.FindWithTag ("Player"));

		targetMinis = new RectTransform[targets.Count];
		for (int i = 0; i < targetMinis.Length; i++) {
			targetMinis[i] = Instantiate (pointPrefab, Vector3.zero, Quaternion.identity) as RectTransform;
			targetMinis [i].SetParent (transform);
		}

		rectTransform = transform.GetComponent<RectTransform> ();
		rect = rectTransform.rect;
	}

	float nextTime;
	public float nextTimeBetween = 0.3f;
	void Update () {
		if (Time.time > nextTime) {
			nextTime = Time.time + nextTimeBetween;

			Vector3 _curPos, _viewPort;
			for (int i = 0; i < targetMinis.Length; i++) {
				_curPos = targets [i].transform.position;
				//Debug.Log ("_curPos:" + _curPos);
				if (_curPos.x > bottomPos.x && _curPos.z > bottomPos.z
					&& _curPos.x < topPos.x && _curPos.z < topPos.z) {
					//view port 계산.
					_viewPort =  _curPos - bottomPos;
					_viewPort.x /= distanceV.x;
					_viewPort.y = 0;
					_viewPort.z /= distanceV.z;

					//Debug.Log ("_viewPort:" + _viewPort);
					//위치...
					targetMinis[i].anchoredPosition = new Vector2 (
						_viewPort.x * rect.size.x, 
						-(1f - _viewPort.z) * rect.size.y
					);

					//플레이어는 녹색.
					if(targets[i].layer == playerMask){
						targetMinis [i].GetComponent<Image> ().color = Color.green;
					}
				}
			}	
		}
	}
}
