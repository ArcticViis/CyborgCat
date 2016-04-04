using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
    public EnemyCommunications comms;
    private Enemy itself;
    private float retreatRange;
    private NavMeshAgent agent;

    private Vector3 retreatTarget = Vector3.zero;
    private bool retreating = false;
    // Use this for initialization
    void Start () {
        itself = GetComponent<Enemy>();
        retreatRange = itself.retreatRange;
        agent = itself.agent;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Vector3.Distance(comms.player.transform.position, transform.position) < retreatRange && !retreating)
        {
            float _rot = 0f;
            Vector3 _dir = Vector3.zero;
            while (_rot < 100)
            {
                Vector3 _rand = Random.onUnitSphere;
                _rot = Vector3.Angle(_rand, comms.player.transform.position - transform.position);
                _dir = _rand;
            }
            _rot *= 2f;
            NavMeshHit _hit;
            NavMesh.SamplePosition(transform.position + _dir * 5f, out _hit, 5f,NavMesh.AllAreas);
            retreating = true;
            retreatTarget = _hit.position;
        }
        if (retreating)
        {
            agent.SetDestination(retreatTarget);
            //agent.Move(Vector3.Lerp(transform.position, retreatTarget, Time.deltaTime * 0.2f));
            if (Vector3.Distance(transform.position, retreatTarget) < 2 || Vector3.Distance(transform.position, comms.player.transform.position) > retreatRange + 2f)
            {
                retreating = false;
            }
        }
       
    }
}
