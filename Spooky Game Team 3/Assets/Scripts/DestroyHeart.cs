using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeart : MonoBehaviour
{
   private void DestroyMe() // Called after end of HeartPop animation
    {
        Destroy(gameObject);
    }
}
