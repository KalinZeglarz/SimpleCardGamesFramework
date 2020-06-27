using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IDragHandler
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    public void OnDrag(PointerEventData pt)
    {
        this.transform.position = pt.position;
    }
}
