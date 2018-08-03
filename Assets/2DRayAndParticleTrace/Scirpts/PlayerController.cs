using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager7;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DMapJump3
{
	public class PlayerController : MonoBehaviour {
		public static PlayerController ins;
		Transform trans;
		Plane plane;
		Ray ray;
		Camera cam;
		float v, h, distance;
		Vector3 move, armView, hitPoint, hitView;
		Quaternion armQua;
		public float speed = 2f;
		public SpriteRenderer bodySpriteRenderer;
		public SpriteRenderer gunSpriteRenderer;
		public Transform armPointTransform;
		public Animator gunAnimator;
		public Transform spawnPoint;
		int aniShootHash;
		public LineRenderer laserBeamLine;
		Vector3[] laserPosition;
		bool laserVisible = true;
		ParticleSystem.Burst burst = new ParticleSystem.Burst (0f, 10);

		float waitTime;
		public float WAIT_TIME = .5f;

		void Awake()
		{
			ins = this;
		}

		void Start () {
			cam 	= Camera.main;
			trans 	= transform;
			plane 	= new Plane (Vector3.back, Vector3.zero);
			aniShootHash = Animator.StringToHash ("Shoot");

			laserPosition = new Vector3[laserBeamLine.positionCount];
			for (int i = 0, iMax = laserBeamLine.positionCount; i < iMax; i++) {
				laserPosition [i] = Vector3.zero;
				//Debug.Log (i);
			}

		}

	    void Update()
	    {
			MoveCharactor ();
			RotateArm();
			Shooting ();
	    }

		void MoveCharactor(){
			//이동...
			v = Input.GetAxisRaw("Vertical");
			h = Input.GetAxisRaw("Horizontal");
			move.Set(h, v, 0);
			move = move.normalized;
			trans.Translate(move * speed * Time.deltaTime, Space.World);
		}

	    void RotateArm() {
			//방향...
			ray = cam.ScreenPointToRay(Input.mousePosition);
			if (plane.Raycast (ray, out distance)) {
				hitPoint = ray.GetPoint (distance);
				armView = hitPoint - armPointTransform.position;
				armPointTransform.rotation = Util.GetQuaternionFromDir2D (armView);

				if (armView.x < 0 && bodySpriteRenderer.flipX == false) {
					bodySpriteRenderer.flipX = true;
					gunSpriteRenderer.flipY = true;
				} else if (armView.x >= 0 && bodySpriteRenderer.flipX == true) {
					bodySpriteRenderer.flipX = false;
					gunSpriteRenderer.flipY = false;
				}

				if (laserVisible) {
					//Debug.Log (11);
					//line position
					hitView = hitPoint - spawnPoint.position;
					laserPosition [0] = spawnPoint.position;
					laserPosition [1] = hitPoint;
					laserBeamLine.positionCount = 2;
					laserBeamLine.SetPositions (laserPosition);
				}
			}


			#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Z))
			{
				EditorApplication.isPaused = !EditorApplication.isPaused;
			//}else if(Input.GetKeyDown(KeyCode.Tab)){
			//	gunCount++;
			//	if(gunCount > 10){
			//		gunCount = 1;
			//	}
			}
			#endif
	    }

		public short particleEmissionPerCount = 10;
		void Shooting(){
			//Shooting Animation
			if (Time.time > waitTime){
				if (!laserVisible) {
					//Debug.Log (12);
					laserVisible = true;
					laserBeamLine.positionCount = 0;
					laserBeamLine.gameObject.SetActive (true);
				}

				if (Input.GetMouseButton (0)) {
					waitTime = Time.time + WAIT_TIME;
					gunAnimator.SetInteger (aniShootHash, 1);
					//Quaternion _q;
					//float _angle = Util.GetAngleFromDir(dirView) - _angleTotal / 2f;

					Vector3 _p = spawnPoint.position + hitView / 2f;
					Quaternion _q = Util.GetQuaternionFromDir2D (hitView);
					float _d = hitView.magnitude;
					ParticleSystem _particle = PoolManager.ins.Instantiate ("LineEffect", _p, _q).GetComponent<ParticleSystem> ();
					var _shape = _particle.shape;					
					_shape.radius = hitView.magnitude / 2f;
					var _emission = _particle.emission;
					burst.minCount = (short)(_d * particleEmissionPerCount);
					burst.maxCount = (short)(_d * particleEmissionPerCount);
					_emission.SetBurst(0, burst);

					laserVisible = false;
					laserBeamLine.gameObject.SetActive (false);
				}
			} else if (Input.GetMouseButtonUp (0)) {
				gunAnimator.SetInteger (aniShootHash, 0);
			}
		}
	}
}