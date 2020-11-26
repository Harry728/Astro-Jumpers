using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSpecialWeapons : MonoBehaviour
{
    [SerializeField] SpecialWeapon[] specialWeapons = null;

    int nextWeapon = -1;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NextWeapon();
        }
    }

    void NextWeapon()
    {
        if (specialWeapons.Length == 0) {
            return;
        }
        nextWeapon += 1;
        if (nextWeapon > specialWeapons.Length) {
            nextWeapon = -1;
            return;
        }
        WeaponBattery battery = GetComponent<WeaponBattery>();
        battery.SpinUpWeapon(specialWeapons[nextWeapon]);
    }
}
