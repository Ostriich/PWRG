using UnityEngine;

public class InfoPoint : MonoBehaviour
{
    [SerializeField] private string Name;
    [SerializeField] private Sprite Image;
    [SerializeField] private string Description;

    [SerializeField] private GameObject InfoPanel;

    private void OnMouseDown()
    {
        InfoPanel.GetComponent<InfoPanelManager>().PointTouch(Name, Image, Description, transform.position.x);
    }
}
