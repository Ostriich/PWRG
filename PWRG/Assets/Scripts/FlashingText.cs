using UnityEngine;

public class FlashingText : MonoBehaviour
{
    private byte visibility;
    private bool switcher;

    private void Update()
    {
        if (visibility == 255)
            switcher = false;
        if (visibility == 0)
            switcher = true;

        if (switcher)
            visibility += 1;
        else
            visibility -= 1;

        GetComponent<TextMesh>().color = new Color32(0, 0, 0, visibility);
    }
}
