using Assets.Scripts.Core.Movement.Controller;
using Assets.Scripts.Core.Movement.Data;
using Assets.Scripts.StatsSystem;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : MonoBehaviour
    {

        [SerializeField] private DirictionMovementData _dirictionMovementData;
        [SerializeField] private JumpData _jumpData;


        private Rigidbody2D _rigidbody;

        private DirictionMover _dirictionMover;
        private Jumper _jumper;

        public void Initialize(IStatValueGiver statValueGiver)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _dirictionMover = new DirictionMover(_rigidbody, _dirictionMovementData, statValueGiver);
            _jumper = new Jumper(_rigidbody, _jumpData);
        }

        private void Update()
        {

            if (_jumper._IsJumping)
            {
                _jumper.UpdateJump();
            }
                
        }

        public void MoveHorizonally(float direction)
        {
            if (_jumper._IsJumping)
                return;

            _dirictionMover.MoveHorizonally(direction);
        }
            

        public void Jump() => _jumper.Jump();

    }
}


