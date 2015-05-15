using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class CanNotFindPlayer : ConditionNode
    {
        public CanNotFindPlayer()
        {
        }

        public override bool Process(AiController theOwner)
        {
            return theOwner.CanNotFindPlayer();
        }
    }
}

