using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarfluxEngine.SceneManagement;

namespace Starflux;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "DesktopGLContent";
		IsMouseVisible = true;
		
	}

	protected override void Initialize()
	{
		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);
		
		SceneManager.ContentManager = Content;
		SceneManager.LoadScene(1);
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
		    Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		SceneManager.ActiveScene.UpdateScene();

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.DarkRed);

		_spriteBatch.Begin();
		SceneManager.ActiveScene.DrawScene(_spriteBatch);
		_spriteBatch.End();

		base.Draw(gameTime);
	}
}