using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour
{
    public Sprite CardFront;
    public Sprite CardBack;
    public bool front = true;

    public void Flip()
    {
        if (front)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
            front = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
            front = true;
        }
    }
}
