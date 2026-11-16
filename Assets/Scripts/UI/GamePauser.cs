using UnityEngine;

public class GamePauser : MonoBehaviour
{
    [SerializeField] private bool pauseOnStart = true;

    private void Awake()
    {
        if (pauseOnStart)
        {
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}