using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    private bool moreThenOneTouch = false;
    private bool galleryOpen = false;
    private Vector3 worldStartPoint;

    [SerializeField] private SpriteRenderer mapRenderer;
    [SerializeField] private GameObject gallery;
    [SerializeField] private float zoomStep, minCamSize, maxCamSize;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2 - 3;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2 + 3;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2 - 1f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2 + 1f;
    }

    void Update()
    {
        if (gallery.activeSelf)
            galleryOpen = true;
        else
            galleryOpen = false;

        Touch currentTouch;
        // only work with one touch
        if (Input.touchCount == 1 && !moreThenOneTouch && !galleryOpen)
        {
            currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began)
            {
                worldStartPoint = Camera.main.ScreenToWorldPoint(currentTouch.position);
            }

            if (currentTouch.phase == TouchPhase.Moved)
            {
                Vector3 worldDelta = Camera.main.ScreenToWorldPoint(currentTouch.position) - worldStartPoint;

                Camera.main.transform.position = ClampCamera(Camera.main.transform.position - worldDelta);
            }
        }

        if (Input.touchCount > 1)
        {
            moreThenOneTouch = true;
        }
        else
        {
            moreThenOneTouch = false;
            if (Input.touchCount == 1)
                worldStartPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
    }

    public void ZoomIn()
    {
        float newSize = Camera.main.orthographicSize - zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    }

    public void ZoomOut()
    {
        float newSize = Camera.main.orthographicSize + zoomStep;
        Camera.main.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        Camera.main.transform.position = ClampCamera(Camera.main.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = Camera.main.orthographicSize;
        float camWidth = Camera.main.orthographicSize * Camera.main.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
