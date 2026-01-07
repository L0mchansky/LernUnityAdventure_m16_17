using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public class NpcController_bk : MonoBehaviour
    {
        private float _speed = 5;
        private float _rotationSpeed = 300;

        private float _minDistanceToTarget = 0.05f;

        private MoverTransform _moverTransform;
        private Rotater _rotater;

        private Queue<Vector3> _targetPositions;
        private Vector3 _currentTarget;

        private void Awake()
        {
            _moverTransform = GetComponent<MoverTransform>();
            _rotater = GetComponent<Rotater>();
        }

        private void Update()
        {
            Vector3 direction = GetDirectionToTargetPoint();

            if (direction.magnitude <= _minDistanceToTarget)
                SwitchTarget();

            Vector3 normalizeDirection = direction.normalized;

            //_moverTransform.ProcessTo(normalizeDirection, _speed);
            //_rotater.ProcessTo(normalizeDirection, _rotationSpeed, transform);
        }

        public void SetPatrolPoints(List<Transform> patrolPoints)
        {
            _targetPositions = new Queue<Vector3>();

            foreach (Transform target in patrolPoints)
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