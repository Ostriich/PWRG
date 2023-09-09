using UnityEngine;
using UnityEngine.UI;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject leftPanel, rightPanel;
    [SerializeField] private GameObject leftPanelName, rightPanelName;
    [SerializeField] private GameObject leftPanelImage, rightPanelImage;
    [SerializeField] private GameObject leftPanelDescription, rightPanelDescription;
    [SerializeField] private GameObject gallery;

    public void PointTouch(string name, Sprite image, string description, float posX)
    {
        if (CheckOpenPanel(name))
        {
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);
        }
        else
        {
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);

            if (Camera.main.transform.position.x - posX < 0)
            {
                leftPanel.SetActive(true);
                leftPanelName.GetComponent<Text>().text = name;
                leftPanelImage.GetComponent<Image>().sprite = image;
                leftPanelDescription.GetComponent<Text>().text = description;
            }
            else
            {
                rightPanel.SetActive(true);
                rightPanelName.GetComponent<Text>().text = name;
                rightPanelImage.GetComponent<Image>().sprite = image;
                rightPanelDescription.GetComponent<Text>().text = description;
            }
        }
    }

    private bool CheckOpenPanel(string name)
    {
        if (leftPanel.activeSelf && leftPanelName.GetComponent<Text>().text == name ||
            rightPanel.activeSelf && rightPanelName.GetComponent<Text>().text == name)
            return true;
        else
            return false;
    }

    public void OpenGallery(string side)
    {
        gallery.SetActive(true);

        if (side == "left")
        {
            gallery.GetComponent<GalleryManager>().SetPhotos(leftPanelName.GetComponent<Text>().text);
            leftPanel.SetActive(false);
        }
        else
        {
            gallery.GetComponent<GalleryManager>().SetPhotos(rightPanelName.GetComponent<Text>().text);
            rightPanel.SetActive(false);
        }
    }
}
