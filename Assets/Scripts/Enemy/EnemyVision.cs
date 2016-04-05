using UnityEngine;
using System.Collections;

public class EnemyVision : MonoBehaviour {

    public float viewAngle = 110f;
    public GameObject player;

    private float cautionRange;
    private float alertRange ;
    private float hostileRange ;
    private float retreatRange ;


    private EnemyShoot enemyShoot;
    public EnemyCommunications comms;
    private Enemy itself;

    private bool playerOnSight = false;

	// Use this for initialization
	void Start () {
        enemyShoot = GetComponent<EnemyShoot>();
        itself = GetComponent<Enemy>();
        cautionRange = itself.cautionRange;
        alertRange = itself.alertRange;
        hostileRange = itself.hostileRange;
        retreatRange = itself.retreatRange;
    }
	
	// Update is called once per frame
	void Update () {
        

	}
    void FixedUpdate()
    {
        float _distance = Vector3.Distance(player.transform.position, transform.position);
        float _angle = Vector3.Angle(player.transform.position - transform.position, transform.forward);

        if (_angle <= viewAngle / 2 && _distance < cautionRange )
        {
            if(_distance < cautionRange && _distance > alertRange)
            {
                Debug.Log("I see you!");
                itself.personalSeen = player.transform.position;
            }
            if(_distance < alertRange)
            {   
                playerOnSight = true;
                comms.playerSpot = player.transform.position;

                transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, (comms.playerSpot - transform.position).normalized, Time.fixedDeltaTime * 0.2f);
                transform.LookAt(comms.playerSpot, Vector3.up);
                if(!enemyShoot.shooting) enemyShoot.shooting = true;
            }
            else
            {
                enemyShoot.shooting = false;
                playerOnSight = false;
            }
           
            
        }
    }
}
