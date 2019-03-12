using Entitas;

public sealed class RootSystem : Feature
{
	public RootSystem(Contexts contexts)
	{
		Add(new ChangeDeltaTimeSystem(contexts));
		Add(new IncrementTimeTickSystem(contexts));
		Add(new ReactToTimeTickSystem(contexts));

		Add(new InitializeHexagonGridSystem(contexts));
		Add(new AddHexagonViewSystem(contexts));
		Add(new ClickInputSystem(contexts));
		Add(new DisplayHexagonTypeSystem(contexts));
		Add(new ChangeHexagonTypeSystem(contexts));
		Add(new RotateHexagonSystem(contexts));
		Add(new RotateHaxagonViewSystem(contexts));

		Add(new DestroyGameEntities(contexts));
	}
}