using UnityEngine;

namespace m16_17
{
    public class BooAction : MonoBehaviour, IActionOnState
    {
        private Transform _particleSystem;
        private Npc _npc;

        public void Initialize(Npc npc, Transform particleSystemTransform)
        {
            _npc = npc;
            _particleSystem = particleSystemTransform;
        }

        public void Action()
        {
            Debug.Log("Умираем");
            Die();
        }

        public void Die()
        {
            PlayParticle(_npc.transform);
            Destroy(_npc.gameObject);
        }

        public void PlayParticle(Transform npcTransform)
        {
            _particleSystem.SetParent(null);
            _particleSystem.transform.position = npcTransform.position;
            _particleSystem.gameObject.SetActive(true);
        }
    }
}