using UnityEngine;


public enum RocketType
{
    Rocket,
    HomingMissile
}

public class DecorRocket : MonoBehaviour
{
    [SerializeField] private Sprite rocket;
    [SerializeField] private Sprite homingMissile;

    [SerializeField] private float offset;
    public RocketType CurrentRocket { get; private set; }

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        CurrentRocket = RocketType.Rocket;
        spriteRenderer.sprite = rocket;
    }
    private void Update()
    {
        if (CurrentRocket == RocketType.Rocket)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ + offset);

            if (transform.rotation.z > -1 && transform.rotation.z < -0.5)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if(transform.rotation.z < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            
        }
    }
    public void SwitchDecorRocket()
    {
        if (spriteRenderer.sprite == rocket)
        {

        }
        else if (spriteRenderer.sprite == homingMissile)
        { 

        }
    }

    public void SwitchToRocket()
    {
        CurrentRocket = RocketType.Rocket;
        spriteRenderer.sprite = rocket;
    }

    public void SwitchToHomingMissile()
    {
        CurrentRocket = RocketType.HomingMissile;
        spriteRenderer.sprite = homingMissile;
    }
}