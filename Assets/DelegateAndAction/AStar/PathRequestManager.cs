using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathRequestManager : MonoBehaviour {
	static PathRequestManager ins;
	PathFinding pathFinding;

	Queue<RequestInfo> order = new Queue<RequestInfo>();
	RequestInfo currentRequest;
	bool bProcess;

	void Awake(){
		//Debug.Log ("PathRequestManager Awake");
		ins = this;
		pathFinding = GetComponent<PathFinding> ();
	}

	public static void RequestPath(Vector3 _sp, Vector3 _ep, Action<Vector3[], bool> _cb){
		//Debug.Log ("PathRequestManager RequestPath");
		RequestInfo _request = new RequestInfo (_sp, _ep, _cb);
		ins.order.Enqueue (_request);
		ins.TryProcessNext ();
	}

	void TryProcessNext(){
		if (order.Count > 0 && !bProcess) {
			//Debug.Log ("PathRequestManager TryProcessNext");
			bProcess = true;
			currentRequest = order.Dequeue ();
			pathFinding.StartFindPath (currentRequest.startPoint, currentRequest.endPoint);
		}
	}

	public void FinishedProcessingPath(Vector3[] _wp, bool _bFind){
		//Debug.Log ("PathRequestManager FinishedProcessingPath");
		currentRequest.callback (_wp, _bFind);
		bProcess = false;
		TryProcessNext ();
	}

	public struct RequestInfo{
		public Vector3 startPoint;
		public Vector3 endPoint;
		public Action<Vector3[], bool> callback;

		public RequestInfo(Vector3 _sp, Vector3 _ep, Action<Vector3[], bool> _cb){
			//Debug.Log ("RequestInfo Constructor");
			startPoint = _sp;
			endPoint = _ep;
			callback = _cb;
		}
	}
}
