using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] ParticleSystem crashParticles;
    PlayerController playerController;
    public bool hasLost = false;
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        playerController = FindAnyObjectByType<PlayerController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int floorIndex = LayerMask.NameToLayer("Floor");
        bool headHit = collision.otherCollider is CircleCollider2D;


        {
            if (collision.gameObject.layer == floorIndex && headHit && !FindAnyObjectByType<FinishLine>().hasFinished)
            {
                hasLost = true;
                gameOverText.text = "Game Over!";
                gameOverText.gameObject.SetActive(true);
                playerController.canControlPlayer = false;
                playerController.baseSpeed = 0f;
                crashParticles.Play();
                //SceneManager.LoadScene(0);
                Invoke("ReloadScene", 1.5f);
            }
        }
    
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    


}
