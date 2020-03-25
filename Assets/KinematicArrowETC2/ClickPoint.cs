using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC2
{
	public class ClickPoint : MonoBehaviour
	{
		[SerializeField] Bomb2 prefabBomb;
		Plane ground;
		Camera cam;
		[SerializeField] Transform spawnPoint;

		// Use this for initialization
		void Start()
		{
			cam		= Camera.main;
			ground	= new Plane(-Camera.main.transform.forward, Vector3.zero);
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
				float _distance;
				if(ground.Raycast(_ray, out _distance))
				{
					Vector3 _hitPoint = _ray.GetPoint(_distance);
					Bomb2 _bomb = Instantiate(prefabBomb, spawnPoint.position, Quaternion.identity) as Bomb2;
					_bomb.SetData(spawnPoint.position, _hitPoint);
				}
			}
		}
	}
}