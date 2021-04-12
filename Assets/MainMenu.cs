using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    SettingsManager _settingsManager;
    [SerializeField]
    Toggle _mountScreenToHeadToggle;
    [SerializeField]
    Toggle _sbs3DToggle;

    // Start is called before the first frame update
    void Start()
    {
        _mountScreenToHeadToggle.isOn = _settingsManager.mountToHead;
        _sbs3DToggle.isOn = _settingsManager.sbs;
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
        GameObject.Find("UI Pointer").SetActive(false);
        this.gameObject.SetActive(false);
    }
}
