using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class LevelsBrowser : EditorWindow
{
	#region Fields
	// Window scroll position
	private Vector2 _windowScrollPosition;
	#endregion Fields

	#region EditorWindow
	[MenuItem("Window/Scenes browser", false)]
	private static void Init()
	{
		// On initialisation, get a window of that class type
		GetWindow(typeof(LevelsBrowser), false, "Levels Browser");
	}

	private void OnGUI()
	{
		// Function called on GUI draw
		EditorGUILayout.BeginVertical();
		_windowScrollPosition = EditorGUILayout.BeginScrollView(_windowScrollPosition, false, false);

		EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
		for (int i = 0; i < scenes.Length; i++)
		{
			EditorGUILayout.BeginHorizontal();

			// The first scene will have a play / pause button
			if (i == 0)
			{
				Color guiContentColor = GUI.contentColor;
				if (Application.isPlaying == false)
				{
					GUI.contentColor = Color.green;
					if (GUILayout.Button("►", new GUILayoutOption[] { GUILayout.Width(24.0f) }))
					{
						EditorTools.PlayFromBuildInitialScene();
					}
				}
				else
				{
					GUI.contentColor = Color.red;
					if (GUILayout.Button("■", new GUILayoutOption[] { GUILayout.Width(24.0f) }))
					{
						EditorTools.PlayFromBuildInitialScene();
					}
				}
				GUI.contentColor = guiContentColor;
			}
			else
			{
				GUILayout.Space(30.0f);
			}

			Color guibackgroundColor = GUI.backgroundColor;
			if (EditorSceneManager.GetActiveScene().path == scenes[i].path)
			{
				// Set the background in gray for the current scene
				GUI.backgroundColor = Color.gray;
			}

			GUI.enabled = (Application.isPlaying == false && scenes[i].enabled);
			if (GUILayout.Button(i.ToString() + " - " + scenes[i].path.Split('/')[scenes[i].path.Split('/').Length - 1].Replace(".unity", "")))
			{
				// Checks if we need to save the current scene, if that scene is saved, we can open the new one
				if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
				{
					EditorSceneManager.OpenScene(scenes[i].path);
				}
			}
			GUI.enabled = true;

			GUI.backgroundColor = guibackgroundColor;

			EditorGUILayout.EndHorizontal();
		}

		EditorGUILayout.EndScrollView();
		EditorGUILayout.EndVertical();
	}
	#endregion EditorWindow
}

public class EditorTools
{
	[MenuItem("Tools/Play-Stop, scene at build index = 0", false, 0)]
	public static void PlayFromBuildInitialScene()
	{
		if (EditorApplication.isPlaying == true)
		{
			// If application is playing, then stops it and load previous opened scene
			EditorApplication.isPlaying = false;
			EditorApplication.playModeStateChanged += OpenPreviousScene;
		}
		else
		{
			if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo() == false)
			{
				return;
			}

			EditorPrefs.SetString("PreviousScenePath", EditorSceneManager.GetActiveScene().path);
			EditorSceneManager.OpenScene(GetScenePaths()[0]);
			EditorApplication.isPlaying = true;
		}
	}

	public static string[] GetScenePaths(bool _includeDisabled = false)
	{
		List<string> sceneNames = new List<string>();

		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (scene.enabled || _includeDisabled)
			{
				sceneNames.Add(scene.path);
			}
		}
		return sceneNames.ToArray();
	}

	private static void OpenPreviousScene(PlayModeStateChange state)
	{
		if (EditorPrefs.HasKey("PreviousScenePath"))
		{
			EditorSceneManager.OpenScene(EditorPrefs.GetString("PreviousScenePath"));
		}
		EditorApplication.playModeStateChanged -= OpenPreviousScene;
	}
}
