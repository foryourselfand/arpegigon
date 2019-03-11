using System.Linq;
using Entitas;
using UnityEngine;

public class ClickInputSystem : IExecuteSystem
{
	private Contexts _contexts;
	private IGroup<GameEntity> _entities;

	public ClickInputSystem(Contexts contexts)
	{
		_contexts = contexts;
		_entities = contexts.game.GetGroup(
			GameMatcher.AllOf(GameMatcher.Hexagon, GameMatcher.View));
	}

	public void Execute()
	{
		if (!Input.GetMouseButtonDown(0)) return;
		var hexes = _entities.GetEntities();
		var mousePosition = Input.mousePosition;

		var clickedHex = hexes.OrderBy(x => (x.view.value.transform.position - mousePosition).sqrMagnitude)
			.FirstOrDefault(
				x => (x.view.value.transform.position - mousePosition).magnitude <
				     _contexts.game.globals.value.clickRadius);

		if (clickedHex != null)
		{
			var e = _contexts.game.CreateEntity();
			e.isClickInput = true;
			e.AddPosition(clickedHex.position.value);
		}
	}
}