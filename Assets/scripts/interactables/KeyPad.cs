using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void interact()
    {
        Debug.Log("interacted with " + gameObject.name);
    }
}