using UnityEngine;

public class TankMovementHandle : MonoBehaviour
{
    [SerializeField] private AnimationCurve MoveCurve;

    [SerializeField] private float _speed = 0f;

    [SerializeField] private Vector3 _target = Vector3.zero;
    [SerializeField] private Vector3 _startPoint = Vector3.zero;
    [SerializeField] private float _animationTimePosition = 0f;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        MoveByCurve();
    }

    private void MoveByCurve()
    {
        var transform = _transform;
        float _horizontalInput = Input.GetAxisRaw("Horizontal");
        //ForUpdate
        //float _verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 input = new Vector3(_horizontalInput, 0, 0);

        transform.position += input * _speed * Time.fixedDeltaTime;

        //_startPoint = transform.position;
        _target = transform.position;

        if (_target != transform.position)
        {
            _animationTimePosition += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPoint, _target, MoveCurve.Evaluate(_animationTimePosition));
        }
        else
        {
            transform.position += input * _speed * Time.deltaTime;
            _animationTimePosition = 0;
        }
    }
}