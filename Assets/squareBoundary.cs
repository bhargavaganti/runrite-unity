using UnityEngine;
using System.Collections;

public class squareBoundary : MonoBehaviour {

    public Terrain terrain;
    private TerrainData terrainData;

    int heightMapWidth = 10;// terrainData.heightmapWidth;
    int heightMapHeight = 10; // terrainData.heightmapHeight;

    // float[,] heights = terrainData.GetHeights(0, 0, heightMapWidth, heightMapHeight);
    float[,] heights;

    void Awake()
    {
        terrainData = terrain.terrainData;
    }


    // Use this for initialization
    IEnumerator Start () {
        //  int heightMapWidth =10;// terrainData.heightmapWidth;
        //  int heightMapHeight = 10; // terrainData.heightmapHeight;

        // float[,] heights = terrainData.GetHeights(0, 0, heightMapWidth, heightMapHeight);

        heights = terrainData.GetHeights(0, 0, 0, 0);
        terrainData.SetHeights(0, 0, heights);

        yield return new WaitForSeconds(0.05F);

        heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);
    //   for (int z = 0; z < heightMapHeight; z++)
    //    {

    //       for (int x = 0; x < heightMapWidth; x++)
    //      {
    //         heights[x, z] = 0.02F;// 0.05F;
    //     }
    //  }

    //   for (int i = 10; i < 500; i = i + 50)
    //    {
    //        yield return new WaitForSeconds(2); // causes the delay of 2 seconds before plotting new pillar
    //       terrainData.SetHeights(10, i, heights);

    //    }
         for (int z = 0; z < heightMapHeight; z++)
           {

             for (int x = 0; x < heightMapWidth; x++)
             {
               heights[x, z] = 0.02F;// 0.05F;
            }
          }



         for (int i = 50; i < 300; i=i+50)
          {
            yield return new WaitForSeconds(0.02F);
            terrainData.SetHeights(10, i, heights);
            yield return new WaitForSeconds(0.02F);
            terrainData.SetHeights(250, i, heights);
            yield return new WaitForSeconds(0.02F);
            terrainData.SetHeights(i, 50, heights);
            yield return new WaitForSeconds(0.02F);
            terrainData.SetHeights(i, 250, heights);

          }       
    }

    // Update is called once per frame
    void Update () {

     //   Destroy(terrain, 5);

    }
}
