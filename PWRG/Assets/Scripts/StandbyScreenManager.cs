using UnityEngine;

public class StandbyScreenManager : MonoBehaviour
{
    [SerializeField] private float sleepTime;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject leftInfoPanel, rightInfoPanel, gallery;

    private bool IsSleep = true;

    private void OnMouseDown()
    {
        GetComponent<Animator>().SetBool("screenIsOpen", false);
        IsSleep = false;
    }

    private void Update()
    {
        if (!IsSleep)
            sleepTime += Time.deltaTime;

        if (sleepTime >= 30)
        {
            IsSleep = true;
            sleepTime = 0;
            GetComponent<Animator>().SetBool("screenIsOpen", true);
            cam.orthographicSize = 7;
            cam.transform.position = new Vector3( -9.5f, -3.8f, -10 );
            leftInfoPanel.SetActive(false);
            rightInfoPanel.SetActive(false);
            gallery.SetActive(false);
        }

        if (Input.touchCount > 0)
            sleepTime = 0;
    }
}
