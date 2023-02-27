using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Range(0.2f, 2f)]
    public float moveSpeedModifier = 0.5f;

    float dirX, dirZ;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.acceleration.x * moveSpeedModifier;
        dirZ = Input.acceleration.z * moveSpeedModifier;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3 (rb.velocity.x + dirX, 0, rb.velocity.z + dirZ);
    }
}
