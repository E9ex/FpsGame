using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermotor : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playervelocity;
    private bool isground;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpheight = 1.5f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isground = _controller.isGrounded;
    }
     public void processMove(Vector2 input)
     {
         Vector3 movedirecton = Vector3.zero;
         movedirecton.x = input.x;
         movedirecton.z = input.y;
         _controller.Move(transform.TransformDirection(movedirecton) * speed * Time.deltaTime);
         _playervelocity.y += gravity * Time.deltaTime;
         if (isground && _playervelocity.y<0)
         {
             _playervelocity.y = -2f;
         }
         _controller.Move(_playervelocity * Time.deltaTime);
     }

     public void Jump()
     {
         if (isground)
         {
             _playervelocity.y = Mathf.Sqrt(jumpheight * -3.0f * gravity);
         }
     }
}
