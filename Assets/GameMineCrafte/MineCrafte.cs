using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameMineCrafteTest
{
	public class MineCrafte : MonoBehaviour
	{
		public Transform blockPrefab;
		public Transform blockGuide;
		public Vector3 offset;
		GameObject goGuide;
		public LayerMask blockMask;
		public float distance = 100f;
		
		public List<Transform> listBlock = new List<Transform>();

		RaycastHit hit;
		Camera camera;
		Vector3 spawnPoint;

		void Start()
		{
			camera	= Camera.main;
			goGuide = blockGuide.gameObject;
			goGuide.SetActive(false);
			listBlock.Add(blockPrefab);
			offset = blockPrefab ? blockPrefab.position : offset;
		}

		// Update is called once per frame
		void Update()
		{
			Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(_ray, out hit, distance, blockMask))
			{
				
				spawnPoint = Vector3Int.RoundToInt(hit.point + hit.normal * 0.5f - offset) + offset;				
				if (Input.GetMouseButtonDown(0))
				{	
					Transform _t = Instantiate<Transform>(blockPrefab, spawnPoint, Quaternion.identity);
					listBlock.Add(_t);
				}
				else if (Input.GetMouseButtonDown(1))
				{
					Transform _t = hit.collider.transform;
					if (listBlock.Contains(_t) && _t != blockPrefab)
					{
						listBlock.Remove(_t);
						Destroy(_t.gameObject);
					}
				}
			}

			//display Guide Block
			if (hit.collider)
			{
				if(!goGuide.activeSelf)
				{
					goGuide.SetActive(true);
				}
				blockGuide.position = spawnPoint;
			}
			else
			{
				if (goGuide.activeSelf)
				{
					goGuide.SetActive(false);
				}
			}
		}

		//private void OnDrawGizmos()
		//{
		//	if (hit.collider)
		//	{
		//		Gizmos.DrawWireCube(spawnPoint, Vector3.one);
		//	}
		//}
	}
}