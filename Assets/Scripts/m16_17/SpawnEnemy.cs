using UnityEngine;

namespace m16_17
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        private float _shiftPosition = 0.5f;

        void Start()
        {
            transform.position = new Vector3(transform.position.x, _shiftPosition, transform.position.z);

            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}