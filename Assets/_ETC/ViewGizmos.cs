using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewGizmos : MonoBehaviour {
	
	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.right * 5);
		Gizmos.color = Color.green;
		Gizmos.DrawRay (transform.position, transform.up * 5);
		Gizmos.color = Color.blue;
		Gizmos.DrawRay (transform.position, transform.forward * 5);
	}

}
