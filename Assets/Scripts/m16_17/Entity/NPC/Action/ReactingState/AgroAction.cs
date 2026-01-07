using UnityEngine;

namespace m16_17
{
    public class AgroAction : IActionOnState
    {
        public void Action(EnumState state)
        {
            Debug.Log("Нападаем");
        }
    }
}