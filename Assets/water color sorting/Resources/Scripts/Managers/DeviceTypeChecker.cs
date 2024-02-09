using UnityEngine;

public static class DeviceTypeChecker
{
    public static DeviceType CheckDeviceType()
    {
        
        float screenSizeInches =
            Mathf.Sqrt(Mathf.Pow(Screen.width / Screen.dpi, 2) + Mathf.Pow(Screen.height / Screen.dpi, 2));

        Debug.Log("screenSizeInches = " + screenSizeInches);
        if (screenSizeInches >= 7.0f) // Пороговое значение для определения планшета
        {
            Debug.Log("Device Type: " + DeviceType.Tablet);
            return DeviceType.Tablet;
        }
        else
        {
            Debug.Log("Device Type: " + DeviceType.Smartphone);
            return DeviceType.Smartphone;
        }

    }
    
}
public enum DeviceType
{
    Smartphone,
    Tablet
}