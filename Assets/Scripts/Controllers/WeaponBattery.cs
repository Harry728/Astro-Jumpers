using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBattery : MonoBehaviour
{
    [SerializeField] GameObject[] specialWeaponSilos = null;

    private ArrayList specialWeapons = null;
    
    private void Awake()
    {
        specialWeapons = new ArrayList();
    }

    public void SpinUpWeapon(SpecialWeapon weapon) {
        for(int i = 0; i < specialWeaponSilos.Length; i++) {
            if (!specialWeapons.Contains(i)) {
                //slot is free, load the weapon and start spinup
                Silo silo = specialWeaponSilos[i].GetComponent<Silo>();
                GameObject spinningUpWeapon = Instantiate(weapon.prefab, 
                                                        silo.launchPoint.position, 
                                                        silo.launchPoint.rotation,
                                                        silo.launchPoint.transform);
                spinningUpWeapon.GetComponent<SpecialWeapon>().SetSiloIndex(i, silo);
            }
        }
    }

    public void WeaponWasLaunched(int siloIndex)
    {
        if (specialWeapons.Contains(siloIndex)) {
            specialWeapons.Remove(siloIndex);
        }
    }
}
