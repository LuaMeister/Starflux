
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using StarfluxEngine.SceneManagement;

namespace StarfluxEngine;

public class GameObject
{
	#region Properties

	public string Name { get; set; } = "GameObject";

	#endregion
	
	#region Public Fields

	public readonly Transform Transform;

	#endregion
	
	#region Private Fields

	private readonly List<Component> _components = new();
	private readonly List<IDrawable> _drawableComponents = new();
	private readonly List<IUpdatable> _updatableComponents = new();

	#endregion

	#region Constructors

	private GameObject()
	{
		Transform = AddComponent<Transform>();
	}

	#endregion
	
	#region Public Methods

	public static GameObject Instantiate()
	{
		GameObject gameObject = new();
		
		SceneManager.ActiveScene.GameObjects.Add(gameObject);
		
		return gameObject;
	}
	
	
	/// <summary>
	/// Adds a component class of type componentType to the game object. C# Users can use a generic version.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>An instance of type T that was just created</returns>
	public T AddComponent<T>() where T : Component, new()
	{
		T newComponent = new T() { GameObject = this };

		if (newComponent is IDrawable drawableComponent)
			_drawableComponents.Add(drawableComponent);
		
		if (newComponent is IUpdatable updatableComponent)
			_updatableComponents.Add(updatableComponent);

		_components.Add(newComponent);
		
		return newComponent;
	}
	
	/// <summary>
	/// Gets the first matching reference to a component of type T on the same GameObject as the component specified.
	/// </summary>
	/// <typeparam name="T">Type of the component</typeparam>
	/// <returns>A reference to the component of type T if one is found, otherwise null</returns>
	public T GetComponent<T>() where T : Component
	{
		foreach (Component component in _components)
			if (component is T typeComponent)
				return typeComponent;
		return null;
	}

	#endregion

	#region Lifetime Methods
	
	public void StartComponents()
	{
		foreach (Component component in _components)
			component.Start();
	}

	/// <summary>
	/// Calls the IDrawable.Draw() method on each component inside of list _drawableComponents.
	/// </summary>
	public void DrawComponents(SpriteBatch spriteBatch)
	{
		foreach (IDrawable drawableComponent in _drawableComponents)
			drawableComponent.Draw(spriteBatch);
	}

	/// <summary>
	/// Calls the IUpdatable.Update() method on each component inside of list _updatableComponents.
	/// </summary>
	public void UpdateComponents()
	{
		foreach (IUpdatable updatableComponent in _updatableComponents)
			updatableComponent.Update();
	}

	#endregion
}