using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameAi
{
    public interface IBehaviorTreeNode
    {
        bool Process(AiController theOwner);
    }

    /// <summary>
    /// 行为框架，具体实现要继承DecoratorNode, ConditionNode, ActionNode, ImpulseNode
    /// </summary>
    public class BehaviorTreeRoot : IBehaviorTreeNode
    {
        public IBehaviorTreeNode root = null;
        public BehaviorTreeRoot()
        {
        }

        public bool Process(AiController theOwner)
        {
            return root.Process(theOwner);
        }

        public void AddChild(IBehaviorTreeNode root)
        {
            this.root = root;
        }
    }

    /// <summary>
    /// 复合节点，不能为叶子节点
    /// </summary>
    public class CompositeNode : IBehaviorTreeNode
    {
        protected List<IBehaviorTreeNode> children = new List<IBehaviorTreeNode>();

        /// <summary>
        /// 由子树实现
        /// </summary>
        /// <param name="theOwner"></param>
        /// <returns></returns>
        public virtual bool Process(AiController theOwner)
        {
            return true;
        }

        public void AddChild(IBehaviorTreeNode _node)
        {
            children.Add(_node);
        }

        public void DelChild(IBehaviorTreeNode _node)
        {
            children.Remove(_node);
        }

        public void ClearChildren()
        {
            children.Clear();
        }
    }
    /// <summary>
    /// 修饰类
    /// </summary>
    public class DecoratorNode : IBehaviorTreeNode
    {
        protected IBehaviorTreeNode child = null;

        /// <summary>
        /// 由子类实现
        /// </summary>
        /// <param name="theOwner"></param>
        /// <returns></returns>
        public virtual bool Process(AiController theOwner)
        {
            return child.Process(theOwner);
        }

        public void Proxy(IBehaviorTreeNode _child)
        {
            child = _child;
        }
    }

    /// <summary>
    /// 脉冲类
    /// </summary>
    public class ImpulseNode : IBehaviorTreeNode
    {
        protected IBehaviorTreeNode child = null;

        /// <summary>
        /// 由子类实现
        /// </summary>
        /// <param name="theOwner"></param>
        /// <returns></returns>
        public virtual bool Process(AiController theOwner)
        {
            return child.Process(theOwner);
        }

        public void Proxy(IBehaviorTreeNode _child)
        {
            child = _child;
        }
    }

    /// <summary>
    /// 叶子节点，条件判断类
    /// </summary>
    public class ConditionNode : IBehaviorTreeNode
    {
        /// <summary>
        /// 由子类实现
        /// </summary>
        /// <param name="theOwner"></param>
        /// <returns></returns>
        public virtual bool Process(AiController theOwner)
        {
            return false;
        }
    }

    /// <summary>
    /// 叶子节点，具体行为实现类
    /// </summary>
    public class ActionNode : IBehaviorTreeNode
    {
        /// <summary>
        /// 由子类实现
        /// </summary>
        /// <param name="theOwner"></param>
        /// <returns></returns>
        public virtual bool Process(AiController theOwner)
        {
            return false;
        }
    }

    /// <summary>
    /// 选择节点
    /// 遇到一个child执行后返回true,停止迭代
    /// 本node向自己的父节点返回true
    /// 如果所有的child都返回false，本node向自己父节点返回false
    /// </summary>
    public class SelectorLinear : CompositeNode
    {
        public override bool Process(AiController theOwner)
        {
            foreach (IBehaviorTreeNode _node in children)
            {
                if (_node.Process(theOwner))
                {
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 遇到一个child执行后返回false，停止迭代
    /// 本node向自己的父节点返回false
    /// 如果所有的child都返回true，本node向自己父节点返回true
    /// </summary>
    public class SequenceLinear : CompositeNode
    {
        public override bool Process(AiController theOwner)
        {
            foreach (IBehaviorTreeNode _node in children)
            {
                if (!_node.Process(theOwner))
                {
                    return false;
                }
            }
            return true;
        }
    }

    /// <summary>
    /// 修饰类取反
    /// </summary>
    public class DecoratorNot : DecoratorNode
    {
        public override bool Process(AiController theOwner)
        {
            return !base.Process(theOwner);
        }
    }
}
