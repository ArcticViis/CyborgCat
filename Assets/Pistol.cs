using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Pistol : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private int maxAmmoPool;
    [SerializeField]
    private int ammoPool;
    [SerializeField]
    private int magazineSize;
    [SerializeField]
    private int currentAmmo;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float reloadTime;

    public int AmmoPool { get { return ammoPool; } }
    public int CurrentAmmo { get { return currentAmmo; } }


    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform muzzle;
    private Vector3 muzzleOut;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip shootSound;
    [SerializeField]
    private AudioClip reloadSound;
    [SerializeField]
    private AudioClip emptySound;
    [SerializeField]
    private WeaponState state;

    public Transform weaponPivot;


    // Use this for initialization
    void Start()
    {
        state = WeaponState.Idle;
        audioSource = GetComponent<AudioSource>();
        transform.parent = weaponPivot;
    }

    void Update()
    {
        
        
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(IEShoot());
            Debug.Log("firing");

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(IEShoot());
            if(state != WeaponState.Reload)
            {
                state = WeaponState.Idle;
            }

        }
    }
    void LateUpdate()
    {
        muzzleOut = muzzle.position;
    }

    IEnumerator IEShoot()
    {
        #region test
        //Reload
        while ((
                (Input.GetButton("Fire1") && currentAmmo == 0)
                || (currentAmmo < magazineSize && ammoPool > 0 && Input.GetKey(KeyCode.R))
              )
                && ammoPool > 0 && state != WeaponState.Reload)
        {
            state = WeaponState.Reload;
            audioSource.PlayOneShot(reloadSound);

            yield return new WaitForSeconds(reloadTime);

            if (ammoPool <= magazineSize)
            {
                currentAmmo = ammoPool;
                ammoPool = 0;
            }
            if (ammoPool > magazineSize)
            {
                ammoPool -= magazineSize - currentAmmo;
                currentAmmo = magazineSize;
            }


            state = WeaponState.Idle;
        }
        //Fire
        while (Input.GetButton("Fire1") && currentAmmo > 0 && state == WeaponState.Idle)
        {
            state = WeaponState.Firing;
            currentAmmo--;
            audioSource.PlayOneShot(shootSound);
            GameObject instance = Instantiate(bullet, muzzleOut, muzzle.rotation * Quaternion.Euler(0, 0, 0)) as GameObject;

            yield return new WaitForSeconds(1 / fireRate);

            //state = PistolState.Idle;
        }
        //Magazine empty
        while (Input.GetButton("Fire1") && currentAmmo == 0 && ammoPool == 0 && state == WeaponState.Idle)
        {
            state = WeaponState.Firing;
            audioSource.PlayOneShot(emptySound);
            yield return new WaitForSeconds(0.2f);
            state = WeaponState.Idle;
        }
        #endregion
        //state = RifleState.Idle;
        yield return null;
    }

    public void OnDisable()
    {
        Debug.Log("Rifle changed");
        state = WeaponState.Idle;
    }
}
