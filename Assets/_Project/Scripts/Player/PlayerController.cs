using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1f;
    
    InputAction moveAction;
    Vector3 moveVector;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        transform.position +=  moveVector  * playerSpeed * Time.deltaTime;
    }
}
