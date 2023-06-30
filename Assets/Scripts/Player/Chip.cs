using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chip : MonoBehaviour
{
    public static event Action OnPick;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetRandomSprites(sprites);
    }

    private Sprite GetRandomSprites(Sprite[] transformPoints)
    {
        int index;
        index = Random.Range(0, transformPoints.Length);
        return transformPoints[index];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ChipPicicker player))
        {
            OnPick?.Invoke();
            Destroy(gameObject);
        }
    }
}