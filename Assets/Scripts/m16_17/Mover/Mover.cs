using UnityEngine;

namespace m16_17
{
    public class Mover: MonoBehaviour
    {
        [SerializeField] private MoverAttributes _moverAttributes;
        private IMover _mover;
        private Rotater _rotater;
        private Transform _transformRotate;

        public void Initialize(IMover mover, Rotater rotater, Transform transformRotate)
        {
            _mover = mover;
            _rotater = rotater;
            _transformRotate = transformRotate;
        }

        public void Move(Vector3 normalizeDirection)
        {
            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed);
        }

        public void Rotate(Vector3 normalizeDirection)
        {
            _rotater.Rotate(normalizeDirection, _moverAttributes.RotationSpeed, _transformRotate);
        }
    }
}
