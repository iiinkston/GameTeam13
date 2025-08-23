using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enables the pistol when picked up and plays sound
public class GunPickup : MonoBehaviour
{

    public GameObject ourPistol;// The pistol model to show
    public AudioSource gunPickup;// Sound to play when picked up
    public GameObject pistolFireObj;// Firing system or UI linked to the pistol


    void OnTriggerEnter(Collider other)
    {
        gunPickup.Play();
        ourPistol.SetActive(true);
        pistolFireObj.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
