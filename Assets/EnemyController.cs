using UnityEngine;
using System.Collections;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float health;
    [SerializeField]
    private Transform player;

    public float lookAtDistance = 25f;
    public float attackRange = 45f;
    public float movementSpeed = 5f;
    public float spotRange = 70f;
    public float viewAngle = 50f;

    private Vector3 spotPosition;
    private NavMeshAgent agent;
    private EnemyState state;
	// Use this for initialization

    enum EnemyState { Idle, Patrolling, Alerted, Chase, Shoot};
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        state = EnemyState.Idle;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 _forwardAngle = transform.forward;
        Vector3 _targetAndle = (player.position - transform.position).normalized;
        float _distance = Vector3.Distance(player.position, transform.position);
        float _viewAngle = Vector3.Angle(_forwardAngle, _targetAndle);
        Debug.Log(_viewAngle.ToString() + " " + _distance.ToString());
        if (state == EnemyState.Idle && _viewAngle < viewAngle && _distance < spotRange)
        {
            spotPosition = player.position;
            state = EnemyState.Alerted;
        }
        if(state == EnemyState.Alerted)
        {
            lookAt();
        }
	}

    void lookAt()
    {
        Quaternion _rotation = Quaternion.LookRotation(spotPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.deltaTime * 3);
    }
}
