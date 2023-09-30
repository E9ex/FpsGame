using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]private float distance = 3f;
    [SerializeField]private LayerMask _mask;
    private PlayerUI playerUI;
    private InputManager InputManager;
    
    private void Start()
    {
        _camera = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        InputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        playerUI.updatetext(string.Empty);
        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction*distance);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, distance, _mask))
        {
            if (hitinfo.collider.GetComponent<interactable>()!=null)
            {
                interactable interactable = hitinfo.collider.GetComponent<interactable>();
                playerUI.updatetext(interactable.promptmessage);
                if (InputManager._onFoot.interact.triggered)
                {
                    interactable.baseinteract();
                }
            }
        }

    }
}
