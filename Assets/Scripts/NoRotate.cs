using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotate : MonoBehaviour
{
    void Awake()
    {
        // Устанавливаем ориентацию экрана в альбомную (горизонтальную)
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        // Блокируем поворот экрана
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
}
