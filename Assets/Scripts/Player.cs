using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _rotateSpeed = 10;
        [SerializeField] private float _playerRadius = 0.7f;
        [SerializeField] private float _playerHeight = 2f;

    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;

    void Update()
    {
        Vector2 inputVector = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
       
        _isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir * _rotateSpeed, Time.deltaTime * _rotateSpeed);
        var moveDistance =Time.deltaTime * _moveSpeed;
        var step = moveDir * moveDistance;
        
        bool canMove = Physics.CapsuleCast(transform.position,transform.position+Vector3.up*_playerHeight,_playerRadius, moveDir, moveDistance) == false;
        if (canMove == false)
        {
            var moveDirX = new Vector3(moveDir.x, 0, 0);
            bool canMoveX = Physics.CapsuleCast(transform.position,transform.position+Vector3.up*_playerHeight,_playerRadius, moveDirX, moveDistance) == false;
            if (canMoveX)
            {// try to move on X asis 
                canMove = true;
                step = moveDirX * moveDistance;
            }

            if (canMove == false)
            { // tryto move on Z axis
                var moveDirZ = new Vector3(0, 0, moveDir.z);
                bool canMoveZ = Physics.CapsuleCast(transform.position,transform.position+Vector3.up*_playerHeight,_playerRadius, moveDirZ, moveDistance) == false;
                if (canMoveZ)
                {
                    canMove = true;
                    step = moveDirZ * moveDistance;
                }
            }
        }
        
        if (canMove)
        { // if can move any direction advancce player 
            transform.position += step;
        }
    }


    public bool IsWalking()
    {
        return _isWalking;
    }
}