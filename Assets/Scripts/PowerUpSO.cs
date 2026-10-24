using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Scriptable Objects/PowerUpSO")]
public class PowerUpSO : ScriptableObject
{
    [SerializeField] string powerUpType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string GetPowerUpType() { return powerUpType; }
    public float GetValueChange() { return valueChange; }
    public float GetDuration() { return duration; }

}
