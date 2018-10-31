using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterial2{
	[System.Serializable]
	public class MaterialData{
		public bool bUsing;
		public Material material;
		public MaterialData(Material _m){
			bUsing 	= false;
			material= _m;
		}

		public void SetColor(Color _color){
			material.color = _color;
		}

		public void Release(){
			bUsing = false;
		}
	}

	public class PoolMaterial : MonoBehaviour {
		public static PoolMaterial ins;
		Dictionary<Material, Queue<MaterialData>> dicPools = new Dictionary<Material, Queue<MaterialData>>();
		public int count;
		void Awake(){
			ins = this;
		}

		public MaterialData RegisterMaterial(Renderer _renderer){
			MaterialData _data = null;
			if ( _renderer != null ) {
				Material _material = _renderer.sharedMaterial;
				RegisterMaterial (_material, 5);
				_data = GetMaterial (_material);
				_renderer.sharedMaterial = _data.material;
			}
			return _data;
		}

		//Material Init...
		public void RegisterMaterial(Material _sharedMaterial, int _count = 5){
			if (!dicPools.ContainsKey (_sharedMaterial)) {
				//Debug.Log (_srcSharedMaterial);
				//register queue Material...
				Queue<MaterialData> _q = new Queue<MaterialData> ();
				dicPools.Add (_sharedMaterial, _q);

				//create material...
				Material _m;
				for(int i = 0; i < _count; i++){
					_m = new Material (_sharedMaterial);
					_q.Enqueue (new MaterialData (_m));
				}
			//}else {
			//	Debug.LogError ("이미 똑같은 것이 등록 되었다...");
			}
		}

		//public void EndMaterial (MaterialData _md){
		//	_md.bUsing = false;
		//}

		public void ClearMateril(Material _srcMaterial){
			if (!dicPools.ContainsKey (_srcMaterial)) {
				return;
			}

			Queue<MaterialData> _q = dicPools[_srcMaterial];
			MaterialData _md = null;
			for (int i = 0, iMax = _q.Count; i < iMax; i++) {
				_md = _q.Dequeue ();
				_q.Enqueue (_md);
				_md.Release ();
			}
		}

		//1f	-> 1개정도로 커버됨...
		//.5f 	-> 3개정도 필요...
		public MaterialData GetMaterial(Material _srcMaterial){
			if (!dicPools.ContainsKey (_srcMaterial)) {
				Debug.LogError ("Material not register...");
				return null;
			}
			Queue<MaterialData> _q = dicPools[_srcMaterial];
			//Debug.Log ("dicPools:" + dicPools.Count
			//	+ " queueMat:" + queueMat.Count
			//);

			MaterialData _md = null;
			int _len = _q.Count;
			bool _bFind = false;

			//큐에서 찾기....
			for (int i = 0; i < _len; i++) {
				_md = _q.Dequeue ();
				_q.Enqueue (_md);
				if (!_md.bUsing) {
					//Debug.Log ("Find -> " + i + " t:" + queueMat.Count);
					_bFind = true;
					break;
				}
			}

			//못찾으면~~~ 신규로 생성....
			if (!_bFind) {
				//Debug.Log ("not found create");
				_md = new MaterialData (_md.material);
				_q.Enqueue (_md);
			}
			count = _q.Count;
			_md.bUsing = true;
			return _md;
		}
	}


}