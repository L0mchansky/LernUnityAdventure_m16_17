using UnityEngine;

namespace m16_17
{
    public class NpcController : MonoBehaviour
    {
        private IActionOnState _actionOnState;
        public IActionOnState ActionOnState
        {
            get
            { 
                return _actionOnState; 
            }
            set 
            {
                _actionOnState = value; 
            }
        }
        private void Update()
        {
            if (_actionOnState != null) ActionOnState.Action();
        }

    }
}