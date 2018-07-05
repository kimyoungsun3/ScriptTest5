using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FPSCheck : MonoBehaviour {
	public float updateInterval = .5f;
	float accum, timeleft, fps;
	int frames;
	//string strFps;
	public Text lvFps;

	void Start () {
		timeleft = updateInterval;
	}

	//void OnGUI(){
	//	GUI.Label(new Rect(0, 0, 100, 100), strFps);
	//}

	void Update () {
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;
		if (timeleft < 0) {
			fps = accum / frames;
			lvFps.text = System.String.Format ("{0:F2} FPS", fps);

			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
		}
		
	}
}
