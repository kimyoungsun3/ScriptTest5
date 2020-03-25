using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace CoinEat02{
	public class MouseClick : MonoBehaviour {
		System.Action onAllEat;
		[SerializeField] Transform target;

		private void Start()
		{
			onAllEat = () => { };
		}

		void Update () {
			if (Input.GetMouseButtonDown(0))
			{
				Spawn_GameObject(0);
			}
			else if (Input.GetMouseButtonDown(1))
			{
				Debug.Log(onAllEat);
				if(onAllEat != null)
				{
					Debug.Log(onAllEat);
					onAllEat();
				}
			}
		}


		void Spawn_GameObject(int _idx)
		{
			Vector3 _pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_pos.z = 0;
			CoinEat _scp = PoolManager.ins.Instantiate("Coin_SmoothDamp", _pos, Quaternion.identity).GetComponent<CoinEat>();
			if (_scp != null)
			{
				Debug.Log(1 +":" + onAllEat + ":" + _scp);
				_scp.SetTarget(target.position,ref onAllEat);
				Debug.Log(2 + ":" + onAllEat);
			}
		}
	}
}
