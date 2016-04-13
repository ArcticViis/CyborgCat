using UnityEngine;
using System.Collections;

public class bao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("punch");
            //iTween.PunchPosition(gameObject, Vector3.one , 1);
            iTween.PunchRotation(gameObject, Vector3.right * -2, 1);
        }
	}
}
