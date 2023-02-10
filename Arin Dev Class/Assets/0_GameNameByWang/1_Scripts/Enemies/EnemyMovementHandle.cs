using UnityEngine;

public class EnemyMovementHandle : MonoBehaviour
{
    public AnimationCurve MoveCurve;

    [SerializeField]private Vector3 _target;
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private float _animationTimePosition;
    //[SerializeField] private float _speed = 3f;
    [SerializeField] private float _minimumHeight = -1.3f;

    private void Start()
    {
        UpdatePath();
    }

    private void Update()
    {
        Move();
    }

    private void UpdatePath()
    {
        _startPoint = transform.position;
        _target = Random.insideUnitCircle;
    }
    private void Move()
    {
        
        if (_target.y <= _minimumHeight)
        {
            _target.y = this._minimumHeight;
        }
        
        if (_target != transform.position)
        {
            _animationTimePosition += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPoint, _target, MoveCurve.Evaluate(_animationTimePosition));
        }
        else
        {
            UpdatePath();
            _animationTimePosition = 0;
        }
    }
}
