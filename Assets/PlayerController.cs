using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

    private CharacterController cc;
    private Rigidbody rb;

    // Movement speeds
    [SerializeField]
    private float runMS = 10f;
    [SerializeField]
    private float walkMS = 6f;  // says walk, means jog
    [SerializeField]
    private float sneakMS = 3f;
    [SerializeField]
    private float jumpPower = 5f;

    private bool falling



    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        

    }

    private void Movement()
    {
        float _movementSpeed = walkMS;

        if (Input.GetButton("Sprint"))
        {
            _movementSpeed = runMS;
        }



        Vector3 _forward = Input.GetAxisRaw("Vertical") * transform.forward;
        Vector3 _right = Input.GetAxisRaw("Horizontal") * transform.right;

        Vector3 _movement = (_forward + _right).normalized * _movementSpeed;
        cc.SimpleMove(_movement);

        if (!cc.isGrounded)
        {
            
        }

        if(cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            Debug.Log("hump");
        }
    }

    private float simGravity(float _time)
    {
        float _start = -1;
        if (_start == -1)
        {
            _start = _time;
        }
        else
        {
            _start += _time;
        }

        float _downward = 9.81f * Mathf.Pow(_start, 2f);

        return _downward;
    }
}
