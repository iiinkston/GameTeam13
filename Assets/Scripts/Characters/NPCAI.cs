using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCAI : MonoBehaviour
{
    public GameObject desinationPoint;
    public GameObject fleeDest;
    public AudioSource helpMeFX;

    private NavMeshAgent theAgent;
    private Animator anim;
    private bool isFleeing = false;
    public static bool fleeMode = false;
    private bool isAlive = true;

    [Header("Ragdoll Settings")]
    public Rigidbody[] ragdollBodies;
    public Collider[] ragdollColliders;

    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        DisableRagdoll(); // Start with ragdoll off
    }

    void Update()
    {
        if (!isAlive) return;

        if (!fleeMode)
        {
            theAgent.SetDestination(desinationPoint.transform.position);
            anim.Play("Walking");
        }
        else
        {
            theAgent.SetDestination(fleeDest.transform.position);
            if (!isFleeing)
            {
                isFleeing = true;
                StartCoroutine(FleeingNPC());
            }
        }
    }
    
    //Behaviour for NPC when it is fleeing and not dead
    //Determined in NPCAlerted.cs
    IEnumerator FleeingNPC()
    {
        helpMeFX.Play();
        anim.Play("Running");
        theAgent.speed = 5f;
        yield return new WaitForSeconds(13);
        fleeMode = false;
        isFleeing = false;
        anim.Play("Walking");
        theAgent.speed = 2.5f;
    }

    // Call this when NPC is shot
    public void Die()
    {
        if (!isAlive) return;

        isAlive = false;
        StopAllCoroutines();
        theAgent.isStopped = true;
        anim.enabled = false; // Disable animator

        EnableRagdoll(); // Turn on ragdoll physics
    }

    private void EnableRagdoll()
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = false; // Physics takes over
        }

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = true;
        }
    }

    private void DisableRagdoll()
    {
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = true; // Animator controls movement
        }

        foreach (Collider col in ragdollColliders)
        {
            col.enabled = false;
        }
    }
}
