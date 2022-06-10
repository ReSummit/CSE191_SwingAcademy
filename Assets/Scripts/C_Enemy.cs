using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Enemy : MonoBehaviour
{
    GameManager gm;
    [SerializeField] GameObject projectile;
    float hp, difficulty;

    float timeNextSpawn;

    public void init( float hp, float difficulty )
    {
        this.hp = hp;
        this.difficulty = difficulty;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        timeNextSpawn = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.started)
        { 
            if (hp == 0)
            {
                gm.started = false;
            }
            else
            {
                // Fire projectiles and determine spawn direction
                // Difficulty goes from 1 - 5
                if (Time.time > timeNextSpawn)
                {
                    //timeNextSpawn = 99999999999.0f;
                    timeNextSpawn = Time.time + 3 * (1 - 1.6f * difficulty * 0.1f) + Random.value - 0.5f;
                    Vector3 spawn = new Vector3(transform.position.x + Mathf.Cos(45 * Mathf.PI / 180), transform.position.y + 2, transform.position.z + Mathf.Sin(45 * Mathf.PI / 180));
                    Vector3 spawnDir = spawn - transform.position;
                    GameObject proj = GameObject.Instantiate(projectile, spawn, Quaternion.identity);
                    proj.GetComponent<C_Projectile>().init(gm, GameObject.FindGameObjectWithTag("Player"), 1.0f, 0.1f, 1.0f);
                    proj.transform.LookAt(spawnDir);
                }
            }
        }
    }


}
