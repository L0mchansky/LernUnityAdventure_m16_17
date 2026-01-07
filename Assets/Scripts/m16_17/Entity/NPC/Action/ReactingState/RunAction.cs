using UnityEngine;

namespace m16_17
{
    public class RunAction : IActionOnState
    {
        public void Action(EnumState state)
        {
            Debug.Log("Убегаем");
        }
    }
}