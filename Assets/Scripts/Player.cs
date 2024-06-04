using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5; [SerializeField]
    private float _rotateSpeed = 10;

    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;
    void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir =  new Vector3(inputVector.x, 0f, inputVector.y);
        _isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward,moveDir * _rotateSpeed,Time.deltaTime*_rotateSpeed) ;
        var step = moveDir * (Time.deltaTime * _moveSpeed);
        transform.position += step;
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
}