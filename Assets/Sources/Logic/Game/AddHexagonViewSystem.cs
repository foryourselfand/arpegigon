using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddHexagonViewSystem : ReactiveSystem<GameEntity>
{
	private Contexts _contexts;

	public AddHexagonViewSystem(Contexts contexts) : base(contexts.game)
	{
		_contexts = contexts;
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.Position));
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isHexagon && entity.hasPosition;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		var hexagonPrefab = _contexts.game.globals.value.hexagonPrefab;
		var uiRoot = _contexts.game.uiRoot.value;


		foreach (var e in entities)
		{
			var hexagon = GameObject.Instantiate(hexagonPrefab, uiRoot);
			var rectTransform = (RectTransform) hexagon.transform;
			rectTransform.anchoredPosition = new Vector2(e.position.value.x * 45F, e.position.value.y * 45F);
		}
	}
}