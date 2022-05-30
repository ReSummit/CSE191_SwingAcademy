using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControl : MonoBehaviour
{
    [SerializeField] GameObject blade;
    Rigidbody brb;
    Transform tf;
    Vector3 lastPos, velocity;

    // Start is called before the first frame update
    void Start()
    {
        tf = transform;
        brb = blade.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get controller velocity
        velocity = new Vector3(transform.position.x - lastPos.x, transform.position.y - lastPos.y, transform.position.z - lastPos.z);
        velocity = new Vector3(0.2f, velocity.magnitude * 20, 0.2f);
        blade.transform.localScale = velocity;
        lastPos = transform.position;
    }
}
