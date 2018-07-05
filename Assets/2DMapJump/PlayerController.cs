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
        Vector3 move, hitPoint;
        Transform trans;
        public float speed;
        Plane plane;
        Ray ray;
        Camera cam;
        float distance;

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
                //float _angle = Util.GetAngleFromDir(hitPoint - trans.position);
                //trans.rotation = Quaternion.Euler(0, 0, _angle);
                trans.rotation = Util.GetQuaternionFormDir(hitPoint - trans.position);
            }

            trans.Translate(move * speed * Time.deltaTime, Space.World);

            if (Time.time > waitTime)
            {
                waitTime = Time.time + WAIT_TIME;
                if (Input.GetMouseButton(0))
                {
                    PoolManager.ins.Instantiate("PlayerBullet", spawnPoint.position, spawnPoint.rotation);
                }
            }

            #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Z))
            {
                EditorApplication.isPaused = !EditorApplication.isPaused;
            }
            #endif
        }

        //A -> B => xy 평면에서 바라보는 x축을 기준으로 각도.
        public float GetAngleFromDir(Vector3 _viewDir)
        {
            return Mathf.Atan2(_viewDir.y, _viewDir.x) * Mathf.Rad2Deg;
        }
    }
}