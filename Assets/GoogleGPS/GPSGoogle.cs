using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSGoogle : MonoBehaviour {
	public Text text;	

	public double latitude;
	public double longitude;
	
	float nextTime;
	bool bAccess;
	private IEnumerator StartLocationService() {
		bAccess = true;

		if (!Input.location.isEnabledByUser) {
			Debug.Log ("User has not enabled GPS");
			yield break;
		}

		Input.location.Start ();
		int maxWait = 2;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		 if (maxWait <= 0)
		 {
		     Debug.Log("Timed out");
		     yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Unable to determin device location");
			yield break;
		}
		bAccess = false;
	}

	void Update()
	{
		latitude = Input.location.lastData.latitude;
		longitude = Input.location.lastData.longitude;
		text.text = latitude + "\n" + longitude;


		if (!bAccess && Time.time > nextTime)
		{
			//Debug.Log (1);
			nextTime = Time.time + 2f;
			StartCoroutine(StartLocationService());
		}
	}
}
