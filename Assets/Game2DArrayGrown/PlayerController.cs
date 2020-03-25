using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DMapJump
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController ins;
        public Transform spawnPoint;
        float waitTime;
        public float WAIT_TIME = .05f;

        float v, h;
        Vector3 move, hitPoint, dirView;
        Transform trans;
        public float speed;
        Plane plane;
        Ray ray;
        Camera cam;
        float distance;
		public float gunAngleStep = 5f;
		[Range(1, 10)] public int gunCount = 1;

        void Awake()
        {
            ins = this;
        }
        

        void Start()
        {
            plane = new Plane(Vector3.back, Vector3.zero);
            cam = Camera.main;
            trans = transform;
        }

        void Update()
        {
            //이동...
            v = Input.GetAxisRaw("Vertical");
            h = Input.GetAxisRaw("Horizontal");
            move.Set(h, v, 0);
            move = move.normalized;

            //방향...
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                hitPoint = ray.GetPoint(distance);
                hitPoint.z = 0;
				dirView = hitPoint - trans.position;
                //float _angle = Util.GetAngleFromDir(hitPoint - trans.position);
                //trans.rotation = Quaternion.Euler(0, 0, _angle);
				trans.rotation = Util.GetQuaternionFromDir2D(dirView);


            }

            trans.Translate(move * speed * Time.deltaTime, Space.World);


            if (Time.time > waitTime)
            {
                waitTime = Time.time + WAIT_TIME;
                if (Input.GetMouseButton(0))
                {
					Quaternion _q;
					float _angleTotal = (gunCount - 1) * gunAngleStep;
					float _angle = Util.GetAngleFromDir(dirView) - _angleTotal / 2f;

					for (int i = 0; i < gunCount; i++) {
						_q = Quaternion.Euler (0, 0, _angle);
						_angle += gunAngleStep;

						PoolManager.ins.Instantiate ("PlayerBullet", spawnPoint.position, _q);
					}
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

    }
}