using UnityEngine;

namespace m16_17
{
    public class IdleAction : IActionOnState
    {
        public void Action()
        {
            Debug.Log("Стоим пердим");
        }
    }
}