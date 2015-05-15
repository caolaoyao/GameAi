using UnityEngine;
using System.Collections;
using GameAi.Manager;

namespace GameAi
{
    public class AiController : MonoBehaviour
    {
        private BehaviorTreeRoot _aiBehaviorTree;
        private string _aiBTreeName = "ai_1";
        private float _aiIntervalTick = 0f;
        private float _aiIntervalTime = 0.5f;

        private void RegisterAiBehaviorTree()
        {
            _aiBehaviorTree = BTreeManager.instance.GetBTree(_aiBTreeName);
        }

        // Use this for initialization
        void Start()
        {
            RegisterAiBehaviorTree();
        }

        void FixedUpdate()
        {
            //ai执行时间间隔处理
            if (_aiIntervalTick == -1f)
            {
                _aiBehaviorTree.Process(this);
                _aiIntervalTick = 0f;
            }
            else
            {
                _aiIntervalTick += Time.deltaTime;
                if (_aiIntervalTick >= _aiIntervalTime)
                {
                    _aiBehaviorTree.Process(this);
                    _aiIntervalTick = 0f;
                }
            }
        }

        public void Chase()
        {
            Debug.Log("==========Chase======= ");
        }

        public void Attack()
        {
            Debug.Log("=========Attack========");
        }

        public void Patrol(int patrolRange)
        {
            Debug.Log("=========Patrol========" + patrolRange);
        }

        public bool FindPlayer()
        {
            Debug.Log("=========FindPlayer========");
            if (Random.Range(0, 10) > 5)
            {
                return false;
            }
            return true;
        }

        public bool IsPlayerInAttackRange()
        {
            Debug.Log("=========IsPlayerInAttackRange========");
            if (Random.Range(0, 10) > 5)
            {
                return false;
            }
            return true;
        }

        public bool CanNotFindPlayer()
        {
            Debug.Log("=========CanNotFindPlayer========");
            if (Random.Range(0, 10) > 5)
            {
                return false;
            }
            return true;
        }
    }
}

