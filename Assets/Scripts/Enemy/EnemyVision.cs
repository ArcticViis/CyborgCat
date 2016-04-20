using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class EnemyVision : MonoBehaviour
    {

        public float viewAngle = 110f;
        public GameObject player;

        private float cautionRange;
        private float alertRange;
        private float hostileRange;
        private float retreatRange;

        private Enemy itself;

        private bool playerOnSight = false;

        // Use this for initialization
        void Start()
        {
            itself = GetComponent<Enemy>();
            cautionRange = itself.cautionRange;
            alertRange = itself.alertRange;
            hostileRange = itself.hostileRange;
            retreatRange = itself.retreatRange;
            player = itself.Comms.player;

        }

        void Awake()
        {
           // StartCoroutine(PollEyes());
            Debug.Log("Eyes are watching");
        }
        // Update is called once per frame
        void Update()
        {


        }
        void FixedUpdate()
        {
            float _distance = Vector3.Distance(player.transform.position, transform.position);
            float _angle = Vector3.Angle(player.transform.position - transform.position, transform.forward);

            if (_angle <= viewAngle / 2 && _distance < cautionRange)
            {
                if (_distance < cautionRange && _distance > alertRange)
                {
                    Debug.Log("I see you!");
                    itself.personalSeen = player.transform.position;
                }
                if (_distance < alertRange)
                {
                    Vector3 _line = (transform.position - player.transform.position);
                    Vector3 _targetPos = player.transform.position + _line.normalized * 20f;
                    itself.Mover.MoveToPoint(_targetPos);
                }
                if (_distance < hostileRange)
                {
                    playerOnSight = true;
                    itself.playerOnSight = true;
                    itself.Comms.playerSpot = player.transform.position;

                    Vector3 _dir = player.transform.position - transform.position;
                    Quaternion _targetRot = Quaternion.LookRotation(_dir);
                    transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, Time.fixedDeltaTime * itself.angular);

                    //transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, (comms.playerSpot - transform.position).normalized, Time.fixedDeltaTime * 2f);
                    //transform.LookAt(comms.playerSpot, Vector3.up);

                    if (!itself.Shooter.shooting) itself.Shooter.shooting = true;
                }
                else
                {
                    itself.Shooter.shooting = false;
                    playerOnSight = false;
                    itself.playerOnSight = false;
                }


            }
            
            
            
        }

        //IEnumerator PollEyes()
        //{


        //    while (true)
        //    {
        //        Collider[] colliders = Physics.OverlapSphere(transform.position, 50f, -1, QueryTriggerInteraction.Ignore);
        //        foreach (Collider coll in colliders)
        //        {
        //            if (coll.tag == "Player")
        //            {
        //                Debug.Log("GOTCHA!");
        //            }
        //        }
        //        yield return new WaitForSeconds(0.2f);
        //    }
        //}
    }
}