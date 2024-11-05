using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelCreator : MonoBehaviour
{
    // Start is called before the first frame update


    public int environmentSize = 32;

    private byte[] envMatrix = new byte[32 * 32];

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < environmentSize; i++)
        {
            for (int j = 0; j < environmentSize; j++)
            {


                envMatrix[i*environmentSize + j] = 1;
            }
        }
    }
}
