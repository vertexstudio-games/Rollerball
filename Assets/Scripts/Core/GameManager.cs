using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string nameOfScene;
    public void Restart()
    {
        SceneManager.LoadScene(nameOfScene);
    }
}
