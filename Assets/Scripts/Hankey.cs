using UnityEngine;
using System.Collections;

public class Hankey : MonoBehaviour {
	public AudioSource Hanky;
	public GameObject HankyAudioGO;

	private AudioSource audioSource;
	private bool kill = false;
	// Use th	is for initialization
	void OnTriggerEnter(Collider coll)
	{
		audioSource = HankyAudioGO.GetComponent<AudioSource> ();

		if(coll.gameObject.tag == "Player"){
			
			audioSource.PlayOneShot(audioSource.clip, 1.0f);
			Debug.Log("Playing shit");
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
		if (kill && !audioSource.isPlaying) {
			Destroy (gameObject);
		}

	}
}
