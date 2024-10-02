using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
   [SerializeField] private float _force;
   public Animator Tramp;

   void OnCollisionEnter2D(Collision2D jump)
   {
      if (jump.gameObject.tag == "Player")
      {
         jump.rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
         Tramp.SetTrigger("Tramp");
      }
   }
}
