using System;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    public Transform player;
    public bool hasInteracted = false;
    public Transform interactionTransfrom;

    public virtual void Interact()
    {
        /// This method is ment to be overwritten
        Debug.Log("We have intercated with a " + transform);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransfrom.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    } 
    
    
    
    public void onFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null; 
        hasInteracted = false;
    }
    
    public void OnDrawGizmosSelected()
    {
        if (interactionTransfrom == null)
            interactionTransfrom = transform;
            

            Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTransfrom.position, radius);
    }
}
