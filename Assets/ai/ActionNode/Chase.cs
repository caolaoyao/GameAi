using UnityEngine;
using System.Collections;

namespace GameAi
{
    public class Chase : ActionNode
    {
        public Chase()
        {
        }

        public override bool Process(AiController theOwner)
        {
            theOwner.Chase();
            return true;
        }
    }
}

