using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetMoveTest
{
	public class PlanetMove : MonoBehaviour
	{
		[SerializeField] Transform parentPlanet;
		[SerializeField] float speed = 2f;
		[Range(0.01f, 2f), SerializeField] float interval = 0.5f;
		Transform trans;

		// Use this for initialization
		void Start()
		{
			trans = transform;
			if (parentPlanet != null)
			{
				trans.SetParent(parentPlanet);
			}
		}

		// Update is called once per frame
		void Update()
		{
			if(parentPlanet != null)
			{
				Vector3 _dir		= parentPlanet.position - trans.position;
				Quaternion _dirQ	= Quaternion.LookRotation(_dir);
				trans.rotation		= Quaternion.Lerp(trans.rotation, _dirQ, interval * Time.deltaTime);
			}

			trans.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
}