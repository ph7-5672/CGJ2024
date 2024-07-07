using Godot;

public partial class GameTitle : Control
{
	public override void _Ready()
	{
		startGameButton.Pressed += () =>
		{
			QueueFree();
			GetTree().Root.AddChild(gameScene.Instantiate());
		};

		exitGameButton.Pressed += () =>
		{
			GetTree().Quit();
		};
	}

	[Export]
	TextureButton startGameButton;

	[Export]
	TextureButton exitGameButton;

	[Export]
	PackedScene gameScene;
}
