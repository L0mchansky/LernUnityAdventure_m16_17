using UnityEngine;

namespace m16_17
{
    public class BooAction : MonoBehaviour, IActionOnState
    {
        private const string NAME_PARTICLE_OBJECT = "NpcDeadParticle";
        private Transform _particleSystem;

        private GameObject _npc;
        public void Initialize()
        {
            _npc = gameObject.transform.parent.gameObject;
            _particleSystem = _npc.transform.Find(NAME_PARTICLE_OBJECT);
        }

        public void Action()
        {
            Debug.Log("Умираем");
            Die();
        }

        public void Die()
        {
            PlayParticle(_npc.transform);
            Destroy(_npc);
        }

        public void PlayParticle(Transform npcTransform)
        {
            _particleSystem.SetParent(null);
            _particleSystem.transform.position = npcTransform.position;
            _particleSystem.gameObject.SetActive(true);
        }
    }
}