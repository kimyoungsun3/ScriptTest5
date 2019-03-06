using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectTest22
{
	public class Enemy : MonoBehaviour
	{
		public EnemyInfo enemyInfo;
		float hp;
		Vector3 pos;
		Quaternion rot;
		[HideInInspector] public Transform trans;

		void Start()
		{
			pos = transform.position;
			rot = transform.rotation;
			trans = transform;

			RestorePos();
		}

		void RestorePos()
		{
			transform.position = pos;
			transform.rotation = rot;

			hp = enemyInfo.hp;
		}

		void Update()
		{
			enemyInfo.UpdateState(this);
			//transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}

		private void OnMouseDown()
		{
			RestorePos();
		}
	}
}