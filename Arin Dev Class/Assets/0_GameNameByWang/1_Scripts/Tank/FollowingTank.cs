using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTank : MonoBehaviour
{
    [SerializeField]private float _followingSpeed = 5f;
    [SerializeField]private GameObject _target;
    public GameObject Target { get => _target; }


    private void FixedUpdate()
    {
        Following();
    }

    protected virtual void Following()
    {
        if (this._target == null) return;
        Vector3 targetPos = this._target.transform.position;
        targetPos.y = -4.17f;
        transform.position = Vector3.Lerp(transform.position, targetPos, _followingSpeed * Time.fixedDeltaTime);
    }
}
