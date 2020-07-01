using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class PlayerController : NetworkBehaviour
{
    public GameObject DropZone;
    public GameObject EnemyDropZone;
    public PlayerManager PlayerManager;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    public bool isDraggable = true;
    private GameObject startParent;
    private Vector2 startPosition;

    private void Start()
    {
        if (!hasAuthority)
        {
            isDraggable = false;
        }
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null && hasAuthority)
        {
            isOverDropZone = true;
            PlayerManager.DropZone.GetComponent<Image>().color = new Color32(25, 176, 55, 100);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        PlayerManager.DropZone.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        transform.SetParent(transform.parent.parent.transform, true);
        isDragging = true;
    }

    public void EndDrag()
    {
        PlayerManager.DropZone.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            isDraggable = false;
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}