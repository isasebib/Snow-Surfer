using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinishLine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI victoryText;
    [SerializeField] ParticleSystem finishParticles;
    public bool hasFinished = false;
    void Start()
    {
        victoryText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !FindAnyObjectByType<CrashDetector>().hasLost)
        {
            hasFinished = true;
            FindAnyObjectByType<PlayerController>().canControlPlayer = false;
            FindAnyObjectByType<PlayerController>().baseSpeed = 0f;
            victoryText.text = "Victory!";
            victoryText.gameObject.SetActive(true);
            finishParticles.Play();
            //SceneManager.LoadScene(0);
            Invoke("ReloadScene", 1.5f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
