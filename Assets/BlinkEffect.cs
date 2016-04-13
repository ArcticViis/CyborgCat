using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	void Awake()
    {
        Invoke("Kill", 2);
    }

	void Kill()
    {
        Destroy(gameObject);
    }
}
