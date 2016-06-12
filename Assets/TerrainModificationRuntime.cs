using UnityEngine;
using System;
using System.Collections;

public class TerrainModificationRuntime : MonoBehaviour {

    public Terrain terrain; // terrain to modify
    private TerrainData terrainData;


    void Awake()
    {
        terrainData = terrain.terrainData;
    }

	// Use this for initialization
	void Start () {

        // sample data points
        int[,,] dataPoints = new int[,,] { { { 0, 0, 0, 0, 0 }, {0, 0, 0, 0, 0 } ,
                                 {0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, {1, 0, 0, 0, 0 },
        {5, 2, 1, 0, 0}, {12, 6, 4, 1, 0 }, {24, 23, 15, 8, 9 },
        { 48, 36, 25, 9, 11}, {56, 44, 36, 12, 15 }, {86, 76, 44, 11, 9}, {75, 84, 36, 12, 10 },
        {45, 65, 24, 9, 7 }, {36, 44, 16, 8, 6 }, { 25, 39, 12, 8, 5}, {12, 22, 6, 2, 1 },
        {9, 14, 4, 1, 0 }, {4, 5, 2, 1, 0 }, {1, 2, 0, 0, 0 }, {0, 0, 0, 0, 0 } ,
        {0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0} } };

        //start the funtion with waitforseconds functions inside it
        StartCoroutine(firstDataPoint(dataPoints));
        StartCoroutine(secondDataPoint(dataPoints));
        StartCoroutine(thirdDataPoint(dataPoints));
        StartCoroutine(fourthDataPoint(dataPoints));
        StartCoroutine(fifthDataPoint(dataPoints));

        // interpolate remaining points on the terrain
        interpolateRemainingTerrain();

        //start the terrain without wait for seconds function inside them
        //  firstDataPoint(dataPoints);

    }

    // This function generates the terrain structure depending on the heights array.  
    // @dataPoints: a 3D array that contains all the data points received from the sensor
    // The return type is IEnumerator because it contains a call for the wair for seconds function inside it
    IEnumerator firstDataPoint(int[,,] dataPoints)
    {
        int heightMapWidth = 5;// terrainData.heightmapWidth;
        int heightMapHeight = 5; // terrainData.heightmapHeight;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);

         int val = dataPoints[0, 7, 0];

        // we set each sample of the terrain in the size to the desired height
        for (int z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
               heights[x, z] = normalize(val);
            }
        }

        // 80 and 150 are the postion in the terrain where we want our structure to be located
        // set the new height
        terrainData.SetHeights(50, 350, heights);
      
        // first circumference

        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val)- (normalize(val)*(0.1F));
            }
        }

        //set the height of the terrain
        int xFirstCircum = 50, yFirstCircum = 350,i,j;

          for (i = xFirstCircum - 10; i <= xFirstCircum + 10; i = i+1)
            {
             for (j = yFirstCircum - 10; j <= yFirstCircum + 10; j = j+1)
             {
                if (i < xFirstCircum || j < yFirstCircum || i > (xFirstCircum + 5) || j > (yFirstCircum + 5))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
             }
           }

        //second circumference
        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.2F));
            }
        }

        //set the height of the terrain
       int xSecondCircum = 50, ySecondCircum = 350;

        for (i = xSecondCircum - 20; i <= xSecondCircum + 20; i = i + 1)
        {
            for (j = ySecondCircum - 20; j <= ySecondCircum + 20; j = j + 1)
            {

                if (i < xSecondCircum || j < ySecondCircum || i> (xSecondCircum + 10) || j > (ySecondCircum + 10))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //third circumference
        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.3F));
            }
        }

        //set the height of the terrain
        int xThirdCircum = 50, yThirdCircum = 350;

        for (i = xThirdCircum - 40; i <= xThirdCircum + 40; i = i + 1)
        {
            for (j = yThirdCircum - 40; j <= yThirdCircum + 40; j = j + 1)
            {

                if (i < xThirdCircum || j < yThirdCircum || i > (xThirdCircum + 20) || j > (yThirdCircum + 20))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

    }


    // This function generates the terrain structure depending on the heights array.  
    // @dataPoints: a 3D array that contains all the data points received from the sensor
    // The return type is IEnumerator because it contains a call for the wair for seconds function inside it
    IEnumerator secondDataPoint(int[,,] dataPoints)
    {
        int heightMapWidth = 5;// terrainData.heightmapWidth;
        int heightMapHeight = 5; // terrainData.heightmapHeight;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);

        int val = dataPoints[0, 7, 1];
        for (int z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
              heights[x, z] = normalize(val);
            }
        }

        terrainData.SetHeights(250, 330, heights);

        // first circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.1F));
            }
        }


        int xFirstCircum = 250, yFirstCircum = 330, i, j;

        for (i = xFirstCircum - 5; i <= xFirstCircum + 5; i = i + 1)
        {
            for (j = yFirstCircum - 5; j <= yFirstCircum + 5; j = j + 1)
            {
                if (i < xFirstCircum || j < yFirstCircum || i > (xFirstCircum + 5) || j > (yFirstCircum + 5))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //second circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.2F));
            }
        }

        int xSecondCircum = 250, ySecondCircum = 330;

        for (i = xSecondCircum - 20; i <= xSecondCircum + 20; i = i + 1)
        {
            for (j = ySecondCircum - 20; j <= ySecondCircum + 20; j = j + 1)
            {
                if (i < xSecondCircum || j < ySecondCircum || i > (xSecondCircum + 10) || j > (ySecondCircum + 10))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //third circumference
        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.3F));
            }
        }

        //set the height of the terrain
        int xThirdCircum = 250, yThirdCircum = 330;

        for (i = xThirdCircum - 40; i <= xThirdCircum + 40; i = i + 1)
        {
            for (j = yThirdCircum - 40; j <= yThirdCircum + 40; j = j + 1)
            {

                if (i < xThirdCircum || j < yThirdCircum || i > (xThirdCircum + 20) || j > (yThirdCircum + 20))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }


    }

    // This function generates the terrain structure depending on the heights array.  
    // @dataPoints: a 3D array that contains all the data points received from the sensor
    // The return type is IEnumerator because it contains a call for the wair for seconds function inside it
    IEnumerator thirdDataPoint(int[,,] dataPoints)
    {
        int heightMapWidth = 5;// terrainData.heightmapWidth;
        int heightMapHeight = 5; // terrainData.heightmapHeight;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);
        int val = dataPoints[0, 7, 2];

        for (int z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
              heights[x, z] = normalize(val);
            }
        }

        terrainData.SetHeights(200, 200, heights);

        // first circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.1F));
            }
        }

        int xFirstCircum = 200, yFirstCircum = 200, i, j;

        for (i = xFirstCircum - 5; i <= xFirstCircum + 5; i = i + 1)
        {
            for (j = yFirstCircum - 5; j <= yFirstCircum + 5; j = j + 1)
            {
                if (i < xFirstCircum || j < yFirstCircum || i > (xFirstCircum + 5) || j > (yFirstCircum + 5))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //second circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.2F));
            }
        }

        int xSecondCircum = 200, ySecondCircum = 200;

        for (i = xSecondCircum - 20; i <= xSecondCircum + 20; i = i + 1)
        {
            for (j = ySecondCircum - 20; j <= ySecondCircum + 20; j = j + 1)
            {
                if (i < xSecondCircum || j < ySecondCircum || i > (xSecondCircum + 10) || j > (ySecondCircum + 10))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //third circumference
        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.3F));
            }
        }

        //set the height of the terrain
        int xThirdCircum = 200, yThirdCircum = 200;

        for (i = xThirdCircum - 40; i <= xThirdCircum + 40; i = i + 1)
        {
            for (j = yThirdCircum - 40; j <= yThirdCircum + 40; j = j + 1)
            {

                if (i < xThirdCircum || j < yThirdCircum || i > (xThirdCircum + 20) || j > (yThirdCircum + 20))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }


    }

    // This function generates the terrain structure depending on the heights array.  
    // @dataPoints: a 3D array that contains all the data points received from the sensor
    // The return type is IEnumerator because it contains a call for the wair for seconds function inside it
    IEnumerator fourthDataPoint(int[,,] dataPoints)
    {
        int heightMapWidth = 5;// terrainData.heightmapWidth;
        int heightMapHeight = 5; // terrainData.heightmapHeight;
        int z;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);
        int val = dataPoints[0, 7, 3];

        for (z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
                heights[x, z] = normalize(val);
            }
        }

        terrainData.SetHeights(150, 120, heights);

        // first circumference
        for (z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.1F));
            }
        }

        //  terrainData.SetHeights(10, 75, heights);

        int xFirstCircum = 150, yFirstCircum = 120, i, j;

        for (i = xFirstCircum - 5; i <= xFirstCircum + 5; i = i + 1)
        {
            for (j = yFirstCircum - 5; j <= yFirstCircum + 5; j = j + 1)
            {
                if (i < xFirstCircum || j < yFirstCircum || i > (xFirstCircum + 5) || j > (yFirstCircum + 5))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //second circumference
        for (z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.2F));
            }
        }

        int xSecondCircum = 150, ySecondCircum = 120;

        for (i = xSecondCircum - 20; i <= xSecondCircum + 20; i = i + 1)
        {
            for (j = ySecondCircum - 20; j <= ySecondCircum + 20; j = j + 1)
            {
                if (i < xSecondCircum || j < ySecondCircum || i > (xSecondCircum + 10) || j > (ySecondCircum + 10))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //third circumference
        //fill the height array
        for (z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.3F));
            }
        }

        //set the height of the terrain
        int xThirdCircum = 150, yThirdCircum = 120;

        for (i = xThirdCircum - 40; i <= xThirdCircum + 40; i = i + 1)
        {
            for (j = yThirdCircum - 40; j <= yThirdCircum + 40; j = j + 1)
            {

                if (i < xThirdCircum || j < yThirdCircum || i > (xThirdCircum + 20) || j > (yThirdCircum + 20))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

    }

    // This function generates the terrain structure depending on the heights array.  
    // @dataPoints: a 3D array that contains all the data points received from the sensor
    // The return type is IEnumerator because it contains a call for the wair for seconds function inside it
    IEnumerator fifthDataPoint(int[,,] dataPoints)
    {
        int heightMapWidth = 5;// terrainData.heightmapWidth;
        int heightMapHeight = 5; // terrainData.heightmapHeight;

        // get the heights of the terrain under this game object
        float[,] heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);
        int val = dataPoints[0, 7, 4];

        for (int z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
              heights[x, z] = normalize(val);
            }
        }

        terrainData.SetHeights(60, 80, heights);
        // first circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
               heights[x, z] = normalize(val) - (normalize(val) * (0.1F));
            }
        }

        int xFirstCircum = 60, yFirstCircum = 80, i, j;

        for (i = xFirstCircum - 5; i <= xFirstCircum + 5; i = i + 1)
        {
            for (j = yFirstCircum - 5; j <= yFirstCircum + 5; j = j + 1)
            {
                if (i < xFirstCircum || j < yFirstCircum || i > (xFirstCircum + 5) || j > (yFirstCircum + 5))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //second circumference
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.2F));
            }
        }

        int xSeondCircum = 60, ySecondCircum = 80;

        for (i = xSeondCircum - 20; i <= xSeondCircum + 20; i = i + 1)
        {
            for (j = ySecondCircum - 20; j <= ySecondCircum + 20; j = j + 1)
            {
                if (i < xSeondCircum || j < ySecondCircum || i > (xSeondCircum + 10) || j > (ySecondCircum + 10))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

        //third circumference
        //fill the height array
        for (int z = 0; z < 5; z++)
        {

            for (int x = 0; x < 5; x++)
            {
                heights[x, z] = normalize(val) - (normalize(val) * (0.3F));
            }
        }

        //set the height of the terrain
        int xThirdCircum = 60, yThirdCircum = 80;

        for (i = xThirdCircum - 40; i <= xThirdCircum + 40; i = i + 1)
        {
            for (j = yThirdCircum - 40; j <= yThirdCircum + 40; j = j + 1)
            {

                if (i < xThirdCircum || j < yThirdCircum || i > (xThirdCircum + 20) || j > (yThirdCircum + 20))
                {
                    yield return new WaitForSeconds(0.001F);
                    terrainData.SetHeights(i, j, heights);
                }
            }
        }

    }

    //interpolate the remining portion of the terrain
    void interpolateRemainingTerrain()
    {
         int heightMapWidth =400;// terrainData.heightmapWidth;
         int heightMapHeight = 400; // terrainData.heightmapHeight;
         float[,] heights;
        
        // float[,] heights = terrainData.GetHeights(0, 0, heightMapWidth, heightMapHeight);

        heights = terrainData.GetHeights(0, 0, 0, 0);
        terrainData.SetHeights(0, 0, heights);
        heights = terrainData.GetHeights(50, 50, heightMapWidth, heightMapHeight);

        for (int z = 0; z < heightMapHeight; z++)
        {

            for (int x = 0; x < heightMapWidth; x++)
            {
                heights[x, z] = 0.03F;// 0.05F;
            }
        }
        

        terrainData.SetHeights(10, 20, heights);

    }

    // normalizes a given data point by dividing it by the largets data point present in the file. For now, this is a 
    // constant value.
    private float normalize(int dataPoint)
    {
        float normalizedData;

        int largestValueInTheFile = 86;

        normalizedData = dataPoint /(float) largestValueInTheFile;
       return normalizedData;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(0, 0, Time.deltaTime * 1);
    }
}
