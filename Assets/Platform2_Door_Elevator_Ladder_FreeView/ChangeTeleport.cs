using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTeleport : MonoBehaviour {

	public Transform teleportPoint;
	MeshRenderer renderer;

	private void Start()
	{
		renderer = GetComponent<MeshRenderer>();
		renderer.enabled = false;
	}

	private void OnTriggerEnter(Collider _col)
	{
		if (_col.CompareTag("Player"))
		{
			_col.transform.position = teleportPoint.position;
			//_col.transform.rotation = teleportPoint.rotation;
		}
	}
}
