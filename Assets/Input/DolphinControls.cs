// GENERATED AUTOMATICALLY FROM 'Assets/Input/DolphinControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DolphinControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DolphinControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DolphinControls"",
    ""maps"": [
        {
            ""name"": ""Dolphin/GCPad"",
            ""id"": ""8b1f429f-d3e8-4548-942e-7f2eb47dc734"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""5d62f93c-57b8-47b7-9dd0-ec59ca7549e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""d8cd58a9-4918-4f4a-8987-3a852a27e70c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""0ba24df7-2a34-4181-b996-35615d6254d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""1b3291c8-56c7-4571-85d8-e40b80c0c019"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""d7177015-5303-44fb-99f3-990955abb31d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""575340ce-15b7-49b4-83a7-3fd8618691f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Main Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""7d53ab81-ede9-44f8-a1f1-e9623ba93ff7"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Main Stick Y"",
                    ""type"": ""Value"",
                    ""id"": ""6979b2f5-e27d-412e-8bfc-9d048cf663c3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""C-Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""8fd2b1ce-f5a5-4f16-8fe8-314704cd96d1"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""C-Stick Y"",
                    ""type"": ""Value"",
                    ""id"": ""65c18ef8-cac3-42d9-9e30-280d521fd114"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""8a9f028c-a446-45e8-9852-172bb54cb46f"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R Trigger"",
                    ""type"": ""Value"",
                    ""id"": ""4e501986-4438-45af-a922-18c021520fa9"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""d44d3426-a3db-4d5d-b8a9-9fe1eac22789"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""4f68898e-1d3d-4a5c-9cb1-53ae313453ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""91e66df8-7219-46da-b56d-04dde3bdee25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""08467e25-1572-403d-8099-7e01d8140e5f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": []
        },
        {
            ""name"": ""Dolphin/Wiimote"",
            ""id"": ""3c78cb15-d3b9-4fae-9336-61cf7710be83"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""2eb4291c-5263-4533-94e9-8e84f64524e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""a367764f-27ab-43a2-b92f-6bee442088cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""One"",
                    ""type"": ""Button"",
                    ""id"": ""45322abc-af3e-4fd3-9c17-de8e87e72f47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Two"",
                    ""type"": ""Button"",
                    ""id"": ""084da213-be32-4b0c-b1a0-ad061264531e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Minus"",
                    ""type"": ""Button"",
                    ""id"": ""8fa4af7f-2af7-4ca0-8ba8-2e1650a97e46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plus"",
                    ""type"": ""Button"",
                    ""id"": ""46bc8910-1695-4a4f-aca6-4ab762171d83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Home"",
                    ""type"": ""Button"",
                    ""id"": ""31d9bfb1-6a88-4e06-940d-41f83b6eadac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer X"",
                    ""type"": ""Value"",
                    ""id"": ""3f6e0897-6684-44c5-870a-67c802b4619c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer Y"",
                    ""type"": ""Value"",
                    ""id"": ""5865a9c4-6580-4c66-aabe-d4b61100aa14"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer Z"",
                    ""type"": ""Value"",
                    ""id"": ""88cae884-3247-4f1a-b0d3-7c18816991b3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gyro Pitch"",
                    ""type"": ""Value"",
                    ""id"": ""914607d3-6e72-49eb-bd99-7a4308bcd20c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gyro Yaw"",
                    ""type"": ""Value"",
                    ""id"": ""0cac6723-1ea2-44e8-a1c9-754c7e99c85a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gyro Roll"",
                    ""type"": ""Value"",
                    ""id"": ""91fe8096-e550-4e5d-9e7b-89f0521cdd4a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""01ac6988-eeb3-4067-b7f3-6a5383cfbf2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""0f5d7510-8dea-43a4-a317-737e9e6f018e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""6a5a5a45-9648-4e4c-9269-6070e7706d44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""8c718c6f-cbf4-4da7-916d-35cf6be4e8e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Recenter"",
                    ""type"": ""Button"",
                    ""id"": ""5f66384f-65a9-4720-ad23-280eacbb76e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shake X"",
                    ""type"": ""Button"",
                    ""id"": ""16a41835-cb4e-4bf2-a7f0-e998d3345f48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shake Y"",
                    ""type"": ""Button"",
                    ""id"": ""ad2c44fa-392d-4817-a6e4-4f9d0f474a6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shake Z"",
                    ""type"": ""Button"",
                    ""id"": ""1165a948-3f8e-4f20-b202-6b0cb95887e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1e33419c-c8b0-4d0e-9089-e5ebf369a527"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a152129-11da-4d35-ab5f-c49b87e576e7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62ab2aa1-f0c4-4d91-a8e6-5b2de8d3aad2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""One"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10800db7-bc2e-4d18-834c-284c97307b9c"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Two"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c7106317-a877-40f2-9f1b-98ad8ccb3c6d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38207a07-6313-4876-9640-bb4c8f2cf5f2"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Minus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a17a5d2-eaaf-4aab-8d83-d7b5a38d27e0"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Home"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a31771c1-abbd-4bab-ad26-f63c49c51521"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b2b7e89-bcca-4eed-8564-dd272f1704b0"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd918059-713d-4f44-9dfd-93d1375d52ec"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afd600c0-6b28-478b-be9b-5e3c88ee34e6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gyro Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ea101f3-f534-44e1-a986-df0724d4aa7b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gyro Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80da1a96-6a19-4092-9f3d-d87260af08e9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gyro Yaw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65d5c74f-e87b-41f6-8baa-b1f784e03b4d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d89f163-0280-4160-9217-7ace21b65f91"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1878af1d-ab20-46f6-a0bc-4366016d6ee7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e007377-2f74-48eb-a2fd-95ce17fe5fe1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7230df37-d602-43c1-8479-e27f33978ee6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Recenter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34ae2bb9-393b-4ab2-bfb0-cf8a1d1dfd87"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shake X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ed43e7f-7dbb-4966-a405-e6d795e13b3e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shake Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7de1ba62-08ad-4a70-ba08-2ae1cb6e4d05"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shake Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dolphin/Nunchuk"",
            ""id"": ""a8720965-e7b3-4efe-a20a-07daabde30f3"",
            ""actions"": [
                {
                    ""name"": ""C"",
                    ""type"": ""Button"",
                    ""id"": ""daa60724-3b8f-4503-a256-4a2adeb619b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Z"",
                    ""type"": ""Button"",
                    ""id"": ""b307bc87-aac1-4306-9144-389bcd5c2e81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""5dcac0e7-bbbd-4b92-8609-2519c03ec582"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Stick Y"",
                    ""type"": ""Value"",
                    ""id"": ""efbbdaf2-a65b-4d1f-a74a-3c0ec98f3fa2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer X"",
                    ""type"": ""Value"",
                    ""id"": ""9534ee29-2eae-483f-8dc8-355ea6055a42"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer Y"",
                    ""type"": ""Value"",
                    ""id"": ""64dedc06-130f-4dba-9e8c-90e2beaca22a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerometer Z"",
                    ""type"": ""Value"",
                    ""id"": ""e25d6c3c-d0d4-497e-8ebf-9d026be3297c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6c7b1287-1d70-4b48-b3cf-6d501ff5603a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""970f4380-3da3-4969-ac70-33eeed5bb137"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""C"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6393dfc1-7a66-410b-a55a-f2d316f90cde"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stick X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cf77f3b-1251-4e38-bb83-bc429c9aa516"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Stick Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37463765-21e8-477f-8cd8-78a94c5b1672"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer Z"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e9f93b8-14c2-467c-9027-e4319bcd0fbf"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9247b4bb-c1ba-4cc5-bc2e-2121d5abdb91"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerometer Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dolphin/ClassicController"",
            ""id"": ""4559053d-5ec9-4e39-a37b-10f0849b57f6"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""41819247-f2e4-409b-80c0-f4c8214fdd97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""7fec8229-d0e1-4222-a4f9-39c8cfc3a813"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""cad82d43-49be-41ef-9430-11ac0dc221e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""95568cd9-2bf1-4386-ab5c-48338dd956af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L"",
                    ""type"": ""Value"",
                    ""id"": ""1dc51f92-99b5-4ff4-bbc6-78c611867554"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R"",
                    ""type"": ""Value"",
                    ""id"": ""6a64b04b-69c9-4be7-a36e-963dd91ef815"",
                    ""expectedControlType"": ""Analog"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZL"",
                    ""type"": ""Button"",
                    ""id"": ""fc99bc02-5150-4564-b365-74827edccc8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ZR"",
                    ""type"": ""Button"",
                    ""id"": ""e752d711-b218-41f6-97c9-4dc4d6225901"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Minus"",
                    ""type"": ""Button"",
                    ""id"": ""08e089e7-1347-462c-b6d2-f1a8c2793a97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Plus"",
                    ""type"": ""Button"",
                    ""id"": ""8b205221-94de-435e-b070-1cda22143525"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Home"",
                    ""type"": ""Button"",
                    ""id"": ""8e5d30dc-2827-463e-be84-1db03c4c1422"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""be4ae787-0328-478b-8cda-623bee1e801a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""e19bbab1-8301-4e44-ada1-9565866e843b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""c8dfbbda-80b5-4b0f-af7f-297537a08461"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""b8187fb0-ad61-402d-ac23-46a31a1a24e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""5cd80bd3-b9c1-435b-903c-7c3645401253"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Stick Y"",
                    ""type"": ""Value"",
                    ""id"": ""3ba13395-b70d-41a4-8c2e-310dcf7ff0dd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Stick X"",
                    ""type"": ""Value"",
                    ""id"": ""14193cd8-6efc-442c-bdbe-15958a2e451f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Stick Y"",
                    ""type"": ""Value"",
                    ""id"": ""bc079f6c-8ba4-4762-b05c-f11f35acf5c9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""89707e25-6372-4497-b4e6-e084fe0b89de"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0336a10-2bff-4017-abf5-3db6be267238"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0bf622f-d54a-429b-8389-e95395614d4b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09cc03b8-c6ad-4da8-9ec0-49e0835bbe44"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18d7f30b-16d2-4909-b729-80379d784775"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8194a364-d26e-4100-8e4a-dbf34a1381c4"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Plus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d426434-715e-4a37-bb9a-2c16a88f8a2a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Minus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f551893c-38f8-414c-8899-3895eaf2277d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ZR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""487e421d-533c-4c85-a73d-1256e40aa727"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad576af4-6e18-4742-bc70-569b79ee85d3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ceb512-1d93-4aa9-8e66-ad522838bc5b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Home"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b37c840-2516-4bf5-8c3b-aecb1aba0e68"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b55f191-f2ac-49f1-aa4b-76349e738e5a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""895a4761-1017-4664-819a-6013eb57275f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf6b5b8-26a4-40d9-87a2-2365efbd4cd8"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcef164c-bc87-43e2-b0ac-4c1b7ad92471"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Stick Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""893b5c93-857b-4c81-a75f-b4890238a6a1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11f313cc-98f2-4886-9667-c7a2fa9841ef"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Stick X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33276f6f-8372-49d9-9aa2-5c45adcac504"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Stick X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dolphin/Hotkeys"",
            ""id"": ""0d3e7ce2-66ac-4906-8120-60c7dd43554c"",
            ""actions"": [
                {
                    ""name"": ""Toggle Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f70e48e3-c424-4da1-9219-ee4cdc7a8852"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Take Screenshot"",
                    ""type"": ""Button"",
                    ""id"": ""5df7df97-ba24-4282-a44e-872ebc2f82d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Save State"",
                    ""type"": ""Button"",
                    ""id"": ""549e5a97-dc52-4f41-a21c-43564d27f29f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Load State"",
                    ""type"": ""Button"",
                    ""id"": ""5fe69594-2f77-43ea-81ae-6dda5a1ce332"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decrease Depth"",
                    ""type"": ""Button"",
                    ""id"": ""a7d92616-cf96-47ec-ab79-986d0046b7f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Increase Depth"",
                    ""type"": ""Button"",
                    ""id"": ""870bb38a-fede-48ec-bc98-f6555b31775a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Decrease Convergence"",
                    ""type"": ""Button"",
                    ""id"": ""90d29e4c-b983-4f0d-a2d5-e220ade45787"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Increase Convergence"",
                    ""type"": ""Button"",
                    ""id"": ""a75d7167-0b75-4ce5-9ff0-8adba86bc546"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0633e465-bdba-43c2-acfc-cb1b4cda8769"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0060749a-3db2-4f25-84ff-ee14db6ddbf6"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Take Screenshot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44849715-e021-4f4e-ad28-37e597d07d17"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save State"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e75c3022-a7ce-48d6-bc3c-d568421cc234"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Load State"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999c99bb-ac48-4cc1-b8dd-1a74bef29f71"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decrease Depth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f803c18-0d1f-4dad-93fd-950c9003d970"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Increase Depth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b678e0ce-f513-4508-bff0-52d92b8920f1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decrease Convergence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ae244ba-fead-408e-8bbb-14b8e3136662"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Increase Convergence"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Dolphin/GCPad
        m_DolphinGCPad = asset.FindActionMap("Dolphin/GCPad", throwIfNotFound: true);
        m_DolphinGCPad_A = m_DolphinGCPad.FindAction("A", throwIfNotFound: true);
        m_DolphinGCPad_B = m_DolphinGCPad.FindAction("B", throwIfNotFound: true);
        m_DolphinGCPad_X = m_DolphinGCPad.FindAction("X", throwIfNotFound: true);
        m_DolphinGCPad_Y = m_DolphinGCPad.FindAction("Y", throwIfNotFound: true);
        m_DolphinGCPad_Z = m_DolphinGCPad.FindAction("Z", throwIfNotFound: true);
        m_DolphinGCPad_Start = m_DolphinGCPad.FindAction("Start", throwIfNotFound: true);
        m_DolphinGCPad_MainStickX = m_DolphinGCPad.FindAction("Main Stick X", throwIfNotFound: true);
        m_DolphinGCPad_MainStickY = m_DolphinGCPad.FindAction("Main Stick Y", throwIfNotFound: true);
        m_DolphinGCPad_CStickX = m_DolphinGCPad.FindAction("C-Stick X", throwIfNotFound: true);
        m_DolphinGCPad_CStickY = m_DolphinGCPad.FindAction("C-Stick Y", throwIfNotFound: true);
        m_DolphinGCPad_LTrigger = m_DolphinGCPad.FindAction("L Trigger", throwIfNotFound: true);
        m_DolphinGCPad_RTrigger = m_DolphinGCPad.FindAction("R Trigger", throwIfNotFound: true);
        m_DolphinGCPad_DPadUp = m_DolphinGCPad.FindAction("D-Pad Up", throwIfNotFound: true);
        m_DolphinGCPad_DPadDown = m_DolphinGCPad.FindAction("D-Pad Down", throwIfNotFound: true);
        m_DolphinGCPad_DPadLeft = m_DolphinGCPad.FindAction("D-Pad Left", throwIfNotFound: true);
        m_DolphinGCPad_DPadRight = m_DolphinGCPad.FindAction("D-Pad Right", throwIfNotFound: true);
        // Dolphin/Wiimote
        m_DolphinWiimote = asset.FindActionMap("Dolphin/Wiimote", throwIfNotFound: true);
        m_DolphinWiimote_A = m_DolphinWiimote.FindAction("A", throwIfNotFound: true);
        m_DolphinWiimote_B = m_DolphinWiimote.FindAction("B", throwIfNotFound: true);
        m_DolphinWiimote_One = m_DolphinWiimote.FindAction("One", throwIfNotFound: true);
        m_DolphinWiimote_Two = m_DolphinWiimote.FindAction("Two", throwIfNotFound: true);
        m_DolphinWiimote_Minus = m_DolphinWiimote.FindAction("Minus", throwIfNotFound: true);
        m_DolphinWiimote_Plus = m_DolphinWiimote.FindAction("Plus", throwIfNotFound: true);
        m_DolphinWiimote_Home = m_DolphinWiimote.FindAction("Home", throwIfNotFound: true);
        m_DolphinWiimote_AccelerometerX = m_DolphinWiimote.FindAction("Accelerometer X", throwIfNotFound: true);
        m_DolphinWiimote_AccelerometerY = m_DolphinWiimote.FindAction("Accelerometer Y", throwIfNotFound: true);
        m_DolphinWiimote_AccelerometerZ = m_DolphinWiimote.FindAction("Accelerometer Z", throwIfNotFound: true);
        m_DolphinWiimote_GyroPitch = m_DolphinWiimote.FindAction("Gyro Pitch", throwIfNotFound: true);
        m_DolphinWiimote_GyroYaw = m_DolphinWiimote.FindAction("Gyro Yaw", throwIfNotFound: true);
        m_DolphinWiimote_GyroRoll = m_DolphinWiimote.FindAction("Gyro Roll", throwIfNotFound: true);
        m_DolphinWiimote_DPadUp = m_DolphinWiimote.FindAction("D-Pad Up", throwIfNotFound: true);
        m_DolphinWiimote_DPadDown = m_DolphinWiimote.FindAction("D-Pad Down", throwIfNotFound: true);
        m_DolphinWiimote_DPadLeft = m_DolphinWiimote.FindAction("D-Pad Left", throwIfNotFound: true);
        m_DolphinWiimote_DPadRight = m_DolphinWiimote.FindAction("D-Pad Right", throwIfNotFound: true);
        m_DolphinWiimote_Recenter = m_DolphinWiimote.FindAction("Recenter", throwIfNotFound: true);
        m_DolphinWiimote_ShakeX = m_DolphinWiimote.FindAction("Shake X", throwIfNotFound: true);
        m_DolphinWiimote_ShakeY = m_DolphinWiimote.FindAction("Shake Y", throwIfNotFound: true);
        m_DolphinWiimote_ShakeZ = m_DolphinWiimote.FindAction("Shake Z", throwIfNotFound: true);
        // Dolphin/Nunchuk
        m_DolphinNunchuk = asset.FindActionMap("Dolphin/Nunchuk", throwIfNotFound: true);
        m_DolphinNunchuk_C = m_DolphinNunchuk.FindAction("C", throwIfNotFound: true);
        m_DolphinNunchuk_Z = m_DolphinNunchuk.FindAction("Z", throwIfNotFound: true);
        m_DolphinNunchuk_StickX = m_DolphinNunchuk.FindAction("Stick X", throwIfNotFound: true);
        m_DolphinNunchuk_StickY = m_DolphinNunchuk.FindAction("Stick Y", throwIfNotFound: true);
        m_DolphinNunchuk_AccelerometerX = m_DolphinNunchuk.FindAction("Accelerometer X", throwIfNotFound: true);
        m_DolphinNunchuk_AccelerometerY = m_DolphinNunchuk.FindAction("Accelerometer Y", throwIfNotFound: true);
        m_DolphinNunchuk_AccelerometerZ = m_DolphinNunchuk.FindAction("Accelerometer Z", throwIfNotFound: true);
        // Dolphin/ClassicController
        m_DolphinClassicController = asset.FindActionMap("Dolphin/ClassicController", throwIfNotFound: true);
        m_DolphinClassicController_A = m_DolphinClassicController.FindAction("A", throwIfNotFound: true);
        m_DolphinClassicController_B = m_DolphinClassicController.FindAction("B", throwIfNotFound: true);
        m_DolphinClassicController_X = m_DolphinClassicController.FindAction("X", throwIfNotFound: true);
        m_DolphinClassicController_Y = m_DolphinClassicController.FindAction("Y", throwIfNotFound: true);
        m_DolphinClassicController_L = m_DolphinClassicController.FindAction("L", throwIfNotFound: true);
        m_DolphinClassicController_R = m_DolphinClassicController.FindAction("R", throwIfNotFound: true);
        m_DolphinClassicController_ZL = m_DolphinClassicController.FindAction("ZL", throwIfNotFound: true);
        m_DolphinClassicController_ZR = m_DolphinClassicController.FindAction("ZR", throwIfNotFound: true);
        m_DolphinClassicController_Minus = m_DolphinClassicController.FindAction("Minus", throwIfNotFound: true);
        m_DolphinClassicController_Plus = m_DolphinClassicController.FindAction("Plus", throwIfNotFound: true);
        m_DolphinClassicController_Home = m_DolphinClassicController.FindAction("Home", throwIfNotFound: true);
        m_DolphinClassicController_DPadUp = m_DolphinClassicController.FindAction("D-Pad Up", throwIfNotFound: true);
        m_DolphinClassicController_DPadDown = m_DolphinClassicController.FindAction("D-Pad Down", throwIfNotFound: true);
        m_DolphinClassicController_DPadLeft = m_DolphinClassicController.FindAction("D-Pad Left", throwIfNotFound: true);
        m_DolphinClassicController_DPadRight = m_DolphinClassicController.FindAction("D-Pad Right", throwIfNotFound: true);
        m_DolphinClassicController_LeftStickX = m_DolphinClassicController.FindAction("Left Stick X", throwIfNotFound: true);
        m_DolphinClassicController_LeftStickY = m_DolphinClassicController.FindAction("Left Stick Y", throwIfNotFound: true);
        m_DolphinClassicController_RightStickX = m_DolphinClassicController.FindAction("Right Stick X", throwIfNotFound: true);
        m_DolphinClassicController_RightStickY = m_DolphinClassicController.FindAction("Right Stick Y", throwIfNotFound: true);
        // Dolphin/Hotkeys
        m_DolphinHotkeys = asset.FindActionMap("Dolphin/Hotkeys", throwIfNotFound: true);
        m_DolphinHotkeys_TogglePause = m_DolphinHotkeys.FindAction("Toggle Pause", throwIfNotFound: true);
        m_DolphinHotkeys_TakeScreenshot = m_DolphinHotkeys.FindAction("Take Screenshot", throwIfNotFound: true);
        m_DolphinHotkeys_SaveState = m_DolphinHotkeys.FindAction("Save State", throwIfNotFound: true);
        m_DolphinHotkeys_LoadState = m_DolphinHotkeys.FindAction("Load State", throwIfNotFound: true);
        m_DolphinHotkeys_DecreaseDepth = m_DolphinHotkeys.FindAction("Decrease Depth", throwIfNotFound: true);
        m_DolphinHotkeys_IncreaseDepth = m_DolphinHotkeys.FindAction("Increase Depth", throwIfNotFound: true);
        m_DolphinHotkeys_DecreaseConvergence = m_DolphinHotkeys.FindAction("Decrease Convergence", throwIfNotFound: true);
        m_DolphinHotkeys_IncreaseConvergence = m_DolphinHotkeys.FindAction("Increase Convergence", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Dolphin/GCPad
    private readonly InputActionMap m_DolphinGCPad;
    private IDolphinGCPadActions m_DolphinGCPadActionsCallbackInterface;
    private readonly InputAction m_DolphinGCPad_A;
    private readonly InputAction m_DolphinGCPad_B;
    private readonly InputAction m_DolphinGCPad_X;
    private readonly InputAction m_DolphinGCPad_Y;
    private readonly InputAction m_DolphinGCPad_Z;
    private readonly InputAction m_DolphinGCPad_Start;
    private readonly InputAction m_DolphinGCPad_MainStickX;
    private readonly InputAction m_DolphinGCPad_MainStickY;
    private readonly InputAction m_DolphinGCPad_CStickX;
    private readonly InputAction m_DolphinGCPad_CStickY;
    private readonly InputAction m_DolphinGCPad_LTrigger;
    private readonly InputAction m_DolphinGCPad_RTrigger;
    private readonly InputAction m_DolphinGCPad_DPadUp;
    private readonly InputAction m_DolphinGCPad_DPadDown;
    private readonly InputAction m_DolphinGCPad_DPadLeft;
    private readonly InputAction m_DolphinGCPad_DPadRight;
    public struct DolphinGCPadActions
    {
        private @DolphinControls m_Wrapper;
        public DolphinGCPadActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_DolphinGCPad_A;
        public InputAction @B => m_Wrapper.m_DolphinGCPad_B;
        public InputAction @X => m_Wrapper.m_DolphinGCPad_X;
        public InputAction @Y => m_Wrapper.m_DolphinGCPad_Y;
        public InputAction @Z => m_Wrapper.m_DolphinGCPad_Z;
        public InputAction @Start => m_Wrapper.m_DolphinGCPad_Start;
        public InputAction @MainStickX => m_Wrapper.m_DolphinGCPad_MainStickX;
        public InputAction @MainStickY => m_Wrapper.m_DolphinGCPad_MainStickY;
        public InputAction @CStickX => m_Wrapper.m_DolphinGCPad_CStickX;
        public InputAction @CStickY => m_Wrapper.m_DolphinGCPad_CStickY;
        public InputAction @LTrigger => m_Wrapper.m_DolphinGCPad_LTrigger;
        public InputAction @RTrigger => m_Wrapper.m_DolphinGCPad_RTrigger;
        public InputAction @DPadUp => m_Wrapper.m_DolphinGCPad_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_DolphinGCPad_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_DolphinGCPad_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_DolphinGCPad_DPadRight;
        public InputActionMap Get() { return m_Wrapper.m_DolphinGCPad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DolphinGCPadActions set) { return set.Get(); }
        public void SetCallbacks(IDolphinGCPadActions instance)
        {
            if (m_Wrapper.m_DolphinGCPadActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnB;
                @X.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnX;
                @Y.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnY;
                @Z.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnZ;
                @Z.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnZ;
                @Z.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnZ;
                @Start.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnStart;
                @MainStickX.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickX;
                @MainStickX.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickX;
                @MainStickX.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickX;
                @MainStickY.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickY;
                @MainStickY.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickY;
                @MainStickY.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnMainStickY;
                @CStickX.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickX;
                @CStickX.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickX;
                @CStickX.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickX;
                @CStickY.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickY;
                @CStickY.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickY;
                @CStickY.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnCStickY;
                @LTrigger.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnLTrigger;
                @LTrigger.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnLTrigger;
                @LTrigger.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnLTrigger;
                @RTrigger.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnRTrigger;
                @RTrigger.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnRTrigger;
                @RTrigger.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnRTrigger;
                @DPadUp.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_DolphinGCPadActionsCallbackInterface.OnDPadRight;
            }
            m_Wrapper.m_DolphinGCPadActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @Z.started += instance.OnZ;
                @Z.performed += instance.OnZ;
                @Z.canceled += instance.OnZ;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
                @MainStickX.started += instance.OnMainStickX;
                @MainStickX.performed += instance.OnMainStickX;
                @MainStickX.canceled += instance.OnMainStickX;
                @MainStickY.started += instance.OnMainStickY;
                @MainStickY.performed += instance.OnMainStickY;
                @MainStickY.canceled += instance.OnMainStickY;
                @CStickX.started += instance.OnCStickX;
                @CStickX.performed += instance.OnCStickX;
                @CStickX.canceled += instance.OnCStickX;
                @CStickY.started += instance.OnCStickY;
                @CStickY.performed += instance.OnCStickY;
                @CStickY.canceled += instance.OnCStickY;
                @LTrigger.started += instance.OnLTrigger;
                @LTrigger.performed += instance.OnLTrigger;
                @LTrigger.canceled += instance.OnLTrigger;
                @RTrigger.started += instance.OnRTrigger;
                @RTrigger.performed += instance.OnRTrigger;
                @RTrigger.canceled += instance.OnRTrigger;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
            }
        }
    }
    public DolphinGCPadActions @DolphinGCPad => new DolphinGCPadActions(this);

    // Dolphin/Wiimote
    private readonly InputActionMap m_DolphinWiimote;
    private IDolphinWiimoteActions m_DolphinWiimoteActionsCallbackInterface;
    private readonly InputAction m_DolphinWiimote_A;
    private readonly InputAction m_DolphinWiimote_B;
    private readonly InputAction m_DolphinWiimote_One;
    private readonly InputAction m_DolphinWiimote_Two;
    private readonly InputAction m_DolphinWiimote_Minus;
    private readonly InputAction m_DolphinWiimote_Plus;
    private readonly InputAction m_DolphinWiimote_Home;
    private readonly InputAction m_DolphinWiimote_AccelerometerX;
    private readonly InputAction m_DolphinWiimote_AccelerometerY;
    private readonly InputAction m_DolphinWiimote_AccelerometerZ;
    private readonly InputAction m_DolphinWiimote_GyroPitch;
    private readonly InputAction m_DolphinWiimote_GyroYaw;
    private readonly InputAction m_DolphinWiimote_GyroRoll;
    private readonly InputAction m_DolphinWiimote_DPadUp;
    private readonly InputAction m_DolphinWiimote_DPadDown;
    private readonly InputAction m_DolphinWiimote_DPadLeft;
    private readonly InputAction m_DolphinWiimote_DPadRight;
    private readonly InputAction m_DolphinWiimote_Recenter;
    private readonly InputAction m_DolphinWiimote_ShakeX;
    private readonly InputAction m_DolphinWiimote_ShakeY;
    private readonly InputAction m_DolphinWiimote_ShakeZ;
    public struct DolphinWiimoteActions
    {
        private @DolphinControls m_Wrapper;
        public DolphinWiimoteActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_DolphinWiimote_A;
        public InputAction @B => m_Wrapper.m_DolphinWiimote_B;
        public InputAction @One => m_Wrapper.m_DolphinWiimote_One;
        public InputAction @Two => m_Wrapper.m_DolphinWiimote_Two;
        public InputAction @Minus => m_Wrapper.m_DolphinWiimote_Minus;
        public InputAction @Plus => m_Wrapper.m_DolphinWiimote_Plus;
        public InputAction @Home => m_Wrapper.m_DolphinWiimote_Home;
        public InputAction @AccelerometerX => m_Wrapper.m_DolphinWiimote_AccelerometerX;
        public InputAction @AccelerometerY => m_Wrapper.m_DolphinWiimote_AccelerometerY;
        public InputAction @AccelerometerZ => m_Wrapper.m_DolphinWiimote_AccelerometerZ;
        public InputAction @GyroPitch => m_Wrapper.m_DolphinWiimote_GyroPitch;
        public InputAction @GyroYaw => m_Wrapper.m_DolphinWiimote_GyroYaw;
        public InputAction @GyroRoll => m_Wrapper.m_DolphinWiimote_GyroRoll;
        public InputAction @DPadUp => m_Wrapper.m_DolphinWiimote_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_DolphinWiimote_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_DolphinWiimote_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_DolphinWiimote_DPadRight;
        public InputAction @Recenter => m_Wrapper.m_DolphinWiimote_Recenter;
        public InputAction @ShakeX => m_Wrapper.m_DolphinWiimote_ShakeX;
        public InputAction @ShakeY => m_Wrapper.m_DolphinWiimote_ShakeY;
        public InputAction @ShakeZ => m_Wrapper.m_DolphinWiimote_ShakeZ;
        public InputActionMap Get() { return m_Wrapper.m_DolphinWiimote; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DolphinWiimoteActions set) { return set.Get(); }
        public void SetCallbacks(IDolphinWiimoteActions instance)
        {
            if (m_Wrapper.m_DolphinWiimoteActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnB;
                @One.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnOne;
                @One.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnOne;
                @One.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnOne;
                @Two.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnTwo;
                @Two.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnTwo;
                @Two.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnTwo;
                @Minus.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnMinus;
                @Minus.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnMinus;
                @Minus.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnMinus;
                @Plus.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnPlus;
                @Plus.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnPlus;
                @Plus.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnPlus;
                @Home.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnHome;
                @Home.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnHome;
                @Home.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnHome;
                @AccelerometerX.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerX.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerX.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerY.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerY.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerY.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerZ.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerZ;
                @AccelerometerZ.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerZ;
                @AccelerometerZ.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnAccelerometerZ;
                @GyroPitch.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroPitch;
                @GyroPitch.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroPitch;
                @GyroPitch.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroPitch;
                @GyroYaw.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroYaw;
                @GyroYaw.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroYaw;
                @GyroYaw.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroYaw;
                @GyroRoll.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroRoll;
                @GyroRoll.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroRoll;
                @GyroRoll.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnGyroRoll;
                @DPadUp.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnDPadRight;
                @Recenter.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnRecenter;
                @Recenter.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnRecenter;
                @Recenter.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnRecenter;
                @ShakeX.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeX;
                @ShakeX.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeX;
                @ShakeX.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeX;
                @ShakeY.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeY;
                @ShakeY.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeY;
                @ShakeY.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeY;
                @ShakeZ.started -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeZ;
                @ShakeZ.performed -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeZ;
                @ShakeZ.canceled -= m_Wrapper.m_DolphinWiimoteActionsCallbackInterface.OnShakeZ;
            }
            m_Wrapper.m_DolphinWiimoteActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @One.started += instance.OnOne;
                @One.performed += instance.OnOne;
                @One.canceled += instance.OnOne;
                @Two.started += instance.OnTwo;
                @Two.performed += instance.OnTwo;
                @Two.canceled += instance.OnTwo;
                @Minus.started += instance.OnMinus;
                @Minus.performed += instance.OnMinus;
                @Minus.canceled += instance.OnMinus;
                @Plus.started += instance.OnPlus;
                @Plus.performed += instance.OnPlus;
                @Plus.canceled += instance.OnPlus;
                @Home.started += instance.OnHome;
                @Home.performed += instance.OnHome;
                @Home.canceled += instance.OnHome;
                @AccelerometerX.started += instance.OnAccelerometerX;
                @AccelerometerX.performed += instance.OnAccelerometerX;
                @AccelerometerX.canceled += instance.OnAccelerometerX;
                @AccelerometerY.started += instance.OnAccelerometerY;
                @AccelerometerY.performed += instance.OnAccelerometerY;
                @AccelerometerY.canceled += instance.OnAccelerometerY;
                @AccelerometerZ.started += instance.OnAccelerometerZ;
                @AccelerometerZ.performed += instance.OnAccelerometerZ;
                @AccelerometerZ.canceled += instance.OnAccelerometerZ;
                @GyroPitch.started += instance.OnGyroPitch;
                @GyroPitch.performed += instance.OnGyroPitch;
                @GyroPitch.canceled += instance.OnGyroPitch;
                @GyroYaw.started += instance.OnGyroYaw;
                @GyroYaw.performed += instance.OnGyroYaw;
                @GyroYaw.canceled += instance.OnGyroYaw;
                @GyroRoll.started += instance.OnGyroRoll;
                @GyroRoll.performed += instance.OnGyroRoll;
                @GyroRoll.canceled += instance.OnGyroRoll;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
                @Recenter.started += instance.OnRecenter;
                @Recenter.performed += instance.OnRecenter;
                @Recenter.canceled += instance.OnRecenter;
                @ShakeX.started += instance.OnShakeX;
                @ShakeX.performed += instance.OnShakeX;
                @ShakeX.canceled += instance.OnShakeX;
                @ShakeY.started += instance.OnShakeY;
                @ShakeY.performed += instance.OnShakeY;
                @ShakeY.canceled += instance.OnShakeY;
                @ShakeZ.started += instance.OnShakeZ;
                @ShakeZ.performed += instance.OnShakeZ;
                @ShakeZ.canceled += instance.OnShakeZ;
            }
        }
    }
    public DolphinWiimoteActions @DolphinWiimote => new DolphinWiimoteActions(this);

    // Dolphin/Nunchuk
    private readonly InputActionMap m_DolphinNunchuk;
    private IDolphinNunchukActions m_DolphinNunchukActionsCallbackInterface;
    private readonly InputAction m_DolphinNunchuk_C;
    private readonly InputAction m_DolphinNunchuk_Z;
    private readonly InputAction m_DolphinNunchuk_StickX;
    private readonly InputAction m_DolphinNunchuk_StickY;
    private readonly InputAction m_DolphinNunchuk_AccelerometerX;
    private readonly InputAction m_DolphinNunchuk_AccelerometerY;
    private readonly InputAction m_DolphinNunchuk_AccelerometerZ;
    public struct DolphinNunchukActions
    {
        private @DolphinControls m_Wrapper;
        public DolphinNunchukActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @C => m_Wrapper.m_DolphinNunchuk_C;
        public InputAction @Z => m_Wrapper.m_DolphinNunchuk_Z;
        public InputAction @StickX => m_Wrapper.m_DolphinNunchuk_StickX;
        public InputAction @StickY => m_Wrapper.m_DolphinNunchuk_StickY;
        public InputAction @AccelerometerX => m_Wrapper.m_DolphinNunchuk_AccelerometerX;
        public InputAction @AccelerometerY => m_Wrapper.m_DolphinNunchuk_AccelerometerY;
        public InputAction @AccelerometerZ => m_Wrapper.m_DolphinNunchuk_AccelerometerZ;
        public InputActionMap Get() { return m_Wrapper.m_DolphinNunchuk; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DolphinNunchukActions set) { return set.Get(); }
        public void SetCallbacks(IDolphinNunchukActions instance)
        {
            if (m_Wrapper.m_DolphinNunchukActionsCallbackInterface != null)
            {
                @C.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnC;
                @C.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnC;
                @C.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnC;
                @Z.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnZ;
                @Z.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnZ;
                @Z.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnZ;
                @StickX.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickX;
                @StickX.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickX;
                @StickX.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickX;
                @StickY.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickY;
                @StickY.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickY;
                @StickY.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnStickY;
                @AccelerometerX.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerX.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerX.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerX;
                @AccelerometerY.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerY.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerY.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerY;
                @AccelerometerZ.started -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerZ;
                @AccelerometerZ.performed -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerZ;
                @AccelerometerZ.canceled -= m_Wrapper.m_DolphinNunchukActionsCallbackInterface.OnAccelerometerZ;
            }
            m_Wrapper.m_DolphinNunchukActionsCallbackInterface = instance;
            if (instance != null)
            {
                @C.started += instance.OnC;
                @C.performed += instance.OnC;
                @C.canceled += instance.OnC;
                @Z.started += instance.OnZ;
                @Z.performed += instance.OnZ;
                @Z.canceled += instance.OnZ;
                @StickX.started += instance.OnStickX;
                @StickX.performed += instance.OnStickX;
                @StickX.canceled += instance.OnStickX;
                @StickY.started += instance.OnStickY;
                @StickY.performed += instance.OnStickY;
                @StickY.canceled += instance.OnStickY;
                @AccelerometerX.started += instance.OnAccelerometerX;
                @AccelerometerX.performed += instance.OnAccelerometerX;
                @AccelerometerX.canceled += instance.OnAccelerometerX;
                @AccelerometerY.started += instance.OnAccelerometerY;
                @AccelerometerY.performed += instance.OnAccelerometerY;
                @AccelerometerY.canceled += instance.OnAccelerometerY;
                @AccelerometerZ.started += instance.OnAccelerometerZ;
                @AccelerometerZ.performed += instance.OnAccelerometerZ;
                @AccelerometerZ.canceled += instance.OnAccelerometerZ;
            }
        }
    }
    public DolphinNunchukActions @DolphinNunchuk => new DolphinNunchukActions(this);

    // Dolphin/ClassicController
    private readonly InputActionMap m_DolphinClassicController;
    private IDolphinClassicControllerActions m_DolphinClassicControllerActionsCallbackInterface;
    private readonly InputAction m_DolphinClassicController_A;
    private readonly InputAction m_DolphinClassicController_B;
    private readonly InputAction m_DolphinClassicController_X;
    private readonly InputAction m_DolphinClassicController_Y;
    private readonly InputAction m_DolphinClassicController_L;
    private readonly InputAction m_DolphinClassicController_R;
    private readonly InputAction m_DolphinClassicController_ZL;
    private readonly InputAction m_DolphinClassicController_ZR;
    private readonly InputAction m_DolphinClassicController_Minus;
    private readonly InputAction m_DolphinClassicController_Plus;
    private readonly InputAction m_DolphinClassicController_Home;
    private readonly InputAction m_DolphinClassicController_DPadUp;
    private readonly InputAction m_DolphinClassicController_DPadDown;
    private readonly InputAction m_DolphinClassicController_DPadLeft;
    private readonly InputAction m_DolphinClassicController_DPadRight;
    private readonly InputAction m_DolphinClassicController_LeftStickX;
    private readonly InputAction m_DolphinClassicController_LeftStickY;
    private readonly InputAction m_DolphinClassicController_RightStickX;
    private readonly InputAction m_DolphinClassicController_RightStickY;
    public struct DolphinClassicControllerActions
    {
        private @DolphinControls m_Wrapper;
        public DolphinClassicControllerActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_DolphinClassicController_A;
        public InputAction @B => m_Wrapper.m_DolphinClassicController_B;
        public InputAction @X => m_Wrapper.m_DolphinClassicController_X;
        public InputAction @Y => m_Wrapper.m_DolphinClassicController_Y;
        public InputAction @L => m_Wrapper.m_DolphinClassicController_L;
        public InputAction @R => m_Wrapper.m_DolphinClassicController_R;
        public InputAction @ZL => m_Wrapper.m_DolphinClassicController_ZL;
        public InputAction @ZR => m_Wrapper.m_DolphinClassicController_ZR;
        public InputAction @Minus => m_Wrapper.m_DolphinClassicController_Minus;
        public InputAction @Plus => m_Wrapper.m_DolphinClassicController_Plus;
        public InputAction @Home => m_Wrapper.m_DolphinClassicController_Home;
        public InputAction @DPadUp => m_Wrapper.m_DolphinClassicController_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_DolphinClassicController_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_DolphinClassicController_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_DolphinClassicController_DPadRight;
        public InputAction @LeftStickX => m_Wrapper.m_DolphinClassicController_LeftStickX;
        public InputAction @LeftStickY => m_Wrapper.m_DolphinClassicController_LeftStickY;
        public InputAction @RightStickX => m_Wrapper.m_DolphinClassicController_RightStickX;
        public InputAction @RightStickY => m_Wrapper.m_DolphinClassicController_RightStickY;
        public InputActionMap Get() { return m_Wrapper.m_DolphinClassicController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DolphinClassicControllerActions set) { return set.Get(); }
        public void SetCallbacks(IDolphinClassicControllerActions instance)
        {
            if (m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnB;
                @X.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnX;
                @Y.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnY;
                @L.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnL;
                @L.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnL;
                @L.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnL;
                @R.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnR;
                @R.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnR;
                @R.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnR;
                @ZL.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZL;
                @ZL.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZL;
                @ZL.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZL;
                @ZR.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZR;
                @ZR.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZR;
                @ZR.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnZR;
                @Minus.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnMinus;
                @Minus.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnMinus;
                @Minus.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnMinus;
                @Plus.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnPlus;
                @Plus.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnPlus;
                @Plus.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnPlus;
                @Home.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnHome;
                @Home.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnHome;
                @Home.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnHome;
                @DPadUp.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnDPadRight;
                @LeftStickX.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickX;
                @LeftStickX.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickX;
                @LeftStickX.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickX;
                @LeftStickY.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickY;
                @LeftStickY.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickY;
                @LeftStickY.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnLeftStickY;
                @RightStickX.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickX;
                @RightStickX.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickX;
                @RightStickX.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickX;
                @RightStickY.started -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickY;
                @RightStickY.performed -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickY;
                @RightStickY.canceled -= m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface.OnRightStickY;
            }
            m_Wrapper.m_DolphinClassicControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @L.started += instance.OnL;
                @L.performed += instance.OnL;
                @L.canceled += instance.OnL;
                @R.started += instance.OnR;
                @R.performed += instance.OnR;
                @R.canceled += instance.OnR;
                @ZL.started += instance.OnZL;
                @ZL.performed += instance.OnZL;
                @ZL.canceled += instance.OnZL;
                @ZR.started += instance.OnZR;
                @ZR.performed += instance.OnZR;
                @ZR.canceled += instance.OnZR;
                @Minus.started += instance.OnMinus;
                @Minus.performed += instance.OnMinus;
                @Minus.canceled += instance.OnMinus;
                @Plus.started += instance.OnPlus;
                @Plus.performed += instance.OnPlus;
                @Plus.canceled += instance.OnPlus;
                @Home.started += instance.OnHome;
                @Home.performed += instance.OnHome;
                @Home.canceled += instance.OnHome;
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
                @LeftStickX.started += instance.OnLeftStickX;
                @LeftStickX.performed += instance.OnLeftStickX;
                @LeftStickX.canceled += instance.OnLeftStickX;
                @LeftStickY.started += instance.OnLeftStickY;
                @LeftStickY.performed += instance.OnLeftStickY;
                @LeftStickY.canceled += instance.OnLeftStickY;
                @RightStickX.started += instance.OnRightStickX;
                @RightStickX.performed += instance.OnRightStickX;
                @RightStickX.canceled += instance.OnRightStickX;
                @RightStickY.started += instance.OnRightStickY;
                @RightStickY.performed += instance.OnRightStickY;
                @RightStickY.canceled += instance.OnRightStickY;
            }
        }
    }
    public DolphinClassicControllerActions @DolphinClassicController => new DolphinClassicControllerActions(this);

    // Dolphin/Hotkeys
    private readonly InputActionMap m_DolphinHotkeys;
    private IDolphinHotkeysActions m_DolphinHotkeysActionsCallbackInterface;
    private readonly InputAction m_DolphinHotkeys_TogglePause;
    private readonly InputAction m_DolphinHotkeys_TakeScreenshot;
    private readonly InputAction m_DolphinHotkeys_SaveState;
    private readonly InputAction m_DolphinHotkeys_LoadState;
    private readonly InputAction m_DolphinHotkeys_DecreaseDepth;
    private readonly InputAction m_DolphinHotkeys_IncreaseDepth;
    private readonly InputAction m_DolphinHotkeys_DecreaseConvergence;
    private readonly InputAction m_DolphinHotkeys_IncreaseConvergence;
    public struct DolphinHotkeysActions
    {
        private @DolphinControls m_Wrapper;
        public DolphinHotkeysActions(@DolphinControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePause => m_Wrapper.m_DolphinHotkeys_TogglePause;
        public InputAction @TakeScreenshot => m_Wrapper.m_DolphinHotkeys_TakeScreenshot;
        public InputAction @SaveState => m_Wrapper.m_DolphinHotkeys_SaveState;
        public InputAction @LoadState => m_Wrapper.m_DolphinHotkeys_LoadState;
        public InputAction @DecreaseDepth => m_Wrapper.m_DolphinHotkeys_DecreaseDepth;
        public InputAction @IncreaseDepth => m_Wrapper.m_DolphinHotkeys_IncreaseDepth;
        public InputAction @DecreaseConvergence => m_Wrapper.m_DolphinHotkeys_DecreaseConvergence;
        public InputAction @IncreaseConvergence => m_Wrapper.m_DolphinHotkeys_IncreaseConvergence;
        public InputActionMap Get() { return m_Wrapper.m_DolphinHotkeys; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DolphinHotkeysActions set) { return set.Get(); }
        public void SetCallbacks(IDolphinHotkeysActions instance)
        {
            if (m_Wrapper.m_DolphinHotkeysActionsCallbackInterface != null)
            {
                @TogglePause.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTogglePause;
                @TogglePause.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTogglePause;
                @TogglePause.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTogglePause;
                @TakeScreenshot.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTakeScreenshot;
                @TakeScreenshot.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTakeScreenshot;
                @TakeScreenshot.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnTakeScreenshot;
                @SaveState.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnSaveState;
                @SaveState.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnSaveState;
                @SaveState.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnSaveState;
                @LoadState.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnLoadState;
                @LoadState.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnLoadState;
                @LoadState.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnLoadState;
                @DecreaseDepth.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseDepth;
                @DecreaseDepth.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseDepth;
                @DecreaseDepth.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseDepth;
                @IncreaseDepth.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseDepth;
                @IncreaseDepth.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseDepth;
                @IncreaseDepth.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseDepth;
                @DecreaseConvergence.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseConvergence;
                @DecreaseConvergence.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseConvergence;
                @DecreaseConvergence.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnDecreaseConvergence;
                @IncreaseConvergence.started -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseConvergence;
                @IncreaseConvergence.performed -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseConvergence;
                @IncreaseConvergence.canceled -= m_Wrapper.m_DolphinHotkeysActionsCallbackInterface.OnIncreaseConvergence;
            }
            m_Wrapper.m_DolphinHotkeysActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePause.started += instance.OnTogglePause;
                @TogglePause.performed += instance.OnTogglePause;
                @TogglePause.canceled += instance.OnTogglePause;
                @TakeScreenshot.started += instance.OnTakeScreenshot;
                @TakeScreenshot.performed += instance.OnTakeScreenshot;
                @TakeScreenshot.canceled += instance.OnTakeScreenshot;
                @SaveState.started += instance.OnSaveState;
                @SaveState.performed += instance.OnSaveState;
                @SaveState.canceled += instance.OnSaveState;
                @LoadState.started += instance.OnLoadState;
                @LoadState.performed += instance.OnLoadState;
                @LoadState.canceled += instance.OnLoadState;
                @DecreaseDepth.started += instance.OnDecreaseDepth;
                @DecreaseDepth.performed += instance.OnDecreaseDepth;
                @DecreaseDepth.canceled += instance.OnDecreaseDepth;
                @IncreaseDepth.started += instance.OnIncreaseDepth;
                @IncreaseDepth.performed += instance.OnIncreaseDepth;
                @IncreaseDepth.canceled += instance.OnIncreaseDepth;
                @DecreaseConvergence.started += instance.OnDecreaseConvergence;
                @DecreaseConvergence.performed += instance.OnDecreaseConvergence;
                @DecreaseConvergence.canceled += instance.OnDecreaseConvergence;
                @IncreaseConvergence.started += instance.OnIncreaseConvergence;
                @IncreaseConvergence.performed += instance.OnIncreaseConvergence;
                @IncreaseConvergence.canceled += instance.OnIncreaseConvergence;
            }
        }
    }
    public DolphinHotkeysActions @DolphinHotkeys => new DolphinHotkeysActions(this);
    public interface IDolphinGCPadActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnZ(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
        void OnMainStickX(InputAction.CallbackContext context);
        void OnMainStickY(InputAction.CallbackContext context);
        void OnCStickX(InputAction.CallbackContext context);
        void OnCStickY(InputAction.CallbackContext context);
        void OnLTrigger(InputAction.CallbackContext context);
        void OnRTrigger(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
    }
    public interface IDolphinWiimoteActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnOne(InputAction.CallbackContext context);
        void OnTwo(InputAction.CallbackContext context);
        void OnMinus(InputAction.CallbackContext context);
        void OnPlus(InputAction.CallbackContext context);
        void OnHome(InputAction.CallbackContext context);
        void OnAccelerometerX(InputAction.CallbackContext context);
        void OnAccelerometerY(InputAction.CallbackContext context);
        void OnAccelerometerZ(InputAction.CallbackContext context);
        void OnGyroPitch(InputAction.CallbackContext context);
        void OnGyroYaw(InputAction.CallbackContext context);
        void OnGyroRoll(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
        void OnRecenter(InputAction.CallbackContext context);
        void OnShakeX(InputAction.CallbackContext context);
        void OnShakeY(InputAction.CallbackContext context);
        void OnShakeZ(InputAction.CallbackContext context);
    }
    public interface IDolphinNunchukActions
    {
        void OnC(InputAction.CallbackContext context);
        void OnZ(InputAction.CallbackContext context);
        void OnStickX(InputAction.CallbackContext context);
        void OnStickY(InputAction.CallbackContext context);
        void OnAccelerometerX(InputAction.CallbackContext context);
        void OnAccelerometerY(InputAction.CallbackContext context);
        void OnAccelerometerZ(InputAction.CallbackContext context);
    }
    public interface IDolphinClassicControllerActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnL(InputAction.CallbackContext context);
        void OnR(InputAction.CallbackContext context);
        void OnZL(InputAction.CallbackContext context);
        void OnZR(InputAction.CallbackContext context);
        void OnMinus(InputAction.CallbackContext context);
        void OnPlus(InputAction.CallbackContext context);
        void OnHome(InputAction.CallbackContext context);
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
        void OnLeftStickX(InputAction.CallbackContext context);
        void OnLeftStickY(InputAction.CallbackContext context);
        void OnRightStickX(InputAction.CallbackContext context);
        void OnRightStickY(InputAction.CallbackContext context);
    }
    public interface IDolphinHotkeysActions
    {
        void OnTogglePause(InputAction.CallbackContext context);
        void OnTakeScreenshot(InputAction.CallbackContext context);
        void OnSaveState(InputAction.CallbackContext context);
        void OnLoadState(InputAction.CallbackContext context);
        void OnDecreaseDepth(InputAction.CallbackContext context);
        void OnIncreaseDepth(InputAction.CallbackContext context);
        void OnDecreaseConvergence(InputAction.CallbackContext context);
        void OnIncreaseConvergence(InputAction.CallbackContext context);
    }
}
