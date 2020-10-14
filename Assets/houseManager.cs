using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houseManager : MonoBehaviour
{
    public bool isAtDoor;
    public Sprite openSprite;

    private SpriteRenderer spriteRenderer;
    private Sprite closeSprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        closeSprite = spriteRenderer.sprite;

        openSprite.texture.filterMode = FilterMode.Point;
    }

    public void OpenDoor()
    {
        spriteRenderer.sprite = openSprite;
    }

    void CloseDoor()
    {
        spriteRenderer.sprite = closeSprite;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isAtDoor = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAtDoor = false;
            CloseDoor();
        }
    }
}
