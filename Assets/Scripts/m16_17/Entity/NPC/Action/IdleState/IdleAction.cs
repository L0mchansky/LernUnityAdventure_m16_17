using UnityEngine;

namespace m16_17
{
    public class IdleAction : IActionOnState
    {
        public void Action(EnumState state)
        {
            Debug.Log("Стоим пердим");
        }
    }
}