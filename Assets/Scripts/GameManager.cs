using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager handles when the game starts and ends, as well as reporting
// game statistics onto the controller as counters.
// Intuitively, we would want to show:
// 1. The number of sliced objects
// 2. The direction of the next closest object
// 3. Time left
// 4. Controller indicators to pause

public class GameManager : MonoBehaviour
{
    bool paused;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetGameStatus()
    {
        return paused;
    }
}
