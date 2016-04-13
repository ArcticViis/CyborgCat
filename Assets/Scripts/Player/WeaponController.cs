using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Werecat
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField]
        private GameObject rifle;
        [SerializeField]
        private GameObject pistol;
        [SerializeField]
        private Text text;

        private GameObject activeWeapon;

        [SerializeField]
        private Pistol pistolScript;
        [SerializeField]
        private Rifle rifleScrpit;
        private string currentAmmo;
        private string ammoPool;
        private PlayerInput pi;
        enum Weapons { Pistol = 0, Rifle };
        void Start()
        {
            pistol.SetActive(true);
            activeWeapon = pistol;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                pistol.SetActive(!pistol.activeSelf);
                rifle.SetActive(!rifle.activeSelf);
                activeWeapon = pistol.activeSelf ? pistol : rifle; ;
            }

            if (activeWeapon == pistol)
            {
                currentAmmo = pistolScript.CurrentAmmo.ToString();
                ammoPool = pistolScript.AmmoPool.ToString();
            }
            else
            {
                currentAmmo = rifleScrpit.CurrentAmmo.ToString();
                ammoPool = rifleScrpit.AmmoPool.ToString();
            }


            text.text = currentAmmo + " / " + ammoPool;

        }


    }
    enum WeaponState { Idle, Firing, Reload };
}