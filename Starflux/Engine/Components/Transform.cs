
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
	
	public Vector2 AbsolutePosition { get; private set; } = Vector2.Zero;
	
	#endregion

	#region Private Fields

	private Vector2 _position = new(0, 0);

	#endregion

	#region Public Methods

	private void UpdateAbsolutePosition(Vector2 position)
	{
		if (Parent != null)
			AbsolutePosition = Parent.AbsolutePosition + Position;
		else
			AbsolutePosition = Position;
		
		_position = position;
	}

	#endregion
}