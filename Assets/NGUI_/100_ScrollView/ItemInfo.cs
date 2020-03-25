using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_ScrollView
{
	public class ItemInfo : MonoBehaviour
	{

		string strName;
		Transform trans;
		[SerializeField] UISprite sprite;
		[SerializeField] UILabel label;

		public void SetInit(string _name)
		{
			trans	= transform;
			strName = _name;

			sprite.spriteName = _name;
			label.text = _name;
		}
	}
}
