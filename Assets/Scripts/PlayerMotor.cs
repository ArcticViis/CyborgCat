using UnityEngine;
using System.Collections;


namespace Werecat
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerCameraController))]
    public class PlayerMotor : MonoBehaviour
    {

        [SerializeField]
        private float movementSpeed = 5f;
        [SerializeField]
        private float walkSpeed = 5f;
        [SerializeField]
        private float sprintSpeed = 10f;
        [SerializeField]
        private float jumpPower = 5f;
        [SerializeField]
        private float looksens;
        [SerializeField]
        private float groundCheckDistance = 1f;
        [SerializeField]
        private float minFOV = 60f;
        [SerializeField]
        private float maxFOV = 70f;
        [SerializeField]
        private float fovChangeSpeed = 0.2f;

        private bool isGrounded = true;

        private PlayerCameraController pcc;
        private Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            pcc = GetComponent<PlayerCameraController>();
            looksens = pcc.LookSensitivity;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            QualitySettings.vSyncCount = 0;
        }

        // Update is called once per frame
        void Update()
        {
            CheckGround();
            Jump();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Input.GetButtonDown("Sprint"))
            {
                StartCoroutine(SprintFOV(fovChangeSpeed));
            }
                
        }
        void FixedUpdate()
        {
            Movement();
            
        }
        void LateUpdate()
        {
            Turning();
        }

        void CheckGround()
        {
            isGrounded = false;
            Ray ray = new Ray(transform.position, transform.up * -1);
            if (Physics.Raycast(ray, groundCheckDistance)) isGrounded = true;
            
            Debug.DrawLine(transform.position, transform.position + transform.up * -groundCheckDistance);
        }
        void Movement()
        {
            Vector3 _forward = Input.GetAxisRaw("Vertical") * transform.forward;
            Vector3 _right = Input.GetAxisRaw("Horizontal") * transform.right;

            Vector3 _movement = (_forward + _right).normalized *  movementSpeed ;
            rb.MovePosition(transform.position + _movement * Time.fixedDeltaTime );
        }
        void Jump()
        {
            if(Input.GetButtonDown("Jump") && isGrounded) rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        }

        void Turning()
        {
            float _rotationY = Input.GetAxisRaw("Mouse X");
            transform.Rotate(new Vector3(0, _rotationY * looksens, 0));
        }

        private IEnumerator SprintFOV(float time)
        {
            movementSpeed = sprintSpeed;
            bool _sprint = Input.GetButton("Sprint");
            float _elapsed = 0f;
            while (_sprint )
            {
                _elapsed += Time.deltaTime;

                Camera.main.fieldOfView = Mathf.Lerp(minFOV, maxFOV, (_elapsed / time));
                _elapsed = _elapsed > time ? time : _elapsed;
                _sprint = Input.GetButton("Sprint");
                yield return new WaitForEndOfFrame();
            }
           
            while (!_sprint && _elapsed > 0)
            {
                _elapsed = _elapsed > time ? time : _elapsed;
                _elapsed -= Time.deltaTime;
                Camera.main.fieldOfView = Mathf.Lerp(minFOV, maxFOV, (_elapsed / time));
                _sprint = Input.GetButton("Sprint");
                yield return new WaitForEndOfFrame();
            }
            
        }
    }
}

