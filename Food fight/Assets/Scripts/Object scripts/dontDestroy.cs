using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private static GameObject[] carryOverObjects = new GameObject[2];
    public int objectIndex;
    // Start is called before the first frame update
    void Awake()
    {
        if (carryOverObjects[objectIndex] == null)
        {
            carryOverObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);
        }

        else if(carryOverObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
