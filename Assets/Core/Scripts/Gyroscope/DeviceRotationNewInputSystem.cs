using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

public class DeviceRotationNewInputSystem : MonoBehaviour
{
    public GameObject objectToRotate;
    private InputAction gyroAction;
    
    private void OnEnable()
    {
        InputSystem.EnableDevice(Gyroscope.current);
        gyroAction = new InputAction("Gyroscope/GyroscopeValue", InputActionType.Value, "<Gyroscope>");
        gyroAction.Enable();
    }

    private void OnDisable()
    {
        gyroAction.Disable();
    }

    private void Update()
    {
        Vector3 gyroValue = gyroAction.ReadValue<Vector3>();
        transform.rotation = Quaternion.Euler(-gyroValue.y, gyroValue.x, gyroValue.z);
    }


    public void OnDeviceRotation(InputValue value)
    {
        Vector3 rotation = value.Get<Vector3>();
        objectToRotate.transform.rotation = Quaternion.Euler(rotation.y, -rotation.x, 0);
    }
}
