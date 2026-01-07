using UnityEngine;

namespace m16_17
{
    public class PatrolAction : IActionOnState
    {
        public void Action(EnumState state)
        {
            Debug.Log("Ходим патрулируем");
        }
    }
}