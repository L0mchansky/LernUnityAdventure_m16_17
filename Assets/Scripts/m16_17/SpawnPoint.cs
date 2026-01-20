using m16_17;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnumActionIdleState _enumIdle;
    [SerializeField] private EnumActionReactingState _enumReacting;

    public EnumActionIdleState GetActionIdle() => _enumIdle;
    public EnumActionReactingState GetActionReacting() => _enumReacting;
}
