
using System;
using Microsoft.Xna.Framework;
namespace StarfluxEngine;

public class Bouncer : Component, IUpdatable
{
	#region Public Fields

	public float Amplitude { get; set; } = 50;

	#endregion
	
	#region Framework Methods

	public void Update()
	{
		GameObject.Transform.Position += new Vector2(
			0,
			Amplitude * MathF.Sin(MathHelper.TwoPi * Time.TotalElapsedTime)
		);
	}
	
	#endregion
}