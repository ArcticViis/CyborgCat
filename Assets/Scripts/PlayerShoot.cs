using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {


    public GameObject projectilePrefab;
    public Transform tube;
    public Transform pipe;
    private Vector3 aim = Vector3.zero;
    public float bulletVelo = 2500f;
    public Transform followCross;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
        //Debug.DrawLine(pipe.position, aim);
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject instance = Instantiate(projectilePrefab, pipe.position, pipe.rotation * Quaternion.Euler(90,0,0)) as GameObject;
            instance.GetComponent<Rigidbody>().AddForce((aim - pipe.position).normalized * bulletVelo);
        }
        
    }

    void LateUpdate()
    {
        AimAt();


        tube.LookAt(aim);
        tube.Rotate(Vector3.right, 90);

        followCrossfunc();
        
    }

    void AimAt()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit _hit;
        
        if(Physics.Raycast(ray, out _hit, 300))
        {
            aim = _hit.point;
        }
        else
        {
            aim = Camera.main.transform.position + Camera.main.transform.forward * 300;
        }
    }

    void followCrossfunc()
    {

        Vector3 _aim = Vector3.zero;
        Ray ray = new Ray(tube.position, pipe.up);
        RaycastHit _hit;

        if(Physics.Raycast(ray,out _hit, 300))
        {
            followCross.position = Camera.main.WorldToScreenPoint(_hit.point);
        }
        else
        {
            followCross.position = Vector3.zero;
        }

        
    }
}
