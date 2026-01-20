using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public class PatrolAction : IActionOnState
    {
        private List<Transform> _patrolPoints;
        private Transform _transformNpc;

        private MoverTransform _mover;
        private Rotater _rotater;
        private MoverAttributes _moverAttributes;

        private float _minDistanceToTarget = 0.05f;

        private Queue<Vector3> _targetPositions;
        private Vector3 _currentTarget;


        public PatrolAction(List<Transform> patrolPoints, Transform transformNpc, MoverTransform mover, Rotater rotater, MoverAttributes moverAttributes)
        {
            _mover = mover;
            _rotater = rotater;
            _moverAttributes = moverAttributes;
            _transformNpc = transformNpc;
            SetPatrolPoints(patrolPoints);
        }

        public void Action()
        {
            Debug.Log("Ходим патрулируем");
            Movement();
        }

        private void Movement()
        {
            Vector3 direction = GetDirectionToTargetPoint();

            if (direction.magnitude <= _minDistanceToTarget)
                SwitchTarget();

            Vector3 normalizeDirection = direction.normalized;

            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
            _rotater.Rotate(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
        }

        private void SetPatrolPoints(List<Transform> patrolPoints)
        {
            _patrolPoints = patrolPoints;

            _targetPositions = new Queue<Vector3>();

            foreach (Transform target in _patrolPoints)
                _targetPositions.Enqueue(target.position);

            SwitchTarget();
        }

        private Vector3 GetDirectionToTargetPoint() => _currentTarget - _transformNpc.position;

        private void SwitchTarget()
        {
            _currentTarget = _targetPositions.Dequeue();
            _targetPositions.Enqueue(_currentTarget);
        }
    }
}