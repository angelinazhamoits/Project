using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{
    public class MovementController : MonoBehaviour
    {
        internal float _moveInput;

        private void Start()
        {
            Player.I = GetComponent<Player>();
        }
        void Update()
        {
            _moveInput = Input.GetAxis("Horizontal");
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.I.Jump();
            }
        }
    }
}
