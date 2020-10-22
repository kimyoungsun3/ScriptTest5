using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=yzcfTb9e0lo&t=134s
namespace FogOfWarTest
{
	public class FogOfWar : MonoBehaviour
	{
		public Transform fogOfWarPlane;		
		public int Number = 1;
		Material fogMaterial;
		Transform trans;
		string param;


		// Use this for initialization
		void Start()
		{
			trans		= transform;
			param		= "_Player" + Number.ToString() + "_Pos";
			fogMaterial = fogOfWarPlane.GetComponent<Renderer>().material;
		}

		// Update is called once per frame
		void Update()
		{
			if (fogMaterial != null)
			{
				fogMaterial.SetVector(param, trans.position);
			}
		}
	}

}