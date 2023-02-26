using UnityEngine;


public class DeviceRotationOldInputSystem : MonoBehaviour
{
    Vector3 rot;
    
    private void Start()
    {
        // Prevent the screen from turning off due to inactivity
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        rot = Vector3.zero;
        Input.gyro.enabled = true;
    }

    void Update()
    {
        #region 1st try (failed)
        /*        rot.x = Input.gyro.rotationRateUnbiased.x;
                rot.z = Input.gyro.rotationRateUnbiased.z;
                transform.Rotate(rot);
                Debug.Log(rot);*/
        #endregion 1st try

        #region 2nd try
        // Get the current device rotation from the gyroscope
        Quaternion deviceRotation = Input.gyro.attitude;

        // Convert the device rotation from right-handed to left-handed coordinate system
        deviceRotation = new Quaternion(deviceRotation.x, deviceRotation.y, -deviceRotation.z, -deviceRotation.w);

        // Apply the device rotation to the plane's transform
        transform.rotation = deviceRotation;
        Debug.Log(deviceRotation);
        #endregion 2nd try
    }
}
