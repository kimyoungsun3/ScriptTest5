using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace DMapJump
{
    public class PlayerBullet : MonoBehaviour
    {
        public LayerMask mask;
        public float speed = 30f;
        Ray ray;
        RaycastHit hit;
        float moveDistance;
        Transform trans;
        public int damage = 1;
        public bool bDebug = true;
        float plusCheckRadius = .1f;
        Vector3 limit;

        void Start()
        {
            trans = transform;
            limit.Set(
                Camera.main.orthographicSize * Camera.main.aspect,
                Camera.main.orthographicSize,
                0
                );
        }

        void Update()
        {
            ray.origin      = trans.position;
            ray.direction   = trans.forward;
            moveDistance    = speed * Time.deltaTime;
            //Debug.Log(ray + ":" + moveDistance + ":" + mask);
            //이게 안된다 왜일까? ㅠㅠ...
            if (Physics.Raycast(ray, out hit, moveDistance, mask, QueryTriggerInteraction.Collide))
            {
                IDamageable _scp = hit.collider.GetComponent<IDamageable> ();
                //Debug.Log(_scp);
                if (_scp != null) {
                    _scp.TakeDamage (damage);
                }	

                //Sound, Particle
                ParticleSystem _p = PoolManager.ins.Instantiate("ShellExplosion", hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
                _p.Stop();
                _p.Play();

                //SoundManager.ins.Play ("ShellExplosion", -1);
                PoolReturn();
            }

            #if UNITY_EDITOR
                Debug.DrawRay(trans.position, trans.right * moveDistance, Color.green);
            #endif
            trans.Translate(Vector3.right * moveDistance);


            if (trans.position.x < -limit.x || trans.position.x > limit.x
                || trans.position.y < -limit.y || trans.position.y > limit.y)
            {
                PoolReturn();
            }                
        }

        void PoolReturn()
        {
            gameObject.SetActive(false);
        }
    }
}
