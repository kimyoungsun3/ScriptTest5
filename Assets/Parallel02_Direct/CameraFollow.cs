using UnityEngine;
using System.Collections;

namespace Parallel01_Direct{
	public class CameraFollow : MonoBehaviour {
		public Player scpPlayer;
		Vector3 camPos, playPos;
		Camera cam;
		float camSize;
		public float CAM_EDGE = 5f;
		public Vector2 MINMAX = new Vector2(10f, 10000f);

		void Start(){
			cam = GetComponent<Camera> ();
		}

		// Update is called once per frame
		void Update () {
			camPos 	= transform.position;
			playPos = scpPlayer.transform.position;
			camSize = playPos.y / 2f + CAM_EDGE;
			camPos.y = playPos.y / 2f;
			cam.orthographicSize = Mathf.Clamp (camSize, MINMAX.x, MINMAX.y);

			camPos.x = scpPlayer.transform.position.x;
			transform.position = camPos;


		}
	}
}