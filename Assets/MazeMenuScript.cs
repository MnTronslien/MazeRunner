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
            Debug.Log("Creating a prefab out of " + t.gameObject.name);
            //Add mesh collider
            MeshCollider mc = t.gameObject.AddComponent<MeshCollider>();
            mc.sharedMesh = t.gameObject.GetComponentInChildren<MeshFilter>().sharedMesh;
            Debug.Log("Mesh collider with mesh added");

            Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/Resources/UnsortedMazePrefabs/" + t.gameObject.name + ".prefab");
            PrefabUtility.ReplacePrefab(t.gameObject, prefab, ReplacePrefabOptions.ConnectToPrefab);
            DestroyImmediate(t.gameObject);

            AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GetAssetPath(Selection.activeObject));
        }
    }

}