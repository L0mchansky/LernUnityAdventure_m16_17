using UnityEngine;

namespace m16_17
{
    public class Npc : MonoBehaviour
    {
        private const string _nameStrategyObject = "NpcStrategy";

        public NpcStrategy NpcStrategy { get; private set; }

        private void Awake()
        {
            Transform childTransformStrategy = transform.Find(_nameStrategyObject);

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