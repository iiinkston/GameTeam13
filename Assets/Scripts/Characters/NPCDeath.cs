using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCDeath : MonoBehaviour
{
    public int npcHealth = 20;
    public bool npcDead = false;
    public GameObject npcObject;
    public GameObject interactionTrigger;
    public GameObject helpMe;

    [Header("Ragdoll")]
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;

    void Start()
    {
        DisableRagdoll();
    }

    // Call this when NPC is hit
    public void HurtNPC(int shotDamage)
    {
        if (npcDead) return;

        npcHealth -= shotDamage;
        if (npcHealth <= 0)
        {
            npcDead = true;
            StartCoroutine(EndNPC());
        }
    }

    IEnumerator EndNPC()
    {
        GlobalWanted.wantedLevel += 1;
        GlobalWanted.activateStar = true;

        // Disable movement and interaction
        npcObject.GetComponent<NPCAI>().enabled = false;
        npcObject.GetComponent<NavMeshAgent>().enabled = false;
        npcObject.GetComponent<Collider>().enabled = false;
        interactionTrigger.SetActive(false);
        helpMe.SetActive(false);

        // Enable ragdoll for realistic death
        EnableRagdoll();

        yield return null; // optional delay if needed
    }

    private void EnableRagdoll()
    {
        Animator anim = npcObject.GetComponent<Animator>();
        if (anim != null) anim.enabled = false;

        foreach (Rigidbody rb in ragdollBodies)
            rb.isKinematic = false;

        foreach (Collider col in ragdollColliders)
            col.enabled = true;
    }

    private void DisableRagdoll()
    {
        foreach (Rigidbody rb in ragdollBodies)
            rb.isKinematic = true;

        foreach (Collider col in ragdollColliders)
            col.enabled = false;
    }
}
