using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. File Info Read
//2. Click inventory input
//3. ....

namespace Inventory{
	public class Ui_Inventory : MonoBehaviour {
		public GameObject body;
		public Transform prefabInventory;
		public UIGrid uiGrid;
		public UIScrollView uiScrollView;
		List<Item> list = new List<Item>();
		int col = 6, row = 10;

		// Use this for initialization
		void Start () {
			ShowInventory ();
		}

		public void ShowInventory(){
			//1. create list
			int _max = row * col;
			Transform _t;
			Transform _parent = uiGrid.transform;
			for (int i = 0; i < _max; i++) {
				_t = Instantiate (prefabInventory, _parent.position, Quaternion.identity) as Transform;
				_t.SetParent (_parent);
				list.Add (_t.GetComponent<Item> ());
			}
			uiScrollView.ResetPosition ();

			//2. memory prefab destory.
			//prefabInventory.gameObject.SetActive (false);
			DestroyImmediate(prefabInventory.gameObject);
			uiGrid.Reposition ();
		}

		public void InvokeClose(){
			body.SetActive(false);
		}
		
	}
}