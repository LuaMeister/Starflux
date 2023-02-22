
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace StarfluxEngine.SceneManagement;

public class Scene
{
	#region Public Fields

	public List<GameObject> GameObjects = new();

	#endregion
	
	#region Public Methods

	public void StartScene()
	{
		foreach (GameObject gameObject in GameObjects)
			gameObject.StartComponents();
	}
	
	public void DrawScene(SpriteBatch spriteBatch)
	{
		foreach (GameObject gameObject in GameObjects)
			gameObject.DrawComponents(spriteBatch);
	}

	public void UpdateScene()
	{
		foreach (GameObject gameObject in GameObjects)
			gameObject.UpdateComponents();
	}

	#endregion
}