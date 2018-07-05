using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GPURendering{
	public class ObjData{
		public Vector3 pos;
		public Vector3 scale;
		public Quaternion rot;
		Vector3 dir;

		public Matrix4x4 matrix{
			get{
				pos += dir * Time.deltaTime;
				return Matrix4x4.TRS (pos, rot, scale);
			}
		}

		public ObjData(Vector3 _pos, Vector3 _scale, Quaternion _rot){
			int r = Random.Range (0, 3);
			if (r <= 0) {
				dir = Vector3.forward;
			}else if( r <= 1){
				dir = Vector3.up;
			}else{
				dir = Vector3.down;
			}
			
			pos = _pos;
			scale = _scale;
			rot = _rot;
		}
	}

	public class SpawnerGPU : MonoBehaviour {
		public int instances = 1000;
		public Vector3 maxPos = new Vector3 (200, 200, 200);
		public Mesh objMesh;
		public Material objMat;
		Matrix4x4 m;
		List<List<ObjData>> batches = new List<List<ObjData>>();

		// Use this for initialization
		void Start () {
			int batchIndexNum = 0;
			List<ObjData> curBatch = new List<ObjData> ();
			for (int i = 0; i < instances; i++) {
				AddObj (curBatch, i);
				batchIndexNum++;
				if (batchIndexNum >= 1000) {
					batches.Add (curBatch);
					curBatch = BuildNewBatch ();
					batchIndexNum = 0;
				}
			}			
		}

		
		// Update is called once per frame
		void Update () {
			RenderBatches ();
		}

		void AddObj(List<ObjData> _curBatch, int i){
			Vector3 pos = new Vector3 (Random.Range (-maxPos.x, maxPos.x),
				              Random.Range (-maxPos.y, maxPos.y),
				              Random.Range (-maxPos.z, maxPos.z));
			_curBatch.Add (new ObjData (pos, new Vector3 (2, 2, 2), Quaternion.identity));
		}

		List<ObjData> BuildNewBatch(){
			return new List<ObjData> ();
		}

		void RenderBatches(){
			foreach (var batch in batches) {
				Graphics.DrawMeshInstanced (objMesh, 0, objMat, batch.Select ((a) => a.matrix).ToList ());
			}
		}
	}

}