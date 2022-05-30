using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSliceManager : MonoBehaviour
{
    int slicedObjs;
    float startTime, endTime;

    [SerializeField] GameObject[] dirObjs;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        slicedObjs = 0;
        startTime = endTime = 0;
        gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Manages the spawning of objects to slice with extendo sword
        // Need to generate a starting position, launch direction, time to throw, and force of throw
        // Each object will report on collision to this object, which will increment sliced objects.

        if ( !gm.GetGameStatus() )
        {
            Time.timeScale = 1.0f;
            // Begin calculating and throwing.
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }

    int getSlicedObjs()
    {
        return slicedObjs;
    }

    void EventOnObjSliced(GameObject obj)
    {
        if (obj == null)
        {
            return;
        }
        else
        {
            slicedObjs++;
        }
    }
}
