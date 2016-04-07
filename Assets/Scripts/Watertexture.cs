using UnityEngine;
using System.Collections;

public class Watertexture : MonoBehaviour {

	/*
	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f);
	public string textureName1 = "_MainTex";
	public string textureName2 = "_BumpMap";
	*/
	public float scrollspeed = 1;
	private Renderer rend;

	Vector2 uvOffset = Vector2.zero;

	/*void LateUpdate () {
		uvOffset += (uvAnimationRate * Time.deltaTime);
		if (GetComponent<Renderer>().enabled) {
			GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName1, uvOffset);
			GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName2, uvOffset);
		}*/

	void Start(){
		rend = GetComponent<Renderer> ();
	}

	void Update(){
		float offset = Time.time * scrollspeed;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}