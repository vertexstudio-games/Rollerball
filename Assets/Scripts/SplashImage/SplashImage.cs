using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashImage : MonoBehaviour
{
    public float tempo = 3f; // tempo em segundos
    public string nomeDaCena = "Minigame";

    void Start()
    {
        StartCoroutine(CarregarCena());
    }

    IEnumerator CarregarCena()
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(nomeDaCena);
    }
}
