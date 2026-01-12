using UnityEngine;

namespace m16_17
{
    public class Npc : MonoBehaviour
    {
        private const string NAME_STRATEGY_OBJECT = "NpcStrategy";

        public NpcStrategy NpcStrategy { get; private set; }

        private void Awake()
        {
            Transform childTransformStrategy = transform.Find(NAME_STRATEGY_OBJECT);

            if (childTransformStrategy != null)
            {
                if (childTransformStrategy.TryGetComponent<NpcStrategy>(out NpcStrategy npcStrategy))
                {
                    NpcStrategy = npcStrategy;
                }
            }
        }
    }
}