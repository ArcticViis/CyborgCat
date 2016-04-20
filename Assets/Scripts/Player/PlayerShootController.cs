using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class PlayerShootController : MonoBehaviour
    {


        //public GameObject projectilePrefab;
        public Transform aimTarget;
        public Transform weaponPivot;
        public Transform pipe;
        private Vector3 aim = Vector3.zero;
        public Transform followCross;
        public float damp = 1;
        //private Vector3 launchposition = Vector3.zero;


        // Update is called once per frame
        void Update()
        {


            //Debug.DrawLine(pipe.position, aim);
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    StopCoroutine("Shoot");
            //    shootProjectile();
            //    StartCoroutine(Shoot(10f));
            //}

        }

        void LateUpdate()
        {

            AimAt();
            //followCrossfunc();
            //launchposition = pipe.position;
        }

        void AimAt()
        {
            RaycastHit _hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);


            if (Physics.Raycast(ray, out _hit, 300f, -1, QueryTriggerInteraction.Ignore ))
            { aim = _hit.point; }
            else
            { aim = Camera.main.transform.position + Camera.main.transform.forward * 300; }
            aimTarget.position = Vector3.Lerp(aimTarget.position, aim, 1);
            weaponPivot.LookAt(aimTarget);

        }

        void followCrossfunc()
        {

            //Vector3 _aim = Vector3.zero;
            Ray ray = new Ray(weaponPivot.position, pipe.up);
            RaycastHit _hit;
            int layermask = 1 << 8;
            layermask = ~layermask;

            if (Physics.Raycast(ray, out _hit, 300f, layermask, QueryTriggerInteraction.Ignore))
            {
                followCross.position = Vector3.Lerp(followCross.position, Camera.main.WorldToScreenPoint(_hit.point), Time.deltaTime * damp);
            }
            else
            {
                followCross.position = Vector3.Lerp(followCross.position, new Vector2(Screen.width / 2, Screen.height / 2), Time.deltaTime * damp);
            }
        }


    }
}