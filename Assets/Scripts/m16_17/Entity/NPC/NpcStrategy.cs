using UnityEngine;
namespace m16_17
{
    public class NpcStrategy : MonoBehaviour
    {
        [SerializeField] private DetectorCharacter _detectorCharacter;
        [SerializeField] private NpcController _npcController;

        [SerializeField] private EnumActionIdleState _enumIdle;
        [SerializeField] private EnumActionReactingState _enumReacting;

        public EnumActionIdleState EnumIdle {
            get
            { 
                return _enumIdle; 
            }
            private set 
            { 
                _enumIdle = value; 
            }
        }

        public EnumActionReactingState EnumReacting
        {
            get 
            { 
                return _enumReacting; 
            }
            private set 
            { 
                _enumReacting = value; 
            }
        }

        private bool IsWithin { get; set; }

        public void Initialize(EnumActionIdleState enumIdle, EnumActionReactingState enumReacting)
        {
            EnumIdle = enumIdle;
            EnumReacting = enumReacting;
        }

        private void Awake()
        {
            IsWithin = false;
        }

        private void Update()
        {
            Character character = _detectorCharacter.Detect();

            if (character != null)
            {

                if (IsWithin == false)
                {
                    ChangeActionOnState(EnumState.Reacting);
                    IsWithin = true;
                }
            }
            else
            {

                if (IsWithin)
                {
                    ChangeActionOnState(EnumState.Idle);
                    IsWithin = false;
                }
            }
        }

        private void ChangeActionOnState(EnumState state)
        {
            IActionOnState action = null;

            if (state == EnumState.Idle)
            {
                switch (_enumIdle)
                {
                    case EnumActionIdleState.IdleAction:
                        action = new IdleAction();
                        break;
                    case EnumActionIdleState.PatrolAction:
                        action = new PatrolAction();
                        break;
                    case EnumActionIdleState.WalkingAction:
                        action = new WalkingAction();
                        break;
                }
            }
            else if (state == EnumState.Reacting)
            {
                switch (_enumReacting)
                {
                    case EnumActionReactingState.RunAction:
                        action = new RunAction();
                        break;
                    case EnumActionReactingState.AgroAction:
                        action = new AgroAction();
                        break;
                    case EnumActionReactingState.BooAction:
                        action = new BooAction();
                        break;
                }
            }

            if (action != null)
            {
                _npcController.ActionOnState = action;
            }
        }
    }
}