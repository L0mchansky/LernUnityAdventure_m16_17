using UnityEngine;

namespace m16_17
{
    public class BooAction : IActionOnState
    {
        private Transform _particleSystem;
        private GameObject _npc;

        public BooAction(GameObject npc, Transform particleSystemTransform)
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
            Remover.RemoveGameobject(_npc);
        }

        public void PlayParticle(Transform npcTransform)
        {
            _particleSystem.SetParent(null);
            _particleSystem.transform.position = npcTransform.position;
            _particleSystem.gameObject.SetActive(true);
        }
    }
}