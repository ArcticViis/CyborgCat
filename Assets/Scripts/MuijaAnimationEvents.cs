using UnityEngine;
using System.Collections;

public class MuijaAnimationEvents : MonoBehaviour {

	public ParticleSystem Portalparticles;
	public GameObject portal;
	public GameObject portalvalo;
	public GameObject kilpipallo;
	public ParticleSystem Kilpiparticles;
	public GameObject kilpivalo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Portaljotain () {
		Portalparticles.Play();
		portal.SetActive (true);
		portalvalo.SetActive (true);

	}
	public void PortaaliHelvettiin(){
		portal.SetActive (false);
		portalvalo.SetActive (false);
	}

	public void Kilpi(){
		kilpipallo.SetActive (true);
		Kilpiparticles.Play();
		kilpivalo.SetActive (true);

	}
	public void KilpiHelvettiin(){
		kilpipallo.SetActive (false);
		kilpivalo.SetActive (false);
	}
}
