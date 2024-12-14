using UnityEngine;

public class ResponsiveGame : MonoBehaviour
{
    void Start()
    {
        AdjustToIframeSize();
        AdjustAspectRatio();
    }

    void AdjustToIframeSize()
    {
        int minWidth = 640;
        int minHeight = 480;

        if (Screen.width < minWidth || Screen.height < minHeight)
        {
            Screen.SetResolution(minWidth, minHeight, false);
        }
    }

    void AdjustAspectRatio()
    {
        float targetAspect = 640f / 480f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}

