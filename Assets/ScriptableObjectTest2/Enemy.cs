using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest2{
	public class Enemy : MonoBehaviour {
		public EnemyInfoSO infoSO;
		public TextMesh text;
		float hp, speed;
		Vector3 pos;
		Quaternion rot;
		bool bRefresh;

		private void Start()
		{
			pos = transform.position;
			rot = transform.rotation;
			ResetData();
		}

		private void ResetData()
		{
			transform.position = pos;
			transform.rotation = rot;

			hp		= infoSO.health;
			speed	= infoSO.speed;

			bRefresh = true;
		}

		private void Update()
		{
			hp -= Time.deltaTime;
			transform.Translate(Vector3.forward * speed * Time.deltaTime);

			if (bRefresh)
			{
				bRefresh = false;
				text.text = infoSO.ToString();
			}
		}


		public void OnMouseDown()
		{
			ResetData();
			Debug.Log (this + ":" + infoSO.ToString ());
		}
	}
}
