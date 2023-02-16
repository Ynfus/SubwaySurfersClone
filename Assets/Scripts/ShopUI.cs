using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI astronautButtonText;
    [SerializeField] TextMeshProUGUI homelessButtonText;
    [SerializeField] Button buyAstronautButton;
    [SerializeField] Button buyHomelessButton;
    [SerializeField] TextMeshProUGUI coinsAmount;
    private string ownedSkinsString;
    private string skinInUse;
    private string[] ownedSkins;
    private const string ASTRONAUT = "astronaut";
    private const string HOMELESS = "homeless";
    private const int ASTRONAUT_PRICE = 10;
    private const int HOMELESS_PRICE = 20;

    private void Start()

    {
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        skinInUse = PlayerPrefs.GetString("SkinInUse");
        ownedSkinsString = PlayerPrefs.GetString("OwnedSkins");
        ownedSkins = ownedSkinsString.Split(',');

        if (ownedSkins.Contains(ASTRONAUT))
        {
            if (skinInUse == ASTRONAUT)
            {
                astronautButtonText.text = "In use";
                buyAstronautButton.interactable = false;
            }
            else
            {
                astronautButtonText.text = "Choose";
                buyAstronautButton.interactable = true;
            }
        }
        else
        {
            astronautButtonText.text = "Buy";
            buyAstronautButton.interactable = true;
        }

        if (ownedSkins.Contains(HOMELESS))
        {
            if (skinInUse == HOMELESS)
            {
                homelessButtonText.text = "In use";
                buyHomelessButton.interactable = false;
            }
            else
            {
                homelessButtonText.text = "Choose";
                buyHomelessButton.interactable = true;
            }
        }
        else
        {
            homelessButtonText.text = "Buy";
            buyHomelessButton.interactable = true;
        }
    }

    public void BuyAstronautSkin()
    {
        int coins = PlayerPrefs.GetInt("Coins");

        if (coins >= ASTRONAUT_PRICE)
        {
            coins -= ASTRONAUT_PRICE;
            PlayerPrefs.SetInt("Coins", coins);

            ownedSkinsString += "," + ASTRONAUT;
            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);

            UpdateButtons();
        }
    }

    public void BuyHomelessSkin()
    {
        int coins = PlayerPrefs.GetInt("Coins");

        if (coins >= HOMELESS_PRICE)
        {
            coins -= HOMELESS_PRICE;
            PlayerPrefs.SetInt("Coins", coins);

            ownedSkinsString += "," + HOMELESS;
            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);

            UpdateButtons();
        }
    }

    public void ChooseAstronautSkin()
    {
        PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
        UpdateButtons();
    }

    public void ChooseHomelessSkin()
    {
        PlayerPrefs.SetString("SkinInUse", HOMELESS);
        UpdateButtons();
    }
    //[SerializeField] TextMeshProUGUI astronautButtonText;
    //[SerializeField] TextMeshProUGUI homelessButtonText;
    //[SerializeField] TextMeshProUGUI coinsAmount;

    //private const string ASTRONAUT = "astronaut";
    //private const string HOMELESS = "homeless";

    //private void Start()
    //{

    //    string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT); // ustawienie domyœlnego skina w przypadku braku zapisu
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", ""); // ustawienie pustego stringa w przypadku braku zapisu
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    Dictionary<string, TextMeshProUGUI> buttonMap = new Dictionary<string, TextMeshProUGUI>()
    //{
    //    { ASTRONAUT, astronautButtonText },
    //    { HOMELESS, homelessButtonText }
    //};

    //    foreach (string skin in buttonMap.Keys)
    //    {
    //        if (ownedSkins.Contains(skin))
    //        {
    //            if (skin == skinInUse)
    //            {
    //                buttonMap[skin].text = "In use";
    //            }
    //            else
    //            {
    //                buttonMap[skin].text = "Choose";
    //            }
    //        }
    //        else
    //        {
    //            buttonMap[skin].text = "Unlock";
    //        }
    //    }
    //}
    //private void Update()
    //{
    //    coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    //}






}
