using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class climController : MonoBehaviour
    {
        public GameObject player;

        void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other.tag == "Player");
            if (other.tag == "Player")
            {
                player.GetComponent<PlayerController>().climbing = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            //Debug.Log(other.tag == "Player");
            if (other.tag == "Player")
            {
                player.GetComponent<PlayerController>().climbing = false;
            }
        }
    }
}
