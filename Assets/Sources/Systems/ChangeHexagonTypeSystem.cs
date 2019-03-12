using System.Collections.Generic;
using Entitas;

public class ChangeHexagonTypeSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;

	public ChangeHexagonTypeSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(
			GameMatcher.ClickInput,
			GameMatcher.Position,
			GameMatcher.ButtonNumber));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isClickInput && entity.hasPosition &&
		       entity.hasButtonNumber && entity.buttonNumber.value == 0;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var hexagons = _contexts.game.GetEntitiesWithPosition(e.position.value);
			foreach (var hexagon in hexagons)
			{
				if (!hexagon.hasHexagonType) continue;
				var newType = (int) hexagon.hexagonType.value;
				newType++;
				newType %= 5;
				hexagon.ReplaceHexagonType((HexagonType) newType);
			}

			e.Destroy();
		}
	}
}