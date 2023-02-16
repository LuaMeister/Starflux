
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content;

namespace StarfluxEngine.SceneManagement;

public class SceneManager
{
	#region Public Fields

	public static Scene ActiveScene;
	public static ContentManager ContentManager;
	
	#endregion

	#region Private Fields

	private static readonly Dictionary<int, string> BuildIndex = new() { { 1, "ExperimentScene"} };

	#endregion
	
	#region Public Methods

	public static void LoadScene(int sceneNumber)
	{
		var sceneName = GetSceneName(sceneNumber);
		var documentPath = GetDocumentPath(sceneName);
		var sceneDocument = LoadSceneDocument(documentPath);
		Console.WriteLine(sceneDocument.DocumentElement);
	}

	#endregion

	#region Private Methods

	private static string GetDocumentPath(string sceneName)
	{
		Console.WriteLine(ContentManager.RootDirectory);
		return Path.Combine(ContentManager.RootDirectory, "Scenes", sceneName + ".xml");
	}

	private static XmlDocument LoadSceneDocument(string documentPath)
	{
		XmlDocument sceneDocument = new();
		sceneDocument.Load(documentPath);
		
		return sceneDocument;
	}

	private static string GetSceneName(int sceneNumber)
	{
		string sceneName = BuildIndex[sceneNumber];

		if (sceneName == null)
			Console.WriteLine("BuildIndex" + sceneNumber + "does not exist.");

		return sceneName;
	}

	#endregion
}