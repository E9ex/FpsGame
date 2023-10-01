using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    public bool useEvents;
    public string promptmessage;

    public void baseinteract()
    {
        if (useEvents)
        {
            GetComponent<interactionEvents>().OnInteract.Invoke(); 
        }
        interact();
    }

    protected virtual void interact()
    {
        
    }

}
