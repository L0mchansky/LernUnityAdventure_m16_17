using UnityEngine;

namespace m16_17
{
    public class BooAction : IActionOnState
    {
        public void Action(EnumState state)
        {
            Debug.Log("Умираем");
        }
    }
}