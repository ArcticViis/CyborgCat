using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private Text text;

    private Weapons activeWeapon;

    [SerializeField]
    private Pistol pistolScript;
    [SerializeField]
    private Rifle rifleScrpit;
    private string currentAmmo;
    private string ammoPool;

    enum Weapons { Pistol = 0, Rifle };
    void Start()
    {
        weapons[(int)Weapons.Pistol].SetActive(true);
        activeWeapon = Weapons.Pistol;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            weapons[(int)Weapons.Pistol].SetActive(!weapons[(int)Weapons.Pistol].activeSelf);
            weapons[(int)Weapons.Rifle].SetActive(!weapons[(int)Weapons.Rifle].activeSelf);
            activeWeapon = activeWeapon == Weapons.Pistol ? Weapons.Rifle : Weapons.Pistol;
        }

        if(activeWeapon == Weapons.Pistol)
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