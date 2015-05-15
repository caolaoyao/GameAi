using GameAi.Util;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameAi.Manager
{
    class BTreeManager : Singleton<BTreeManager>
    {
        private Dictionary<string, BehaviorTreeRoot> _bTreeDict;
        private Type _bTreeType;
        private Assembly _bTreeAsm;

        public BTreeManager()
        {
            _bTreeType = typeof(BehaviorTreeRoot);
            _bTreeAsm = Assembly.GetAssembly(_bTreeType);
            _bTreeDict = new Dictionary<string, BehaviorTreeRoot>();
        }

        public BehaviorTreeRoot GetBTree(string name)
        {
            if (_bTreeDict.ContainsKey(name))
            {
                return _bTreeDict[name];
            }
            return CreateNetBTree(name);
        }

        private BehaviorTreeRoot CreateNetBTree(string name)
        {
            System.Type type = _bTreeAsm.GetType(string.Format("{0}.{1}", _bTreeType.Namespace, name));
            BehaviorTreeRoot bTree = System.Activator.CreateInstance(type) as BehaviorTreeRoot;
            return bTree;
        }
    }
}
