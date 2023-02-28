using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceelerometer : MonoBehaviour
{
    public bool isFlat = true;
    Rigidbody rb;
    [Range(0.5f, 100f)]
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tilt = Input.acceleration * Time.deltaTime * speed;
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        rb.AddForce(tilt);
        Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
    }
}
