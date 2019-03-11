using System.Collections.Generic;
using Entitas;

public class DisplayHexagonTypeSystem : ReactiveSystem<GameEntity>
{
	public DisplayHexagonTypeSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.HexagonType);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasView && entity.hasHexagonType;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			e.view.value.GetComponent<HexagonViewBehaviour>().SetType(e.hexagonType.value);
		}
	}
}