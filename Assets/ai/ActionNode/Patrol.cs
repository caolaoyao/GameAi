using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class Patrol : ActionNode
    {
        public int PatrolRange = 0;
        public Patrol()
        {
        }

        public override bool Process(AiController theOwner)
        {
            theOwner.Patrol(PatrolRange);
            return true;
        }
    }
}

