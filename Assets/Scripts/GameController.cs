using UnityEngine;

public class GameController : MonoBehaviour
{
	public Globals globals;
	public RectTransform uiRoot;

	private RootSystem _systems;

	private void Start()
	{
		var contexts = Contexts.sharedInstance;

		contexts.game.SetGlobals(globals);
		contexts.game.SetUiRoot(uiRoot );

		_systems = new RootSystem(contexts);

		_systems.Initialize();
	}

	private void Update()
	{
		_systems.Execute();
		_systems.Cleanup();
	}

	private void OnDestroy()
	{
		_systems.TearDown();
	}
}