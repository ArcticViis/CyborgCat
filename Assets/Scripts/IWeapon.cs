using UnityEngine;
using System.Collections;

public interface IWeapon
{
    void Fire();
    IEnumerator Shoot();
    void Reload();
}