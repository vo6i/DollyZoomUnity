public class DollyZoom : MonoBehaviour
{
    // based around the formula:
    // distance = width / (2 * tan(1/2 * FOV)))

    public float width = 5f;
    public float distance = 0f;
    public float fieldOfView = 60f;

    private Camera _camera;


    private void Start()
    {
        _camera = transform.GetComponent<Camera>();
        distance = transform.localPosition.z;

        // set initial FOV value for camera
        fieldOfView = Mathf.Rad2Deg * Mathf.Atan(width / (2 * distance)) * 2;
        _camera.fieldOfView = fieldOfView;

    }

    private void Update()
    {
        if (_camera.fieldOfView != fieldOfView)
        {
            fieldOfView = _camera.fieldOfView;
            distance = width / (2 * Mathf.Tan(0.5f *  Mathf.Deg2Rad * fieldOfView));

            Vector3 localPos = transform.localPosition;
            localPos.z = distance;
            transform.localPosition = localPos;


        } else if (distance != transform.localPosition.z)
        {
            distance = transform.localPosition.z;
            fieldOfView = Mathf.Rad2Deg * Mathf.Atan(width / (2 * distance)) * 2;
            _camera.fieldOfView = fieldOfView;
            
        }
    }

}
