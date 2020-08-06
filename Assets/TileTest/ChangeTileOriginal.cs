using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace _TileTest
{
	public class ChangeTileOriginal : MonoBehaviour
	{


		public Tile tile;
		public Tilemap tilemap;

		private Vector3Int previous;

		// do late so that the player has a chance to move in update if necessary
		private void LateUpdate()
		{
			// get current grid location
			Vector3Int _current = tilemap.WorldToCell(transform.position);
			// add one in a direction (you'll have to change this to match your directional control)
			//_current.x += 1;
			//_current.y += 1;

			// if the position has changed
			if (_current != previous)
			{
				// set the new tile
				tilemap.SetTile(_current, tile);

				// erase previous
				tilemap.SetTile(previous, null);

				// save the new position for next frame
				previous = _current;
			}
		}
	}

}