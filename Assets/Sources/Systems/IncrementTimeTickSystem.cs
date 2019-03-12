using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class IncrementTimeTickSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;

	public IncrementTimeTickSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.DeltaTime);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasDeltaTime;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var deltaTimeEntity = entities.SingleEntity();
		var currentTick = _contexts.game.hasTickTime ? _contexts.game.tickTime.value : 0;
		currentTick += deltaTimeEntity.deltaTime.value;

		if (currentTick > _contexts.game.globals.value.tickInterval)
		{
			currentTick = 0;
			_contexts.game.isTick = false;
			_contexts.game.isTick = true;

//			Debug.Log("Tick Happened");
		}

		_contexts.game.ReplaceTickTime(currentTick);
	}
}