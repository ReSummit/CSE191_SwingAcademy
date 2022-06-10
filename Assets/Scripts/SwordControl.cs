using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    [SerializeField] GameObject blade;
    Rigidbody rb;
    Valve.VR.SteamVR_Behaviour_Pose controller;
    Vector3 lastPos, velocity, rot;
    float energyReserve = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        controller = this.GetComponent<Valve.VR.SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get controller velocity
        velocity = controller.GetVelocity();
        rot = controller.GetAngularVelocity();

        if ( velocity.magnitude > 0.001 || rot.magnitude > 0.01 )
        {
            float vel = velocity.magnitude + rot.magnitude;
            float end = 0.1f + Mathf.Pow(1, vel);
            velocity = new Vector3(0.1f, end, 0.1f);
            blade.transform.localScale = velocity;
            blade.transform.localPosition = new Vector3(0, Mathf.Sin(Mathf.PI / 4) * end, Mathf.Cos(Mathf.PI / 4) * end);
            lastPos = transform.position;
        }
        else
        {
            velocity = new Vector3(0.1f, 0.15f, 0.1f);
            blade.transform.localScale = velocity;
            blade.transform.localPosition = new Vector3(0, Mathf.Sin(Mathf.PI / 4) * 0.15f, Mathf.Cos(Mathf.PI / 4) * 0.1f);
            lastPos = transform.position;
        }
        
    }
}
