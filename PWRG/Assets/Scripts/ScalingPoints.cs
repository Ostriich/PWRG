using UnityEngine;

public class ScalingPoints : MonoBehaviour
{
    private float checkCamSize = 7;

    void Update()
    {
        if (checkCamSize != Camera.main.orthographicSize)
        {
            float scale = (Camera.main.orthographicSize - checkCamSize) / 20 * 3;
            transform.localScale = new Vector3(transform.localScale.x + scale, transform.localScale.y + scale, transform.localScale.z);
            checkCamSize = Camera.main.orthographicSize;
        }
    }
}
