using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetResolution3 : MonoBehaviour {

	private void Start()
	{
		CheckResolution();
	}

	private void OnValidate()
	{
		CheckResolution();
	}

	private void Update()
	{
		CheckResolution();
	}

	void CheckResolution()
	{

		Camera _camera = Camera.main;
		if (_camera.orthographic)
		{
			switch (kkk)
			{
				case 1:
					Screen.SetResolution(1280, 720, true);
					break;
				case 2:
					Screen.SetResolution(Screen.width, (int) (Screen.width / 2 * 3), true );
					break;
				case 3:
					Screen.SetResolution(Screen.width, Screen.width * 16 / 9, true);
					break;
				case 4:
					Screen.SetResolution((int)(Screen.height * 16 / 9), Screen.height, true);
					break;
			}
		}

	}
	[Range(1,4)][SerializeField]int kkk = 1;
}
