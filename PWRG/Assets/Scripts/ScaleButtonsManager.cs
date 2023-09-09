using UnityEngine;
using UnityEngine.UI;

public class ScaleButtonsManager : MonoBehaviour
{
    [SerializeField] private int extremeValue;

    private void Update()
    {
        if (Camera.main.orthographicSize == extremeValue)
        {
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().color = new Color32(255, 255, 255, 150);
        }
        else
        {
            GetComponent<Button>().enabled = true;
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
