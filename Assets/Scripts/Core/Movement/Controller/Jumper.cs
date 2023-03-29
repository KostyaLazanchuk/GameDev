using Assets.Scripts.Core.Movement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

namespace Assets.Scripts.Core.Movement.Controller
{
    public class Jumper
    {
        private readonly JumpData _jumpData;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;


        private float _startJumpVerticalPosition;
        private int _countOfJump;


        public bool _IsJumping { get; private set; }

        public Jumper(Rigidbody2D rigidbody2D, JumpData jumpData)
        {
            _rigidbody= rigidbody2D;
            _jumpData= jumpData;
            _transform= _rigidbody.transform;
        }

        public void Jump()
        {
            if (_countOfJump >= _jumpData.MaxJump)
                return;

            _countOfJump++;
            _IsJumping = true;
            if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            }
            _rigidbody.AddForce(Vector2.up * _jumpData.JumpForce);
            _rigidbody.gravityScale = _jumpData.GravityScale;
            _startJumpVerticalPosition = _rigidbody.position.y;
            
        }

        public void UpdateJump()
        {
            if (_rigidbody.velocity.y < 0 && _rigidbody.position.y <= _startJumpVerticalPosition && _IsJumping)
            {
                ResetJump();
                return;
            }
        }

        public void ResetJump()
        {
            _countOfJump = 0;
            _rigidbody.position = new Vector2(_transform.position.x, _startJumpVerticalPosition);
            _rigidbody.gravityScale = 0;
            _IsJumping = false;
        }
    }
}
