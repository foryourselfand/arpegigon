using Entitas;

public sealed class RootSystem : Feature
{
	public RootSystem(Contexts contexts)
	{
		Add(new InitializeHexagonGridSystem(contexts));
		Add(new AddHexagonViewSystem(contexts));
		Add(new ClickInputSystem(contexts));
		Add(new DisplayHexagonTypeSystem(contexts));
		Add(new ChangeHexagonTypeSystem(contexts));
	}
}