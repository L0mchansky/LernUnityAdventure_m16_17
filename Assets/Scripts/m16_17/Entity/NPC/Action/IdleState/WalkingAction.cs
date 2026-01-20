using UnityEngine;

namespace m16_17
{
    public class WalkingAction : IActionOnState
    {
        private Transform _transformNpc;

        private MoverTransform _mover;
        private Rotater _rotater;
        private MoverAttributes _moverAttributes;

        private float _timer = 0f;
        private Vector3 _currentDirection;

        public WalkingAction(Transform transformNpc, MoverTransform mover, Rotater rotater, MoverAttributes moverAttributes)
        {
            _mover = mover;
            _rotater = rotater;
            _moverAttributes = moverAttributes;
            _transformNpc = transformNpc;
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

            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
            _rotater.Rotate(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
        }

        private Vector3 GetRandomDirection()
        {
            Vector3 newRandomDirection = new Vector3
                (
                Random.Range(-1f, 1f),
                0f,
                Random.Range(-1f, 1f)
                );
            
            return newRandomDirection;
        }
    }
}