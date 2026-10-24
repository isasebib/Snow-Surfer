using UnityEngine;
public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailParticles;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int floorIndex = LayerMask.NameToLayer("Floor");
    
        if (collision.gameObject.layer == floorIndex)
        {
            snowTrailParticles.Play();
        }
    
    }
  
    void OnCollisionExit2D(Collision2D collision)
    {
        int floorIndex = LayerMask.NameToLayer("Floor");
    
        if (collision.gameObject.layer == floorIndex)
        {
            snowTrailParticles.Stop();
        }
    
    }

}
