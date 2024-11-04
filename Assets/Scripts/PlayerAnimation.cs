using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    private const string _runAnimName = "isRun";
    private const string _jumpAnimName = "isJump";

    private const float posZ = 4.8f;

    [SerializeField] private Animator _animator;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
    }
    public void RunAnimation(bool state)
    {
        _animator.SetBool(_runAnimName, state);
    }
    public void JumpAnimation(bool state)
    {
        _animator.SetBool(_jumpAnimName, state);
    }
}
