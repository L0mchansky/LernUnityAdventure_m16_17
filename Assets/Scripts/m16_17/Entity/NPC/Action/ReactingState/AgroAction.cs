using UnityEngine;

namespace m16_17
{
    public class AgroAction : MonoBehaviour, IActionOnState
    {
        private IMover _mover;
        private Rotater _rotater;

        private MoverAttributes _moverAttributes;

        private DetectorCharacter _detectorCharacter;
        private Character _character;

        public void Initialize(DetectorCharacter detectorCharacter)
        {
            _detectorCharacter = detectorCharacter;

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
            Debug.Log("Нападаем");

            if (_character != null)
            {
                Movement();
            }
            else
            {
                _character = _detectorCharacter._character;
            }
        }

        private void Movement()
        {
            Vector3 normalizeDirection = GetRunDirection();

            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed);
            _rotater.Rotate(normalizeDirection, _moverAttributes.RotationSpeed, _moverAttributes.transform);
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