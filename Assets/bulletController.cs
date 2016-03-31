using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

    public float muzzleVelocity = 300f;

    private LineRenderer line;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
    }
    void FixedUpdate()
    {
        RaycastHit _rhit;
        
        if (Physics.Raycast(transform.position, transform.forward, out _rhit, muzzleVelocity * Time.fixedDeltaTime))
        {
            Debug.Log(_rhit);
            Debug.Log("Destroy");
            Destroy(gameObject);
            
        }

        transform.position += transform.forward * muzzleVelocity * Time.fixedDeltaTime ;
    }
}
