using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UGUIPattern{
	public class LockPattern : MonoBehaviour {
		public GameObject prefabTest;
		public GameObject prefabCircle;
		public int count = 9;
		public Dictionary<int, Circle> dicCircle = new Dictionary<int, Circle>();
		bool unLocking = false;

		public GameObject prefabLine;
		public Canvas canvas;
		public List<Circle> listLine = new List<Circle> ();

		// Use this for initialization
		void Start () {
			DestroyImmediate (prefabTest);
			GameObject _go;
			Circle _circle;
			EventTrigger _trigger;
			for (int i = 0; i < count; i++) {
				_go = Instantiate (prefabCircle, transform);
				_circle = _go.GetComponent<Circle> ();
				_circle.id = i;
				_circle.name += i.ToString ();

				_trigger = _go.GetComponent<EventTrigger> ();
				_trigger.AddListener( EventTriggerType.PointerEnter, OnMouseEnterCircle);
				_trigger.AddListener( EventTriggerType.PointerExit, OnMouseExitCircle);
				_trigger.AddListener( EventTriggerType.PointerDown, OnMouseDownCircle);
				_trigger.AddListener( EventTriggerType.PointerUp, OnMouseUpCircle);


				dicCircle.Add (_circle.id, _circle);
			}			
		}

		public void OnMouseEnterCircle(PointerEventData data){
			Circle _c = data.pointerEnter.GetComponent<Circle>();
			Debug.Log ("OnMouseEnterCircle:" + _c.id);
		}

		public void OnMouseExitCircle(PointerEventData data){
			Circle _c = data.pointerEnter.GetComponent<Circle>();
			Debug.Log ("OnMouseExitCircle:" + _c.id);
		}

		public void OnMouseDownCircle(PointerEventData data2){
			Circle _c = data2.pointerEnter.GetComponent<Circle>();
			Debug.Log ("OnMouseDownCircle:" + _c.id);
			unLocking = true;

			CreateLine (_c.transform.localPosition, _c.id);
		}

		GameObject CreateLine(Vector3 _localPos, int _id){
			GameObject _go = Instantiate (prefabLine, canvas.transform);
			_go.transform.localPosition = _localPos;
			Circle _c = _go.GetComponent<Circle> ();
			_c.id = _id;

			listLine.Add (_c);

			return _go;
		}

		public void OnMouseUpCircle(PointerEventData data){
			Circle _c = data.pointerEnter.GetComponent<Circle>();
			Debug.Log ("OnMouseUpCircle:" + _c.id);
			unLocking = false;
		}

		//public static void AddListener( EventTrigger trigger, EventTriggerType _type, System.Action<PointerEventData> _on )
		//{
		//	//EventTrigger trigger = _go.GetComponent<EventTrigger>();
		//	EventTrigger.Entry entry = new EventTrigger.Entry();
		//	entry.eventID = _type;
		//	entry.callback.AddListener ((data) => { _on((PointerEventData)data); });
		//	trigger.triggers.Add(entry);
		//	//EventTrigger trigger = _go.GetComponent<EventTrigger>();
		//	//EventTrigger.Entry entry = new EventTrigger.Entry();
		//	//entry.eventID = EventTriggerType.PointerDown;
		//	//entry.callback.AddListener((data) => { OnMouseUpCircle((PointerEventData)data); });
		//	//trigger.triggers.Add(entry);
		//}


	}
}
