using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class SpellController : MonoBehaviour
    {
        //private CharacterController cc;
        //private GameObject player;
        public Transform enemy;
        private RaycastHit _rhit;
        private Vector3 telePos;
        public float teleportDistance = 25f;

        public GameObject blinkEffect;

        // Use this for initialization
        void Start()
        {
            //cc = GetComponent<CharacterController>();
            //player = gameObject;

        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(blinkEffect, transform.position, transform.rotation);
                Blink(telePos);
            }

            Debug.DrawLine(transform.position, transform.forward * teleportDistance);
            if (Physics.CapsuleCast(Camera.main.transform.position + Camera.main.transform.forward * 6 - Vector3.up, Camera.main.transform.position + Vector3.up, 1.1f, Camera.main.transform.forward, out _rhit, teleportDistance))
            {
                //Debug.Log(_rhit.point);
                telePos = _rhit.point;
                Debug.DrawLine(transform.position, _rhit.point);
                enemy.position = telePos;
            }
            else
            {
                telePos = Camera.main.transform.position + Camera.main.transform.forward * teleportDistance - Vector3.up;
                enemy.position = telePos;
            }

            //Debug.DrawLine(player.transform.position + Vector3.up, Camera.main.transform.position + Camera.main.transform.forward * 150, hit ? Color.green : Color.red);
        }
        private void Blink(Vector3 _loc)
        {
            transform.position = _loc;
        }
    }
}