using UnityEngine;

namespace m16_17
{
    public class AgroAction : MonoBehaviour, IActionOnState
    {
        private Mover _mover;

        private DetectorCharacter _detectorCharacter;
        private Character _character;

        public void Initialize(DetectorCharacter detectorCharacter, Mover mover)
        {
            _detectorCharacter = detectorCharacter;
            _mover = mover;
        }

        public void Action()
        {
            Debug.Log("Нападаем");

            if (_character != null)
            {
                Movement();
            }
            else
            {
                _character = _detectorCharacter.Character;
            }
        }

        private void Movement()
        {
            Vector3 normalizeDirection = GetRunDirection();

            _mover.Move(normalizeDirection);
            _mover.Rotate(normalizeDirection);
        }

        private Vector3 GetRunDirection()
        {
            Vector3 direction = GetDirectionToCharacter();
            direction = direction.normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            return direction;
        }

        private Vector3 GetDirectionToCharacter() => _character.transform.position - transform.position;
    }
}