using UnityEditor;
using UnityEngine;
public class MazeMenuScript : MonoBehaviour
{
    // Add a menu item named "CreateMazePiece" to Maze in the menu bar.
    /// <summary>
    /// Turns a slected object(s) into a Prefab and ads it to the list of set pieces
    /// </summary>
    [MenuItem("Maze/CreateMazePiece")]
    static void DoCreateMazePiecePrefab()
    {
        Transform[] transforms = Selection.transforms;
        foreach (Transform t in transforms)
        {

            MeshCollider mc = t.gameObject.AddComponent<MeshCollider>();
            Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/Resources/UnsortedMazePrefabs/" + t.gameObject.name + ".prefab");
            PrefabUtility.ReplacePrefab(t.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate(t.gameObject);
        }
    }

}