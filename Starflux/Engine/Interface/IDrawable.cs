
using Microsoft.Xna.Framework.Graphics;
namespace StarfluxEngine;

public interface IDrawable
{
	#region Public Methods

	public void Draw(SpriteBatch spriteBatch);

	#endregion
}