using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterTest : MonoBehaviour {
	public Collider colArm, colLeg;
	public LayerMask mask;
	Transform trans;


	void Start () {
		trans = transform;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			HitArea (colArm);
		} else if (Input.GetKeyDown (KeyCode.G)) {
			HitArea (colLeg);
		}
	}

	void HitArea(Collider _col){
		Collider[] _cols = Physics.OverlapBox (_col.bounds.center, _col.bounds.extents, _col.transform.rotation, mask);
		Collider _c;
		for (int i = 0, iMax = _cols.Length; i < iMax; i++) {
			_c = _cols [i];
			if (_c.transform.parent.parent == trans) {
				continue;
			}

			float _damage = 0;
			switch (_c.name) {
			case "Head":
				_damage = 10;
				Debug.Log ("Head");
				break;
			case "Body":
				_damage = 3;
				Debug.Log ("Body");
				break;
			default:
				Debug.LogError ("Not Define Area");
				break;
			}
			//Debug.Log (_c.name);

			_c.SendMessageUpwards ("TakeDamage", _damage);
		}
	}
}
