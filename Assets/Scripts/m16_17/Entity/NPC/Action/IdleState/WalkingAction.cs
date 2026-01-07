using UnityEngine;

namespace m16_17
{
    public class WalkingAction : IActionOnState
    {
        public void Action()
        {
            Debug.Log("Ходим-бродим");
        }
    }
}