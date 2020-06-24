using UnityEngine;
using UnityEngine.SceneManagement;

public class FailLevel : MonoBehaviour
{
        public void LoadNLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
