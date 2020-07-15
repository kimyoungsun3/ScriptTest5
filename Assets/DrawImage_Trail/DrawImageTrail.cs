using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DrawImage_Trail
{
    public class DrawImageTrail : MonoBehaviour
    {
        public GameObject trailPrefab;
        GameObject thisTrail;
        Vector3 startPos;
        Plane objPlane;

        // Use this for initialization
        void Start()
        {
            objPlane = new Plane(Camera.main.transform.forward * -1, transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
            {
                
                Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float _distance;
                if(objPlane.Raycast(_ray, out _distance))
                {
                    thisTrail = (GameObject)Instantiate(trailPrefab, _ray.GetPoint(_distance), Quaternion.identity);
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float _distance;
                if (objPlane.Raycast(_ray, out _distance))
                {
                    thisTrail.transform.position = _ray.GetPoint(_distance);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if(Vector3.Distance(thisTrail.transform.position, startPos) < 0.1f)
                {
                    Destroy(thisTrail);
                }
            }
        }
    }
}