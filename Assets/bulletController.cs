using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

    public float muzzleVelocity = 300f;
    public float lifeTime = 4f;



    //private LineRenderer line;
	// Use this for initialization
	void Start () {
        
	}
	

    void Update()
    {
        float _update = Time.deltaTime;
        RaycastHit _rhit;
        
        if (Physics.Raycast(transform.position, transform.forward, out _rhit, muzzleVelocity * _update))
        {
            Debug.Log(_rhit);
            Debug.Log("Destroy");
            Destroy(gameObject);
            
        }

        transform.position += transform.forward * muzzleVelocity * _update ;

        lifeTime -= _update;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
