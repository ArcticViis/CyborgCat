using UnityEngine;
using System.Collections;

public class climController : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag == "Player");
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().climbing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag == "Player");
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().climbing = false;
        }
    }
}
