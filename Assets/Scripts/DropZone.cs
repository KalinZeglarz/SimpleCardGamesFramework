using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		DragAndDrop d = eventData.pointerDrag.GetComponent<DragAndDrop>();
		if (d != null)
		{
			d.parentToReturnTo = this.transform;
		}
	}
}
