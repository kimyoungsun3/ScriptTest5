using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UGUI_002_ScrollRect
{
	public class Ui_ScrollView2 : MonoBehaviour
	{
		[SerializeField] List<ButtonData> listData = new List<ButtonData>();
		[SerializeField] RectTransform content;
		//[SerializeField] ContentSizeFitter contentSizeFitter;
		//[SerializeField] VerticalLayoutGroup verticalLayoutGroup;
		[SerializeField] Button prefabButton;
		[SerializeField] Vector2 offset = new Vector2(0, 5f);
		

		// Use this for initialization
		IEnumerator Start()
		{
			Button _button;
			RectTransform _rt;
			RectTransform _r = (RectTransform)prefabButton.transform;
			Debug.Log("position:" +  _r.position  + "\n"
				+ "localPosition:" + _r.localPosition + "\n"
				+ "offsetMax:" + _r.offsetMax + "\n"
				+ "offsetMin:" + _r.offsetMin + "\n"
				+ "pivot:" + _r.pivot + "\n"
				+ "sizeDelta:" + _r.sizeDelta + "\n"
				+ "anchoredPosition:" + _r.anchoredPosition + "\n"
				+ "anchorMax:" + _r.anchorMax + "\n"
				+ "anchoredPosition3D:" + _r.anchoredPosition3D + "\n"
				+ "rect:" + _r.rect + "\n"
				+ "anchorMin:" + _r.anchorMin);
			Vector2 _startPos = _r.anchoredPosition;
			Vector2 _sizeDelta = _r.sizeDelta;
			Vector2 _pos = _startPos;
			for (int i = 0, imax = listData.Count; i < imax; i++)
			{
				int _idx = i;
				_button = Instantiate(prefabButton) as Button;
				_button.onClick.AddListener(() => {
					Invoke_Message(listData[_idx]);
				});
				_button.GetComponentInChildren<Text>().text = listData[_idx].name;
				_button.transform.SetParent(content);

				_rt = (RectTransform) _button.transform;
				_rt.anchoredPosition = _pos;
				_pos.y -= (offset.y + _sizeDelta.y);
				//Debug.Log(i + ":" + _pos);
			}
			_pos.y = Mathf.Abs(_pos.y);
			content.sizeDelta = _pos;

			prefabButton.gameObject.SetActive(false);
			yield return null;

		}

		void Invoke_Message(ButtonData _data)
		{
			Debug.Log(_data.name + ":" + _data.num);
		}

	}

}