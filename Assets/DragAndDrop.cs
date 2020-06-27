using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData pt)
    {
        this.transform.position = pt.position;
    }
}