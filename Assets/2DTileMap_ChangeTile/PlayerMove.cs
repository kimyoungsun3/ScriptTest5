using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _TileTest
{
	public class PlayerMove : MonoBehaviour
	{
		[SerializeField] float speed = 2f;
		[SerializeField] Vector3 offset = new Vector3(1, 1, 0);
		Transform trans;
		Vector3 dir;
		ChangeTile changeTile;

		void Start()
		{
			trans = transform;
			changeTile = GetComponent<ChangeTile>();
		}

		// Update is called once per frame
		void Update()
		{
			float _v = Input.GetAxisRaw("Vertical");
			float _h = Input.GetAxisRaw("Horizontal");
			bool _bChangeTile = Input.GetKeyDown(KeyCode.C);
			dir.Set(_h, _v, 0);

			trans.Translate(dir.normalized * speed * Time.deltaTime);

			//if (_bChangeTile)
			{
				if(_h != 0)	offset.x = Mathf.Sign(_h);
				changeTile.ChangeTileData(trans.position + offset);
			}
			
		}
	}
}