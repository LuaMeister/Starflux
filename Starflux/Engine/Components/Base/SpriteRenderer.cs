
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
		Console.WriteLine(GameObject.Transform.RotationRadians);
		spriteBatch.Draw(
			Sprite,
			GameObject.Transform.AbsolutePosition,
			null,
			Color,
			GameObject.Transform.RotationRadians,
			GameObject.Transform.Origin,
			GameObject.Transform.Scale,
			SpriteEffects.None,
			0
		);
	}

	#endregion
}

public class Textur2D { }