using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public interface IActionOnState
    {
        public void Action();
        public void Initialize() {}
        public void Initialize(List<Transform> transforms) {}
    }
}
