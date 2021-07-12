using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer = null;

    public Animator TargetHitAnimator = null;

    public Transform PartToRotate = null;


    private Vector3 Location;

    public float StayTime;

    private float Speed = 2.5f;

    public bool IsHit { get; private set; }

    private bool _isMovingIn = false;
    private bool _isStaying = false;
    private bool _isMovingOut = false;

    private float _timeLeft = 0f;

    public event Action IsOut;

    private void OnEnable()
    {
        IsHit = false;
        _isMovingIn = false;
        _isStaying = false;
        _isMovingOut = false;
        TargetHitAnimator.enabled = false;
        PartToRotate.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (_isStaying)
        {
            _timeLeft -= Time.deltaTime;
        }
        else
        {
            if (Mathf.Abs(transform.position.x - Location.x) < 0.01f)
            {
                transform.position = Location;

                if (_isMovingOut)
                {
                    gameObject.SetActive(false);
                    IsOut?.Invoke();
                    return;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, Location, Speed * Time.deltaTime);
            }
        }
    }

    private void MoveOut()
    {
        _isMovingIn = false;
        _isStaying = false;
        Location = (Location.x < 0 ? new Vector3(-10, 0) : new Vector3(10, 0));
        _isMovingOut = true;
    } 

    public void Hit(Vector2 position)
    {
        if (IsHit)
            return;

        IsHit = true;

        TargetHitAnimator.enabled = true;
        MoveOut();
    }
}
