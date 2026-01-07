using UnityEngine;
namespace m16_17
{
    public class NpcStrategy : MonoBehaviour
    {
        [SerializeField] EnumActionIdleState _enumIdle;
        [SerializeField] EnumActionReactingState _enumReacting;

        [SerializeField] private DetectorCharacter _detectorCharacter;
        [SerializeField] private Npc _npc;

        private bool IsWithin { get; set; }

        //private IMover _mover;

        //[SerializeField] private Rotater _rotater;
        private IActionOnState ActionOnState { get; set; }

        private void Awake()
        {
            IsWithin = false;
        }

        //private void Awake()
        //{
        //    if (gameObject.TryGetComponent<IMover>(out IMover mover))
        //    {
        //        _mover = mover;
        //    }
        //}

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

            ActionOnState.Action(_npc.State);

            //_moverTransform.ProcessTo(normalizeDirection, _speed);
            //_rotater.ProcessTo(normalizeDirection, _rotationSpeed, transform);
        }

        private void ChangeActionOnState(EnumState state)
        {
            _npc.State = state;

            if (state == EnumState.Idle)
            {
                switch (_enumIdle)
                {
                    case EnumActionIdleState.IdleAction:
                        ActionOnState = new IdleAction();
                        break;
                    case EnumActionIdleState.PatrolAction:
                        ActionOnState = new PatrolAction();
                        break;
                    case EnumActionIdleState.WalkingAction:
                        ActionOnState = new WalkingAction();
                        break;
                    default:
                        ActionOnState = new IdleAction();
                        break;
                }
            }
            else if (state == EnumState.Reacting)
            {
                switch (_enumReacting)
                {
                    case EnumActionReactingState.RunAction:
                        ActionOnState = new RunAction();
                        break;
                    case EnumActionReactingState.AgroAction:
                        ActionOnState = new AgroAction();
                        break;
                    case EnumActionReactingState.BooAction:
                        ActionOnState = new BooAction();
                        break;
                    default:
                        ActionOnState = new RunAction();
                        break;
                }
            }
        }
    }
}