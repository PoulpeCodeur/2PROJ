using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SunEffect : MonoBehaviour
{
    public float radius = 5f;
    public float dayDuration = 24f;
    public float startTime = 6f;
    
    private float angle;
    private Light2D lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light2D>();
        angle = (startTime / 24f) * 360f - 180f;
    }

    void Update()
    {
        angle += (360f / dayDuration) * Time.deltaTime;
        
        float radian = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radian) * radius;
        float y = Mathf.Abs(Mathf.Sin(radian)) * radius;
        
        transform.position = new Vector3(x, y, transform.position.z);
        
        if (lightComponent != null)
        {
            float currentHour = ((angle + 180f) % 360f) * 24f / 360f;
            
            if (currentHour < 6 || currentHour > 18)
            {
                lightComponent.intensity = 0.2f;
            }
            else
            {
                float t = Mathf.Abs(currentHour - 12f) / 6f;
                lightComponent.intensity = Mathf.Lerp(1f, 0.2f, t);
            }
        }
    }
}