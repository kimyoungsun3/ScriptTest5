using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace _GameFlowStruct
{
	public class PlayerManager : MonoBehaviour
	{
		#region singletone
		public static PlayerManager ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		public Player prefabUser;
		public List<Player> listPlayer = new List<Player>();
		public Player selectPlayer;

		private void Start()
		{
			ItemInfo.ins.Init();
		}

		public void Invoke_CreatePlayer()
		{
			//1. 생성후 리스트에 추가.
			Vector3 _pos	= new Vector3(Random.Range(-4f, +4f), Random.Range(-4f, +4f), 0);
			Quaternion _rot	= Quaternion.identity;
			Player _player	= Instantiate(prefabUser, _pos, _rot) as Player;
			_player.InitData();

			listPlayer.Add(_player);
		}

		public void Invoke_DeletePlayer()
		{	
			if (listPlayer.Count > 0)
			{
				//2. 리스트에서 삭제후 오브젝트 삭제...
				Player _player = listPlayer[listPlayer.Count - 1];
				listPlayer.Remove(_player);

				_player.DestroyUser();
			}
		}

		public void Invoke_SelectPlayer()
		{
			if (listPlayer.Count > 0)
			{
				int _index = Random.Range(0, listPlayer.Count);
				selectPlayer = listPlayer[_index];
				for (int i = 0, imax = listPlayer.Count; i < imax; i++)
				{
					listPlayer[i].ReleasePlayer();
				}
				selectPlayer.SelectPlayer();
			}
		}

		public void Invoke_Attack()
		{
			if (listPlayer.Count > 0)
			{
				selectPlayer.Attack();
			}
		}
	}
}