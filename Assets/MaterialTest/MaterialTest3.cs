using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTest3 : MonoBehaviour {
	Renderer renderer;
	void Start () {
		renderer = GetComponent<Renderer> ();
	}

	Material[] matA = new Material[10];
	Material[] matB = new Material[10];
	Material[] matC = new Material[10];
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			matA[0] = renderer.material;
			matA[1] = renderer.material;
			matA[2] = renderer.sharedMaterial;

			Debug.Log("m/m/s(2,3,4)" 
				+ ":" + ( matA[0] == matA[1] ) 
				+ ":" + ( matA[1] == matA[2] )
			);
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			matA [0].color = Color.red;
		}else if(Input.GetKeyDown(KeyCode.Alpha3)){
			matA [1].color = Color.green;			
		}else if(Input.GetKeyDown(KeyCode.Alpha4)){
			matA [2].color = Color.blue;

		}else if(Input.GetKeyDown(KeyCode.Alpha6)){
			matB[0] = renderer.sharedMaterial;
			matB[1] = renderer.material;
			matB[2] = renderer.material;
			if (matB [3] == null) {
				matB [3] = matB [0];
				matB [4] = matB [1];
				matB [5] = matB [2];

				Debug.Log ("s/m/m(7,8,9)x1"
					+ ":" + (matB [0] == matB [1])
					+ ":" + (matB [1] == matB [2])
				);
			} else {
				Debug.Log ("s/m/m(7,8,9)x2"
					+ ":" + (matB [0] == matB [1])
					+ ":" + (matB [1] == matB [2])
					+ ":" + (matB [2] == matB [3])
					+ ":" + (matB [3] == matB [4])
					+ ":" + (matB [4] == matB [5])

					+ " :" + (matB [0] == matB [3])
					+ ":" + (matB [0] == matB [4])
				);
				//matB [3] = matB [0];
				//matB [4] = matB [1];
				//matB [5] = matB [2];
			}
		}else if(Input.GetKeyDown(KeyCode.Alpha7)){
			matB [0].color = Color.red;
		}else if(Input.GetKeyDown(KeyCode.Alpha8)){
			matB [1].color = Color.green;			
		}else if(Input.GetKeyDown(KeyCode.Alpha9)){
			matB [2].color = Color.blue;

		}else if(Input.GetKeyDown(KeyCode.O)){
			matC[0] = renderer.sharedMaterial;
			Debug.Log("s(O, P)" );
		}else if(Input.GetKeyDown(KeyCode.P)){
			matC [0].color = Color.red;
			renderer.sharedMaterial = matC [0];  
		}
	}
}
