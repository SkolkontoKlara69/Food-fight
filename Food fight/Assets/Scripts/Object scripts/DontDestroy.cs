using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] carryOverobjects = new GameObject[3];
    public int objectIndex;

    // Start is called before the first frame update
    void Awake()
    {
        if(carryOverobjects[objectIndex] == null)
        {
            carryOverobjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }


        else if(carryOverobjects[objectIndex] != gameObject) 
        {
            Destroy(gameObject);
        }

        

    }

    
}
