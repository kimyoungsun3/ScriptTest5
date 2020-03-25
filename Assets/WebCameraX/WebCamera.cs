using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WebCamera : MonoBehaviour {

	private RawImage rawImage;
	private WebCamTexture webCamTexture;
	private AspectRatioFitter aspectRationFitter;


	// Use this for initialization
	void Start ()
	{
		rawImage			= GetComponent<RawImage>();
		aspectRationFitter	= GetComponent< AspectRatioFitter > ();
		webCamTexture		= new WebCamTexture(Screen.width, Screen.height);
		rawImage.texture	= webCamTexture;
		webCamTexture.Play();
	}

	// Update is called once per frame
	void Update () {
		if(webCamTexture.width < 100)
		{
			return;
		}

		float cwNeeded = -webCamTexture.videoRotationAngle;
		if (webCamTexture.videoVerticallyMirrored)
			cwNeeded += 180f;

		rawImage.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);

		float videoRatio = (float)webCamTexture.width / (float)webCamTexture.height;
		aspectRationFitter.aspectRatio = videoRatio;

		if (webCamTexture.videoVerticallyMirrored)
		{
			rawImage.uvRect = new Rect(1, 0, -1, 1);
		}
		else
		{
			rawImage.uvRect = new Rect(0, 0, 1, 1);
		}
	}
	public void goLoad()
	{
		webCamTexture.Stop();
		//EnemyDeadState.i = 9;
		Application.LoadLevel("LoadScene");
	}
}
