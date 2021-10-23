using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;

    public int baseDelay;
    public int startDelay;
    public int patternNumber;

    private int delay;

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter -= startDelay;
        delay = baseDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == delay)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            counter = 0;
            DelayUpdater();
        }
        else
        {
            counter++;
        }
    }

    // changes the delay in accordance with current bullet pattern after each bullet
    void DelayUpdater(){

    }
}
