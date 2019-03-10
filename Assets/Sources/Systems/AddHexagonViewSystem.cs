using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

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
		var globals = _contexts.game.globals.value;
		var hexagonPrefab = globals.hexagonPrefab;
		var uiRoot = _contexts.game.uiRoot.value;

		foreach (var entity in entities)
		{
			var hexagon = GameObject.Instantiate(hexagonPrefab, uiRoot);
			var rectTransform = (RectTransform) hexagon.transform;
			entity.AddView(hexagon);

			var position = new Vector2(entity.position.x * globals.widthSpacing,
				entity.position.y * globals.heightSpacing);
			var isEven = entity.position.x % 2 == 0;
			var image = hexagon.GetComponent<Image>();

			if (isEven)
			{
				image.color = globals.evenColor;
			}
			else
			{
				image.color = globals.oddColor;
				position.y += globals.heightOffSet;
			}

			rectTransform.anchoredPosition = position;
		}
	}
}