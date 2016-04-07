using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = gameObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rend.sharedMaterial.SetTextureOffset("_BumpMap", new Vector2(Time.time, Time.time));
        rend.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(Time.time, Time.time));
    }
}
