using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
