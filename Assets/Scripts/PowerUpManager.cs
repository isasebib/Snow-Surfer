using UnityEngine;
public class PowerUpManager : MonoBehaviour
{

    [SerializeField] PowerUpSO powerUp;
    PlayerController playerController;

    SpriteRenderer spriteRenderer;
    float timeRemaining;
    bool powerUpActive = false;

    CrashDetector crashDetector;
    bool hasLost;

    void Start()
    {

        crashDetector = FindAnyObjectByType<CrashDetector>();
        playerController = FindAnyObjectByType<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeRemaining = powerUp.GetDuration();
        
        
    }

    void Update()
    {
        hasLost = crashDetector.hasLost;

        if (!spriteRenderer.enabled && powerUpActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                playerController.DeactivatePowerUp(powerUp);
                powerUpActive = false;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && spriteRenderer.enabled && !hasLost)
        {
            powerUpActive = true;
            spriteRenderer.enabled = false;
            playerController.ActivatePowerUp(powerUp);
        }
    }

}
