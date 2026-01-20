using UnityEngine;

namespace m16_17
{
    public abstract class BaseMovementAction : IActionOnState
    {
        protected Transform _transformNpc;
        protected MoverTransform _mover;
        protected Rotater _rotater;
        protected MoverAttributes _moverAttributes;
        protected Transform _targetTransform;

        public BaseMovementAction(Transform transformNpc, MoverTransform mover,
                                Rotater rotater, MoverAttributes moverAttributes,
                                Transform targetTransform)
        {
            _transformNpc = transformNpc;
            _mover = mover;
            _rotater = rotater;
            _moverAttributes = moverAttributes;
            _targetTransform = targetTransform;
        }

        public void Action()
        {
            Debug.Log(GetActionName());
            Movement();
        }

        protected abstract string GetActionName();

        private void Movement()
        {
            Vector3 normalizeDirection = GetRunDirection();
            _mover.Move(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
            _rotater.Rotate(normalizeDirection, _moverAttributes.MoveSpeed, _transformNpc);
        }

        protected abstract Vector3 GetRunDirection();

        protected Vector3 GetDirectionToCharacter()
            => _targetTransform.position - _transformNpc.position;
    }
}