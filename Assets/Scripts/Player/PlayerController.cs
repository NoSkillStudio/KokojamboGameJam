using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // если на игроке нет Rigidbody2D, скрипт добавит
public class PlayerController : MonoBehaviour
{
    private float _speed;

    [SerializeField] private float _startSpeed;
    private Vector2 _axis;
    private Rigidbody2D _rb;
    private bool isFasingRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _startSpeed;
    }

    private void Update()
    {
        _axis.x = Input.GetAxisRaw("Horizontal");
        _axis.y = Input.GetAxisRaw("Vertical");

        if (_axis.x == 1 && !isFasingRight)
        {
            Turn();
        }
        else if (_axis.x == -1 && isFasingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        isFasingRight = !isFasingRight;

        transform.Rotate(0,180f,0);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _axis * _speed * Time.fixedDeltaTime); // axis от -1, до 1, нет смысла его нормализовать
    }

    public void StopSpeed() => _speed = 0;

    public void SetNormalSpeed() => _speed = _startSpeed;
}
