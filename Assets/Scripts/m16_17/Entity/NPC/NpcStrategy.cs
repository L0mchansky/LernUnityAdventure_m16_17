using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace m16_17
{
    public class NpcStrategy : MonoBehaviour
    {
        [SerializeField] private DetectorCharacter _detectorCharacter;
        [SerializeField] private NpcController _npcController;

        [SerializeField] private EnumActionIdleState _enumIdle;
        [SerializeField] private EnumActionReactingState _enumReacting;

        [SerializeField] private Mover _moverPrefab;

        private Npc _npc;

        private const string NAME_COLLETIONS_PATROL_POINTS = "PatrolPoints";
        private const string NAME_PARTICLE_OBJECT = "NpcDeadParticle";

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

        public void Initialize(EnumActionIdleState enumIdle, EnumActionReactingState enumReacting, Npc npc)
        {
            EnumIdle = enumIdle;
            EnumReacting = enumReacting;
            _npc = npc;

            SetAction(EnumState.Idle);
        }

        private void Awake()
        {
            IsWithin = false;
        }

        private void Update()
        {
            ChangeActionOnState();
        }

        private void ChangeActionOnState()
        {
            Character character = _detectorCharacter.Detect();

            if (character != null)
            {

                if (IsWithin == false)
                {
                    SetAction(EnumState.Reacting);
                    IsWithin = true;
                }
            }
            else
            {

                if (IsWithin)
                {
                    SetAction(EnumState.Idle);
                    IsWithin = false;
                }
            }
        }

        private void SetAction(EnumState state)
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

                        if(TryGetComponent<PatrolAction>(out PatrolAction patrolAction) == false)
                        {
                            action = createPatrolAction();
                        }
                        else
                        {
                            action = patrolAction;
                        }

                        break;

                    case EnumActionIdleState.WalkingAction:

                        if (TryGetComponent<WalkingAction>(out WalkingAction walkingAction) == false)
                        {
                            Mover mover = CreateMover();
                            WalkingAction newWalkingAction = gameObject.AddComponent<WalkingAction>();
                            newWalkingAction.Initialize(mover);
                            action = newWalkingAction;
                        }
                        else
                        {
                            action = walkingAction;
                        }

                        break;
                }
            }
            else if (state == EnumState.Reacting)
            {
                switch (_enumReacting)
                {
                    case EnumActionReactingState.RunAction:

                        if (TryGetComponent<RunAction>(out RunAction runAction) == false)
                        {
                            Mover mover = CreateMover();
                            RunAction newRunAction = gameObject.AddComponent<RunAction>();
                            newRunAction.Initialize(_detectorCharacter, mover);
                            action = newRunAction;
                        }
                        else
                        {
                            action = runAction;
                        }

                        break;

                    case EnumActionReactingState.AgroAction:

                        if (TryGetComponent<AgroAction>(out AgroAction agroAction) == false)
                        {
                            Mover mover = CreateMover();
                            AgroAction newAgroAction = gameObject.AddComponent<AgroAction>();
                            newAgroAction.Initialize(_detectorCharacter, mover);
                            action = newAgroAction;
                        }
                        else
                        {
                            action = agroAction;
                        }

                        break;

                    case EnumActionReactingState.BooAction:

                        if (TryGetComponent<BooAction>(out BooAction booAction) == false)
                        {
                            BooAction newBooAction = gameObject.AddComponent<BooAction>();
                            Transform particleSystemTransform = _npc.transform.Find(NAME_PARTICLE_OBJECT);
                            newBooAction.Initialize(_npc, particleSystemTransform);
                            action = newBooAction;
                        }
                        else
                        {
                            action = booAction;
                        }

                        break;
                }
            }

            if (action != null)
            {
                _npcController.ActionOnState = action;
            }
        }

        private IActionOnState createPatrolAction()
        {
            Mover mover = CreateMover();

            PatrolAction patrolAction = gameObject.AddComponent<PatrolAction>();

            GameObject patrolPoints = GameObject.Find(NAME_COLLETIONS_PATROL_POINTS);
            Transform[] allChildren = patrolPoints.GetComponentsInChildren<Transform>();

            List<Transform> childTransforms = new List<Transform>();

            foreach (Transform child in allChildren)
            {
                if (child != patrolPoints.transform) 
                    childTransforms.Add(child);
            }

            patrolAction.Initialize(childTransforms, mover);

            return patrolAction;
        }

        private Mover CreateMover()
        {
            Mover oldMover = _npc.GetComponentInChildren<Mover>();

            if (oldMover != null)
                return oldMover;

            Mover mover = Instantiate(_moverPrefab, transform.position, Quaternion.identity);

            MoverTransform moverTransform = mover.AddComponent<MoverTransform>();
            moverTransform.Initialize(_npc.transform);

            Rotater rotater = mover.AddComponent<Rotater>();

            mover.Initialize(moverTransform, rotater, _npc.transform);

            mover.transform.SetParent(_npc.transform);

            return mover;
        }
    }
}