using UnityEngine;



namespace Water2DSuface
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class Water2DReflect : MonoBehaviour
	{

		[SerializeField] Vector3 localPosition = new Vector3(0, -0.25f, 0);
		[SerializeField] Vector3 localRotation = new Vector3(0, 0, -180);
		public Sprite sprite;
		public string spriteLayer = "Default";
		public int spriteLayerOrder = -5;

		public void Editor_MakeUnderWater()
		{
			string _name = "WaterReflect";
			Transform _wr = transform.Find(_name);
			if (_wr)
			{
				DestroyImmediate(_wr.gameObject);
			}
			GameObject _go = new GameObject(_name);
			_go.transform.SetParent(transform);
			_go.transform.localPosition = localPosition;
			_go.transform.localRotation = Quaternion.Euler(localRotation);
			_go.transform.localScale	= transform.localScale;
			
			SpriteRenderer _myRenderer	= GetComponent<SpriteRenderer>();
			SpriteRenderer _newRenderer = _go.AddComponent<SpriteRenderer>();

			_newRenderer.sprite = (sprite) ? sprite: _myRenderer.sprite;
			_newRenderer.color = _myRenderer.color;
			_newRenderer.flipX = _myRenderer.flipX;
			_newRenderer.flipY = _myRenderer.flipY;
			_newRenderer.sortingLayerName	= spriteLayer;
			_newRenderer.sortingOrder		= spriteLayerOrder;
		}
	}
}