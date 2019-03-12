using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ReactToTimeTickSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;
	
	public ReactToTimeTickSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Tick );
	}

	protected override bool Filter(GameEntity entity)
	{
		return true;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		Debug.Log("Tick Happens in another System");
	}
}