using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _TileTest
{
	public class ChangeTile : MonoBehaviour
	{
		[SerializeField] Tilemap tilemap;
		[SerializeField] Tile tile;
		Vector3Int previous;


		public void ChangeTileData(Vector3 _worldPos, bool _beforeClear = true)
		{
			Vector3Int _current = tilemap.WorldToCell(_worldPos);

			if(_current != previous)
			{
				//현재 위치에 타일교체하기...
				tilemap.SetTile(_current, tile);
				if (_beforeClear)
				{
					tilemap.SetTile(previous, null);
				}					

				previous = _current;
			}
		}
	}
}