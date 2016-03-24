using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		/****WALKING****/
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
			anim.SetBool ("walk", true);
		} else {
			anim.SetBool ("walk", false);
		}
		/******RUNNINHG******/
		if ((Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) && Input.GetKey (KeyCode.LeftShift)) {
			anim.SetBool ("Running", true);
		} else {
			anim.SetBool ("Running", false);
		}
		/******WALKING BACKWARDS******/
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			anim.SetBool ("WalkB", true); 
		} else {
			anim.SetBool ("WalkB", false);
		}
		/******STRAFING LEFT******/
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			anim.SetBool ("StrafeL", true); 
		} else {
			anim.SetBool ("StrafeL", false);
		}
		/******STRAFING RIGHT******/
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			anim.SetBool ("StrafeL", true); 
		} else {
			anim.SetBool ("StrafeL", false);
		}
	}
}
