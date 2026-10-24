using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AddScore(100, 1000);
    }

    void AddScore(int flipScore = 0, int finishScore = 0)
    {
        if (!FindAnyObjectByType<FinishLine>().hasFinished) {
            finishScore = 0;
        }
        long totalFlipScore = flipScore * FindAnyObjectByType<PlayerController>().flipCount;
        scoreText.text = "Score: " + (totalFlipScore + finishScore).ToString();
        
    }
}
