using UnityEngine;
using System.Collections;
namespace Werecat
{
    public class EnemyMove : MonoBehaviour
    {
        private Enemy itself;
        private float retreatRange;
        private NavMeshAgent agent;

        private Vector3 moveTarget = Vector3.zero;
        private bool moving = false;

        // Use this for initialization
        void Start()
        {
            itself = GetComponent<Enemy>();
            retreatRange = itself.retreatRange;
            agent = itself.agent;
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(itself.Comms.player.transform.position, transform.position) < retreatRange && !moving && itself.playerOnSight)
            {
                float _rot = 0f;
                Vector3 _dir = Vector3.zero;
                while (_rot < 100)
                {
                    Vector3 _rand = Random.onUnitSphere;
                    _rot = Vector3.Angle(_rand, itself.Comms.player.transform.position - transform.position);
                    _dir = _rand;
                }
                _rot *= 2f;
                NavMeshHit _hit;
                NavMesh.SamplePosition(transform.position + _dir * 5f, out _hit, 5f, NavMesh.AllAreas);
                moving = true;
                moveTarget = _hit.position;
            }
            if (moving)
            {
                agent.SetDestination(moveTarget);
                //agent.Move(Vector3.Lerp(transform.position, retreatTarget, Time.deltaTime * 0.2f));
                if (Vector3.Distance(transform.position, moveTarget) < 2 || Vector3.Distance(transform.position, itself.Comms.player.transform.position) > retreatRange + 2f)
                {
                    moving = false;
                }
            }
            Debug.DrawLine(transform.position + transform.up, moveTarget + Vector3.up, Color.red);
        }

        void Retreat()
        {

        }
        public void MoveToPoint(Vector3 _pos)
        {
            NavMeshHit _hit;
            NavMesh.SamplePosition(_pos, out _hit, 3f, NavMesh.AllAreas);
            if (!moving)
            {
                moveTarget = _hit.position;
                moving = true;
            }

        }
    }
}