using UnityEngine;
using System.Collections;

public class CameraAndroid : MonoBehaviour {

    public GameObject dougie1,dougie2,dougie3,dougie4;
    public int scale;
    // Use this for initialization
    GameObject[] players;
   public  Camera came;
    public int maxSize, minSize;
    float minX, maxX, minY, maxY;
    void CalculateBounds()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        minX = Mathf.Infinity;
        maxX = -1 * Mathf.Infinity;
        minY = Mathf.Infinity;
         maxY = -1 * Mathf.Infinity;

        for (int x=0;x<players.Length;x++)
        {
            Vector3 tempPlayer = players[x].transform.position;

            //X Bounds
            if (tempPlayer.x < minX)
                minX = tempPlayer.x;
            if (tempPlayer.x > maxX)
                maxX = tempPlayer.x;
            //Y Bounds
            if (tempPlayer.y < minY)
                minY = tempPlayer.y;
            if (tempPlayer.y > maxY)
                maxY = tempPlayer.y;
        }
      
    }
    Vector3 cameraCenter;
    float camSpeed =2;
    int camDist = 100;
    float camSize = 3;
    void CalculateCameraPosAndSize()
    {
        cameraCenter = Vector3.zero;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            cameraCenter += player.transform.position;
            print("sup");
        }
        Vector3 final= cameraCenter / players.Length;
        final.z = -10;
        //final.y = -10;
        //
        //   came.transform.position = final;
        came.transform.position = final;
        //Size
        float sizeX = maxX - minX;
        float sizeY = maxY - minY;
        
        if (sizeX > sizeY)
        {
            if (sizeX < minSize)
            {
                sizeX = minSize;
            }

            if (sizeX > maxSize)
            {
                sizeX = maxSize;
            }

            came.orthographicSize = sizeX*0.5f;
        }
        else
        {
            if (sizeY < minSize)
            {
                sizeY = minSize;
            }

            if (sizeY > maxSize)
            {
                sizeY = maxSize;
            }
            came.orthographicSize = sizeY*0.5f;
        }
        
    }
    void Start () {
        //Camera.main.orthographicSize = Mathf.Max(Screen.width, Screen.height)/scale;
      
        
    }
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        CalculateBounds();

        CalculateCameraPosAndSize();
    }

}
