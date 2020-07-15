using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UGUI_002_ScrollRect
{
	[System.Serializable]
	public class ButtonData
	{
		new public string name;
		public int num;
	}
	public class Ui_ScrollView : MonoBehaviour
	{
		[SerializeField] Button prefabButton;
		[SerializeField] RectTransform content;
		[SerializeField] List<ButtonData> listData = new List<ButtonData>();
		ContentSizeFitter contentSizeFitter;
		VerticalLayoutGroup verticalLayoutGroup;
		// Use this for initialization
		IEnumerator Start()
		{
			contentSizeFitter	= content.GetComponent<ContentSizeFitter>();
			verticalLayoutGroup = content.GetComponent<VerticalLayoutGroup>();

			Button _button;
			for (int i = 0, imax = listData.Count; i < imax; i++)
			{
				int _idx = i;
				_button = Instantiate(prefabButton) as Button;
				_button.onClick.AddListener(() => {
					Invoke_Message(listData[_idx]);
				});
				_button.GetComponentInChildren<Text>().text = listData[_idx].name;

				_button.transform.SetParent(content);
			}

			//DestroyImmediate(prefabButton.gameObject);
			prefabButton.gameObject.SetActive(false);
			contentSizeFitter.enabled = true;
			verticalLayoutGroup.enabled = true;
			yield return null;

			contentSizeFitter.enabled = false;
			verticalLayoutGroup.enabled = false;
		}

		void Invoke_Message(ButtonData _data)
		{
			Debug.Log(_data.name + ":" + _data.num);
		}

	}

}