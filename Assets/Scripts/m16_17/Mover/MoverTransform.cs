using UnityEngine;

namespace m16_17
{
    public class MoverTransform : MonoBehaviour, IMover
    {
        private Transform _entityTransform;

        public void Move(Vector3 normalizedDirection, float speed)
        {
            if (_entityTransform != null)
                _entityTransform.Translate(normalizedDirection * speed * Time.deltaTime, Space.World);
        }

        public void Initialize(Transform transform)
        {
            _entityTransform = transform;
        }
    }
}