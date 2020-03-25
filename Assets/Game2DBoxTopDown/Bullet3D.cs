using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolManager5;

namespace Game2DBoxTopDown
{
    public class Bullet3D : MonoBehaviour
	{
		Transform trans;

		[SerializeField] LayerMask mask;
		[SerializeField] float speed = 30f;
        //Ray ray;
        RaycastHit hit;
        float moveDistance;
        public int damage = 1;
        //public bool bDebug = true;
        Vector3 oldPosition, curPoint, nextPoint;
        float skinWidth = .01f;
        float skinLast = 0.1f;
        Vector3 limit;

        void Start()
        {
            trans = transform;
            limit.Set(
                Camera.main.orthographicSize * Camera.main.aspect + 2f,
                Camera.main.orthographicSize + 2f,
                0
                );
        }

        void Update()
        {
            moveDistance    = speed * Time.deltaTime;
            curPoint        = trans.position - trans.right * moveDistance;
            nextPoint       = trans.position + trans.right * (moveDistance + skinWidth);

#if UNITY_EDITOR
			//Debug.Log(trans.up);
			Debug.DrawLine(curPoint, trans.position, Color.yellow);
            Debug.DrawLine(trans.position, nextPoint, Color.green);
#endif
            //Debug.Log(ray + ":" + moveDistance + ":" + mask);
            //이것은 된다....
            if (Physics.Linecast(curPoint, nextPoint, out hit, mask, QueryTriggerInteraction.Collide))
            {
                IDamageable _scp = hit.collider.GetComponent<IDamageable>();
                //Debug.Log(_scp);
                if (_scp != null)
                {
                    _scp.TakeDamage(damage);
                }

                //Sound, Particle
                ParticleSystem _p = PoolManager.ins.Instantiate("ShellExplosion", hit.point, Quaternion.identity).GetComponent<ParticleSystem>();
                _p.Stop();
                _p.Play();

                //SoundManager.ins.Play ("ShellExplosion", -1);
                PoolReturn();
            }

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
