using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;
public class PlayerController : NetworkBehaviour
{
    public GameObject DropZone;
    public GameObject EnemyDropZone;
    public PlayerManager PlayerManager;
    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;
    private GameObject startParent;
    private Vector2 startPosition;

    private void Start()
    {
        if (!hasAuthority)
        {
            isDraggable = false;
        }
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(transform.parent.parent.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        DropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
    }

    public void StartDrag()
    {
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(DropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            PlayerManager = networkIdentity.GetComponent<PlayerManager>();
            PlayerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}