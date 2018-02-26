using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorld : MonoBehaviour {
    int location_X = 0;
    int location_Y = 0;
    private GameObject tileHolder;

    void RoomGeneration()
    {
        SpawnTile(location_X,location_Y);
        SpawnTile(1, 1);
    }

    void SpawnTile(int x, int y)
    {
        Vector3 position = new Vector3(x, y, 0f);
        GameObject tileInstance = Instantiate(Resources.Load("Prefabs/grey flagstones 2"), position, Quaternion.identity) as GameObject;
        tileInstance.transform.parent = tileHolder.transform;
    }




    // Use this for initialization
    void Start () {
        tileHolder = new GameObject("TileHolder");
        RoomGeneration();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
