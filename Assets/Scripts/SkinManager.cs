using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameObject[] skins;

    private const string CYCLIST= "cyclist";
    private const string ACTIONHERO= "actionHero";
    private const string EXPLORER= "explorer";
    private const string CONSTRUCTIONWORKER= "constructionWorker";
    private const string CLOWN= "clown";
    private const string ESKIMO ="eskimo";
    private const string FARMER= "farmer";
    private const string PARAMEDIC= "paramedic";
    private const string POLICE= "police";
    private const string BUSINESS= "business";
    private const string ASTRONAUT= "astronaut";
    private const string CLAUS= "claus";
    private const string COWBOY= "cowboy";
    private const string FIREFIGHTER= "fireFighter";
    private const string HAZARD= "hazard";
    private const string MECHANIC= "mechanic";
    private const string MUMMY ="mummy";
    private const string NAVALOFFICER= "navalOfficer";
    private const string PILOT ="pilot";
    private const string PIRATE="pirate";
    private const string RACEDRIVER= "raceDriver";
    private const string SKATE= "skate";
    private const string SKELETON ="skeleton";
    private const string SKIMAN ="skiMan";
    private const string SUPERHERO= "superHero";
    private const string VIKING= "viking";
    private const string WIZARD ="wizard";
    private const string YETI ="yeti";
    private const string ZOMBIE ="zombie";

    private const string SKININUSE = "SkinInUse";
    private void Start()
    {
        string skinInUse = PlayerPrefs.GetString(SKININUSE);
        switch (skinInUse)
        {
            default:
                break;
            case CYCLIST:
                skins[0].gameObject.SetActive(true);
                    break;
            case ACTIONHERO:
                skins[1].gameObject.SetActive(true);
                    break;
            case EXPLORER:
                skins[2].gameObject.SetActive(true);
                break;
            case CONSTRUCTIONWORKER:
                skins[3].gameObject.SetActive(true);
                break;
            case CLOWN:
                skins[4].gameObject.SetActive(true);
                break;
            case ESKIMO:
                skins[5].gameObject.SetActive(true);
                break;
            case FARMER:
                skins[6].gameObject.SetActive(true);
                break;
            case PARAMEDIC:
                skins[7].gameObject.SetActive(true);
                break;
            case POLICE:
                skins[8].gameObject.SetActive(true);
                break;
            case BUSINESS:
                skins[9].gameObject.SetActive(true);
                break;
            case ASTRONAUT:
                skins[10].gameObject.SetActive(true);
                break;
            case CLAUS:
                skins[11].gameObject.SetActive(true);
                break;
            case COWBOY:
                skins[12].gameObject.SetActive(true);
                break;
            case FIREFIGHTER:
                skins[13].gameObject.SetActive(true);
                break;
            case HAZARD:
                skins[14].gameObject.SetActive(true);
                break;
            case MECHANIC:
                skins[15].gameObject.SetActive(true);
                break;
            case MUMMY:
                skins[16].gameObject.SetActive(true);
                break;
            case NAVALOFFICER:
                skins[17].gameObject.SetActive(true);
                break;
            case PILOT:
                skins[18].gameObject.SetActive(true);
                break;
            case PIRATE:
                skins[19].gameObject.SetActive(true);
                break;
            case RACEDRIVER:
                skins[20].gameObject.SetActive(true);
                break;
            case SKATE:
                skins[21].gameObject.SetActive(true);
                break;
            case SKELETON:
                skins[22].gameObject.SetActive(true);
                break;
            case SKIMAN:
                skins[23].gameObject.SetActive(true);
                break;
            case SUPERHERO:
                skins[24].gameObject.SetActive(true);
                break;
            case VIKING:
                skins[25].gameObject.SetActive(true);
                break;
            case WIZARD:
                skins[26].gameObject.SetActive(true);
                break; 
            case YETI:
                skins[27].gameObject.SetActive(true);
                break;
            case ZOMBIE:
                skins[28].gameObject.SetActive(true);
                break;
        }


    }
}
