// 2016 - Damien Mayance (@Valryon)
// Source: https://github.com/valryon/water2d-unity/
using UnityEngine;


namespace Water2DSuface
{
	[ExecuteInEditMode]
	public class Water2DScript : MonoBehaviour
	{
		[SerializeField] Vector2 m_Speed = new Vector2(0.01f, 0f);
		[SerializeField] int m_SortingLayerID;
		[SerializeField] int m_SortingOrder;
		Renderer renderer;
		Material material;

		void Awake()
		{
			Init();
		}

		void Init()
		{
			renderer = GetComponent<Renderer>();
			if (Application.isEditor)
				material = renderer.sharedMaterial;
			else
				material = renderer.material;

			renderer.sortingLayerID = m_SortingLayerID;
			renderer.sortingOrder = m_SortingOrder;
		}

		void LateUpdate()
		{
			WaterWave();
		}

		void WaterWave()
		{
			Vector2 scroll = Time.deltaTime * m_Speed;
			material.mainTextureOffset += scroll;
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			if (renderer == null)
				Init();
			WaterWave();
		}
#endif
	}
}