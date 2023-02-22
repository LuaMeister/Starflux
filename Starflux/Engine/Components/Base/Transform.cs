
using System;
using Microsoft.Xna.Framework;
namespace StarfluxEngine;

public class Transform : Component
{
	#region Properties
	
	public Transform Parent { get; private set; } = null;
	
	public Vector2 Position {
		get => _position;
		set => UpdateAbsolutePosition(value);
	}
	
	public Vector2 Origin
	{
		get => _origin;
		set => UpdateOrigin(value);
	}

	public float Rotation
	{
		get => _rotation;
		set
		{
			_rotation = value;
			_rotationRadians = MathHelper.ToRadians(value);
		}
	}
	
	public float RotationRadians
	{
		get => _rotationRadians;
		set
		{
			_rotationRadians = value;
			_rotation = MathHelper.ToDegrees(value);
		}
	}
	
	public Vector2 Scale { get; set; } = Vector2.One;
	public Vector2 AbsolutePosition { get; private set; } = Vector2.Zero;
	
	#endregion
	
	#region Private Fields

	private Vector2 _position = new(0, 0);
	private Vector2 _origin = new(0, 0);
	private float _rotation = 0;
	private float _rotationRadians = 0;

	#endregion

	#region Private Methods

	private void UpdateAbsolutePosition(Vector2 position)
	{
		if (Parent != null)
			AbsolutePosition = Parent.AbsolutePosition + Position;
		else
			AbsolutePosition = Position;

		_position = position;
	}

	private void UpdateOrigin(Vector2 origin)
	{
		Vector2 multiplier = Vector2.Clamp(origin, Vector2.Zero, Vector2.One);
		
		SpriteRenderer spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
		if (spriteRenderer != null)
		{
			_origin = new Vector2(
				spriteRenderer.Sprite.Width * multiplier.X,
				spriteRenderer.Sprite.Height * multiplier.Y
			);
		}
	}
	
	#endregion
}