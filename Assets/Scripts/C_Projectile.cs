using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Projectile : MonoBehaviour
{
    // Homing target
    GameObject target;
    GameManager gm;
    Vector3 rot;

    // Set "difficulty" (speed, size, hit count, etc)
    Rigidbody rb;
    float scale, speed, rotationTime;

    float tim = 0.0f;

    // State of projectile; alive or dead
    bool alive = true, initt = false;
    float deadTime = 0;

    public void init(GameManager gm, GameObject target, float scale, float speed, float rotationTime)
    {
        this.target = target;
        this.scale = scale;
        this.speed = speed;
        this.rotationTime = rotationTime;
        this.gm = gm;
        initt = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(this.scale, this.scale, this.scale);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if projectile is live.
        // If so, 
        if (initt)
        {
            if (alive)
            {
                Vector3 dir = (target.transform.position - transform.position).normalized;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime / rotationTime);
                transform.Translate(Vector3.forward * speed * 0.1f);
            }
            else
            {
                if (transform.localScale.magnitude == 0.0f)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    rb.AddForce(-transform.forward, ForceMode.VelocityChange);
                    transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, (Time.time - deadTime) / (Random.value + 2f));
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Sword"))
        {
            rb.velocity = -rb.velocity;
            alive = false;
            deadTime = Time.time;
        }
    }
}
