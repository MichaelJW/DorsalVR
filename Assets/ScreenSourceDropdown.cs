using Ruccho.GraphicsCapture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenSourceDropdown : MonoBehaviour
{
    Dropdown dd;
    Dictionary<int, ICaptureTarget> listTargets;

    // Start is called before the first frame update
    void Start()
    {
        dd = this.GetComponent<Dropdown>();
        listTargets = new Dictionary<int, ICaptureTarget>();
        UpdateList();
    }

    public void OnDropdownClicked(BaseEventData eventData) {
        UpdateList();  // Update the list before showing it to the user
    }

    void UpdateList() {
        string currentlySelectedDescription = dd.captionText.text;
        int newlySelectedIndex = 0;

        dd.ClearOptions();
        List<string> options = new List<string>();
        listTargets.Clear();
        int i = 0;

        // First the monitors, then the windows
        foreach (ICaptureTarget target in Utils.GetMonitors()) {
            if (target.TargetType == CaptureTargetType.Monitor) {
                listTargets[i] = target;
                options.Add(target.Description);

                if (target.Description == currentlySelectedDescription) {
                    newlySelectedIndex = i;
                }

                i++;
            }
        }
        foreach (ICaptureTarget target in Utils.GetTopWindows(false)) {
            listTargets[i] = target;
            options.Add(target.Description);

            if (target.Description == currentlySelectedDescription) {
                newlySelectedIndex = i;
            }

            i++;
        }

        dd.AddOptions(options);
        dd.RefreshShownValue();
        dd.value = newlySelectedIndex;
    }

    public ICaptureTarget GetTarget(int listIndex) {
        return listTargets[listIndex];
    }
}
