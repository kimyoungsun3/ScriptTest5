using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FogOfWarTest
{
	public class DevTest : MonoBehaviour
	{

		// Use this for initialization
		void Awake()
		{
			gameObject.SetActive(true);
			Destroy(this);
		}
	}
}