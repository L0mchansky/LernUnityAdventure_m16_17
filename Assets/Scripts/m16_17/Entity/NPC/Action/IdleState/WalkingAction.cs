using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public class WalkingAction : MonoBehaviour, IActionOnState
    {
        private IMover _mover;
        private Rotater _rotater;

        private MoverAttributes _moverAttributes;

        private float _timer = 0f;
        private Vector3 _currentDirection;

        public void Initialize()
        {
            GameObject _npc = gameObject.transform.parent.gameObject;

            _rotater = _npc.GetComponent<Rotater>();
            _moverAttributes = _npc.GetComponent<MoverAttributes>();

            if (_npc.TryGetComponent<IMover>(out IMover mover))
            {
                _mover = mover;
            }

            _currentDirection = GetRandomDirection();
        }

        public void Action()
        {
            Debug.Log("Ходим-бродим");
            Movement();
        }

        private void Movement()
        {
            _timer += Time.deltaTime;

            if (_timer > 1f)
            {
                _timer = 0f;
                _currentDirection = GetRandomDirection();
            }

            Vector3 normalizeDirection = _currentDirection.normalized;

            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed);
            _rotater.Rotate(normalizeDirection, _moverAttributes.RotationSpeed, _moverAttributes.transform);
        }

        private Vector3 GetRandomDirection()
        {
            Vector3 newRandomDirection = new Vector3(
                Random.Range(-1f, 1f),
                0f,
                Random.Range(-1f, 1f)
                );
            
            return newRandomDirection;
        }
    }
}