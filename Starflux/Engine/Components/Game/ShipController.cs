
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace StarfluxEngine;
	
public class ShipController : Component, IUpdatable
{

	#region Framework Methods

	public void Update()
	{
		Vector2 direction = GetDirection();
		GameObject.Transform.Position += direction * 3;
	}

	private Vector2 GetDirection()
	{
		KeyboardState keyboardState = Keyboard.GetState();
		Vector2 inputVector = new Vector2(
			keyboardState.IsKeyDown(Keys.D) ? 1 : keyboardState.IsKeyDown(Keys.A) ? -1 : 0,
			keyboardState.IsKeyDown(Keys.S) ? 1 : keyboardState.IsKeyDown(Keys.W) ? -1 : 0
		);
		
		if (inputVector != Vector2.Zero)
			inputVector.Normalize();
		
		return inputVector;
	}

	#endregion
	
}