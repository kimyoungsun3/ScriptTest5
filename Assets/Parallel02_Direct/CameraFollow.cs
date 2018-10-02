using UnityEngine;
using System.Collections;

namespace Parallel01_Direct{
	public class CameraFollow : MonoBehaviour {
		public Player scpPlayer;
		Vector3 camPos, playPos, bgScale;
		Camera cam;
		float camSize;
		public float CAM_EDGE = 5f;
		public Vector2 MINMAX = new Vector2(10f, 10000f);
		public Transform transBG;
		Vector3 BG_MIN = Vector3.one;
		Vector3 BG_MAX = Vector3.one * 5f;

		void Start(){
			cam = GetComponent<Camera> ();
		}

		// Update is called once per frame
		void Update () {
			camPos 	= transform.position;
			playPos = scpPlayer.transform.position;
			bgScale	= transBG.localScale;


			camSize 	= playPos.y / 2f + CAM_EDGE;
			camPos.y 	= playPos.y / 2f;
			cam.orthographicSize = Mathf.Clamp (camSize, MINMAX.x, MINMAX.y);
			bgScale = Vector3.Lerp(BG_MIN, BG_MAX, (camSize / 10f) / 5f);

			camPos.x = scpPlayer.transform.position.x;
			transform.position = camPos;
			transBG.localScale = bgScale;


		}
	}
}