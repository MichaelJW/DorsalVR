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
    Dropdown _screenSourceDropdown;
    [SerializeField]
    MirrorScreenTexture _targetScreen;
    [SerializeField]
    Toggle _mountScreenToHeadToggle;
    [SerializeField]
    Toggle _sbs3DToggle;
    [SerializeField]
    GameObject _uiPointer;

    // Start is called before the first frame update
    void Start()
    {
        _mountScreenToHeadToggle.isOn = _settingsManager.mountToHead;
        _sbs3DToggle.isOn = _settingsManager.sbs;
    }

    public void ChangeScreenSource(int listIndex) {
        _settingsManager.SetScreenSource(_screenSourceDropdown.GetComponent<ScreenSourceDropdown>().GetTarget(listIndex));
    }
        
    public void MountScreenToHead(bool isEnabled) {
        _settingsManager.SetMounttoHead(isEnabled);
        _settingsManager.ApplySettings();
    }

    public void UseSBS3D(bool isEnabled) {
        _settingsManager.SetSBS3D(isEnabled);
        _settingsManager.ApplySettings();
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
