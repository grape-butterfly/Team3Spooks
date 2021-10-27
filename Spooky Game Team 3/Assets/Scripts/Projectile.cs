using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public float speed;
  public float fireMultiplier;
  public int direction; //-1 for right to left, 1 for left to right
  public float firePosition;
  public float multiplier;

  private bool fired = false;
  protected Vector3 position;

  // Start is called before the first frame update
  void Start()
  {
      position = transform.position;
      multiplier = 1;
  }

  // Update is called once per frame
  void Update()
  {
      if(!fired){
        position[1] -= speed * multiplier;
        if(position[1] <= firePosition){
          fired = true;
        }
      } else {
        position[0] += speed * fireMultiplier * multiplier * direction;
      }
      transform.position = position;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
      if(other.transform.tag == "Player")
      {
          other.GetComponent<Player>().TakeDamage(1);
          Destroy(gameObject);
      }
      else if(other.transform.tag == "DeletionZone")
      {
          Destroy(gameObject);
      }
  }
}
