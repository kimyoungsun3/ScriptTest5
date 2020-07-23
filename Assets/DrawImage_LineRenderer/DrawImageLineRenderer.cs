using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace DrawImageLineRendererTest
{
	[System.Serializable]
	public struct LineInfo
	{
		public Color currentColor;
		public float width;
	}

	public class DrawImageLineRenderer : MonoBehaviour {
		[SerializeField] LineRendererInfo line;
		[SerializeField] LineInfo lineInfo;
		Camera camera;
		Vector3 pos;
		Plane board;
		LineRendererInfo currentLine;
		[SerializeField] List<LineRendererInfo> list = new List<LineRendererInfo>();

		// Use this for initialization
		void Start() {
			camera = Camera.main;
			board = new Plane(-camera.transform.forward, Vector3.zero);
		}

		public void Invoke_Clear()
		{
			for(int i = 0, imax = list.Count; i < imax; i++)
			{
				list[i].Destroy();
			}
			list.Clear();
		}

		public void Invoke_Undo()
		{
			if (list.Count > 0) {
				int _idx = list.Count - 1;

				list[_idx].Destroy();				

				list.RemoveAt(_idx);
			}
		}

		public void Invoke_Color(Image _image)
		{
			lineInfo.currentColor = _image.color;
		}

		public void Inovke_Thick(Slider _slider)
		{
			//Debug.Log(_slider.value);
			lineInfo.width = _slider.value;
		}

		public void Invoke_ActiveObject()
		{
			if(currentLine != null)
				currentLine.SetActiveObject();
		}

		// Update is called once per frame
		void Update() {
			if (EventSystem.current.IsPointerOverGameObject()) return;
			

			if (Input.GetMouseButtonDown(0))
			{
				Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
				float _distance;
				if (board.Raycast(_ray, out _distance))
				{
					pos = _ray.GetPoint(_distance);
					currentLine = Instantiate(line, Vector3.zero, Quaternion.identity) as LineRendererInfo;
					currentLine.InitData(lineInfo);
					currentLine.SetPosition(pos);
					list.Add(currentLine);
				}
			}
			else if (currentLine && Input.GetMouseButton(0))
			{
				Ray _ray = camera.ScreenPointToRay(Input.mousePosition);
				float _distance;
				if (board.Raycast(_ray, out _distance))
				{
					pos = _ray.GetPoint(_distance);
					currentLine.SetPosition(pos);
				}
			}
		}
	}
}