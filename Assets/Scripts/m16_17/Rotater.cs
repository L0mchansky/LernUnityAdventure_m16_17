using UnityEngine;

namespace m16_17
{
    public class Rotater : MonoBehaviour
    {
        public void Rotate(Vector3 direction, float rotationSpeed, Transform transform)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = rotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}