using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Water2DSuface
{
	public class Fish : MonoBehaviour
	{
		[SerializeField] SpriteAtlas atlas;
		[SerializeField] List<string> listNames = new List<string>();
		int index = 0;
		SpriteRenderer renderer;
		float nextTime;
		[SerializeField] float NEXT_TIME = .5f;

		private void Start()
		{
			renderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			if (Time.time > nextTime)
			{
				nextTime = Time.time + NEXT_TIME;
				index = (index + 1) % listNames.Count;
				Sprite _sprite = atlas.GetSprite(listNames[index]);
				if(_sprite != null)
				{
					renderer.sprite = _sprite;
				}				
			}
		}


	}
}
