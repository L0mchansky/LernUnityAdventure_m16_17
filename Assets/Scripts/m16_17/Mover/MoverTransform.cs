using UnityEngine;

namespace m16_17
{
    public class MoverTransform : MonoBehaviour
    {
        public void Move(Vector3 normalizedDirection, float speed, Transform transform)
        {
            transform.Translate(normalizedDirection * speed * Time.deltaTime, Space.World);
        }
    }
}