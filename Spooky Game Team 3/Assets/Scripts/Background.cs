using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position[1] -= .2f;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other){
      if(other.transform.tag == "DeletionZone")
      {
          Destroy(gameObject);
      }
    }
}
