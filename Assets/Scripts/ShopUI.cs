using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] Button cyclistButton;
    [SerializeField] Button actionHeroButton;
    [SerializeField] Button explorerButton;
    [SerializeField] Button constructionWorkerButton;
    [SerializeField] Button clownButton;
    [SerializeField] Button eskimoButton;
    [SerializeField] Button farmerButton;
    [SerializeField] Button paramedicButton;
    [SerializeField] Button policeButton;
    [SerializeField] Button businessButton;
    [SerializeField] Button astronautButton;
    [SerializeField] Button clausButton;
    [SerializeField] Button cowboyButton;
    [SerializeField] Button firefighterButton;
    [SerializeField] Button hazardButton;
    [SerializeField] Button mechanicButton;
    [SerializeField] Button mummyButton;
    [SerializeField] Button navalOfficerButton;
    [SerializeField] Button pilotButton;
    [SerializeField] Button pirateButton;
    [SerializeField] Button raceDriverButton;
    [SerializeField] Button skateButton;
    [SerializeField] Button skeletonButton;
    [SerializeField] Button skiManButton;
    [SerializeField] Button superHeroButton;
    [SerializeField] Button vikingButton;
    [SerializeField] Button wizardButton;
    [SerializeField] Button yetiButton;
    [SerializeField] Button zombieButton;
   
    [SerializeField] Button backButton;

    [SerializeField] TextMeshProUGUI cyclistButtonText;
    [SerializeField] TextMeshProUGUI actionHeroButtonText;
    [SerializeField] TextMeshProUGUI explorerButtonText;
    [SerializeField] TextMeshProUGUI constructionWorkerButtonText;
    [SerializeField] TextMeshProUGUI clownButtonText;
    [SerializeField] TextMeshProUGUI eskimoButtonText;
    [SerializeField] TextMeshProUGUI farmerButtonText;
    [SerializeField] TextMeshProUGUI paramedicButtonText;
    [SerializeField] TextMeshProUGUI policeButtonText;
    [SerializeField] TextMeshProUGUI businessButtonText;
    [SerializeField] TextMeshProUGUI astronautButtonText;
    [SerializeField] TextMeshProUGUI clausButtonText;
    [SerializeField] TextMeshProUGUI cowboyButtonText;
    [SerializeField] TextMeshProUGUI firefighterButtonText;
    [SerializeField] TextMeshProUGUI hazardButtonText;
    [SerializeField] TextMeshProUGUI mechanicButtonText;
    [SerializeField] TextMeshProUGUI mummyButtonText;
    [SerializeField] TextMeshProUGUI navalOfficerButtonText;
    [SerializeField] TextMeshProUGUI pilotButtonText;
    [SerializeField] TextMeshProUGUI pirateButtonText;
    [SerializeField] TextMeshProUGUI raceDriverButtonText;
    [SerializeField] TextMeshProUGUI skateButtonText;
    [SerializeField] TextMeshProUGUI skeletonButtonText;
    [SerializeField] TextMeshProUGUI skiManButtonText;
    [SerializeField] TextMeshProUGUI superHeroButtonText;
    [SerializeField] TextMeshProUGUI vikingButtonText;
    [SerializeField] TextMeshProUGUI wizardButtonText;
    [SerializeField] TextMeshProUGUI yetiButtonText;
    [SerializeField] TextMeshProUGUI zombieButtonText;


    [SerializeField] TextMeshProUGUI coinsAmount;


    private const string CYCLIST = "cyclist";
    private const string ACTIONHERO = "actionHero";
    private const string EXPLORER = "explorer";
    private const string CONSTRUCTIONWORKER = "constructionWorker";
    private const string CLOWN = "clown";
    private const string ESKIMO = "eskimo";
    private const string FARMER = "farmer";
    private const string PARAMEDIC = "paramedic";
    private const string POLICE = "police";
    private const string BUSINESS = "business";
    private const string ASTRONAUT = "astronaut";
    private const string CLAUS = "claus";
    private const string COWBOY = "cowboy";
    private const string FIREFIGHTER = "fireFighter";
    private const string HAZARD = "hazard";
    private const string MECHANIC = "mechanic";
    private const string MUMMY = "mummy";
    private const string NAVALOFFICER = "navalOfficer";
    private const string PILOT = "pilot";
    private const string PIRATE = "pirate";
    private const string RACEDRIVER = "raceDriver";
    private const string SKATE = "skate";
    private const string SKELETON = "skeleton";
    private const string SKIMAN = "skiMan";
    private const string SUPERHERO = "superHero";
    private const string VIKING = "viking";
    private const string WIZARD = "wizard";
    private const string YETI = "yeti";
    private const string ZOMBIE = "zombie";

    struct Skin
    {
        public string name;
        public int cost;
        public Button button;
        public TextMeshProUGUI buttonText;
        public Skin(string name, int cost, Button button, TextMeshProUGUI buttonText)
        {
            this.name = name;
            this.cost = cost;
            this.button = button;
            this.buttonText = buttonText;
        }
    }
    private List<Skin> skins = new List<Skin>();


    private void Start()
    {
        skins.AddRange(new List<Skin> {
            new Skin(CYCLIST, 10, cyclistButton, cyclistButtonText),
            new Skin(ACTIONHERO, 10, actionHeroButton, actionHeroButtonText),
            new Skin(EXPLORER, 10, explorerButton, explorerButtonText),
            new Skin(CONSTRUCTIONWORKER, 10, constructionWorkerButton, constructionWorkerButtonText),
            new Skin( CLOWN,10, clownButton, clownButtonText),
            new Skin(ESKIMO, 10, eskimoButton, eskimoButtonText),
            new Skin(FARMER, 10, farmerButton, farmerButtonText),
            new Skin(PARAMEDIC, 10, paramedicButton, paramedicButtonText),
            new Skin(POLICE, 10, policeButton, policeButtonText),
            new Skin(BUSINESS, 10, businessButton, businessButtonText),
            new Skin(ASTRONAUT, 10, astronautButton, astronautButtonText),
            new Skin( CLAUS,10, clausButton, clausButtonText),
            new Skin(COWBOY, 10, cowboyButton, cowboyButtonText),
            new Skin(FIREFIGHTER, 10, firefighterButton, firefighterButtonText),
            new Skin(HAZARD, 10, hazardButton, hazardButtonText),
            new Skin(MECHANIC, 10, mechanicButton, mechanicButtonText),
            new Skin( MUMMY,10, mummyButton, mummyButtonText),
            new Skin(NAVALOFFICER, 10, navalOfficerButton, navalOfficerButtonText),
            new Skin(PILOT, 10, pilotButton, pilotButtonText),
            new Skin(PIRATE, 10, pirateButton, pirateButtonText),
            new Skin(RACEDRIVER, 10, raceDriverButton, raceDriverButtonText),
            new Skin( SKATE, 10, skateButton, skateButtonText),
            new Skin(SKELETON, 10, skeletonButton, skeletonButtonText),
            new Skin(SKIMAN, 10, skiManButton, skiManButtonText),
            new Skin(SUPERHERO, 10, superHeroButton, superHeroButtonText),
            new Skin(VIKING, 10, vikingButton, vikingButtonText),
            new Skin(WIZARD, 10, wizardButton, wizardButtonText),
            new Skin(YETI,10, yetiButton, yetiButtonText),
            new Skin(ZOMBIE, 10, zombieButton, zombieButtonText),

        });
        //PlayerPrefs.DeleteKey("OwnedSkins");
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        foreach (Skin skin in skins)
        {
            skin.button.onClick.AddListener(() => BuySkin(skin));
        }
        backButton.onClick.AddListener(() => GoBack());
        UpdateSkinButtons();
    }
    private void GoBack()
    { 
        gameObject.SetActive(false);
    
    }
    private void BuySkin(Skin skin)
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');
        if (!ownedSkins.Contains(skin.name))
        {
            if (coins >= skin.cost)
            {
                coins -= skin.cost;

                ownedSkinsString = ownedSkinsString + skin.name + ",";
                PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);
            }
            else
            {
                // Not enough coins
                return;
            }
        }

        PlayerPrefs.SetString("SkinInUse", skin.name);
        PlayerPrefs.SetInt("Coins", coins);
        UpdateSkinButtons();
    }
    private void UpdateSkinButtons()
    {
        string skinInUse = PlayerPrefs.GetString("SkinInUse",CYCLIST);
        string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
        string[] ownedSkins = ownedSkinsString.Split(',');

        foreach (Skin skin in skins)
        {
            if (ownedSkins.Contains(skin.name))
            {
                if (skin.name == skinInUse)
                {
                    skin.buttonText.text = "In use";
                }
                else
                {
                    skin.buttonText.text = "Choose";
                }
            }
            else
            {
                skin.buttonText.text = "Unlock for: " + skin.cost.ToString();
            }
        }

    }








    //private void Start()
    //{
    //    PlayerPrefs.DeleteKey("OwnedSkins");
    //    UpdateSkinButtons();
    //    astronautButton.onClick.AddListener(BuyAstronautSkin);
    //    homelessButton.onClick.AddListener(BuyHomelessSkin);
    //    cyclistButton.onClick.AddListener(BuyCyclistSkin);
    //    //astronautButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectAstronautSkin);
    //    //homelessButtonText.transform.parent.GetComponent<Button>().onClick.AddListener(SelectHomelessSkin);
    //}

    //private void UpdateSkinButtons()
    //{
    //    string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    Dictionary<string, (TextMeshProUGUI, int)> buttonMap = new Dictionary<string, (TextMeshProUGUI, int)>()
    //{
    //    { ASTRONAUT, (astronautButtonText, ASTRONAUT_COST) },
    //    { HOMELESS, (homelessButtonText, HOMELESS_COST) },
    //    { CYCLIST,(cyclistButtonText, CYCLIST_COST)}
    //};
    //    coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    //    foreach (string skin in buttonMap.Keys)
    //    {
    //        if (ownedSkins.Contains(skin))
    //        {
    //            if (skin == skinInUse)
    //            {
    //                buttonMap[skin].Item1.text = "In use";
    //            }
    //            else
    //            {
    //                buttonMap[skin].Item1.text = "Choose";
    //            }
    //        }
    //        else
    //        {
    //            buttonMap[skin].Item1.text = "Unlock for: " + buttonMap[skin].Item2.ToString();
    //        }
    //    }
    //}

    //private void BuyAstronautSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(ASTRONAUT))
    //    {
    //        if (coins >= ASTRONAUT_COST)
    //        {
    //            coins -= ASTRONAUT_COST;




    //            ownedSkinsString = ownedSkinsString + ASTRONAUT + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //        UpdateSkinButtons();
    //    }
    //}
    //private void BuyCyclistSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(CYCLIST))
    //    {
    //        if (coins >= CYCLIST_COST)
    //        {
    //            coins -= CYCLIST_COST;




    //            ownedSkinsString = ownedSkinsString + CYCLIST + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", CYCLIST);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", CYCLIST);
    //        UpdateSkinButtons();
    //    }
    //}

    //private void BuyHomelessSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(HOMELESS))
    //    {
    //        if (coins >= HOMELESS_COST)
    //        {
    //            coins -= HOMELESS_COST;




    //            ownedSkinsString = ownedSkinsString + HOMELESS + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //            PlayerPrefs.SetInt("Coins", coins);
    //            UpdateSkinButtons();

    //        }
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //        UpdateSkinButtons();
    //    }
    //}





























































    //private void BuyAstronautSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(ASTRONAUT))
    //    {
    //        if (coins >= 50)
    //        {
    //            coins -= 50;




    //            ownedSkinsString = ownedSkinsString + ASTRONAUT + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            PlayerPrefs.SetInt("Coins", coins);
    //        }
    //    }
    //}

    //private void BuyHomelessSkin()
    //{
    //    int coins = PlayerPrefs.GetInt("Coins", 0);
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');
    //    if (!ownedSkins.Contains(HOMELESS))
    //    {
    //        if (coins >= 100)
    //        {
    //            coins -= 100;




    //            ownedSkinsString = ownedSkinsString + HOMELESS + ",";
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);


    //            PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //            PlayerPrefs.SetInt("Coins", coins);
    //        }
    //    }
    //}
    //public void SelectAstronautSkin()
    //{
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", ""); 
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    if (ownedSkins.Contains(ASTRONAUT))
    //    {
    //        PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //        UpdateSkinButtons(); 
    //    }
    //    else
    //    {
    //        int coins = PlayerPrefs.GetInt("Coins", 0);
    //        if (coins >= ASTRONAUT_COST)
    //        {
    //            coins -= ASTRONAUT_COST;
    //            PlayerPrefs.SetInt("Coins", coins); 
    //            ownedSkinsString += (ownedSkinsString == "" ? "" : ",") + ASTRONAUT; 
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString);
    //            PlayerPrefs.SetString("SkinInUse", ASTRONAUT);
    //            UpdateSkinButtons(); 
    //            coinsAmount.text = coins.ToString();
    //        }
    //        else
    //        {
    //            Debug.Log("Not enough coins to buy skin");
    //        }
    //    }
    //}

    //public void SelectHomelessSkin()
    //{
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", "");
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    if (ownedSkins.Contains(HOMELESS))
    //    {
    //        PlayerPrefs.SetString("SkinInUse", HOMELESS);
    //        UpdateSkinButtons();
    //    }
    //    else
    //    {
    //        int coins = PlayerPrefs.GetInt("Coins", 0);
    //        if (coins >= HOMELESS_COST)
    //        {
    //            coins -= HOMELESS_COST;
    //            PlayerPrefs.SetInt("Coins", coins); 
    //            ownedSkinsString += (ownedSkinsString == "" ? "" : ",") + HOMELESS; 
    //            PlayerPrefs.SetString("OwnedSkins", ownedSkinsString); 
    //            PlayerPrefs.SetString("SkinInUse", HOMELESS); 
    //            UpdateSkinButtons(); 
    //            coinsAmount.text = coins.ToString(); 
    //        }
    //        else
    //        {
    //            Debug.Log("Not enough coins to buy skin");
    //        }
    //    }
    //}

    /////////////////////////////////////////////////////////////////////
    //[SerializeField] TextMeshProUGUI homelessButtonText;
    //    [SerializeField] TextMeshProUGUI coinsAmount;

    //private const string ASTRONAUT = "astronaut";
    //private const string HOMELESS = "homeless";

    //private void Start()
    //{

    //    string skinInUse = PlayerPrefs.GetString("SkinInUse", ASTRONAUT); // ustawienie domyœlnego skina w przypadku braku zapisu
    //    string ownedSkinsString = PlayerPrefs.GetString("OwnedSkins", ""); // ustawienie pustego stringa w przypadku braku zapisu
    //    string[] ownedSkins = ownedSkinsString.Split(',');

    //    Dictionary<string, TextMeshProUGUI> buttonMap = new Dictionary<string, TextMeshProUGUI>()
    //    {
    //        { ASTRONAUT, astronautButtonText },
    //        { HOMELESS, homelessButtonText }
    //    };

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
