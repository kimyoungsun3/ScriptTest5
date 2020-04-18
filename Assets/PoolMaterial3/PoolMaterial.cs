using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoolMaterial3{
	[System.Serializable]
	public class MaterialData{
		public bool bUsing;
		public Material material, orgMaterial;
		public MaterialData(Material _new, Material _org){
			bUsing 		= false;
			material	= _new;
			orgMaterial = _org;
		}

		Renderer renderer;
		public void SetColor(Renderer _renderer, Color _color)
		{
			bUsing					= true;
			renderer				= _renderer;
			renderer.sharedMaterial = material;
			material.color			= _color;
		}

		public void Release()
		{
			bUsing = false;
			if (renderer != null)
				renderer.sharedMaterial = orgMaterial;			
		}
	}

	public class PoolMaterial : MonoBehaviour {
		#region singletone
		public static PoolMaterial ins;
		void Awake(){
			ins = this;
		}
		#endregion

		Dictionary<Material, Queue<MaterialData>> dic_Pools = new Dictionary<Material, Queue<MaterialData>>();

		public void RegisterMaterial(Renderer _renderer)
		{
			if (_renderer != null)
			{
				Material _sharedMaterial = _renderer.sharedMaterial;
				if (!dic_Pools.ContainsKey(_sharedMaterial))
				{
					RegisterMaterial(_sharedMaterial, 5);
				}
			}
		}

		//Material Init...
		void RegisterMaterial(Material _sharedMaterial, int _count = 5){
			if (!dic_Pools.ContainsKey (_sharedMaterial)) {
				//Debug.Log (_srcSharedMaterial);
				//register queue Material...
				Queue<MaterialData> _q = new Queue<MaterialData> ();
				dic_Pools.Add (_sharedMaterial, _q);

				//create material...
				Material _m;
				for(int i = 0; i < _count; i++){
					_m = new Material (_sharedMaterial);
					_q.Enqueue (new MaterialData (_m, _sharedMaterial));
				}
			//}else {
			//	Debug.LogError ("이미 똑같은 것이 등록 되었다...");
			}
		}

		//public void EndMaterial(MaterialData _md)
		//{
		//	_md.bUsing = false;
		//}

		public void ClearMaterial(Material _sharedMaterial){
			if (!dic_Pools.ContainsKey (_sharedMaterial)) {
				return;
			}

			Queue<MaterialData> _q	= dic_Pools[_sharedMaterial];
			MaterialData _md		= null;
			for (int i = 0, imax = _q.Count; i < imax; i++) {
				_md = _q.Dequeue ();
				_md.Release();
				_q.Enqueue (_md);
			}
		}

		//1f	-> 1개정도로 커버됨...
		//.5f 	-> 3개정도 필요...
		public MaterialData GetMaterial(Renderer _renderer)
		{
			return GetMaterial(_renderer.sharedMaterial);
		}

		MaterialData GetMaterial(Material _sharedMaterial){
			if (!dic_Pools.ContainsKey (_sharedMaterial)) {
				Debug.LogError ("Material not register...");
				return null;
			}
			Queue<MaterialData> _q = dic_Pools[_sharedMaterial];
			//Debug.Log ("dicPools:" + dicPools.Count
			//	+ " queueMat:" + queueMat.Count
			//);

			MaterialData _md	= null;
			bool _bFind			= false;
			//큐에서 찾기....
			for (int i = 0, imax = _q.Count; i < imax; i++) {
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
				Material _newMaterial = new Material(_sharedMaterial);
				_md = new MaterialData (_newMaterial, _sharedMaterial);
				_q.Enqueue (_md);
			}
			_md.bUsing = true;
			return _md;
		}
	}


}