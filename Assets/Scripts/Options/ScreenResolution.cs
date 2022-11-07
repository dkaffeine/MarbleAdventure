using UnityEngine;

/// <summary>
/// Generic class that handles screen resolution
/// </summary>
[System.Serializable]
public class ScreenResolution
{

    /// <summary>
    /// Screen resolution width
    /// </summary>
    private int width;

    /// <summary>
    /// Screen resolution height
    /// </summary>
    private int height;

    /// <summary>
    /// Screen refresh rate
    /// </summary>
    private int refreshRate;

    /// <summary>
    /// Default constructor: sets the resolution on 1920x1080 pixels, with a refresh rate of 60Hz
    /// </summary>
    public ScreenResolution()
    {
        this.width = 1920;
        this.height = 1080;
        this.refreshRate = 60;
    }

    /// <summary>
    /// Constructor in which the resolution is given, with a refresh rate of 60Hz
    /// </summary>
    /// <param name="width">Screen width in pixels</param>
    /// <param name="height">Screen height in pixels</param>
    public ScreenResolution(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.refreshRate = 60;
    }

    /// <summary>
    /// Constructor in which the resolution and refresh rate are given
    /// </summary>
    /// <param name="width">Screen width in pixels</param>
    /// <param name="height">Screen height in pixels</param>
    /// <param name="refreshRate">Refresh rate in Hz</param>
    public ScreenResolution(int width, int height, int refreshRate)
    {
        this.width = width;
        this.height = height;
        this.refreshRate = refreshRate;
    }

    /// <summary>
    /// Get resolution name
    /// </summary>
    /// <returns>Resolution name, under the format width x height px, refreshRate Hz</returns>
    public string GetResolutionName()
    {
        string resolutionName = width.ToString() + "x" + height.ToString() + "px, " + refreshRate.ToString() + "Hz";
        return resolutionName;
    }

    public void SetResolution(bool fullScreenFlag)
    {
        Screen.SetResolution(this.width, this.height, fullScreenFlag, this.refreshRate);
    }
}
