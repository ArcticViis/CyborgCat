using UnityEngine;
using System.Collections;

public class projectileScript : MonoBehaviour {


    float time = 10f;
	// Use this for initialization
	void Start () {
        time = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time <= 0) Destroy(gameObject);
	}

}
