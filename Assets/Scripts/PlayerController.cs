using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float torque = 100f;
    [SerializeField] public float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 35f;
    InputAction moveAction;
    Rigidbody2D rigidbody;
    SurfaceEffector2D surfaceEffector2D;
    public bool canControlPlayer = true;
    float previousRotation, totalRotation;
    public uint flipCount;

    [SerializeField] TextMeshProUGUI speedPowerUpText;
    [SerializeField] TextMeshProUGUI torquePowerUpText;
    
    [SerializeField] ParticleSystem SpeedPowerUpParticles;
    [SerializeField] ParticleSystem TorquePowerUpParticles;
    
    
    void Start()
    {
        speedPowerUpText.gameObject.SetActive(false);
        torquePowerUpText.gameObject.SetActive(false);

        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();  
        flipCount = 0;
    }

    
  
    void Update()
    {
        if (canControlPlayer)
        {
            RotatePlayer();
            BoostPlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        
        if(moveVector.x < 0)
        {
            rigidbody.AddTorque(torque);
        }
        else if(moveVector.x > 0)
        {
            rigidbody.AddTorque(-torque);
        }
    }

    void BoostPlayer()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.y > 0)
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z; 

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        previousRotation = currentRotation;

        if (totalRotation < -340 || totalRotation > 340)
        {
            flipCount++;
            totalRotation = 0f;
            Debug.Log("Flips: " + flipCount);
        }

    }

    public void ActivatePowerUp(PowerUpSO powerUp)
    {
        if (powerUp.GetPowerUpType() == "speed")
        {
            print("Speed Power-Up Activated!");
            baseSpeed += powerUp.GetValueChange();
            boostSpeed += powerUp.GetValueChange();
            speedPowerUpText.text = "Speed Boost!";
            speedPowerUpText.gameObject.SetActive(true);
            SpeedPowerUpParticles.Play();
        }

        else if (powerUp.GetPowerUpType() == "torque")
        {
            print("Torque Power-Up Activated!");
            torque += powerUp.GetValueChange();
            torquePowerUpText.text = "Spinner!";
            torquePowerUpText.gameObject.SetActive(true);
            TorquePowerUpParticles.Play();
        }
    }

    public void DeactivatePowerUp(PowerUpSO powerUp)
    {
        if (powerUp.GetPowerUpType() == "speed")
        {
            print("Speed Power-Up Deactivated!");
            baseSpeed -= powerUp.GetValueChange();
            boostSpeed -= powerUp.GetValueChange();
            speedPowerUpText.gameObject.SetActive(false);
            SpeedPowerUpParticles.Stop();
        }

        else if (powerUp.GetPowerUpType() == "torque")
        {
            print("Torque Power-Up Deactivated!");
            torque -= powerUp.GetValueChange();
            torquePowerUpText.gameObject.SetActive(false);
            TorquePowerUpParticles.Stop();
        }
    }
}
