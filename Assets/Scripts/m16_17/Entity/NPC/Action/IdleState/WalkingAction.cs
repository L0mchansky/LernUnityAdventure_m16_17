using UnityEngine;

namespace m16_17
{
    public class WalkingAction : MonoBehaviour, IActionOnState
    {
        private Mover _mover;

        private float _timer = 0f;
        private Vector3 _currentDirection;

        public void Initialize(Mover mover)
        {
            _currentDirection = GetRandomDirection();
            _mover = mover;
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

            _mover.Move(normalizeDirection);
            _mover.Rotate(normalizeDirection);
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