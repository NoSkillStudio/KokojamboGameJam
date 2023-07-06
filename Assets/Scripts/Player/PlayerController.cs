using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private float _speed;

    [SerializeField] private float _startSpeed;
    private SpriteRenderer _renderer;
    private Vector2 _axis;
    private Rigidbody2D _rb;
    private Camera _mainCamera;
    private bool isFasingRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = _startSpeed;
        _renderer = GetComponent<SpriteRenderer>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _axis.x = Input.GetAxisRaw("Horizontal");
        _axis.y = Input.GetAxisRaw("Vertical");

        _rb.MovePosition(_rb.position + _axis * _speed * Time.fixedDeltaTime);

        /*if (_axis.x == 1)
        {
            _renderer.flipX = false;
        }
        else if (_axis.x == -1)
        {
            _renderer.flipX = true;
        }*/

        Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        float diff = mousePos.x - _rb.position.x;
        _renderer.flipX = diff < 0f;
    }

    public void StopSpeed() => _speed = 0;

    public void SetNormalSpeed() => _speed = _startSpeed;
}
