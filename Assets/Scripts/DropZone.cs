using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public bool hand;
	public void OnPointerExit(PointerEventData p)
	{

	}

	public void OnPointerEnter(PointerEventData p)
	{

	}
	public void OnDrop(PointerEventData eventData)
	{
		PlayerController d = eventData.pointerDrag.GetComponent<PlayerController>();
		if (d != null && !hand)
		{
			d.parentToReturnTo = this.transform;
			d.inBox = true;
		}
		else
		{
			d.parentToReturnTo = this.transform;
			d.inBox = false;
		}
	}
}
