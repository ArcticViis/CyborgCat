using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {


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
            StopCoroutine("Shoot");
            StartCoroutine(Shoot(2f, 3f));
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
        int layermask = 1 << 8;
        layermask = ~layermask;

        if(Physics.Raycast(ray,out _hit, 300f, layermask))
        {
            followCross.position = Vector3.Lerp(followCross.position, Camera.main.WorldToScreenPoint(_hit.point), Time.deltaTime*damp);
        }
        else
        {
            followCross.position = Vector3.Lerp(followCross.position, new Vector2(Screen.width/2, Screen.height/2), Time.deltaTime*damp);
        }
    }

    private void shootProjectile()
    {
        GameObject instance = Instantiate(projectilePrefab, pipe.position, pipe.rotation * Quaternion.Euler(90, 0, 0)) as GameObject;
        instance.GetComponent<Rigidbody>().velocity = ((aim - pipe.position).normalized * bulletVelo);
    }
    private IEnumerator Shoot( float _chargeTime, float _waitTime)
    {

        float _timeElapsed = 0;
        while (Input.GetButton("Fire1") && _chargeTime > _timeElapsed)
        {
            _timeElapsed += Time.fixedDeltaTime;
            //Debug.Log("Charging");
            yield return new WaitForFixedUpdate();
        }

        if (_chargeTime > _timeElapsed)
        {
            yield return null;
        }
        else
        {
            Debug.Log("Firing");
            shootProjectile();
        }
        yield return new WaitForSeconds(_waitTime);
    }
}
