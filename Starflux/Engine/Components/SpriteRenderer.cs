
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarfluxEngine.SceneManagement;

namespace StarfluxEngine;

public class SpriteRenderer : Component, IDrawable
{
	#region Properties

	public Texture2D Sprite { get; set; } = null;
	public Color Color { get; set; } = Color.White;

	#endregion
	
	#region Public Methods

	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(
			texture: Sprite,
			position: GameObject.Transform.AbsolutePosition,
			color: Color
		);
	}

	#endregion
}

public class Textur2D { }