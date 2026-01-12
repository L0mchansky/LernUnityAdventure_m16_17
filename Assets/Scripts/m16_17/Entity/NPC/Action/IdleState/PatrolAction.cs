using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public class PatrolAction : MonoBehaviour, IActionOnState
    {
        private IMover _mover;
        private Rotater _rotater;

        private MoverAttributes _moverAttributes;

        [SerializeField] private List<Transform> _patrolPoints;

        private float _minDistanceToTarget = 0.05f;

        private Queue<Vector3> _targetPositions;
        private Vector3 _currentTarget;

        public void Initialize(List<Transform> patrolPoints)
        {
            SetPatrolPoints(patrolPoints);

            GameObject _npc = gameObject.transform.parent.gameObject;

            _rotater = _npc.GetComponent<Rotater>();
            _moverAttributes = _npc.GetComponent<MoverAttributes>();

            if (_npc.TryGetComponent<IMover>(out IMover mover))
            {
                _mover = mover;
            }
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

            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed);
            _rotater.Rotate(normalizeDirection, _moverAttributes.RotationSpeed, _moverAttributes.transform);
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