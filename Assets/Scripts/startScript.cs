using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        theText.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = Color.black;
    }
}
