using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager handles when the game starts and ends, as well as reporting
// game statistics onto the controller as counters.
// Intuitively, we would want to show:
// 1. The number of sliced objects
// 2. The direction of the next closest object as a radar
// 3. HP Left
// 4. Controller indicators to pause

public class GameManager : MonoBehaviour
{
    [SerializeField] C_Enemy enemy;
    // Yeah not the best thing to do but we don't have the time to set up
    // getter and setter functions
    [SerializeField] public bool paused, started = false;
    bool init = false;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!init)
            { 
                enemy.init(100.0f, 1.0f); 
                init = true;
            }

            if (paused)
            {

            }
            else
            {

            }
        }
        else
        {
            init = false;
        }
    }

    public bool GetGameStatus()
    {
        return paused;
    }
}
