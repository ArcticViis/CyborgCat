using UnityEngine;
using System.Collections;

namespace Werecat
{
    public class PlayerInput : MonoBehaviour
    {
        public bool Lockcursor = false;
        public bool Jump = false;
        public bool Spell1 = false;
        public bool Spell2 = false;
        public bool Spell3 = false;
        public bool Spell4 = false;

        public bool Fire1 = false;
        public bool Fire2 = false;
        public bool ChangeWeapon = false;
        public bool Sprint = false;
        public Vector3 wasd = Vector3.zero;

        public float MouseY = 0;
        public float MouseX = 0;
        //public CustomButton Jump;

        // Use this for initialization
        void Start()
        {
           // Jump = new CustomButton("Jump", true);
        }

        // Update is called once per frame
        void Update()
        {
            Lockcursor = Input.GetKey(KeyCode.G);
            Jump = Input.GetButton("Jump");

            Spell1 = Input.GetKey(KeyCode.Keypad1);
            Spell2 = Input.GetKey(KeyCode.Keypad2);
            Spell3 = Input.GetKey(KeyCode.Keypad3);
            Spell4 = Input.GetKey(KeyCode.Keypad4);

            Fire1 = Input.GetButton("Fire1");
            Fire2 = Input.GetButton("Fire2");
            ChangeWeapon = Input.GetKey(KeyCode.Q);
            Sprint = Input.GetButton("Sprint");
            wasd = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");

            MouseX = Input.GetAxisRaw("Mouse X");
            MouseY = Input.GetAxisRaw("Mouse Y");

        }
    }
    class CustomButton
    {
        private bool pressed;
        private bool down;
        private bool up;
        private bool raw;
        private float ax;

        private KeyCode key = KeyCode.None;
        private string name = null;
        private KeyType keyType;

        public float Axis
        {
            get
            {
                return ax;
            }

        }

        public bool Up
        {
            get
            {
                return up;
            }
        }

        public bool Down
        {
            get
            {
                return down;
            }
        }

        public bool Pressed
        {
            get
            {
                return pressed;
            }
        }

        private enum KeyType { Key, Axis, Button };
        public CustomButton (KeyCode _key)
        {
            key = _key;
            keyType = KeyType.Key;
        }
        public CustomButton(string _string, bool isButton)
        {
            name = _string;
            if (true)
            {
                keyType = KeyType.Button;
            }
            else
            {
                keyType = KeyType.Axis;
                raw = true;
            }

        }
        public CustomButton(string _string, bool button, bool _raw)
        {
            name = _string;
            if (button)
            {
                keyType = KeyType.Button;
            }
            else
            {
                keyType = KeyType.Axis;
            }
            raw = _raw;

        }

        private void Refresh()
        {
            if(keyType == KeyType.Axis)
            {
                if(raw)
                    ax = Input.GetAxisRaw(name);
                if (!raw)
                    ax = Input.GetAxis(name);
            }
            if (keyType == KeyType.Button)
            {
                up = Input.GetButtonUp(name);
                down = Input.GetButtonDown(name);
                pressed = Input.GetButton(name);
            }
            if (keyType == KeyType.Key)
            {
                up = Input.GetKeyUp(key);
                down = Input.GetKeyDown(key);
                pressed = Input.GetKey(key);
            }
        }

    }
}