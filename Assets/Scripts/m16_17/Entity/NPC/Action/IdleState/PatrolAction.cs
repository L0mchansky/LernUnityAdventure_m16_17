using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public class PatrolAction : MonoBehaviour, IActionOnState
    {
        [SerializeField] private List<Transform> _patrolPoints;
        private Mover _mover;

        private float _minDistanceToTarget = 0.05f;

        private Queue<Vector3> _targetPositions;
        private Vector3 _currentTarget;

        public void Initialize(List<Transform> patrolPoints, Mover mover)
        {
            SetPatrolPoints(patrolPoints);
            _mover = mover;
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

            _mover.Move(normalizeDirection);
            _mover.Rotate(normalizeDirection);
        }

        private void SetPatrolPoints(List<Transform> patrolPoints)
        {
            _patrolPoints = patrolPoints;

            _targetPositions = new Queue<Vector3>();

            foreach (Transform target in _patrolPoints)
                _targetPositions.Enqueue(target.position);

            SwitchTarget();
        }

        private Vector3 GetDirectionToTargetPoint() => _currentTarget - transform.position;

        private void SwitchTarget()
        {
            _currentTarget = _targetPositions.Dequeue();
            _targetPositions.Enqueue(_currentTarget);
        }
    }
}