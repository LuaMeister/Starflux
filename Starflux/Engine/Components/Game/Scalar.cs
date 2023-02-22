
using System;
using Microsoft.Xna.Framework;

namespace StarfluxEngine;

public class Scalar : Component, IUpdatable
{
	#region Public Field

	public float Amplitude { get; set; } = 1;
	public float Speed { get; set; } = 1;

	#endregion

	#region Framework Methods

	public void Update()
	{
		float sine = MathF.Sin(Time.TotalElapsedTime * MathHelper.TwoPi * Speed);
		GameObject.Transform.Scale = Vector2.One * (sine + 1) / 2 * Amplitude;
	}
	
	#endregion
}