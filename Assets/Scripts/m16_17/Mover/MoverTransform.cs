using UnityEngine;

namespace m16_17
{
    public class MoverTransform : MonoBehaviour, IMover
    {
        public void Move(Vector3 normalizedDirection, float speed)
        {
            transform.Translate(normalizedDirection * speed * Time.deltaTime, Space.World);
        }
    }
}