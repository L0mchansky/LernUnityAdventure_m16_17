using m16_17;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _npcPrefab;
    [SerializeField] private Character _character;
    [SerializeField] private List<Transform> _patrolPoints;
    [SerializeField] private List<GameObject> _spawnPointsPrefab;
    [SerializeField] private ParticleSystem _particleSystemPrefab;

    private float _shiftPosition = 0.5f;

    private void Start()
    {
        foreach (GameObject spawnPointGameObject in _spawnPointsPrefab)
        {
            SpawnPoint spawnPoint = spawnPointGameObject.GetComponent<SpawnPoint>();

            EnumActionIdleState enumActionIdle = spawnPoint.GetActionIdle();
            EnumActionReactingState enumActionReaction = spawnPoint.GetActionReacting();

            enumActionIdle = enumActionIdle == 0 ? EnumActionIdleState.IdleAction : enumActionIdle;
            enumActionReaction = enumActionReaction == 0 ? EnumActionReactingState.BooAction : enumActionReaction;

            GameObject npc = SpawnNpc(spawnPoint.transform);

            ParticleSystem particleSystem = Instantiate(_particleSystemPrefab, npc.transform);
            particleSystem.gameObject.SetActive(false);

            MoverTransform mover = npc.GetComponent<MoverTransform>();
            Rotater rotater = npc.GetComponent<Rotater>();
            MoverAttributes moverAttributes = npc.GetComponent<MoverAttributes>();

            IActionOnState actionIde = CreateActionIdle(enumActionIdle, npc, mover, rotater, moverAttributes);
            IActionOnState actionReaction = CreateActionReaction(enumActionReaction, npc, mover, rotater, moverAttributes, particleSystem);

            DetectorDistance detectorDistance = new DetectorDistance();

            NpcStrategy npcStrategy = npc.GetComponent<NpcStrategy>();
            npcStrategy.Initialize(actionIde, actionReaction, detectorDistance, _character.transform);
        }
    }

    private GameObject SpawnNpc(Transform transformSpawnPoint)
    {
        Vector3 npcPosition = new Vector3(transformSpawnPoint.position.x, _shiftPosition, transformSpawnPoint.position.z);
        GameObject npc = Instantiate(_npcPrefab, npcPosition, Quaternion.identity);
        return npc;
    }

    private IActionOnState CreateActionIdle(EnumActionIdleState state, GameObject npc, MoverTransform mover, Rotater rotater, MoverAttributes moverAttributes)
    {
        IActionOnState action = null;

        switch (state)
        {
            case EnumActionIdleState.IdleAction:
                action = new IdleAction();
                break;

            case EnumActionIdleState.PatrolAction:
                action = new PatrolAction(_patrolPoints, npc.transform, mover, rotater, moverAttributes);    
                break;

            case EnumActionIdleState.WalkingAction:
                action = new WalkingAction(npc.transform, mover, rotater, moverAttributes);
                break;
        }

        return action;
    }

    private IActionOnState CreateActionReaction(EnumActionReactingState state, GameObject npc, MoverTransform mover, Rotater rotater, MoverAttributes moverAttributes, ParticleSystem particleSystem)
    {
        IActionOnState action = null;

        switch (state)
        {
            case EnumActionReactingState.RunAction:
                action = new RunAction(npc.transform, mover, rotater, moverAttributes, _character.transform);
                break;

            case EnumActionReactingState.AgroAction:
                action= new AgroAction(npc.transform, mover, rotater, moverAttributes, _character.transform);
                break;

            case EnumActionReactingState.BooAction:
                action = new BooAction(npc, particleSystem.transform);
                break;
        }

        return action;
    }
}
