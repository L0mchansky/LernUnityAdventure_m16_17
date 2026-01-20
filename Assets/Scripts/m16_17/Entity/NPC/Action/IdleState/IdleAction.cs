using UnityEngine;

namespace m16_17
{
    public class IdleAction : IActionOnState
    {
        public IdleAction() { }

        public void Action()
        {
            Debug.Log("Стоим");
        }
    }
}