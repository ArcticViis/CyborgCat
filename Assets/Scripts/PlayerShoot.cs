using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public AudioSource railgun;
	public AudioSource railgun1;
    public GameObject projectilePrefab;
    public Transform tube;
    public Transform pipe;
    private Vector3 aim = Vector3.zero;
    public float bulletVelo = 2500f;
    public Transform followCross;
    public float damp = 1;


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
        //Debug.DrawLine(pipe.position, aim);
        if (Input.GetButtonDown("Fire1"))
        {
			StartCoroutine (Shoot ());
        }
        
    }

	IEnumerator Shoot(){
		railgun1.PlayOneShot(railgun1.clip, 1.0f);
		yield return new WaitForSeconds (3f);
		railgun.PlayOneShot(railgun.clip, 1.0f);
		yield return new WaitForSeconds (0.5f);
		GameObject instance = Instantiate(projectilePrefab, pipe.position, pipe.rotation * Quaternion.Euler(90,0,0)) as GameObject;
		instance.GetComponent<Rigidbody>().velocity = ((aim - pipe.position).normalized * bulletVelo);
		yield return new WaitForSeconds (0.4f);
		railgun1.PlayOneShot(railgun1.clip, 1.0f);
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
			Debug.DrawRay (ray.origin, _hit.point, Color.green);
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
        int layermask = 1 << 8;
        layermask = ~layermask;


        if(Physics.Raycast(ray,out _hit, 300f, layermask))
        {
            followCross.position = Vector3.Lerp(followCross.position, Camera.main.WorldToScreenPoint(_hit.point), Time.deltaTime*damp);
			Debug.DrawRay (ray.origin, _hit.point, Color.green);
        }
        else
        {
            followCross.position = Vector3.Lerp(followCross.position, new Vector2(Screen.width/2, Screen.height/2), Time.deltaTime*damp);
        }

        
    }
}
