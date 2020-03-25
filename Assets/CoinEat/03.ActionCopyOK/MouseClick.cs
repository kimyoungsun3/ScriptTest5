using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace CoinEat03
{
	public class MouseClick : MonoBehaviour {
		public System.Action onAllEat;
		[SerializeField] Transform target;

		private void Start()
		{
			if (target == null)
				target = transform;
		}

		float timer;
		[SerializeField] float SPAWN_NEXT_TIME = 0.1f;
		void Update () {
			if (Input.GetMouseButton(0) && Time.time > timer )
			{
				timer = Time.time + SPAWN_NEXT_TIME;
				Spawn_GameObject(0);
			}
			else if (Input.GetMouseButtonDown(1))
			{
				if(onAllEat != null)
				{
					onAllEat();
				}
			}
		}


		void Spawn_GameObject(int _idx)
		{
			Vector3 _pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_pos.z = 0;
			CoinEat _scp = PoolManager.ins.Instantiate("Coin_SmoothDamp", _pos, Quaternion.identity).GetComponent<CoinEat>();

			//Debug.Log(_scp);
			if (_scp != null)
			{
				//Debug.Log(1 +":" + onAllEat);
				_scp.SetTarget(target, this);
				//Debug.Log(2 + ":" + onAllEat);
			}
		}
	}
}
