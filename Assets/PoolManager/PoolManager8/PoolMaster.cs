using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM6;
using SoundManager8;
using PoolManager8;


namespace PoolManager8
{
	public class PoolMaster : MonoBehaviour
	{
		protected Transform trans;

		public virtual void Awake()
		{
			trans = transform;
		}

		public virtual void Init(int _loop) {
		}

		public virtual void Destroy()
		{
			gameObject.SetActive(false);
		}

		//총알들...
		public virtual void Seek(Transform _target, float _damage, float _radius = 0f)
		{

		}
	}
}