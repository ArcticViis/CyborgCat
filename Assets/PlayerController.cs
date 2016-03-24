using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
    #region Variables
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
    private float climbMS = 3f;
    [SerializeField]
    private float jumpPower = 0f;

    private bool falling;

    public bool climbing = false;
    #endregion

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        falling = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(!climbing) Movement();
        if (climbing) Climbing();
        Turning();
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

        #region Jumpstuff
        if (!cc.isGrounded)
        {
            falling = true;
            jumpPower -= (9.81f * Time.deltaTime);
        }

        if (cc.isGrounded)
        {
            jumpPower = 0f;
        }

        if(Input.GetButton("Jump") && cc.isGrounded)
        {
            Debug.Log("jump");
            jumpPower = 5f;
        }
        #endregion

        cc.Move((_movement + Vector3.up * jumpPower ) * Time.deltaTime);
        

        
    }

    private void Climbing()
    {
        Vector3 _up = Input.GetAxisRaw("Vertical") * transform.up;
        Vector3 _right = Input.GetAxisRaw("Horizontal") * transform.right;
        Vector3 _movement = (_up + _right).normalized * climbMS;
        cc.Move(_movement * Time.deltaTime);
    }
    private void Turning()
    {
        float _rotationY = Input.GetAxisRaw("Mouse X");
        transform.Rotate(new Vector3(0, _rotationY * 3f, 0));
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
