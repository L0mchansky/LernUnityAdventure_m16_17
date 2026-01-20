using UnityEngine;
namespace m16_17
{
    public class NpcStrategy : MonoBehaviour
    {
        private DetectorDistance _detectorDistance;
        
        private Transform _characterTransform;

        private IActionOnState _currentAction;
        private IActionOnState _actionIdle;
        private IActionOnState _actionReacting;

        private bool IsWithin { get; set; }

        public void Initialize(IActionOnState actionIdle, IActionOnState actionReacting, DetectorDistance detectorDistance, Transform characterTransform)
        {
            _actionIdle = actionIdle;
            _actionReacting = actionReacting;
            _characterTransform = characterTransform;
            _detectorDistance = detectorDistance;

            _currentAction = _actionIdle;
        }

        private void Update()
        {
            ChangeActionOnState();
            if (_currentAction != null) _currentAction.Action();
        }

        private void ChangeActionOnState()
        {
            IsWithin = _detectorDistance.IsWithinDistance(_characterTransform, transform);

            if (IsWithin == true)
            {
                _currentAction = _actionReacting;
            }

            if (IsWithin == false)
            {
                _currentAction = _actionIdle;
            } 


        }
    }
}