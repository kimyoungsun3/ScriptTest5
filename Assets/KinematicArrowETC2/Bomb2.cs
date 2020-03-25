using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicArrowETC2{
	public class Bomb2 : MonoBehaviour {
		//public Transform target;
		//public 
		float startTime;
		Transform trans;

		[SerializeField] float journeyPerDistance = 2f;
		float journeyTime;
		Vector3 posStart, posEnd, posBefore;
		Vector3 posStartOrigin;
		Vector3 scaleOrigin;
		[SerializeField] float zDepth = 50f;
		[SerializeField] float maxSize = 4f;
		[SerializeField] ParticleSystem effect;

		//void Start(){
		//
		//}

		public void SetData(Vector3 _posStart, Vector3 _posEnd)
		{	
			
			startTime	= Time.time;
			trans		= transform;

			posStart		= _posStart;
			posEnd			= _posEnd;
			posBefore		= _posStart;
			posStartOrigin	= posStart;
			scaleOrigin		= transform.localScale;

			float _distance = Vector3.Distance(_posStart, _posEnd);
			journeyTime		= _distance / journeyPerDistance;
				

			//Debug.Log(_distance + " >> " + journeyTime);
		}
	 	  
	    void Update() {
			float _distance = Vector3.Distance(trans.position, posEnd);
			if (_distance < 0.1f)
			{
				ParticleSystem _ps = Instantiate(effect, trans.position, Quaternion.identity) as ParticleSystem;
				_ps.Play();
				Destroy(_ps.gameObject, _ps.main.duration);

				Destroy(gameObject);
				return;
			}

			//z move
			Vector3 _center = (posStart + posEnd) * 0.5f;
			_center -= Vector3.forward;

			Vector3 _dirStart 	= posStart - _center;
			Vector3 _dirEnd 	= posEnd - _center;

			float _fracComplete = (Time.time - startTime) / journeyTime;
			trans.position = Vector3.Slerp (_dirStart, _dirEnd, _fracComplete);
			trans.position += _center;

			//Image Direction
			trans.rotation = GetQuaternionFromDir2D(trans.position - posBefore);
			posBefore = trans.position;

			//Image size
			float _gap = Mathf.Abs(trans.position.z - posStartOrigin.z);
			float _size = Mathf.Lerp(1f, maxSize, _gap / zDepth);
			trans.localScale = scaleOrigin * _size;

		}

		public Quaternion GetQuaternionFromDir2D(Vector3 _viewDir)
		{
			//float _angle = Mathf.Atan2 (_dir.y, _dir.x) * Mathf.Rad2Deg;
			//	Quaternion _q = Quaternion.Euler (Vector3.forward * _angle);
			//	return _q;
			return Quaternion.Euler(0, 0, Mathf.Atan2(_viewDir.y, _viewDir.x) * Mathf.Rad2Deg);
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Vector3 _pos	= transform.position;
			Vector3 _right	= transform.right * 5;
			Vector3 _up		= transform.up * 5;
			Vector3 _forward = transform.forward * 5;

			Debug.DrawRay(_pos, _right, Color.red);
			Debug.DrawRay(_pos, _up, Color.green);
			Debug.DrawRay(_pos, _forward, Color.blue);
		}
#endif
	}
}