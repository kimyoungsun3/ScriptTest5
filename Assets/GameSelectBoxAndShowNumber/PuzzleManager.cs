using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _GameSelectBox
{
	public class PuzzleManager : MonoBehaviour
	{
		#region singleton
		public static PuzzleManager ins;
		private void Awake()
		{
			ins = this;
		}
		#endregion

		public PuzzleNumber prefabPuzzleNumber;
		public PuzzleBox prefabPuzzleBox;
		public List<int> list_NumberMaster			= new List<int>();
		public List<Transform> list_SpawnNumber	= new List<Transform>();//생성자리...
		public List<Transform> list_SpawnBox	= new List<Transform>();

		//생성된것....
		List<int> list_NumberSelect				= new List<int>();
		List<PuzzleNumber> list_PuzzleNumber	= new List<PuzzleNumber>();
		List<PuzzleBox> list_PuzzleBox			= new List<PuzzleBox>();
		public Color oppsiteColor, wrongColor;
		public float waitTime = 0.3f;
		bool bReset;

		private void Start()
		{
			//박스의 위치를 바꿔서 셔플한다.
			//생성되기전에 위치 생성을 바꿔버린다.
			//Shuffle_SpawnBox();

			
			for (int i = 0; i < list_NumberMaster.Count; i++)
			{
				//puzzle number
				PuzzleNumber _scpPuzzleNumber = Instantiate(prefabPuzzleNumber, list_SpawnNumber[i].position, Quaternion.identity) as PuzzleNumber;
				_scpPuzzleNumber.SetInit(list_NumberMaster[i]);
				_scpPuzzleNumber.transform.SetParent(transform);
				list_PuzzleNumber.Add(_scpPuzzleNumber);


				//puzzlebox
				PuzzleBox _scpPuzzleBox = Instantiate(prefabPuzzleBox, list_SpawnBox[i].position, Quaternion.identity) as PuzzleBox;
				_scpPuzzleBox.SetInit(list_NumberMaster[i]);
				_scpPuzzleBox.transform.SetParent(transform);
				list_PuzzleBox.Add(_scpPuzzleBox);
			}
		}

		//void Shuffle_SpawnBox()
		//{
		//	int _count = list_SpawnBox.Count;
		//	Transform _temp;
		//	int _rand;
		//	for (int i = 1; i < _count; i++)
		//	{
		//		_rand = Random.Range(i, _count);

		//		_temp					= list_SpawnBox[i - 1];
		//		list_SpawnBox[i - 1]	= list_SpawnBox[_rand];
		//		list_SpawnBox[i - 1]	= _temp;
		//	}
		//}

		public void CheckNumber(int _number)
		{
			List<int> _listMaster	= list_NumberMaster;
			List<int> _listSelect	= list_NumberSelect;
			List<PuzzleBox> _list	= list_PuzzleBox;

			//Debug.Log("전달받은 번호 : " + _number);
			_listSelect.Add(_number);
			int _index			= _listSelect.Count - 1;
			int _numberOriginal = _listMaster[_index];


			//1. 두숫자가 같은가? 색변경하기..
			if (_number == _numberOriginal)
			{
				_list[_index].SetColor(oppsiteColor, true);
			}
			else
			{
				_list[_index].SetColor(wrongColor, false);
			}

			//만약 지정된수(6)개를 다 입력되면....
			if (_list.Count == _listSelect.Count)
			{
				//전수 검사를 실시합니다.
				bool _bOk = true;
				for (int i = 0; i < _list.Count; i++)
				{
					if (_list[i].bOk == false)
					{
						_bOk = false;
						break;
					}
				}
				_listSelect.Clear();

				//하나라도 틀리면 .... >> 아무것도 안함...
				if (_bOk)
				{
					Debug.Log("All Clear");
					//그대로 둔다...
				}
				else
				{
					//잠시 대기후에 클리어해준다.
					if (bReset == false)
					{
						StartCoroutine(Co_WaitAndRestore(_list));
					}
					
				}
			}
		}

		IEnumerator Co_WaitAndRestore(List<PuzzleBox> _list)
		{
			bReset = true;
			yield return new WaitForSeconds(waitTime);

			for (int i = 0; i < _list.Count; i++)
			{
				_list[i].Reset();
			}

			bReset = false;
		}
	}
}