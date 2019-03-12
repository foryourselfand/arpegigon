using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RotateHaxagonViewSystem : ReactiveSystem<GameEntity>
{
	public RotateHaxagonViewSystem(Contexts contexts) : base(contexts.game)
	{
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.HexagonRotation);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasHexagonRotation;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var angle = e.hexagonRotation.value * -60F;
			e.view.value.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
}