using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingProjectile : MonoBehaviour
{
    public float speed;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position[1] -= speed;
        transform.position = position;
    }
}
