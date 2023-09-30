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
    private void Start()
    {
        _camera = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
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
                playerUI.updatetext(hitinfo.collider.GetComponent<interactable>().promptmessage);
            }
        }

    }
}
