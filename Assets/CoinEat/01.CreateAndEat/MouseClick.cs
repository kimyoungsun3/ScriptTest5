using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;

namespace CoinEat01
{
	public class MouseClick : MonoBehaviour {
		[SerializeField] int IMAX = 10;
		public tk2dCamera tk2dcam;
		public Transform target;
		public List<GameObject> list = new List<GameObject>();
		System.Action onAllEat;

		private void Start()
		{
			if(target == null)
			{
				target = transform;
			}
		}

		void Update () {
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				Spawn_GameObject(0);
			}
			else if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				Spawn_GameObject(1);
			}

			if (Input.GetMouseButtonDown(0))
			{
				if(onAllEat != null)
				{
					onAllEat();
				}
			}
		}


		void Spawn_GameObject(int _idx)
		{
			//float _h = Camera.main.orthographicSize;
			//float _w = Camera.main.orthographicSize * Camera.main.aspect;
			float _h = tk2dcam.nativeResolutionWidth/2f - 30;
			float _w = tk2dcam.nativeResolutionHeight/ 2f - 30;

			Vector3 _pos = tk2dcam.transform.position;
			Vector3 _min = new Vector3(_pos.x - _w, _pos.y - _h, 0);
			Vector3 _max = new Vector3(_pos.x + _w, _pos.y + _h, 0);
			_pos.z = 0;
			//Debug.Log(_min + ":" + _max);

			onAllEat = null;
			for (int i = 0; i < IMAX; i++)
			{
				_pos.x = Random.Range(_min.x, _max.x);
				_pos.y = Random.Range(_min.y, _max.y);

				CoinEat _scp = PoolManager.ins.Instantiate(list[_idx], _pos, Quaternion.identity).GetComponent<CoinEat>();
				if (_scp != null)
				{
					_scp.SetTarget(target.position);
					onAllEat += _scp.SetAlive;
				}
			}
		}
	}
}
