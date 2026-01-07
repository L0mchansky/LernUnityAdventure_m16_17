using UnityEngine;

namespace m16_17
{
    public class DetectorDistance
    {
        public bool IsWithinDistance(Transform secondPoint, Transform firstPoint, float _minDistanceForDetect)
        {
            Vector3 direction = secondPoint.position - firstPoint.position;

            float distance = direction.magnitude;

            if (direction.magnitude < _minDistanceForDetect)
            {
                Debug.DrawLine(firstPoint.position, secondPoint.position, Color.red);
                return true;
            }
            else
            {
                Debug.DrawLine(firstPoint.position, secondPoint.position, Color.white);
                return false;
            }
        }
    }
}