using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController20 : MoveControllerMaster {


	void Update () {
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		//auto forward...
		if (Input.GetKeyDown (KeyCode.Tab)) {
			bMoveForward = !bMoveForward;
		} else if (h != 0 || v != 0) {
			bMoveForward = false;
		}

		input.Set (h, v);
		if (bMoveForward) {
			input.Set (input.x, 1);
		}	

		transform.Translate ( input.y * Vector3.forward * speedMove * Time.deltaTime);
		transform.Rotate ( input.x * Vector3.up * speedTurn * Time.deltaTime);
		
	}
}
