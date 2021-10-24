using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private GameObject originalGameObject;
    private Image[] hearts = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        originalGameObject = GameObject.Find("Hearts");
        hearts = originalGameObject.GetComponentsInChildren<Image>();
    }

    public void RemoveHeart(int currentHealth)
    {
        hearts[currentHealth].enabled = false;
    }
}
