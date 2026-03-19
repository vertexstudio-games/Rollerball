using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referencia do objeto player
    [SerializeField] private GameObject player;

    // Distancia entre a camera e o jogador
    private Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Calculando a distancia inicial entre o player e a camera posição
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Mantendo a mesma distancia durante o jogo.
        transform.position = player.transform.position + offset;
    }
}
