using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playervelocity;
    public float speed = 5f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void processMove(Vector2 input)
     {
         Vector3 movedirecton = Vector3.zero;
         movedirecton.x = input.x;
         movedirecton.z = input.y;
         _controller.Move(transform.TransformDirection(movedirecton) * speed * Time.deltaTime);
     }
}
