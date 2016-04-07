using UnityEngine;
using System.Collections;

public class PlayerPistolswitch : MonoBehaviour {


	private Animator _animator;
	//public ParticleSystem particle;
	// Use this for initialization
	void Start () {
		_animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		/****Animaation Vaihto****/
		if (Input.GetKeyDown (KeyCode.Q)) {
			_animator.SetTrigger ("Pistol");
		}
		/****Portal***/
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_animator.SetTrigger ("Portal");
			//particle.Play();
		}
	}
}
