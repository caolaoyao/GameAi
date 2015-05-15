using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class FindPlayer : ConditionNode
    {
        public FindPlayer()
        {
        }

        public override bool Process(AiController theOwner)
        {
            return theOwner.FindPlayer();
        }
    }
}

