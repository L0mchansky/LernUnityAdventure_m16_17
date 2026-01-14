using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace m16_17
{
    public class SpawnNpc : MonoBehaviour
    {
        [SerializeField] private GameObject _npcPrefab;

        [SerializeField] private EnumActionIdleState _enumIdle;
        [SerializeField] private EnumActionReactingState _enumReacting;

        private float _shiftPosition = 0.5f;

        void Start()
        {
            transform.position = new Vector3(transform.position.x, _shiftPosition, transform.position.z);

            GameObject npcObject = Instantiate(_npcPrefab, transform.position, Quaternion.identity);
            Npc npc = npcObject.GetComponent<Npc>();

            _enumIdle = _enumIdle == 0 ? EnumActionIdleState.IdleAction : _enumIdle;
            _enumReacting = _enumReacting == 0 ? EnumActionReactingState.BooAction : _enumReacting;

            NpcStrategy npcStrategy = npc.GetComponent<Npc>().NpcStrategy;

            if (npcStrategy != null)
            {
                npcStrategy.Initialize(_enumIdle, _enumReacting, npc);
            }
        }
    }
}