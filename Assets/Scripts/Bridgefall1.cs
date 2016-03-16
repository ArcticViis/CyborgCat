using UnityEngine;
using System.Collections;

public class Bridgefall1 : MonoBehaviour {


	public AudioSource audioSource;
	public Animator[] animator;
	private bool kill = false;


	void OnTriggerEnter(Collider coll)
	{
		

		if(coll.gameObject.tag == "Player"){
			Debug.Log("trying shit");
			audioSource.PlayOneShot(audioSource.clip, 1.0f);

			foreach (Animator _animator in animator) {
				_animator.SetTrigger ("Playerenter1");
				Debug.Log("Dropping shit");
			}
			for( int i = 0; i >= animator.Length; i++){
				animator[i].SetTrigger ("Playerenter1");
				Debug.Log("Dropping shit");
			}
				
			kill = true;

		}
	}

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}


	// Update is called once per frame
	void Update () {
		/*if (kill && !audioSource.isPlaying) {
			Destroy (gameObject);
		}*/

	}
}
