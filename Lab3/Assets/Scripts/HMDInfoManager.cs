using UnityEngine;
using UnityEngine.XR;

public class HMDInfoManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"XR device is active: {XRSettings.isDeviceActive}");
        Debug.Log($"XR device name is: {XRSettings.loadedDeviceName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
