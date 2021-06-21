using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ruccho.GraphicsCapture;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    SettingsManager _settingsManager;
    [SerializeField]
    GameObject _uiPointer;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void CloseMenu() {
        _uiPointer.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void Update() {
        RaycastResult raycastResult;
        _uiPointer.GetComponent<XRRayInteractor>().TryGetCurrentUIRaycastResult(out raycastResult);
        GameObject.Find("Sphere").transform.position = raycastResult.worldPosition;
    }
}
