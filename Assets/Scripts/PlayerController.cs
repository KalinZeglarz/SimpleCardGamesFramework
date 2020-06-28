using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public bool inBox = false;
    public Sprite front;
    public Sprite back;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        //this.transform.SetParent(parentToReturnTo);
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}