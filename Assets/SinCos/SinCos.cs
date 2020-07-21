using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _SinCos
{
    public class SinCos : MonoBehaviour
    {
        public float speed = 90f;
        Transform trans;
        Vector3 pos;

        void Start()
        {
            trans = transform;
            pos = trans.position;
        }

        // Update is called once per frame
        void Update()
        {
            float _radian = Time.time * speed * Mathf.Deg2Rad;
            float _x = Mathf.Cos(_radian);
            float _y = Mathf.Sin(_radian);
            pos.Set(_x, _y, pos.z);

            trans.position = pos;
        }
    }
}
