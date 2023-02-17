using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameObject[] skins;
    private void Start()
    {
        string skinInUse = PlayerPrefs.GetString("SkinInUse");
        switch (skinInUse)
        {
            default:
                break;
            case "astronaut":
                skins[1].gameObject.SetActive(true);
                    break;
            case "homeless":
                skins[0].gameObject.SetActive(true);
                    break;
        }


    }
}
