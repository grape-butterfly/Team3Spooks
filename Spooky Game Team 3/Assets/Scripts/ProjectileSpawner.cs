using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;

    public int delay;
    public int startDelay;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter -= startDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == delay)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            counter = 0;
        }
        else 
        {
            counter++; 
        }
    }
}
