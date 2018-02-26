using UnityEngine;
using System.Collections;



public class CameraMovement : MonoBehaviour {
    // Use this for initialization
    public GameObject target;
    void MoveCamera()
    {
        Vector3 playerPos = target.transform.position;
        float x = playerPos.x - transform.position.x;
        float y = playerPos.y - transform.position.y;
        Vector3 add = new Vector3(x, y, 0);
        transform.position += add;
    }

    void ConfigureOrthograhic()
    {
        
        float x = Screen.width;
        float y = Screen.height;
        float Size = 2 * (x / (((x / y) * 2) * 256));
        Camera.main.orthographicSize = Size;
    }   
	void Start () {
    }
	
	// Update is called once per frame
	void LateUpdate () {
        MoveCamera();
        ConfigureOrthograhic();



    }

}
