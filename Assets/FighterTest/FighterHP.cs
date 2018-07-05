using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterHP : MonoBehaviour {
	public float life = 100;
	bool bDead = false;

	void TakeDamage(float _damage){
		if (bDead)
			return;

		life -= _damage;
		if (!bDead && life <= 0) {
			bDead = true;
			life = 0;
		}
		Debug.Log (life);
	}
}
