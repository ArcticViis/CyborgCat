using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    public bool shooting = false;
    public bool startshooting = false;
    public float damage = 5f;

    public GameObject bullet;
    private Enemy itself;
    // Use this for initialization
    void Start () {
        itself = GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (shooting && !startshooting)
        {
            StopCoroutine(Burst());
            startshooting = true;
            StartCoroutine(Burst());

        }
    }
    IEnumerator Burst()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 _rot = itself.Comms.playerSpot - transform.position;
            GameObject instance = Instantiate(bullet, transform.position + Vector3.up, transform.rotation) as GameObject;
            instance.GetComponent<bulletController>().damage = damage;
            yield return new WaitForSeconds(1 / 6f);
        }


        shooting = false;
        yield return new WaitForSeconds(2 / 3f);

        startshooting = false;
    }
}
