
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StarfluxEngine.SceneManagement;

public static class SceneManager
{
	#region Public Fields

	public static Scene ActiveScene;
	public static ContentManager ContentManager;
	
	#endregion

	#region Private Fields

	private static readonly Dictionary<int, string> BuildIndex = new() { { 1, "ExperimentScene"} };

	#endregion
	
	#region Public Methods

	/// <summary>
	/// Unloads the previous scene and loads the given scene.
	/// </summary>
	/// <param name="sceneNumber">The build index of the scene to load</param>
	public static void LoadScene(int sceneNumber)
	{
		var sceneName = GetSceneName(sceneNumber);
		var documentPath = GetDocumentPath(sceneName);
		var sceneDocument = LoadSceneDocument(documentPath);
		
		ActiveScene = new Scene();

		if (sceneDocument.DocumentElement == null) return;
		foreach (XmlNode xmlNode in sceneDocument.DocumentElement.ChildNodes)
		{
			switch (xmlNode.Name)
			{
				case "Objects":
					CreateObjects(xmlNode);
					break;
				default:
					Console.WriteLine("XmlNode.Name is not recognized and will not be used, name: " + xmlNode.Name);
					break;
			}
		}
	}

	#endregion

	#region Private Methods

	private static void CreateObjects(XmlNode parentNode, Transform parentTransform = null)
	{
		foreach (XmlNode objectNode in parentNode.ChildNodes)
		{
			GameObject childObject = GameObject.Instantiate();
			childObject.Name = objectNode.Name;
			Transform transform = childObject.Transform;

			foreach (XmlNode componentNode in objectNode.ChildNodes)
			{
				switch (componentNode.Name)
				{
					case "Transform":
						transform.Position = new Vector2(
							float.Parse(componentNode.Attributes?["PositionX"]?.Value ?? "0"),
							float.Parse(componentNode.Attributes?["PositionY"]?.Value ?? "0"));
						break;
					case "SpriteRenderer":
						SpriteRenderer spriteRenderer = childObject.AddComponent<SpriteRenderer>();
						spriteRenderer.Sprite = ContentManager.Load<Texture2D>(
							componentNode.Attributes?["Sprite"]?.Value ?? "Sprites/Default");
						break;
					case "Children":
						CreateObjects(componentNode, transform);
						break;
				}
			}
		}
	}
	

	/// <summary>
	/// Gets the path to the document where this scene should be at
	/// </summary>
	/// <param name="sceneName">Name of the scene we need to find</param>
	/// <returns>The path to the scene document</returns>
	private static string GetDocumentPath(string sceneName)
	{
		return Path.Combine(ContentManager.RootDirectory, "Scenes", sceneName + ".xml");
	}

	/// <summary>
	/// Creates and loads the XML Document
	/// </summary>
	/// <param name="documentPath">Path to the document of the scene</param>
	/// <returns>An XML Document that holds information about the to load</returns>
	private static XmlDocument LoadSceneDocument(string documentPath)
	{
		XmlDocument sceneDocument = new();
		sceneDocument.Load(documentPath);
		
		return sceneDocument;
	}

	/// <summary>
	/// Checks the BuildIndex for a name that exists at that number
	/// </summary>
	/// <param name="sceneNumber">The number that will be used as the index</param>
	/// <returns>A string with the name of this scene, or an empty string if this index did not have a name</returns>
	private static string GetSceneName(int sceneNumber)
	{
		string sceneName = BuildIndex[sceneNumber];

		if (sceneName == null)
			Console.WriteLine("BuildIndex" + sceneNumber + "does not exist.");

		return sceneName;
	}

	#endregion
}