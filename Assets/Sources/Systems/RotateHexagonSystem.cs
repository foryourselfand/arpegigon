using System.Collections.Generic;
using Entitas;

public class RotateHexagonSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;

	public RotateHexagonSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(
			GameMatcher.ClickInput,
			GameMatcher.Position,
			GameMatcher.ButtonNumber)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasButtonNumber && entity.buttonNumber.value == 1;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var entity in entities)
		{
			var hexagons = _contexts.game.GetEntitiesWithPosition(entity.position.value);

			foreach (var hexagon in hexagons)
			{
				if (!hexagon.hasHexagonRotation) continue;
				var newRotation = hexagon.hexagonRotation.value;
				newRotation++;
				newRotation %= 6;

				hexagon.ReplaceHexagonRotation(newRotation);
			}

			entity.Destroy();
		}
	}
}