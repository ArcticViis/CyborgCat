using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private CharacterController cc;

    private float runMS = 10f;
    private float walkMS = 6f;
    private float sneakMS = 3f;



    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
