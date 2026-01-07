using UnityEngine;

namespace m16_17
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;

        [SerializeField] private EnumActionIdleState _enumIdle;
        [SerializeField] private EnumActionReactingState _enumReacting;

        private float _shiftPosition = 0.5f;

        private const string _nameStrategyObject = "NpcStrategy";

        void Start()
        {
            transform.position = new Vector3(transform.position.x, _shiftPosition, transform.position.z);

            GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            _enumIdle = _enumIdle == 0 ? EnumActionIdleState.IdleAction : _enumIdle;
            _enumReacting = _enumReacting == 0 ? EnumActionReactingState.BooAction : _enumReacting;

            Transform childTransform = enemy.transform.Find(_nameStrategyObject);

            if (childTransform != null)
            {
                if (childTransform.TryGetComponent<NpcStrategy>(out NpcStrategy npcStrategy))
                {
                    npcStrategy.Initialize(_enumIdle, _enumReacting);
                }
            }
        }
    }
}