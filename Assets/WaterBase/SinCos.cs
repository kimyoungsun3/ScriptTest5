using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace _SinCos
{
    public class SinCos : MonoBehaviour
    {
        Transform trans;
        Vector3 posOrg;
		Spawner spawner;
		public void SetData(Spawner _scp) {
			gameObject.SetActive(true);
			spawner = _scp;
		} 

		void Start()
        {
            trans = transform;
            posOrg = trans.position;
        }

		

        // Update is called once per frame
        void Update()
        {
            float _radian = spawner.b * posOrg.x + Time.time * spawner.speed * Mathf.Deg2Rad;
            float _x = Mathf.Cos(_radian);
            float _y = spawner.a * Mathf.Sin(_radian);
			Vector3 _pos = new Vector3(_x, _y, 0);
            

            trans.position = posOrg + _pos;
        }
    }
}
