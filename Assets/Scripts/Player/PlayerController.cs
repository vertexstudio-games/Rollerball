using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    [SerializeField] private float speed = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        // Adicionando forca ao jogadaor
        rb.AddForce(movement * speed); // Multiplicando a forca pela velocidade
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Atribuindo variaveis de movimento X e Y
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}
