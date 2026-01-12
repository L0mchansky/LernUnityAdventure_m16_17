using UnityEngine;

namespace m16_17
{
    public class MoverAttributes : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public float MoveSpeed
        {
            get 
            {
                return _moveSpeed;
            }
            private set
            { 
                _moveSpeed = value; 
            }
        }

        public float RotationSpeed
        {
            get 
            {
                return _rotationSpeed;
            }
            private set 
            { 
                _rotationSpeed = value; 
            }
        }
    }
}