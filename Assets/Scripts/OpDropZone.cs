using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OpDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
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
		OponentController d = eventData.pointerDrag.GetComponent<OponentController>();
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
