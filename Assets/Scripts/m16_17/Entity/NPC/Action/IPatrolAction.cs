using System.Collections.Generic;
using UnityEngine;

namespace m16_17
{
    public interface IPatrolAction : IActionOnState
    {
        public void InitializePatrol(List<Transform> patrolPoints);
    }
}
