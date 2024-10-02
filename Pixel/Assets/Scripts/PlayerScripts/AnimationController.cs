using System.Collections;
using System.Collections.Generic;
using PlayerSpace;
using UnityEngine;


namespace AnimationControl
{

    public class AnimationController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private MovingEnemy _enemy;

        private Animator _animatorPlayer;
        private Animator _animatorEnemy;
        
    }
}