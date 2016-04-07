using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float health = 100f;
    public float Health { get; private set; }

    public float cautionRange = 70f;
    public float alertRange = 60f;
    public float hostileRange = 40f;
    public float retreatRange = 10f;
    public NavMeshAgent agent;

    public Vector3 personalSeen;



    public EnemyCommunications comms;
    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void Awake()
    {
        comms.RegisterEnemy(gameObject);
    }
    public void TakeDamage(float _damage)
    {
        if(_damage > health)
        {
            health = 0;
        }
        else
        {
            health -= _damage;
        }
        Debug.Log("Took damage : " + _damage.ToString());
        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    
}
