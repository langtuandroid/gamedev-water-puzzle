using UnityEngine;

public static class DeviceTypeChecker
{
    public static DeviceType CheckDeviceType()
    {
        
        float screenSizeInches =
            Mathf.Sqrt(Mathf.Pow(Screen.width / Screen.dpi, 2) + Mathf.Pow(Screen.height / Screen.dpi, 2));
        
        if (screenSizeInches >= 7.0f) // Пороговое значение для определения планшета
        {
            return DeviceType.Tablet;
        }
        else
        {
            return DeviceType.Smartphone;
        }

    }

}
public enum DeviceType
{
    Smartphone,
    Tablet
}