using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Werecat
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        private CharacterController cc;
        // Movement speeds
        [SerializeField]
        private float runMS = 10f;
        [SerializeField]
        private float walkMS = 6f;  // says walk, means jog
                                    //[SerializeField]
                                    //private float sneakMS = 3f;
        [SerializeField]
        private float climbMS = 3f;
        [SerializeField]
        private float jumpPower = 0f;

        [SerializeField]
        private float health = 200f;
        [SerializeField]
        private float maxHealth = 200f;


        public Image hpbar;
        [SerializeField]
        private Animator aminc;

        public bool climbing = false;
        private PlayerInput pi;
        #endregion


        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            if (!climbing) Movement();
            if (climbing) Climbing();
            Turning();

            if (Input.GetKeyDown(KeyCode.G))
            {
                Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = !Cursor.visible;
            }

            hpbar.fillAmount = health / maxHealth;
        }

        private void Movement()
        {
            float _movementSpeed = walkMS;

            if (Input.GetButton("Sprint"))
            {
                _movementSpeed = runMS;
                aminc.SetBool("running", true);

            }
            else
            { aminc.SetBool("running", false); }


            Vector3 _forward = Input.GetAxisRaw("Vertical") * transform.forward;
            Vector3 _right = Input.GetAxisRaw("Horizontal") * transform.right;
            Vector3 _movement = (_forward + _right).normalized * _movementSpeed;
            Debug.Log(_movement.magnitude.ToString());
            if (_movement.magnitude > 0.1)
            {
                aminc.SetBool("walk", true);
            }
            else
            {
                aminc.SetBool("walk", false);

            }

            aminc.SetFloat("Forward", Input.GetAxisRaw("Vertical"));
            aminc.SetFloat("Left", Input.GetAxisRaw("Horizontal"));

            #region Jumpstuff
            if (!cc.isGrounded)
            {

                jumpPower -= (9.81f * Time.deltaTime);
                aminc.SetBool("onLand", false);
            }

            if (cc.isGrounded)
            {
                jumpPower = 0f;
                aminc.SetBool("onLand", true);
            }

            if (Input.GetButton("Jump") && cc.isGrounded)
            {
                jumpPower = 5f;
                aminc.SetTrigger("jump");
            }
            #endregion

            cc.Move((_movement + Vector3.up * jumpPower) * Time.deltaTime);

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
            float _rotationY = Input.GetAxisRaw("Mouse X") * 0.4f;
            transform.Rotate(new Vector3(0, _rotationY * 3f, 0));
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
            Debug.Log("Took damage : " + _damage.ToString());
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}