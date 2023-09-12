using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class OpenSceneEditor : EditorWindow {
   private static string _scenePath = "Assets/MyGame/Scenes/Project/{0}.unity";

   [MenuItem("OpenScene/Loading", false, 1)]
   public static void Menu()
   {
      EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
      EditorSceneManager.OpenScene
         (string.Format(_scenePath, "Loading"), OpenSceneMode.Single);
   }

   [MenuItem("OpenScene/Map 1", false, 1)]
   public static void Level1()
   {
      EditorSceneManager.SaveScene(SceneManager.GetActiveScene()); 
      EditorSceneManager.OpenScene
         (string.Format(_scenePath, "Map1"), OpenSceneMode.Single);
   }
    [MenuItem("OpenScene/Map 2", false, 1)]
    public static void Level2()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        EditorSceneManager.OpenScene
           (string.Format(_scenePath, "Map2"), OpenSceneMode.Single);
    }

    [MenuItem("OpenScene/Test UI", false, 1)]

    public static void TestUI()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        EditorSceneManager.OpenScene(string.Format(_scenePath, "UITest"), OpenSceneMode.Single);
    }

    [MenuItem("OpenScene/Test Scene", false, 1)]

    public static void TestScene()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        EditorSceneManager.OpenScene(string.Format(_scenePath, "Demo_01"), OpenSceneMode.Single);
    }
}
