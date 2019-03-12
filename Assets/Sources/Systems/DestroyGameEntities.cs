using System.Collections.Generic;
using Entitas;

public class DestroyGameEntities : ReactiveSystem<GameEntity>
{
	public DestroyGameEntities(Contexts contexts) : base(contexts.game)
	{
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.Destroyed);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isDestroyed;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.Destroy();
		}
	}
}