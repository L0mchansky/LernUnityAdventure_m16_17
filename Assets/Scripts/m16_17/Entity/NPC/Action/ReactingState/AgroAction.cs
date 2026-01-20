using UnityEngine;

namespace m16_17
{
    public class AgroAction : BaseMovementAction
    {
        public AgroAction
            (Transform transformNpc,
            MoverTransform mover,
            Rotater rotater,
            MoverAttributes moverAttributes,
            Transform targetTransform)
            : base(transformNpc, mover, rotater, moverAttributes, targetTransform)
        {
        }

        protected override string GetActionName() => "Нападаем";

        protected override Vector3 GetRunDirection()
        {
            Vector3 direction = GetDirectionToCharacter();
            direction = direction.normalized;
            direction = new Vector3(direction.x, 0, direction.z);
            return direction;
        }
    }
}