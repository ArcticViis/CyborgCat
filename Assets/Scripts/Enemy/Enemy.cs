using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float health = 100f;
        public float Health { get; private set; }

        public float cautionRange = 70f;
        public float alertRange = 60f;
        public float hostileRange = 40f;
        public float retreatRange = 10f;
        public NavMeshAgent agent;
        public float angular = 1f;

        public Vector3 personalSeen;
        public bool alive = true;

        [SerializeField]
        private EnemyCommunications comms;
        [SerializeField]
        private EnemyMove mover;
        [SerializeField]
        private EnemyShoot shooter;
        [SerializeField]
        private EnemyVision vision;

        public EnemyCommunications Comms { get { return comms; } private set { } }
        public EnemyMove Mover { get { return mover; } private set { } }
        public EnemyShoot Shooter { get { return shooter; } private set { } }
        public EnemyVision Eyes { get { return vision; } private set { } }




        public bool playerOnSight = false;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void Awake()
        {
            //comms.RegisterEnemy(gameObject);
            comms = FindObjectOfType<EnemyCommunications>();
        }
        public void TakeDamage(float _damage)
        {
            if (_damage > health)
            {
                health = 0;
            }
            else
            {
                health -= _damage;
            }
            //Debug.Log("Took damage : " + _damage.ToString());
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }


    }
}