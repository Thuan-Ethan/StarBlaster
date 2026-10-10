using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float leftBoundsPadding;
    [SerializeField] private float rightBoundsPadding;
    [SerializeField] private float topBoundsPadding;
    [SerializeField] private float bottomBoundsPadding;
    
    InputAction moveAction;
    Vector3 moveVector;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }
    
    void InitBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Debug.Log(minBounds);
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
        Debug.Log(maxBounds);
    }

    void PlayerMove()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * playerSpeed * Time.deltaTime;
        
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundsPadding, maxBounds.x - leftBoundsPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + bottomBoundsPadding, maxBounds.y - topBoundsPadding);
        
        transform.position =  newPos;
    }
}
