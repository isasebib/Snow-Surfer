using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoChar;
    [SerializeField] GameObject frogChar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SelectDino()
    {
        dinoChar.SetActive(true);
        BeginGame();
    }

    public void SelectFrog()
    {
        frogChar.SetActive(true);
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
