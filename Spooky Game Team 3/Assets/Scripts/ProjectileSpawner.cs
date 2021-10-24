using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {   }

    // Update is called once per frame
    void Update()
    {  }

    // changes the delay in accordance with current bullet pattern after each bullet
    public void Fire(){
      Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
