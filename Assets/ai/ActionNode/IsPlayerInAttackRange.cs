using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class IsPlayerInAttackRange : ConditionNode
    {
        public IsPlayerInAttackRange()
        {
        }

        public override bool Process(AiController theOwner)
        {
            return theOwner.IsPlayerInAttackRange();
        }
    }
}

