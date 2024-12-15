using Nakaya.UI;
using UnityEngine;

public class SettingButton : CommonSelectableButton
{
    void Start()
    {
        AddPressAction(() => Debug.Log("Setting"));
    }
}
