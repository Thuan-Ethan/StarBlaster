using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        offset += moveSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }
}
