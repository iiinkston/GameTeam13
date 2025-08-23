using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds pistol ammo when the player touches the ammo crate
public class AmmoCratePistol : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        GlobalAmmo.pistolShots += 15;// Increase pistol ammo
        this.gameObject.SetActive(false);// Hide the crate after pickup
    }
}
