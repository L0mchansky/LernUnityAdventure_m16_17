using UnityEngine;

namespace m16_17
{
    public class PatrolAction : IActionOnState
    {
        public void Action()
        {
            Debug.Log("Ходим патрулируем");
        }
    }
}