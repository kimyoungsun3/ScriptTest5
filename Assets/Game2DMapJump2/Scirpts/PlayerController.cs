using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PoolManager7;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DMapJump2
{
	public class PlayerController : MonoBehaviour {
		public static PlayerController ins;
		Transform trans;
		Plane plane;
		Ray ray;
		Camera cam;
		float v, h, distance;
		Vector3 move, dirView;
		public float speed = 2f;
		public SpriteRenderer bodySpriteRenderer;
		public SpriteRenderer gunSpriteRenderer;
		public Transform armPointTransform;
		public Animator gunAnimator;
		public Transform spawnPoint;
		int aniShootHash;

		float waitTime;
		public float WAIT_TIME = .05f;
		

		void Awake()
		{
			ins = this;
		}

		void Start () {
			cam = Camera.main;
			trans = transform;
			plane = new Plane (Vector3.back, Vector3.zero);
			aniShootHash = Animator.StringToHash ("Shoot");
		}

	    void Update()
	    {

			MoveCharactor ();
			RotateArm();
			Shooting ();
	    }

		
		public void InvokeLoad()
		{
			Scene _currentScene = SceneManager.GetActiveScene();
			Debug.Log(SceneManager.sceneCount + ":" + _currentScene.buildIndex);
			int _idx = _currentScene.buildIndex + 1;
			if (_idx > SceneManager.sceneCount)
				_idx = 0;
			SceneManager.LoadScene(_idx, LoadSceneMode.Single);
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
			if (plane.Raycast(ray, out distance)){
				dirView = ray.GetPoint (distance) - armPointTransform.position;
				armPointTransform.rotation = Util.GetQuaternionFromDir2D (dirView);

				if (dirView.x < 0 && bodySpriteRenderer.flipX == false) {
					bodySpriteRenderer.flipX = true;
					gunSpriteRenderer.flipY = true;
				} else if (dirView.x >= 0 && bodySpriteRenderer.flipX == true) {
					bodySpriteRenderer.flipX = false;
					gunSpriteRenderer.flipY = false;
				}
			}


			#if UNITY_EDITOR
			if (Input.GetKeyDown(KeyCode.Z))
			{
				EditorApplication.isPaused = !EditorApplication.isPaused;
			}else if(Input.GetKeyDown(KeyCode.Tab)){
				gunCount++;
				if(gunCount > 10){
					gunCount = 1;
				}
			}
			#endif
	    }

		[Range(1, 10)] public int gunCount = 1;
		public float gunAngleStep = 5f;
		void Shooting(){
			//Shooting Animation
			if (Time.time > waitTime && Input.GetMouseButton (0)) {
				waitTime = Time.time + WAIT_TIME;
				gunAnimator.SetInteger (aniShootHash, 1);
				Quaternion _q;
				float _angleTotal = (gunCount - 1) * gunAngleStep;
				float _angle = Util.GetAngleFromDir(dirView) - _angleTotal / 2f;

				for (int i = 0; i < gunCount; i++) {
					_q = Quaternion.Euler (0, 0, _angle);
					_angle += gunAngleStep;

					PoolManager.ins.Instantiate ("PlayerBullet", spawnPoint.position, _q);
				}
			} else if (Input.GetMouseButtonUp (0)) {
				gunAnimator.SetInteger (aniShootHash, 0);
			}
		}
	}
}