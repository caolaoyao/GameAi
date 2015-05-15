// Exported behavior: GameAi\ai_1.cs
// Exported file:     C:\Users\liang\Documents\Brainiac Designer\Behaviors\GameAi\ai_1.xml

namespace GameAi
{
	public sealed class ai_1 : BehaviorTreeRoot
	{
		public ai_1()
		{
			{
				SelectorLinear node1 = new SelectorLinear();
				this.AddChild(node1);
				{
					SequenceLinear node2 = new SequenceLinear();
					node1.AddChild(node2);
					{
						IsPlayerInAttackRange node3 = new IsPlayerInAttackRange();
						node2.AddChild(node3);
					}
					{
						Attack node4 = new Attack();
						node2.AddChild(node4);
					}
				}
				{
					SequenceLinear node5 = new SequenceLinear();
					node1.AddChild(node5);
					{
						CanNotFindPlayer node6 = new CanNotFindPlayer();
						node5.AddChild(node6);
					}
					{
						Patrol node7 = new Patrol();
						node7.PatrolRange = 5;
						node5.AddChild(node7);
					}
				}
				{
					SequenceLinear node8 = new SequenceLinear();
					node1.AddChild(node8);
					{
						FindPlayer node9 = new FindPlayer();
						node8.AddChild(node9);
					}
					{
						Chase node10 = new Chase();
						node8.AddChild(node10);
					}
				}
			}
		}
	}
}
