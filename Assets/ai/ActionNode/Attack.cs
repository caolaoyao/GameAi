using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class Attack : ActionNode
    {
        public Attack()
        {
        }

        public override bool Process(AiController theOwner)
        {
            theOwner.Attack();
            return true;
        }
    }
}

