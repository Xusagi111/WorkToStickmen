﻿using UnityEngine;
using UnityEngine.UI;

public class UiData : MonoBehaviour
{
    public GameObject PrefabMarker;
    public Canvas Canvas;
    public Image Winimage;
    public static UiData instanse;
    public Image DebugImage;
    private void Awake()
    {
        instanse = this;
    }
}
