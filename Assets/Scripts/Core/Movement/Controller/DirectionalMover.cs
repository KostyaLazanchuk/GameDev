using Assets.Scripts.Core.Enums;
using Assets.Scripts.Core.Movement.Data;
using Assets.Scripts.StatsSystem;
using Assets.Scripts.StatsSystem.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirictionMover : MonoBehaviour
{
    private readonly Rigidbody2D _rigidbody;
    private readonly Transform _transform;
    private readonly DirictionMovementData _dirictionMovementData;
    private readonly IStatValueGiver _statValueGiver;

    private Vector2 _movement;
    private Direction _direction;
    public bool FacingRight { get; private set; }
    public bool IsMoving => _movement.magnitude> 0;
    public DirictionMover(Rigidbody2D rigidbody, DirictionMovementData dirictionMovementData, IStatValueGiver statValueGiver)
    {
        _rigidbody = rigidbody;
        _transform = _rigidbody.transform;
        _statValueGiver= statValueGiver;
        _dirictionMovementData = dirictionMovementData;
    }
    public void MoveHorizonally(float direction)
    {
        SetDirection(direction);
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = direction * _statValueGiver.GetStatValue(StatType.Speed);
        _rigidbody.velocity = velocity;
    }

    private void SetDirection(float direction)
    {
        if ((_direction == Direction.Right && direction < 0) ||
            (_direction == Direction.Left && direction > 0))
            Flip();
    }

    private void Flip()
    {
        _transform.Rotate(0, 180, 0);
        _direction = _direction ==Direction.Right ? Direction.Left :Direction.Right;
    }
}
