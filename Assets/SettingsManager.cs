using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public bool sbs = false;
    public bool mountToHead = false;
    int serverPort = 26659;
    int angleX = 0;
    int angleY = 0;
    int angleZ = 0;

    [SerializeField]
    GameObject leftEyeScreen;
    [SerializeField]
    GameObject rightEyeScreen;
    [SerializeField]
    GameObject headMount;
    [SerializeField]
    GameObject room;

    Vector3 originalScreenPos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg == "-sbs") sbs = true;
            if (arg == "-selfie") mountToHead = true;
            if (arg.StartsWith("-port=")) serverPort = int.Parse(arg.Substring(6));
            if (arg.StartsWith("-angleX=")) angleX = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleY=")) angleY = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleZ=")) angleZ = int.Parse(arg.Substring(7));
        }

        originalScreenPos = leftEyeScreen.transform.localPosition;

        Debug.Log(string.Format("{0}\t{1}", originalScreenPos, headMount.transform.localRotation));

        ApplySettings();

        //GameObject.Find("IO").GetComponent<IO>().StartServer(serverPort);
    }

    public void SetSBS3D(bool isEnabled) {
        sbs = isEnabled;
    }

    public void SetMounttoHead(bool isEnabled) {
        mountToHead = isEnabled;
    }

    public void ApplySettings() {
        Debug.Log("ApplySettings");
        if (sbs) {
            leftEyeScreen.layer = 6;
            leftEyeScreen.GetComponent<uDesktopDuplication.Texture>().useClip = true;
            rightEyeScreen.SetActive(true);
            rightEyeScreen.GetComponent<uDesktopDuplication.Texture>().useClip = true;
        } else {
            leftEyeScreen.layer = 0;
            leftEyeScreen.GetComponent<uDesktopDuplication.Texture>().useClip = false;
            rightEyeScreen.GetComponent<uDesktopDuplication.Texture>().useClip = false;
            rightEyeScreen.SetActive(false);
        }

        if (mountToHead) {
            room.SetActive(false);
            headMount.GetComponent<DorsalDriver>().deviceType = DorsalDevice.DeviceType.HMD;
            headMount.GetComponent<DorsalDriver>().ConnectToChosenDevice();
            leftEyeScreen.transform.localPosition = new Vector3(0, 0, 1.3f);
            rightEyeScreen.transform.localPosition = leftEyeScreen.GetComponent<Transform>().position;
        } else {
            room.SetActive(true);
            headMount.GetComponent<DorsalDriver>().deviceType = DorsalDevice.DeviceType.Undefined;
            headMount.GetComponent<DorsalDriver>().ConnectToChosenDevice();
            headMount.transform.localPosition = Vector3.zero;
            headMount.transform.localRotation = Quaternion.identity;
            leftEyeScreen.transform.localPosition = originalScreenPos;
            rightEyeScreen.transform.localPosition = leftEyeScreen.transform.localPosition;
        }

        Quaternion relativeRotation = Quaternion.Euler((float)angleX, (float)angleY, (float)angleZ);
        GameObject.Find("DorsalDeviceManager").GetComponent<DorsalDeviceManager>().SetControllerRelativeRotations(relativeRotation);


        Debug.Log(string.Format("{0}\t{1}", leftEyeScreen.transform.localRotation, headMount.transform.localRotation));
    }
}
