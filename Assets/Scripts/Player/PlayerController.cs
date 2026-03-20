using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Rigidbody do player
    private Rigidbody rb;

    private int count;

    // Movimento ao longo dos eixos X e Y
    private float movementX;
    private float movementY;

    // Velocidade do player
    [SerializeField] private float speed = 0;

    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject restart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Armazenando o componente Rigidbody do player a variavel
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        winText.SetActive(false);
    }
    private void FixedUpdate()
    {
        // Criando o movimento 3D usando os eixos X e Y do input
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        // Adicionando forca ao jogadaor
        rb.AddForce(movement * speed); // Multiplicando a forca pela velocidade
    }

    // Essa função e chamada quando detecta o input de move (Ex.: WASD)
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Atribuindo variaveis de movimento X e Y
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winText.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            restart.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // checando se o objeto colidido e o da tag (no caso PickUp)
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Desativando o objeto coledido.
            other.gameObject.SetActive(false);

            //count++;
            count = count + 1;

            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Debug.Log("Teste Collision");
            this.gameObject.SetActive(false);
            //Destroy(gameObject);

            winText.gameObject.SetActive(true);
            winText.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            restart.SetActive(true);
        }
    }
}
