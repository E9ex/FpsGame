using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
  {
    Transform hitransform = other.transform;
    if (hitransform.CompareTag("Player"))
    {
      Debug.Log("hit player");
      hitransform.GetComponent<PlayerHealth>().takedamage(10);
    }
    Destroy(gameObject);
  }
}
