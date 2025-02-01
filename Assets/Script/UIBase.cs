using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public void SetActive(bool b) => gameObject.SetActive(b);
}
