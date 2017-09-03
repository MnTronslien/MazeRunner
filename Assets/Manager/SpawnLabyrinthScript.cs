using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is able to generate a maze during runtime
/// </summary>
[ExecuteInEditMode]
public class SpawnLabyrinthScript : MonoBehaviour {

    [Tooltip("Folder must be a child-folder of 'Resources'. Contains the chunk prefabs used for generating")]
    [SerializeField]
    string _folderName = "MazePrefabs";
    [SerializeField]
    int SetPiceDimension = 1;
    [SerializeField]
    int _gridSize = 9;
    [SerializeField]
    float _scale;
    //public GameObject[] SetPieces;

    GameObject[] SetPieces;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void DoRandomizeMaze()
    {
        SetPieces = Resources.LoadAll<GameObject>(_folderName);
        if (SetPieces.Length == 0) {
            Debug.LogError("The folder 'Resources/"+ _folderName +"' is either non existant, or empty!");
            return;
        }
        GameObject mazeManager;

        /*
        * Find the object the maze should be created under. 
        * If it allready exists, destroy all its children.
        * If it doesen't exist, create it        
        */

        if (GameObject.Find("Maze"))
        {
            mazeManager = GameObject.Find("Maze");
            while (mazeManager.transform.childCount != 0)
            {
                DestroyImmediate(mazeManager.transform.GetChild(0).gameObject);
            }
        }        
        else mazeManager = new GameObject("Maze");

        //Spawn inn all the maze pieces
        Debug.Log("Generating new maze...");
        for (int z = 0; z < _gridSize; z++)
        {
            for (int x = 0; x < _gridSize; x++)           
            {
                GameObject obj = Instantiate(SetPieces[Random.Range(0, SetPieces.Length)]);
                obj.transform.localScale = new Vector3(_scale,_scale,_scale);
                obj.transform.position = new Vector3(x*SetPiceDimension*_scale,0,z*SetPiceDimension*_scale);

                Vector3 newRotaion = new Vector3();
                int r = Random.Range(0, 4);
                newRotaion.y = r * 90;
                obj.transform.Rotate(newRotaion);

                obj.transform.SetParent(mazeManager.transform);
                obj.isStatic = true;
                obj.transform.GetChild(0).gameObject.isStatic = true;
            }
        }
        Debug.Log("Maze generated succesfully!");
    }
}
