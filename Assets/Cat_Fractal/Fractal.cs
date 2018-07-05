using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour {
	public Mesh mesh;
	public Material material;
	public int maxDepth;
	int depth;
	public float childScale;

	static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back
	};

	static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler (Vector3.forward * -90f),
		Quaternion.Euler (Vector3.forward * +90f),
		Quaternion.Euler (Vector3.right * +90f),
		Quaternion.Euler (Vector3.right * -90f)
	};

	//void Awake () {
	//	//Debug.Log (this + "Awake");
	//}
	//void OnEnable () {
	//	//Debug.Log (this + "OnEnable");
	//}

	static Material[] materials;


	void InitMaterial(){
		materials = new Material[maxDepth + 1];
		for (int i = 0; i <= maxDepth; i++) {
			materials [i] = new Material (material);
			materials[i].color = Color.Lerp (Color.white, Color.yellow, (float)i / maxDepth);
		}
	}


	void Start () {
		if (materials == null) {
			//Debug.Log (1);
			InitMaterial ();
		}

		//Debug.Log (this + "Start");
		gameObject.AddComponent<MeshFilter> ().mesh = mesh;
		gameObject.AddComponent<MeshRenderer> ().material = materials[depth];
		//material.color = Color.Lerp (Color.white, Color.yellow, (float)depth / maxDepth);

		if (depth < maxDepth) {
			StartCoroutine (CreateChildren());
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.up);
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.right);
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.down);
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.left);
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.forward);
			//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.back);
		}
	}
		

	IEnumerator CreateChildren(){
		for (int i = 0; i < childOrientations.Length; i++) {
			yield return new WaitForSeconds (Random.Range(0.1f,.5f));
			new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, i);
		}
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.up, Quaternion.identity);
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.right, Quaternion.Euler(Vector3.forward * -90f));
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.left, Quaternion.Euler(Vector3.forward * +90f));
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.down);
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.forward);
		//yield return new WaitForSeconds(.5f);
		//new GameObject ("Fractal Child").AddComponent<Fractal> ().Init (this, Vector3.back);
	}

	void Init(Fractal _parent, int _idx){
		//Debug.Log (this + "Init:" + (_parent.depth + 1));
		mesh = _parent.mesh;
		//material = _parent.material;
		maxDepth = _parent.maxDepth;
		depth = _parent.depth + 1;
		childScale = _parent.childScale;

		Vector3 _dir = childDirections [_idx];
		Quaternion _q = childOrientations [_idx];

		transform.SetParent (_parent.transform);
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = _dir * (childScale + childScale * .5f);
		transform.localRotation = _q;
	}

	//bool bUpdate ;
	//void Update(){
	//	if (!bUpdate) {
	//		Debug.Log (this + "Update:"+depth);
	//		bUpdate = !bUpdate;
	//	}
	//}
}
