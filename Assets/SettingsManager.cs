using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Quick hack for setting options via command line until we add a proper UI

    bool sbs = false;
    bool selfie = false;
    int serverPort = 26659;
    int angleX = 0;
    int angleY = 0;
    int angleZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        foreach (string arg in args) {
            if (arg == "-sbs") sbs = true;
            if (arg == "-selfie") selfie = true;
            if (arg.StartsWith("-port=")) serverPort = int.Parse(arg.Substring(6));
            if (arg.StartsWith("-angleX=")) angleX = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleY=")) angleY = int.Parse(arg.Substring(7));
            if (arg.StartsWith("-angleZ=")) angleZ = int.Parse(arg.Substring(7));
        }

        if (sbs) {
            GameObject.Find("Monitor Board (Left Eye)").layer = 6;
            GameObject.Find("Monitor Board (Left Eye)").GetComponent<uDesktopDuplication.Texture>().useClip = true;
            GameObject.Find("Monitor Board (Right Eye)").SetActive(true);
            GameObject.Find("Monitor Board (Right Eye)").GetComponent<uDesktopDuplication.Texture>().useClip = true;
        } else {
            GameObject.Find("Monitor Board (Right Eye)").SetActive(false);
        }

        if (selfie) {
            GameObject.Find("Room").SetActive(false);
            GameObject.Find("Selfie Stick").GetComponent<DorsalDriver>().deviceType = DorsalDevice.DeviceType.HMD;
            GameObject.Find("Selfie Stick").GetComponent<DorsalDriver>().ConnectToChosenDevice();
            GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().position = new Vector3(0, 0, GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().position.z);
            GameObject.Find("Monitor Board (Right Eye)").GetComponent<Transform>().position = GameObject.Find("Monitor Board (Left Eye)").GetComponent<Transform>().position;
        } else {
            GameObject.Find("Room").SetActive(true);
        }

        GameObject.Find("IO").GetComponent<IO>().StartServer(serverPort);

        Quaternion relativeRotation = Quaternion.Euler((float)angleX, (float)angleY, (float)angleZ);
        GameObject.Find("DorsalDeviceManager").GetComponent<DorsalDeviceManager>().SetControllerRelativeRotations(relativeRotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
