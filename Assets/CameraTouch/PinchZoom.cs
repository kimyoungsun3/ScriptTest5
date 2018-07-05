using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchZoom : MonoBehaviour {

	public float speedZoomPerspective = 0.08f;
	public float speedMovePerspective = 3f;
	//public Vector2 perspectiveZoomMinMax = new Vector2 (10f, 179f);
	public float speedZoomOrtho = 0.08f;
	public float speedMoveOrtho = 1f;
	public Vector2 orthoZoomMinMax = new Vector2 (1f, 15f);

	Touch t0, t1;
	Vector2 t0OldPos, t1OldPos;
	float distanceOld, distanceCur, deltaDistance;
	Camera camera;
	int touchCount;
	Transform trans;
	Vector3 move;

	public Transform target;

	void Start(){
		camera = GetComponent<Camera> ();

		trans = transform;
	}


	void Update () {

		touchCount = Input.touchCount;
		if (touchCount > 0) {
			t0 = Input.GetTouch (0);
			if (touchCount == 1) {
				if (camera.orthographic) {
					trans.Translate (-t0.deltaPosition * Time.deltaTime * speedMoveOrtho);
				} else {
					trans.Translate (-t0.deltaPosition * Time.deltaTime * speedMovePerspective);
				}
			}else if (Input.touchCount == 2) {
				t1 = Input.GetTouch (1);

				t0OldPos = t0.position - t0.deltaPosition;
				t1OldPos = t1.position - t1.deltaPosition;

				distanceOld = Vector2.Distance (t0OldPos, t1OldPos);
				distanceCur = Vector2.Distance (t0.position, t1.position);
				deltaDistance = distanceOld - distanceCur;
				if (camera.orthographic) {
					//Debug.Log ("> orthographic");
					camera.orthographicSize += deltaDistance * speedZoomOrtho;
					camera.orthographicSize = Mathf.Clamp (camera.orthographicSize, orthoZoomMinMax.x, orthoZoomMinMax.y);
				} else {
					//Debug.Log ("> perspect");
					camera.transform.Translate (-Vector3.forward * deltaDistance * speedZoomPerspective);
					//camera.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;
					//camera.fieldOfView = Mathf.Clamp (camera.fieldOfView, perspectiveZoomMinMax.x, perspectiveZoomMinMax.y);
				}
			}

			if (target != null && !camera.orthographic) {
				trans.LookAt (target);
			}
		}
	}
}
