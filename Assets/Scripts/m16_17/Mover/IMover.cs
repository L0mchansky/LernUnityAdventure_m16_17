using UnityEngine;

namespace m16_17
{
    public interface IMover
    {
        void Move(Vector3 normalizedDirection, float speed);
    }
}