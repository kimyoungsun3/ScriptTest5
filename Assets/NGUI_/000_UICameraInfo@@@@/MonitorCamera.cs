using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGUI_001_UICameraInfo
{
	public class MonitorCamera : MonoBehaviour
	{
		void OnHover(bool _isOver){		Debug.Log(this + " OnHover _isOver:" + _isOver);	}
		void OnPress(bool _isDown){		Debug.Log(this + "OnPress _isDown:" + _isDown);		}
		void OnSelect(bool selected){	Debug.Log(this + "OnSelect selected:" + selected);	}
		void OnClick()	{				Debug.Log(this + " OnClick");		}
		void OnDoubleClick(){			Debug.Log(this + " OnDoubleClick");		}

		//-------------------------------
		void OnDragStart()	{			Debug.Log(this + " OnDragStart");		}
		void OnDrag(Vector2 delta){		Debug.Log(this + " OnDrag delta:" + delta);	}
		void OnDragOver(object draggedObject){Debug.Log(this + " OnDragOver draggedObject:" + draggedObject);	}
		void OnDragOut(object draggedObject){Debug.Log(this + " OnDragOut draggedObject:" + draggedObject);}
		void OnDragEnd(){				Debug.Log(this + " OnDragEnd");		}

		//----------------------------------------
		void OnTooltip(bool show){		Debug.Log(this + " OnTooltip show:" + show);}
		void OnScroll(float delta){		Debug.Log(this + " OnScroll delta:" + delta);	}
		void OnNavigate(KeyCode key){	Debug.Log(this + " OnNavigate key:" + key);		}
		void OnPan(Vector2 delta){		Debug.Log(this + " OnPan delta:" + delta);		}
		void OnKey(KeyCode key)	{		Debug.Log(this + " OnKey key:" + key);		}
	}
}
