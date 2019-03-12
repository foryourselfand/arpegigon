using Entitas;
using UnityEngine;

public class InitializeHexagonGridSystem : IInitializeSystem
{
	private Contexts _contexts;

	public InitializeHexagonGridSystem(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Initialize()
	{
		for (var i = 0; i < 6; i++)
		{
			for (var j = 0; j < 14; j++)
			{
				var e = _contexts.game.CreateEntity();

				e.AddPosition(new IntVector2(j, i));
				e.isHexagon = true;
				e.AddHexagonType(HexagonType.Empty);
				e.AddHexagonRotation(0);
			}
		}
	}
}