using UnityEngine;

namespace m16_17
{
    public class Npc : MonoBehaviour
    {
        public readonly float _speed = 5;
        public readonly float _rotationSpeed = 300;

        private EnumState _state;

        public EnumState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        private void Awake()
        {
            State = EnumState.Idle;
        }
    }
}