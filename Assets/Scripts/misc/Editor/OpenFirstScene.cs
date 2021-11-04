/*
 * Copy this script to Assets/Scripts/Editor/ in your Unity project
 * The first scene in the list Build Settings -> "Scenes in Build"
 *  will be loaded automatically after starting Unity,
 *  even if the Library folder is missing.
 *
 * I'm not sure why Unity does not do this by default.
 */

using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class OpenFirstScene
{
    static bool active;
    static OpenFirstScene()
    {
        active = true;
        EditorSceneManager.newSceneCreated += NewSceneCreated;
        EditorSceneManager.sceneOpened += SceneOpened;
    }

    private static void SceneOpened(Scene scene, OpenSceneMode mode)
    {
        active = false;
    }

    private static void NewSceneCreated(Scene scene, NewSceneSetup setup, NewSceneMode mode)
    {
        if (!active) return;
        if (scene.name == "" && setup == NewSceneSetup.DefaultGameObjects && mode == NewSceneMode.Single)
        {
            string firstScenePath = SceneUtility.GetScenePathByBuildIndex(0);
            if (firstScenePath != null && firstScenePath != "") {
                EditorSceneManager.OpenScene(firstScenePath);
            }
        }
        active = false;
    }
}
