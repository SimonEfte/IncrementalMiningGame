using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

public class LocalizationScript : MonoBehaviour
{
    public LevelMechanics levelScript;
    public TheAnvil theAnvilScript;

    public static string languageName;

    public TextMeshProUGUI skillTreeName_text, skillTreeDesc_text, skillTreePrice_text, skillTreePurchased_text;

    public AudioManager audioManager;

    private void Awake()
    {
        languageChosen = PlayerPrefs.GetInt("language");

        if (!PlayerPrefs.HasKey("language"))
        {
            CultureInfo userCulture = CultureInfo.CurrentCulture;
            RegionInfo region = new RegionInfo(userCulture.Name);

            // Use the region name to set the language
            string regionName = region.Name;

            SetLanguageByRegion(regionName);
        }
        else
        {
            ChooseLanguage(false);
        }
    }

    #region Check country
    void SetLanguageByRegion(string regionName)
    {
        switch (regionName)
        {
            case "US": // English (United States)
            case "CA": // English (Canada)
                languageChosen = 1;
                ChooseLanguage(false);
                break;

            case "FR": // French
                languageChosen = 2;
                ChooseLanguage(false);
                break;

            case "IT": // Italian
                languageChosen = 3;
                ChooseLanguage(false);
                break;

            case "DE": //German
                languageChosen = 4;
                ChooseLanguage(false);
                break;

            case "ES": // Spanish
                languageChosen = 5;
                ChooseLanguage(false);
                break;

            case "JP": // Japanese
                languageChosen = 6;
                ChooseLanguage(false);
                break;

            case "KR": // Korean
                languageChosen = 7;
                ChooseLanguage(false);
                break;

            case "PL": // Polish
                languageChosen = 8;
                ChooseLanguage(false);
                break;

            case "PT": // Portuguese
            case "BR": // Portuguese (Brazil)
                languageChosen = 9;
                ChooseLanguage(false);
                break;

            case "RU": // Russian
                languageChosen = 10;
                ChooseLanguage(false);
                break;

            case "CN": // Simplified Chinese
                languageChosen = 11;
                ChooseLanguage(false);
                break;

            default: // Fallback to English
                languageChosen = 1;
                ChooseLanguage(false);
                break;
        }
    }
    #endregion

    public static bool isEnglish, isFrench, isItalian, isGerman, isSpanish, isJapanese, isKorean, isPolish, isPortugese, isRussian, isSimplefiedChinese;
    public static int languageChosen;

    public GameObject englishFlag, frenchFlag, italianFlag, germanFlag, spanishFlag, japaneseFlag, koreanFlag, polishFlag, portugeseFlag, russianFlag, simplefiedChineseFlag;

    public void ChooseLanguage(bool changeLanguage)
    {
        englishFlag.SetActive(false); frenchFlag.SetActive(false); italianFlag.SetActive(false); germanFlag.SetActive(false);
        spanishFlag.SetActive(false); japaneseFlag.SetActive(false); koreanFlag.SetActive(false); polishFlag.SetActive(false);
        portugeseFlag.SetActive(false); russianFlag.SetActive(false); simplefiedChineseFlag.SetActive(false);

        isEnglish = false; isFrench = false; isItalian = false; isGerman = false; isSpanish = false; isJapanese = false; isKorean = false; isPolish = false; isPortugese = false; isRussian = false; isSimplefiedChinese = false;

        if(changeLanguage == true)
        {
            languageChosen += 1;
            audioManager.Play("UI_Click1");
        }

        if (languageChosen == 1) { isEnglish = true; englishFlag.SetActive(true); englishFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 2) { isFrench = true; frenchFlag.SetActive(true); frenchFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 3) { isItalian = true; italianFlag.SetActive(true); italianFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 4) { isGerman = true; germanFlag.SetActive(true); germanFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 5) { isSpanish = true; spanishFlag.SetActive(true); spanishFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 6) { isJapanese = true; japaneseFlag.SetActive(true); japaneseFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 7) { isKorean = true; koreanFlag.SetActive(true); koreanFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 8) { isPolish = true; polishFlag.SetActive(true); polishFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 9) { isPortugese = true; portugeseFlag.SetActive(true); portugeseFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 10) { isRussian = true; russianFlag.SetActive(true); russianFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 11) { isSimplefiedChinese = true; simplefiedChineseFlag.SetActive(true); simplefiedChineseFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        if (languageChosen == 12) { languageChosen = 1; isEnglish = true; englishFlag.SetActive(true); englishFlag.GetComponent<Button>().onClick.Invoke(); PlayerPrefs.SetInt("language", languageChosen); }
        NoChangeStrings();

        levelScript.SetSignText();
        levelScript.SetTalentTexts();

        for (int i = 0; i < 21; i++)
        {
            TalentTexts(i);
        }

        SetOtherTexts();
        TutText();
        EndingTexts();
        StatsText();
        TalentCardsLeftText();
        TheMineTexts(true);
        TheMineTexts(false);

        theAnvilScript.CheckSkin();
        theAnvilScript.CheckPickaxes();
        theAnvilScript.CheckPickaxeName();
    }

    public static double currentHoverPrice;
    public static int currentPurchaseCount, currentTotalPurchaseCount;

    public void SetSkillTreeTexts(string upgradeName, int upgradeType, double upgradePrice, int purchaseCount, int totalPurchaseCount)
    {
        currentHoverPrice = upgradePrice;

        if (currentHoverPrice % 1 != 0)  // Check if there's a decimal part
        {
            if (currentHoverPrice % 1 >= 0.5)
            {
                currentHoverPrice = Math.Ceiling(currentHoverPrice);  // Round up if decimal part >= 0.5
            }
            else
            {
                currentHoverPrice = Math.Floor(currentHoverPrice);  // Round down if decimal part < 0.5
            }
        }

        currentPurchaseCount = purchaseCount;
        currentTotalPurchaseCount = totalPurchaseCount;

        SkillTreeText(upgradeName, upgradeType, currentHoverPrice, purchaseCount, totalPurchaseCount);
    }

    #region Set no change strings
    public static string pickaxe1_name, pickaxe2_name, pickaxe3_name, pickaxe4_name,pickaxe5_name, pickaxe6_name, pickaxe7_name, pickaxe8_name,pickaxe9_name, pickaxe10_name, pickaxe11_name, pickaxe12_name, pickaxe13_name, pickaxe14_name;

    public static string rolled, oresTripled;
    public static string price, talentLevel, durability, levelUp;
    public static string skin;
    public static string artifactFound, horn, device, bone, meteorite, book, sack, goldRing, royalRing, dice, cheese, wolf, axe, runestone, skull;
    public static string crafting;

    public TextMeshProUGUI cost;
    public TextMeshProUGUI artifactBuffTooltip;

    public static string closeString;
    public TextMeshProUGUI purchaseText, skillTreeClose, talentClose, talentLevelClose, theMineInfoClose, artifactClose;

    public void NoChangeStrings()
    {
        #region English
        if(isEnglish == true)
        {
            closeString = "CLOSE";
            purchaseText.text = "PURCHASE";

            cost.text = "Cost:";
            artifactBuffTooltip.text = "Artifact buff:";

            pickaxe1_name = "Mr. Rusty";
            pickaxe2_name = "Sir. Goldy";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Old Reliable";
            pickaxe5_name = "The Opulaxe";
            pickaxe6_name = "Stonesplitter";
            pickaxe7_name = "Dagger-Pick";
            pickaxe8_name = "Uranium Fever";
            pickaxe9_name = "Forgeborn ";
            pickaxe10_name = "Crimson Sovereign";
            pickaxe11_name = "The Gemcutter";
            pickaxe12_name = "Kings Companion";
            pickaxe13_name = "The Crusher";
            pickaxe14_name = "Diamond Pickaxe";

            rolled = "Rolled:";
            oresTripled = "Ores multiplied X5!";

            price = "Price:";

            talentLevel = "Talent level:";
            durability = "Durability";
            levelUp = "LEVEL UP!";

            skin = "SKIN ";

            artifactFound = "Artifact found!";
            horn = "Ox Horn";
            device = "Ancient Device";
            bone = "Fossilized Bone";
            meteorite = "Meteorite Ore";
            book = "Magic Book";
            sack = "Sack of Gold";
            goldRing = "Gold Ring";
            royalRing = "Royal Ring";
            dice = "Ancient Dice";
            cheese = "Holy Cheese";
            wolf = "Wolf Claw";
            axe = "Warrior's Axe";
            runestone = "Runestone";
            skull = "Warrior's Skull";

            crafting = "Crafting";
        }
        #endregion

        #region French
        if (isFrench == true)
        {
            closeString = "FERMER";
            purchaseText.text = "ACHETER";

            cost.text = "Cost:";

            artifactBuffTooltip.text = "Bonus de l'artéfact :";

            pickaxe1_name = "Mr. Rouillé";
            pickaxe2_name = "Sir Doré";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Vieux Fiable";
            pickaxe5_name = "L’Opulaxe";
            pickaxe6_name = "Brise-Pierre";
            pickaxe7_name = "Dague-Pic";
            pickaxe8_name = "Fièvre d’Uranium";
            pickaxe9_name = "Forge-né";
            pickaxe10_name = "Souverain Cramoisi";
            pickaxe11_name = "Le Tailleur de Gemmes";
            pickaxe12_name = "Compagnon du Roi";
            pickaxe13_name = "Le Broyeur";
            pickaxe14_name = "Pioche en Diamant";

            rolled = "Lancé :";
            oresTripled = "Minerais multipliés par 5 !";

            price = "Prix :";

            talentLevel = "Niveau de talent :";
            durability = "Durabilité";
            levelUp = "NIVEAU SUPÉRIEUR !";

            skin = "SKIN ";

            artifactFound = "Artefact trouvé !";
            horn = "Corne de Bœuf";
            device = "Ancien Dispositif";
            bone = "Os Fossilisé";
            meteorite = "Minerai de Météorite";
            book = "Livre Magique";
            sack = "Sac d’Or";
            goldRing = "Anneau d’Or";
            royalRing = "Anneau Royal";
            dice = "Dés Anciens";
            cheese = "Fromage Sacré";
            wolf = "Griffe de Loup";
            axe = "Hache de Guerrier";
            runestone = "Rune";
            skull = "Crâne de Guerrier";

            crafting = "Fabrication";
        }
        #endregion

        #region Italian
        if (isItalian == true)
        {
            closeString = "CHIUDI";
            purchaseText.text = "ACQUISTA";

            cost.text = "Costo:";
            artifactBuffTooltip.text = "Bonus dell'artefatto:";

            pickaxe1_name = "Mr. Arrugginito";
            pickaxe2_name = "Sir Dorato";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Vecchio Fedele";
            pickaxe5_name = "L’Opulazza";
            pickaxe6_name = "Spaccapietre";
            pickaxe7_name = "Pico-Pugnale";
            pickaxe8_name = "Febbre da Uranio";
            pickaxe9_name = "Forgiato";
            pickaxe10_name = "Sovrano Cremisi";
            pickaxe11_name = "Tagliagemme";
            pickaxe12_name = "Compagno del Re";
            pickaxe13_name = "Il Frantumatore";
            pickaxe14_name = "Piccone di Diamante";

            rolled = "Lanciato:";
            oresTripled = "Minerali moltiplicati per 5!";

            price = "Prezzo:";

            talentLevel = "Livello talento:";
            durability = "Durabilità";
            levelUp = "LIVELLO SUPERIORE!";

            skin = "SKIN ";

            artifactFound = "Artefatto trovato!";
            horn = "Corno di Bue";
            device = "Dispositivo Antico";
            bone = "Osso Fossilizzato";
            meteorite = "Minerale di Meteorite";
            book = "Libro Magico";
            sack = "Sacco d’Oro";
            goldRing = "Anello d’Oro";
            royalRing = "Anello Reale";
            dice = "Dadi Antichi";
            cheese = "Formaggio Sacro";
            wolf = "Artiglio di Lupo";
            axe = "Ascia del Guerriero";
            runestone = "Pietra Runica";
            skull = "Teschio del Guerriero";

            crafting = "Creazione";
        }
        #endregion

        #region German
        if (isGerman == true)
        {
            closeString = "SCHLIESSEN";
            purchaseText.text = "KAUFEN";

            cost.text = "Kosten:";
            artifactBuffTooltip.text = "Artefakt-Bonus:";

            pickaxe1_name = "Mr. Rostig";
            pickaxe2_name = "Sir Goldig";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Alter Zuverlässiger";
            pickaxe5_name = "Die Opulaxe";
            pickaxe6_name = "Steinspalter";
            pickaxe7_name = "Dolch-Pick";
            pickaxe8_name = "Uran-Fieber";
            pickaxe9_name = "Schmiedgeboren";
            pickaxe10_name = "Purpurner Souverän";
            pickaxe11_name = "Der Edelsteinschneider";
            pickaxe12_name = "Königsgefährte";
            pickaxe13_name = "Der Zermalmer";
            pickaxe14_name = "Diamantspitzhacke";

            rolled = "Gewürfelt:";
            oresTripled = "Erze mit 5X multipliziert!";

            price = "Preis:";

            talentLevel = "Talentstufe:";
            durability = "Haltbarkeit";
            levelUp = "LEVEL AUF!";

            skin = "SKIN ";

            artifactFound = "Artefakt gefunden!";
            horn = "Ochsenhorn";
            device = "Antikes Gerät";
            bone = "Fossilisierter Knochen";
            meteorite = "Meteoriterz";
            book = "Magisches Buch";
            sack = "Goldsack";
            goldRing = "Goldring";
            royalRing = "Königsring";
            dice = "Antike Würfel";
            cheese = "Heiliger Käse";
            wolf = "Wolfsklaue";
            axe = "Kriegeraxt";
            runestone = "Runenstein";
            skull = "Kriegerschädel";

            crafting = "Herstellung";
        }
        #endregion

        #region Spanish
        if (isSpanish == true)
        {
            closeString = "CERRAR";
            purchaseText.text = "COMPRAR";

            cost.text = "Costo:";
            artifactBuffTooltip.text = "Mejora del artefacto:";

            pickaxe1_name = "Sr. Oxidado";
            pickaxe2_name = "Sir Dorado";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Viejo Fiel";
            pickaxe5_name = "La Opulacha";
            pickaxe6_name = "Partedor de Piedra";
            pickaxe7_name = "Pico-Daga";
            pickaxe8_name = "Fiebre de Uranio";
            pickaxe9_name = "Forjado";
            pickaxe10_name = "Soberano Carmesí";
            pickaxe11_name = "El Tallador de Gemas";
            pickaxe12_name = "Compañero del Rey";
            pickaxe13_name = "El Triturador";
            pickaxe14_name = "Pico de Diamante";

            rolled = "Lanzado:";
            oresTripled = "¡Minerales multiplicados por 5!";

            price = "Precio:";

            talentLevel = "Nivel de talento:";
            durability = "Durabilidad";
            levelUp = "¡SUBIR DE NIVEL!";

            skin = "SKIN ";

            artifactFound = "¡Artefacto encontrado!";
            horn = "Cuerno de Buey";
            device = "Dispositivo Antiguo";
            bone = "Hueso Fosilizado";
            meteorite = "Mineral de Meteorito";
            book = "Libro Mágico";
            sack = "Saco de Oro";
            goldRing = "Anillo de Oro";
            royalRing = "Anillo Real";
            dice = "Dados Antiguos";
            cheese = "Queso Sagrado";
            wolf = "Garra de Lobo";
            axe = "Hacha del Guerrero";
            runestone = "Piedra Rúnica";
            skull = "Calavera de Guerrero";

            crafting = "Fabricación";
        }
        #endregion

        #region Japanese
        if (isJapanese == true)
        {
            closeString = "閉じる";
            purchaseText.text = "購入";

            cost.text = "コスト：";
            artifactBuffTooltip.text = "アーティファクト効果:";

            pickaxe1_name = "ミスターラスティ";
            pickaxe2_name = "サー・ゴールディ";
            pickaxe3_name = "ロイヤルピック";
            pickaxe4_name = "オールドリライアブル";
            pickaxe5_name = "オプラックス";
            pickaxe6_name = "ストーンスプリッター";
            pickaxe7_name = "ダガーピック";
            pickaxe8_name = "ウラン熱";
            pickaxe9_name = "フォージボーン";
            pickaxe10_name = "クリムゾン・ソブリン";
            pickaxe11_name = "ジェムカッター";
            pickaxe12_name = "キングズコンパニオン";
            pickaxe13_name = "ザ・クラッシャー";
            pickaxe14_name = "ダイヤモンドピッケル";

            rolled = "結果：";
            oresTripled = "鉱石が5倍！";

            price = "価格：";

            talentLevel = "才能レベル：";
            durability = "耐久度";
            levelUp = "レベルアップ！";

            skin = "スキン ";

            artifactFound = "アーティファクト発見！";
            horn = "牛の角";
            device = "古代の装置";
            bone = "化石化した骨";
            meteorite = "隕石鉱石";
            book = "魔法の書";
            sack = "金の袋";
            goldRing = "金の指輪";
            royalRing = "王家の指輪";
            dice = "古代のサイコロ";
            cheese = "神聖なチーズ";
            wolf = "狼の爪";
            axe = "戦士の斧";
            runestone = "ルーン石";
            skull = "戦士の頭蓋骨";

            crafting = "クラフト";
        }
        #endregion

        #region Korean
        if (isKorean == true)
        {
            closeString = "닫기";
            purchaseText.text = "구매";

            cost.text = "비용:";
            artifactBuffTooltip.text = "아티팩트 버프:";

            pickaxe1_name = "미스터 러스티";
            pickaxe2_name = "서 골디";
            pickaxe3_name = "로얄-픽";
            pickaxe4_name = "올드 리라이어블";
            pickaxe5_name = "오풀랙스";
            pickaxe6_name = "스톤스플리터";
            pickaxe7_name = "대거-픽";
            pickaxe8_name = "우라늄 열풍";
            pickaxe9_name = "포지본";
            pickaxe10_name = "크림슨 소버린";
            pickaxe11_name = "젬커터";
            pickaxe12_name = "왕의 동료";
            pickaxe13_name = "더 크러셔";
            pickaxe14_name = "다이아몬드 곡괭이";

            rolled = "굴림:";
            oresTripled = "광물이 5배로 증가!";

            price = "가격:";

            talentLevel = "특성 레벨:";
            durability = "내구도";
            levelUp = "레벨 업!";

            skin = "스킨 ";

            artifactFound = "유물 발견!";
            horn = "황소 뿔";
            device = "고대 장치";
            bone = "화석화된 뼈";
            meteorite = "운석 광석";
            book = "마법서";
            sack = "금 주머니";
            goldRing = "금 반지";
            royalRing = "왕의 반지";
            dice = "고대 주사위";
            cheese = "성스러운 치즈";
            wolf = "늑대 발톱";
            axe = "전사의 도끼";
            runestone = "룬스톤";
            skull = "전사의 해골";

            crafting = "제작";
        }
        #endregion

        #region Polish
        if (isPolish == true)
        {
            closeString = "ZAMKNIJ";
            purchaseText.text = "KUP";

            cost.text = "Koszt:";
            artifactBuffTooltip.text = "Premia artefaktu:";

            pickaxe1_name = "Pan Zardziały";
            pickaxe2_name = "Sir Złoty";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Stary Pewniak";
            pickaxe5_name = "Opulaks";
            pickaxe6_name = "Rozłupacz Kamieni";
            pickaxe7_name = "Sztyletowy Kilof";
            pickaxe8_name = "Uranowa Gorączka";
            pickaxe9_name = "Kuźniowy";
            pickaxe10_name = "Karmazynowy Suweren";
            pickaxe11_name = "Szlifierz Klejnotów";
            pickaxe12_name = "Królewski Towarzysz";
            pickaxe13_name = "Krusher";
            pickaxe14_name = "Diamentowy Kilof";

            rolled = "Wyrzucono:";
            oresTripled = "Rudy pomnożone x5!";

            price = "Cena:";

            talentLevel = "Poziom talentu:";
            durability = "Trwałość";
            levelUp = "POZIOM W GÓRĘ!";

            skin = "SKÓRKA ";

            artifactFound = "Znaleziono artefakt!";
            horn = "Róg Wołu";
            device = "Starożytne Urządzenie";
            bone = "Skamieniała Kość";
            meteorite = "Ruda Meteorytowa";
            book = "Magiczna Księga";
            sack = "Worek Złota";
            goldRing = "Złoty Pierścień";
            royalRing = "Królewski Pierścień";
            dice = "Starożytne Kości";
            cheese = "Święty Ser";
            wolf = "Wilczy Pazur";
            axe = "Topór Wojownika";
            runestone = "Kamień Runiczny";
            skull = "Czaszka Wojownika";

            crafting = "Rzemiosło";
        }
        #endregion

        #region Portuguese (Brazil)
        if (isPortugese == true)
        {
            closeString = "FECHAR";
            purchaseText.text = "COMPRAR";

            cost.text = "Custo:";
            artifactBuffTooltip.text = "Bônus do artefato:";

            pickaxe1_name = "Sr. Enferrujado";
            pickaxe2_name = "Sir Dourado";
            pickaxe3_name = "Royale-Pick";
            pickaxe4_name = "Velho Fiel";
            pickaxe5_name = "Opulacha";
            pickaxe6_name = "Quebra-Pedra";
            pickaxe7_name = "Picareta-Adaga";
            pickaxe8_name = "Febre de Urânio";
            pickaxe9_name = "Forjado";
            pickaxe10_name = "Soberano Carmesim";
            pickaxe11_name = "Cortador de Gemas";
            pickaxe12_name = "Companheiro do Rei";
            pickaxe13_name = "O Triturador";
            pickaxe14_name = "Picareta de Diamante";

            rolled = "Rolado:";
            oresTripled = "Minérios multiplicados por 5!";

            price = "Preço:";

            talentLevel = "Nível de talento:";
            durability = "Durabilidade";
            levelUp = "NÍVEL UP!";

            skin = "SKIN ";

            artifactFound = "Artefato encontrado!";
            horn = "Chifre de Boi";
            device = "Dispositivo Antigo";
            bone = "Osso Fossilizado";
            meteorite = "Minério de Meteorito";
            book = "Livro Mágico";
            sack = "Saco de Ouro";
            goldRing = "Anel de Ouro";
            royalRing = "Anel Real";
            dice = "Dados Antigos";
            cheese = "Queijo Sagrado";
            wolf = "Garra de Lobo";
            axe = "Machado do Guerreiro";
            runestone = "Pedra Rúnica";
            skull = "Crânio do Guerreiro";

            crafting = "Criação";
        }
        #endregion

        #region Russian
        if (isRussian == true)
        {
            closeString = "ЗАКРЫТЬ";
            purchaseText.text = "КУПИТЬ";

            cost.text = "Стоимость:";
            artifactBuffTooltip.text = "Бонус артефакта:";

            pickaxe1_name = "Мистер Ржавый";
            pickaxe2_name = "Сэр Золотой";
            pickaxe3_name = "Роял-Пик";
            pickaxe4_name = "Старый Надёжный";
            pickaxe5_name = "Опулакс";
            pickaxe6_name = "Камнерез";
            pickaxe7_name = "Кинжал-Пик";
            pickaxe8_name = "Урановая Лихорадка";
            pickaxe9_name = "Кузнечный";
            pickaxe10_name = "Багровый Суверен";
            pickaxe11_name = "Гравёр Камней";
            pickaxe12_name = "Королевский Спутник";
            pickaxe13_name = "Дробитель";
            pickaxe14_name = "Алмазная Кирка";

            rolled = "Выпало:";
            oresTripled = "Руда умножена на 5!";

            price = "Цена:";

            talentLevel = "Уровень таланта:";
            durability = "Прочность";
            levelUp = "НОВЫЙ УРОВЕНЬ!";

            skin = "СКИН ";

            artifactFound = "Артефакт найден!";
            horn = "Бычий Рог";
            device = "Древнее Устройство";
            bone = "Окаменелая Кость";
            meteorite = "Метеоритная Руда";
            book = "Магическая Книга";
            sack = "Мешок Золота";
            goldRing = "Золотое Кольцо";
            royalRing = "Королевское Кольцо";
            dice = "Древние Кости";
            cheese = "Святой Сыр";
            wolf = "Волчий Коготь";
            axe = "Топор Воина";
            runestone = "Рунический Камень";
            skull = "Череп Воина";

            crafting = "Крафт";
        }
        #endregion

        #region Simplified Chinese
        if (isSimplefiedChinese == true)
        {
            closeString = "关闭";
            purchaseText.text = "购买";

            cost.text = "花费：";
            artifactBuffTooltip.text = "神器增益：";

            pickaxe1_name = "锈先生";
            pickaxe2_name = "金爵士";
            pickaxe3_name = "皇家镐";
            pickaxe4_name = "老可靠";
            pickaxe5_name = "富贵镐";
            pickaxe6_name = "裂石者";
            pickaxe7_name = "匕首镐";
            pickaxe8_name = "铀狂热";
            pickaxe9_name = "铸造之子";
            pickaxe10_name = "猩红君主";
            pickaxe11_name = "宝石切割者";
            pickaxe12_name = "国王伙伴";
            pickaxe13_name = "破碎者";
            pickaxe14_name = "钻石镐";

            rolled = "掷出：";
            oresTripled = "矿石×5倍！";

            price = "价格：";

            talentLevel = "天赋等级：";
            durability = "耐久度";
            levelUp = "升级！";

            skin = "皮肤 ";

            artifactFound = "发现遗物！";
            horn = "牛角";
            device = "古代装置";
            bone = "化石骨";
            meteorite = "陨石矿";
            book = "魔法书";
            sack = "金币袋";
            goldRing = "金戒指";
            royalRing = "皇家戒指";
            dice = "古代骰子";
            cheese = "神圣奶酪";
            wolf = "狼爪";
            axe = "战士之斧";
            runestone = "符石";
            skull = "战士之颅";

            crafting = "锻造";
        }
        #endregion

        skillTreeClose.text = closeString;
        talentClose.text = closeString;
        talentLevelClose.text = closeString;
        theMineInfoClose.text = closeString;
        artifactClose.text = closeString;
    }
    #endregion

    #region More strings and texts
    public static string holdToCraft, clickToEquip;
    public static string yes, no;

    public TextMeshProUGUI mainMenu, exitGame, fullscreen, resetGame;
    public TextMeshProUGUI areYouSureText, thisIsNotText, pressYesText, resetYes, resetNo;

    public TextMeshProUGUI mineTheBigRock, keepOnMining_MainMenu;

    public TextMeshProUGUI revealTalentCards, choose1, allCardsChosen;

    public TextMeshProUGUI equipped, mineTime1, mineTime2, minePower1, minePower2, mine2X1, mine2X2, mineSize1, mineSize2;

    public TextMeshProUGUI unlockTheMine;

    public TextMeshProUGUI playText, settingsText, creditsText, exitGameText;

    public static string musicCreditName1;
    public TextMeshProUGUI credits, gameBy, musicBy, customArtBy;
    public TextMeshProUGUI skillTree, talents, theAnvil, theMine, artifacts;

    public TextMeshProUGUI endSession, miningSessionDone, oresGathered, barsCrafted, totalBars, xpGathered, levelUpSessionDone, upgrade, keepOnMining_endFrame;

    public static string startMining, outOfTime;

    public TextMeshProUGUI coolText;

    public TextMeshProUGUI theMineTooltipText;

    public TextMeshProUGUI COMPLETION, allSkillTree, byHaving, theseUpgrades, theseUpgradesCanBe, ok_EndlessOpoUP;

    public void SetOtherTexts()
    {
        musicCreditName1 = "XtremeFreddy";

        #region English
        if (isEnglish == true)
        {
            COMPLETION.text = "COMPLETION!";
            allSkillTree.text = "All skill tree upgrades purchased!";
            byHaving.text = "By having purchased all of the skill tree upgrades, you have unlocked the ENDLESS UPGRADES.";
            theseUpgrades.text = "The endless upgrades are located at the top of the skill tree. ";
            theseUpgradesCanBe.text = "These upgrades can be continuously purchased and is aimed at players who want to continue to play the game after it's completion!";

            yes = "YES";
            no = "NO";

            coolText.text = "COOL";

            holdToCraft = "Hold to craft";
            clickToEquip = "Click to equip";

            mainMenu.text = "MAIN MENU";
            exitGame.text = "EXIT GAME";
            fullscreen.text = "Fullscreen";
            resetGame.text = "RESET GAME";

            areYouSureText.text = "Are you sure you want to reset the entire game?";
            thisIsNotText.text = "THIS IS NOT A PRESTIGE MECHANIC!";
            pressYesText.text = "Pressing YES will reset the entire game to the beginning.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Mine the big rock!";
            keepOnMining_MainMenu.text = "Keep on Mining!";

            revealTalentCards.text = "REVEAL TALENT CARDS";
            choose1.text = "CHOOSE 1";
            allCardsChosen.text = "ALL TALENT\nCARDS CHOSEN";

            equipped.text = "Equipped";
            mineTime1.text = "Mine Time:";
            mineTime2.text = "Mine Time:";
            minePower1.text = "Mine Power:";
            minePower2.text = "Mine Power:";
            mine2X1.text = "2X Power Chance:";
            mine2X2.text = "2X Power Chance:";
            mineSize1.text = "Mining Area Size:";
            mineSize2.text = "Mining Area Size:";

            unlockTheMine.text = "UNLOCK THE MINE";

            playText.text = "Play";
            settingsText.text = "Settings";
            credits.text = "Credits";
            creditsText.text = "Credits";
            exitGameText.text = "Exit Game";

            gameBy.text = "Game by: EagleEye Games";
            musicBy.text = $"Music by: {musicCreditName1}";
            customArtBy.text = "Custom art by: Artisgamemobile";

            skillTree.text = "Skill tree";
            talents.text = "Talents";
            theAnvil.text = "The anvil";
            theMine.text = "The mine";
            artifacts.text = "Artifacts";

            endSession.text = "END SESSION";
            miningSessionDone.text = "Mining session done!";
            oresGathered.text = "Ores Gathered";
            barsCrafted.text = "Bars Crafted";
            totalBars.text = "Total Bars";
            xpGathered.text = "XP Gathered";
            upgrade.text = "UPGRADE!";
            keepOnMining_endFrame.text = "KEEP ON MINING!";

            startMining = "START MINING!";
            outOfTime = "OUT OF TIME!";

            theMineTooltipText.text = "The \"Ore Value\" skill tree upgrades also effect the mined bars from The Mine!";
        }
        #endregion

        #region French
        if (isFrench == true)
        {
            COMPLETION.text = "ACHÈVEMENT !";
            allSkillTree.text = "Toutes les améliorations de l'arbre de compétences ont été achetées !";
            byHaving.text = "En ayant acheté toutes les améliorations de l'arbre de compétences, vous avez débloqué les AMÉLIORATIONS SANS FIN.";
            theseUpgrades.text = "Les améliorations sans fin se trouvent en haut de l'arbre de compétences.";
            theseUpgradesCanBe.text = "Ces améliorations peuvent être achetées en continu et sont destinées aux joueurs qui souhaitent continuer à jouer après avoir terminé le jeu.";

            startMining = "COMMENCEZ À MINER !";
            outOfTime = "PLUS DE TEMPS !";

            yes = "OUI";
            no = "NON";

            coolText.text = "COOL";

            holdToCraft = "Maintenir pour fabriquer";
            clickToEquip = "Cliquer pour équiper";

            mainMenu.text = "MENU PRINCIPAL";
            exitGame.text = "QUITTER LE JEU";
            fullscreen.text = "Plein écran";
            resetGame.text = "RÉINITIALISER LE JEU";

            areYouSureText.text = "Êtes-vous sûr de vouloir réinitialiser le jeu en entier ?";
            thisIsNotText.text = "CECI N'EST PAS UNE MÉCANIQUE DE PRESTIGE !";
            pressYesText.text = "Appuyer sur OUI réinitialisera entièrement le jeu.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Minez le gros rocher !";
            keepOnMining_MainMenu.text = "ALLER MINER !";

            revealTalentCards.text = "RÉVÉLER CARTES DE TALENT";
            choose1.text = "CHOISISSEZ 1";
            allCardsChosen.text = "TOUTES LES CARTES\nDE TALENT SONT CHOISIES";

            equipped.text = "Équipé";
            mineTime1.text = "<size=31>Temps de minage :";
            mineTime2.text = "<size=31>Temps de minage :";
            minePower1.text = "<size=31>Puissance de minage :";
            minePower2.text = "<size=31>Puissance de minage :";
            mine2X1.text = "<size=31>Chance de Puissance 2X :";
            mine2X2.text = "<size=31>Chance de Puissance 2X :";
            mineSize1.text = "<size=31>Taille de la zone :";
            mineSize2.text = "<size=31>Taille de la zone :";

            unlockTheMine.text = "DÉBLOQUER LA MINE";

            playText.text = "Jouer";
            settingsText.text = "Paramètres";
            credits.text = "Crédits";
            creditsText.text = "Crédits";
            exitGameText.text = "Quitter le jeu";

            gameBy.text = "Jeu par : EagleEye Games";
            musicBy.text = $"Musique par : {musicCreditName1}";
            customArtBy.text = "Art personnalisé par : Artisgamemobile";

            skillTree.text = "Arbre de compétences";
            talents.text = "Talents";
            theAnvil.text = "L'enclume";
            theMine.text = "La mine";
            artifacts.text = "Artefacts";

            endSession.text = "TERMINER SESSION";
            miningSessionDone.text = "Session de minage terminée !";
            oresGathered.text = "Minerais collectés";
            barsCrafted.text = "Lingots créés";
            totalBars.text = "Lingots totaux";
            xpGathered.text = "XP collectée";
            upgrade.text = "AMÉLIORER !";
            keepOnMining_endFrame.text = "ALLER MINER !";

            theMineTooltipText.text = "Les améliorations de l'arbre de compétences « Valeur du minerai » affectent également les lingots extraits de la Mine !";
        }
        #endregion

        #region Italian
        if (isItalian == true)
        {
            COMPLETION.text = "COMPLETAMENTO!";
            allSkillTree.text = "Tutti i potenziamenti dell'albero abilità sono stati acquistati!";
            byHaving.text = "Avendo acquistato tutti i potenziamenti dell'albero abilità, hai sbloccato i POTENZIAMENTI INFINITI.";
            theseUpgrades.text = "I potenziamenti infiniti si trovano nella parte superiore dell'albero abilità.";
            theseUpgradesCanBe.text = "Questi potenziamenti possono essere acquistati continuamente e sono pensati per i giocatori che vogliono continuare a giocare dopo aver completato il gioco.";

            startMining = "INIZIA A MINARE!";
            outOfTime = "TEMPO SCADUTO!";

            yes = "SÌ";
            no = "NO";

            coolText.text = "COOL";

            holdToCraft = "Tieni premuto per forgiare";
            clickToEquip = "Clicca per equipaggiare";

            mainMenu.text = "MENU PRINCIPALE";
            exitGame.text = "ESCI DAL GIOCO";
            fullscreen.text = "Schermo intero";
            resetGame.text = "RESETTA IL GIOCO";

            areYouSureText.text = "Sei sicuro di voler resettare l'intero gioco?";
            thisIsNotText.text = "QUESTO NON È UN MECCANISMO DI PRESTIGIO!";
            pressYesText.text = "Premere SÌ reimposterà l'intero gioco dall'inizio.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Scava la roccia gigante!";
            keepOnMining_MainMenu.text = "VAI A MINARE!";

            revealTalentCards.text = "RIVELA CARTE TALENTO";
            choose1.text = "SCEGLI 1";
            allCardsChosen.text = "TUTTE LE CARTE\nTALENTO SCELTE";

            equipped.text = "Equipaggiato";
            mineTime1.text = "<size=31>Tempo di scavo:";
            mineTime2.text = "<size=31>Tempo di scavo:";
            minePower1.text = "<size=31>Potenza di scavo:";
            minePower2.text = "<size=31>Potenza di scavo:";
            mine2X1.text = "<size=31>Probabilità Potenza 2X:";
            mine2X2.text = "<size=31>Probabilità Potenza 2X:";
            mineSize1.text = "<size=31>Dimensione area:";
            mineSize2.text = "<size=31>Dimensione area:";

            unlockTheMine.text = "SBLOCCA LA MINIERA";

            playText.text = "Gioca";
            settingsText.text = "Impostazioni";
            credits.text = "Crediti";
            creditsText.text = "Crediti";
            exitGameText.text = "Esci dal gioco";

            gameBy.text = "Gioco di: EagleEye Games";
            musicBy.text = $"Musica di: {musicCreditName1}";
            customArtBy.text = "Arte personalizzata di: Artisgamemobile";

            skillTree.text = "Albero abilità";
            talents.text = "Talenti";
            theAnvil.text = "L'incudine";
            theMine.text = "La miniera";
            artifacts.text = "Artefatti";

            endSession.text = "FINE SESSIONE";
            miningSessionDone.text = "Sessione di scavo conclusa!";
            oresGathered.text = "Minerali raccolti";
            barsCrafted.text = "Lingotti forgiati";
            totalBars.text = "Lingotti totali";
            xpGathered.text = "XP raccolta";
            upgrade.text = "AGGIORNA!";
            keepOnMining_endFrame.text = "VAI A MINARE!";

            theMineTooltipText.text = "Gli upgrade dell’albero abilità \"Valore del Minerale\" influenzano anche i lingotti estratti dalla Miniera!";
        }
        #endregion

        #region German
        if (isGerman == true)
        {
            COMPLETION.text = "VOLLENDUNG!";
            allSkillTree.text = "Alle Verbesserungen des Fertigkeitsbaums wurden gekauft!";
            byHaving.text = "Durch den Kauf aller Verbesserungen des Fertigkeitsbaums hast du die ENDLOSEN UPGRADES freigeschaltet.";
            theseUpgrades.text = "Die endlosen Upgrades befinden sich oben im Fertigkeitsbaum.";
            theseUpgradesCanBe.text = "Diese Upgrades können unbegrenzt gekauft werden und richten sich an Spieler, die nach Abschluss des Spiels weiterspielen möchten.";

            startMining = "STARTE ABBAU!";
            outOfTime = "ZEIT ABGELAUFEN!";

            yes = "JA";
            no = "NEIN";

            coolText.text = "COOL";

            holdToCraft = "Halten zum Schmieden";
            clickToEquip = "Klicken zum Ausrüsten";

            mainMenu.text = "HAUPTMENÜ";
            exitGame.text = "SPIEL BEENDEN";
            fullscreen.text = "Vollbild";
            resetGame.text = "SPIEL ZURÜCKSETZEN";

            areYouSureText.text = "Bist du sicher, dass du das ganze Spiel zurücksetzen willst?";
            thisIsNotText.text = "DAS IST KEIN PRESTIGE-MECHANISMUS!";
            pressYesText.text = "Wenn du JA drückst, wird das gesamte Spiel neu gestartet.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Abbau des großen Felsens!";
            keepOnMining_MainMenu.text = "AB IN DIE MINE!";

            revealTalentCards.text = "TALENTKARTEN AUFDECKEN";
            choose1.text = "WÄHLE 1";
            allCardsChosen.text = "ALLE TALENTKARTEN\nGEWÄHLT";

            equipped.text = "Ausgerüstet";
            mineTime1.text = "Abbauzeit:";
            mineTime2.text = "Abbauzeit:";
            minePower1.text = "Abbaukraft:";
            minePower2.text = "Abbaukraft:";
            mine2X1.text = "2X Kraft Chance:";
            mine2X2.text = "2X Kraft Chance:";
            mineSize1.text = "Abbaugebietsgröße:";
            mineSize2.text = "Abbaugebietsgröße:";

            unlockTheMine.text = "MINE FREISCHALTEN";

            playText.text = "Spielen";
            settingsText.text = "Einstellungen";
            credits.text = "Credits";
            creditsText.text = "Credits";
            exitGameText.text = "Spiel beenden";

            gameBy.text = "Spiel von: EagleEye Games";
            musicBy.text = $"Musik von: {musicCreditName1}";
            customArtBy.text = "Individuelle Kunst von: Artisgamemobile";

            skillTree.text = "Fähigkeitsbaum";
            talents.text = "Talente";
            theAnvil.text = "Der Amboss";
            theMine.text = "Die Mine";
            artifacts.text = "Artefakte";

            endSession.text = "SESSION BEENDEN";
            miningSessionDone.text = "Miningsession abgeschlossen!";
            oresGathered.text = "Erze gesammelt";
            barsCrafted.text = "Barren geschmiedet";
            totalBars.text = "Gesamtbarren";
            xpGathered.text = "XP gesammelt";
            upgrade.text = "AUFRÜSTEN!";
            keepOnMining_endFrame.text = "AB IN DIE MINE!";

            theMineTooltipText.text = "Die Fertigkeitsbaum-Upgrades \"Erz-Wert\" wirken sich auch auf die in der Mine abgebauten Barren aus!";
        }
        #endregion

        #region Spanish
        if (isSpanish == true)
        {
            COMPLETION.text = "¡COMPLETADO!";
            allSkillTree.text = "¡Todas las mejoras del árbol de habilidades han sido compradas!";
            byHaving.text = "Al haber comprado todas las mejoras del árbol de habilidades, has desbloqueado las MEJORAS INFINITAS.";
            theseUpgrades.text = "Las mejoras infinitas están ubicadas en la parte superior del árbol de habilidades.";
            theseUpgradesCanBe.text = "Estas mejoras se pueden comprar continuamente y están pensadas para los jugadores que quieren seguir jugando después de completar el juego.";

            startMining = "¡COMIENZA A MINAR!";
            outOfTime = "¡SIN TIEMPO!";

            yes = "SÍ";
            no = "NO";

            coolText.text = "GUAY";

            holdToCraft = "Mantén para forjar";
            clickToEquip = "Haz clic para equipar";

            mainMenu.text = "MENÚ PRINCIPAL";
            exitGame.text = "SALIR DEL JUEGO";
            fullscreen.text = "Pantalla completa";
            resetGame.text = "REINICIAR JUEGO";

            areYouSureText.text = "¿Estás seguro de que quieres reiniciar todo el juego?";
            thisIsNotText.text = "¡ESTO NO ES UN MECÁNICO DE PRESTIGIO!";
            pressYesText.text = "Presionar SÍ reiniciará todo el juego desde el principio.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "¡Mina la gran roca!";
            keepOnMining_MainMenu.text = "¡A MINAR!";

            revealTalentCards.text = "REVELAR CARTAS DE TALENTO";
            choose1.text = "ELIGE 1";
            allCardsChosen.text = "TODAS LAS\nCARTAS ELEGIDAS";

            equipped.text = "Equipado";
            mineTime1.text = "<size=27>Tiempo de minería:";
            mineTime2.text = "<size=27>Tiempo de minería:";
            minePower1.text = "<size=27>Poder de minería:";
            minePower2.text = "<size=27>Poder de minería:";
            mine2X1.text = "<size=27>Probabilidad de 2X Poder:";
            mine2X2.text = "<size=27>Probabilidad de 2X Poder:";
            mineSize1.text = "<size=27>Tamaño del área de minería:";
            mineSize2.text = "<size=27>Tamaño del área de minería:";

            unlockTheMine.text = "DESBLOQUEAR LA MINA";

            playText.text = "Jugar";
            settingsText.text = "Configuración";
            credits.text = "Créditos";
            creditsText.text = "Créditos";
            exitGameText.text = "Salir del juego";

            gameBy.text = "Juego de: EagleEye Games";
            musicBy.text = $"Música por: {musicCreditName1}";
            customArtBy.text = "Arte personalizado por: Artisgamemobile";

            skillTree.text = "Árbol de habilidades";
            talents.text = "Talentos";
            theAnvil.text = "El yunque";
            theMine.text = "La mina";
            artifacts.text = "Artefactos";

            endSession.text = "TERMINAR SESIÓN";
            miningSessionDone.text = "¡Sesión de minería terminada!";
            oresGathered.text = "Minerales recolectados";
            barsCrafted.text = "Lingotes forjados";
            totalBars.text = "Lingotes totales";
            xpGathered.text = "XP recolectada";
            upgrade.text = "MEJORAR!";
            keepOnMining_endFrame.text = "¡A MINAR!";

            theMineTooltipText.text = "Las mejoras del árbol de habilidades \"Valor del Mineral\" también afectan a los lingotes extraídos de la Mina.";
        }
        #endregion

        #region Japanese
        if (isJapanese == true)
        {
            COMPLETION.text = "完成！";
            allSkillTree.text = "すべてのスキルツリーアップグレードを購入しました！";
            byHaving.text = "すべてのスキルツリーアップグレードを購入すると、無限アップグレードがアンロックされます。";
            theseUpgrades.text = "無限アップグレードはスキルツリーの一番上にあります。";
            theseUpgradesCanBe.text = "これらのアップグレードは何度でも購入でき、ゲームクリア後もプレイを続けたいプレイヤー向けです。";

            startMining = "採掘開始！";
            outOfTime = "時間切れ！";

            yes = "はい";
            no = "いいえ";

            coolText.text = "クール";

            holdToCraft = "長押しでクラフト";
            clickToEquip = "クリックで装備";

            mainMenu.text = "メインメニュー";
            exitGame.text = "ゲーム終了";
            fullscreen.text = "フルスクリーン";
            resetGame.text = "ゲームをリセット";

            areYouSureText.text = "本当にゲーム全体をリセットしますか？";
            thisIsNotText.text = "これはプレステージ要素ではありません！";
            pressYesText.text = "「はい」を押すとゲームが最初からリセットされます。";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "巨大な岩を採掘！";
            keepOnMining_MainMenu.text = "採掘開始！";

            revealTalentCards.text = "タレントカードを公開";
            choose1.text = "1枚選択";
            allCardsChosen.text = "すべてのカードを選択済み";

            equipped.text = "装備中";
            mineTime1.text = "採掘時間:";
            mineTime2.text = "採掘時間:";
            minePower1.text = "採掘パワー:";
            minePower2.text = "採掘パワー:";
            mine2X1.text = "2Xパワー確率:";
            mine2X2.text = "2Xパワー確率:";
            mineSize1.text = "採掘エリアサイズ:";
            mineSize2.text = "採掘エリアサイズ:";

            unlockTheMine.text = "マインをアンロック";

            playText.text = "プレイ";
            settingsText.text = "設定";
            credits.text = "クレジット";
            creditsText.text = "クレジット";
            exitGameText.text = "ゲーム終了";

            gameBy.text = "制作: EagleEye Games";
            musicBy.text = $"音楽: {musicCreditName1}";
            customArtBy.text = "カスタムアート: Artisgamemobile";

            skillTree.text = "スキルツリー";
            talents.text = "タレント";
            theAnvil.text = "金床";
            theMine.text = "鉱山";
            artifacts.text = "アーティファクト";

            endSession.text = "セッション終了";
            miningSessionDone.text = "採掘セッション完了！";
            oresGathered.text = "鉱石獲得";
            barsCrafted.text = "インゴット作成";
            totalBars.text = "合計インゴット";
            xpGathered.text = "XP獲得";
            upgrade.text = "アップグレード！";
            keepOnMining_endFrame.text = "採掘開始！";

            theMineTooltipText.text = "「鉱石の価値」スキルツリーのアップグレードは、鉱山で得られるインゴットにも影響します！";
        }
        #endregion

        #region Korean
        if (isKorean == true)
        {
            COMPLETION.text = "완료!";
            allSkillTree.text = "모든 스킬 트리 업그레이드를 구매했습니다!";
            byHaving.text = "모든 스킬 트리 업그레이드를 구매하면 무한 업그레이드가 잠금 해제됩니다.";
            theseUpgrades.text = "무한 업그레이드는 스킬 트리의 맨 위에 있습니다.";
            theseUpgradesCanBe.text = "이 업그레이드는 계속해서 구매할 수 있으며, 게임 완료 후에도 계속 플레이하고 싶은 플레이어를 위한 것입니다.";

            startMining = "채굴 시작!";
            outOfTime = "시간 종료!";

            yes = "예";
            no = "아니오";

            coolText.text = "OK";

            holdToCraft = "길게 눌러 제작";
            clickToEquip = "클릭하여 장착";

            mainMenu.text = "메인 메뉴";
            exitGame.text = "게임 종료";
            fullscreen.text = "전체 화면";
            resetGame.text = "게임 초기화";

            areYouSureText.text = "정말로 게임을 초기화하시겠습니까?";
            thisIsNotText.text = "이것은 프레스티지 시스템이 아닙니다!";
            pressYesText.text = "예를 누르면 게임이 처음부터 초기화됩니다.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "큰 바위를 채굴하세요!";
            keepOnMining_MainMenu.text = "채굴하러 가자!";

            revealTalentCards.text = "탈렌트 카드 공개";
            choose1.text = "1개 선택";
            allCardsChosen.text = "모든 탈렌트 카드 선택됨";

            equipped.text = "장착됨";
            mineTime1.text = "채굴 시간:";
            mineTime2.text = "채굴 시간:";
            minePower1.text = "채굴 파워:";
            minePower2.text = "채굴 파워:";
            mine2X1.text = "2X 파워 확률:";
            mine2X2.text = "2X 파워 확률:";
            mineSize1.text = "채굴 영역 크기:";
            mineSize2.text = "채굴 영역 크기:";

            unlockTheMine.text = "마인 열기";

            playText.text = "플레이";
            settingsText.text = "설정";
            credits.text = "크레딧";
            creditsText.text = "크레딧";
            exitGameText.text = "게임 종료";

            gameBy.text = "제작: EagleEye Games";
            musicBy.text = $"음악: {musicCreditName1}";
            customArtBy.text = "커스텀 아트: Artisgamemobile";

            skillTree.text = "스킬 트리";
            talents.text = "탈렌트";
            theAnvil.text = "모루";
            theMine.text = "광산";
            artifacts.text = "유물";

            endSession.text = "세션 종료";
            miningSessionDone.text = "채굴 세션 완료!";
            oresGathered.text = "채굴된 광석";
            barsCrafted.text = "제작된 바";
            totalBars.text = "총 바 수";
            xpGathered.text = "획득 XP";
            upgrade.text = "업그레이드!";
            keepOnMining_endFrame.text = "채굴하러 가자!";

            theMineTooltipText.text = "\"광석 가치\" 스킬 트리 업그레이드는 광산에서 채굴한 바에도 적용됩니다!";
        }
        #endregion

        #region Polish
        if (isPolish == true)
        {
            COMPLETION.text = "UKOŃCZENIE!";
            allSkillTree.text = "Wszystkie ulepszenia drzewa umiejętności zostały zakupione!";
            byHaving.text = "Po zakupieniu wszystkich ulepszeń drzewa umiejętności odblokowałeś NIESKOŃCZONE ULEPSZENIA.";
            theseUpgrades.text = "Nieskończone ulepszenia znajdują się na górze drzewa umiejętności.";
            theseUpgradesCanBe.text = "Ulepszenia te można kupować bez końca i są przeznaczone dla graczy, którzy chcą kontynuować grę po jej ukończeniu.";

            startMining = "ZACZNIJ KOPAĆ!";
            outOfTime = "KONIEC CZASU!";

            yes = "TAK";
            no = "NIE";

            coolText.text = "FAJNE";

            holdToCraft = "Przytrzymaj, aby stworzyć";
            clickToEquip = "Kliknij, aby wyposażyć";

            mainMenu.text = "MENU GŁÓWNE";
            exitGame.text = "WYJDŹ Z GRY";
            fullscreen.text = "Pełny ekran";
            resetGame.text = "RESETUJ GRĘ";

            areYouSureText.text = "Czy na pewno chcesz zresetować całą grę?";
            thisIsNotText.text = "TO NIE JEST MECHANIKA PRESTIŻU!";
            pressYesText.text = "Kliknięcie TAK zresetuje całą grę od początku.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Wydobądź wielką skałę!";
            keepOnMining_MainMenu.text = "IDŹ KOPAĆ!";

            revealTalentCards.text = "ODKRYJ KARTY TALENTÓW";
            choose1.text = "WYBIERZ 1";
            allCardsChosen.text = "WSZYSTKIE KARTY\nTALENTÓW WYBRANE";

            equipped.text = "Wyposażono";
            mineTime1.text = "Czas wydobycia:";
            mineTime2.text = "Czas wydobycia:";
            minePower1.text = "Moc wydobycia:";
            minePower2.text = "Moc wydobycia:";
            mine2X1.text = "Szansa na 2X Moc:";
            mine2X2.text = "Szansa na 2X Moc:";
            mineSize1.text = "Rozmiar obszaru:";
            mineSize2.text = "Rozmiar obszaru:";

            unlockTheMine.text = "ODKRYJ KOPALNIĘ";

            playText.text = "Graj";
            settingsText.text = "Ustawienia";
            credits.text = "Twórcy";
            creditsText.text = "Twórcy";
            exitGameText.text = "Wyjdź z gry";

            gameBy.text = "Gra od: EagleEye Games";
            musicBy.text = $"Muzyka: {musicCreditName1}";
            customArtBy.text = "Grafika: Artisgamemobile";

            skillTree.text = "Drzewko umiejętności";
            talents.text = "Talenty";
            theAnvil.text = "Kowadło";
            theMine.text = "Kopalnia";
            artifacts.text = "Artefakty";

            endSession.text = "ZAKOŃCZ SESJĘ";
            miningSessionDone.text = "Sesja wydobycia zakończona!";
            oresGathered.text = "Zebrane rudy";
            barsCrafted.text = "Wykute sztabki";
            totalBars.text = "Łączna liczba sztabek";
            xpGathered.text = "Zebrane XP";
            upgrade.text = "ULEPSZ!";
            keepOnMining_endFrame.text = "IDŹ KOPAĆ!";

            theMineTooltipText.text = "Ulepszenia z drzewa umiejętności „Wartość Rudy” wpływają także na sztabki wydobyte w Kopalni!";
        }
        #endregion

        #region Portugese
        if (isPortugese == true)
        {
            COMPLETION.text = "CONCLUSÃO!";
            allSkillTree.text = "Todas as melhorias da árvore de habilidades foram compradas!";
            byHaving.text = "Ao comprar todas as melhorias da árvore de habilidades, você desbloqueou as MELHORIAS INFINITAS.";
            theseUpgrades.text = "As melhorias infinitas estão localizadas no topo da árvore de habilidades.";
            theseUpgradesCanBe.text = "Essas melhorias podem ser compradas continuamente e são destinadas a jogadores que desejam continuar jogando após a conclusão do jogo.";

            startMining = "COMECE A MINERAR!";
            outOfTime = "TEMPO ESGOTADO!";

            yes = "SIM";
            no = "NÃO";

            coolText.text = "LEGAL";

            holdToCraft = "Segure para forjar";
            clickToEquip = "Clique para equipar";

            mainMenu.text = "MENU PRINCIPAL";
            exitGame.text = "SAIR DO JOGO";
            fullscreen.text = "Tela cheia";
            resetGame.text = "REINICIAR JOGO";

            areYouSureText.text = "Tem certeza que deseja reiniciar todo o jogo?";
            thisIsNotText.text = "ISSO NÃO É UMA MECÂNICA DE PRESTÍGIO!";
            pressYesText.text = "Clicar em SIM reiniciará o jogo do início.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Mine a grande rocha!";
            keepOnMining_MainMenu.text = "VÁ MINERAR!";

            revealTalentCards.text = "REVELAR CARTAS DE TALENTO";
            choose1.text = "ESCOLHA 1";
            allCardsChosen.text = "TODAS AS CARTAS\nESCOLHIDAS";

            equipped.text = "Equipado";
            mineTime1.text = "Tempo de mineração:";
            mineTime2.text = "Tempo de mineração:";
            minePower1.text = "Poder de mineração:";
            minePower2.text = "Poder de mineração:";
            mine2X1.text = "Chance de 2X Poder:";
            mine2X2.text = "Chance de 2X Poder:";
            mineSize1.text = "Tamanho da área:";
            mineSize2.text = "Tamanho da área:";

            unlockTheMine.text = "DESBLOQUEAR A MINA";

            playText.text = "Jogar";
            settingsText.text = "Configurações";
            credits.text = "Créditos";
            creditsText.text = "Créditos";
            exitGameText.text = "Sair do jogo";

            gameBy.text = "Jogo por: EagleEye Games";
            musicBy.text = $"Música por: {musicCreditName1}";
            customArtBy.text = "Arte customizada por: Artisgamemobile";

            skillTree.text = "Árvore de habilidades";
            talents.text = "Talentos";
            theAnvil.text = "A bigorna";
            theMine.text = "A mina";
            artifacts.text = "Artefatos";

            endSession.text = "ENCERRAR SESSÃO";
            miningSessionDone.text = "Sessão de mineração concluída!";
            oresGathered.text = "Minérios coletados";
            barsCrafted.text = "Barras forjadas";
            totalBars.text = "Total de barras";
            xpGathered.text = "XP coletado";
            upgrade.text = "UPGRADE!";
            keepOnMining_endFrame.text = "VÁ MINERAR!";

            theMineTooltipText.text = "As melhorias da árvore de habilidades \"Valor do Minério\" também afetam as barras extraídas da Mina!";
        }
        #endregion

        #region Russian
        if (isRussian == true)
        {
            COMPLETION.text = "ЗАВЕРШЕНИЕ!";
            allSkillTree.text = "Все улучшения древа навыков были приобретены!";
            byHaving.text = "Приобретя все улучшения древа навыков, вы открыли БЕСКОНЕЧНЫЕ УЛУЧШЕНИЯ.";
            theseUpgrades.text = "Бесконечные улучшения находятся в верхней части древа навыков.";
            theseUpgradesCanBe.text = "Эти улучшения можно покупать бесконечно, и они предназначены для игроков, которые хотят продолжать играть после завершения игры.";

            startMining = "НАЧАТЬ ДОБЫЧУ!";
            outOfTime = "ВРЕМЯ ВЫШЛО!";

            yes = "ДА";
            no = "НЕТ";

            coolText.text = "КРУТО";

            holdToCraft = "Удерживайте, чтобы создать";
            clickToEquip = "Кликните, чтобы экипировать";

            mainMenu.text = "ГЛАВНОЕ МЕНЮ";
            exitGame.text = "ВЫХОД ИЗ ИГРЫ";
            fullscreen.text = "Полный экран";
            resetGame.text = "СБРОСИТЬ ИГРУ";

            areYouSureText.text = "Вы уверены, что хотите сбросить всю игру?";
            thisIsNotText.text = "ЭТО НЕ ПРЕСТИЖ-МЕХАНИКА!";
            pressYesText.text = "Нажав ДА, вы сбросите игру полностью.";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "Добыть большой камень!";
            keepOnMining_MainMenu.text = "ВПЕРЁД ДОБЫВАТЬ!";

            revealTalentCards.text = "ПОКАЗАТЬ КАРТЫ ТАЛАНТОВ";
            choose1.text = "ВЫБРАТЬ 1";
            allCardsChosen.text = "ВСЕ КАРТЫ\nТАЛАНТОВ ВЫБРАНЫ";

            equipped.text = "Экипировано";
            mineTime1.text = "Время добычи:";
            mineTime2.text = "Время добычи:";
            minePower1.text = "Сила добычи:";
            minePower2.text = "Сила добычи:";
            mine2X1.text = "Шанс 2X силы:";
            mine2X2.text = "Шанс 2X силы:";
            mineSize1.text = "Размер области:";
            mineSize2.text = "Размер области:";

            unlockTheMine.text = "РАЗБЛОКИРОВАТЬ ШАХТУ";

            playText.text = "Играть";
            settingsText.text = "Настройки";
            credits.text = "Авторы";
            creditsText.text = "Авторы";
            exitGameText.text = "Выйти из игры";

            gameBy.text = "Игра от: EagleEye Games";
            musicBy.text = $"Музыка: {musicCreditName1}";
            customArtBy.text = "Кастом арт: Artisgamemobile";

            skillTree.text = "Дерево навыков";
            talents.text = "Таланты";
            theAnvil.text = "Наковальня";
            theMine.text = "Шахта";
            artifacts.text = "Артефакты";

            endSession.text = "ЗАВЕРШИТЬ СЕССИЮ";
            miningSessionDone.text = "Сессия добычи завершена!";
            oresGathered.text = "Собрано руды";
            barsCrafted.text = "Слитков изготовлено";
            totalBars.text = "Всего слитков";
            xpGathered.text = "Собрано XP";
            upgrade.text = "УЛУЧШИТЬ!";
            keepOnMining_endFrame.text = "ВПЕРЁД ДОБЫВАТЬ!";

            theMineTooltipText.text = "Улучшения в древе навыков «Ценность руды» также влияют на слитки, добытые в Шахте!";
        }
        #endregion

        #region SimplifiedChinese
        if (isSimplefiedChinese == true)
        {
            COMPLETION.text = "完成！";
            allSkillTree.text = "所有技能树升级已购买！";
            byHaving.text = "购买所有技能树升级后，你将解锁无限升级。";
            theseUpgrades.text = "无限升级位于技能树的最上方。";
            theseUpgradesCanBe.text = "这些升级可以无限购买，适合在通关后仍想继续游戏的玩家。";

            startMining = "开始挖矿！";
            outOfTime = "时间耗尽！";

            yes = "是";
            no = "否";

            coolText.text = "好的";

            holdToCraft = "按住以锻造";
            clickToEquip = "点击装备";

            mainMenu.text = "主菜单";
            exitGame.text = "退出游戏";
            fullscreen.text = "全屏";
            resetGame.text = "重置游戏";

            areYouSureText.text = "你确定要重置整个游戏吗？";
            thisIsNotText.text = "这不是一个声望系统！";
            pressYesText.text = "点击“是”会将整个游戏重置到最初状态。";

            resetYes.text = yes;
            resetNo.text = no;

            mineTheBigRock.text = "开采大岩石！";
            keepOnMining_MainMenu.text = "开始挖矿！";

            revealTalentCards.text = "揭示天赋卡";
            choose1.text = "选择 1 张";
            allCardsChosen.text = "所有天赋卡已选择";

            equipped.text = "已装备";
            mineTime1.text = "采矿时间:";
            mineTime2.text = "采矿时间:";
            minePower1.text = "采矿力量:";
            minePower2.text = "采矿力量:";
            mine2X1.text = "2X 力量几率:";
            mine2X2.text = "2X 力量几率:";
            mineSize1.text = "采矿区域大小:";
            mineSize2.text = "采矿区域大小:";

            unlockTheMine.text = "解锁矿井";

            playText.text = "开始游戏";
            settingsText.text = "设置";
            credits.text = "制作人员";
            creditsText.text = "制作人员";
            exitGameText.text = "退出游戏";

            gameBy.text = "游戏制作: EagleEye Games";
            musicBy.text = $"音乐: {musicCreditName1}";
            customArtBy.text = "美术: Artisgamemobile";

            skillTree.text = "技能树";
            talents.text = "天赋";
            theAnvil.text = "铁砧";
            theMine.text = "矿井";
            artifacts.text = "神器";

            endSession.text = "结束挖矿";
            miningSessionDone.text = "挖矿已完成！";
            oresGathered.text = "已收集矿石";
            barsCrafted.text = "已锻造锭";
            totalBars.text = "锭总数";
            xpGathered.text = "已获得XP";
            upgrade.text = "升级！";
            keepOnMining_endFrame.text = "开始挖矿！";

            theMineTooltipText.text = "“矿石价值”技能树的升级同样会影响矿井中获得的锭！";
        }
        #endregion

        levelUpSessionDone.text = levelUp;
    }
    #endregion

    #region Tutorial texts
    public TextMeshProUGUI oreAndBars, youWill, thereAre, normalRocks, oresWillBe;
    public static string ok;

    public TextMeshProUGUI welcomeTo, theGameIsSimple, aCircle, onceThe;
    public TextMeshProUGUI levelAndTalent, everyMined, youWillReceive, youCanSpend, talentCardsProvide;
    public TextMeshProUGUI theAnvilTut, hereYouCan, eachPickaxe, eachNew;
    public TextMeshProUGUI theMineTut, onceYouHave, theMineWill, thePercentage;
    public TextMeshProUGUI artifactsTut, hereYouCanView, artifactsHave, everyArtifact;

    public TextMeshProUGUI ok_materialOres, okWelcomeTo, okTalent, okTheAnvil, okTheMine, okArtifacts;

    public void TutText()
    {
        #region English
        if (isEnglish == true)
        {
            ok = "OK";

            artifactsTut.text = "Artifacts!";
            hereYouCanView.text = "Here you can view all found artifacts.";
            artifactsHave.text = "Artifacts have a small chance to be attached to a rock.";
            everyArtifact.text = "Every artifact will provide you with a passive buff.";

            theMineTut.text = "The Mine!";
            onceYouHave.text = "Once you have purchased The Mine, it will automatically mine rocks for you.";
            theMineWill.text = "The Mine will mine bars instead of ores.";
            thePercentage.text = "The percentages above the total bars frames to the left displays the chance The Mine has to mine that type of material.";

            theAnvilTut.text = "The Anvil!";
            hereYouCan.text = "Here you can craft new pickaxes!";
            eachPickaxe.text = "Each pickaxe needs a specific type of material to be crafted.";
            eachNew.text = "Each new pickaxe has different pickaxe stats. The pickaxe stats can also be increased via the Skill Tree upgrades.";

            oreAndBars.text = "Material ores and bars!";
            youWill.text = "You will receive ores from mining rocks.";
            thereAre.text = "There are 3 types of rocks that can spawn. Normal rocks, chunk rocks and full material rocks.";
            normalRocks.text = "Normal rocks will always drop 1 gold ore. Chunk rocks drop 3 and full material rocks drop 7.";
            oresWillBe.text = "Ores will automatically be crafted into bars. It takes 3 ores to craft 1 bar. If you have 1 or 2 extra ores left over, you will craft 1 extra bar. Example: 10 mined ores will craft 4 bars.";

            welcomeTo.text = "Welcome to Keep on Mining!";
            theGameIsSimple.text = "The game is simple. Once a mining session starts, hover over rocks to mine them.";
            onceThe.text = "Once the top right timer reaches 0, the mining session ends.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "A circle will follow your cursor, this is the mining area. Rocks inside the mining area will spawn pickaxes that mine for you.";
            }
            else
            {
                aCircle.text = "A circle will follow your where you tap the screen, this is the mining area. Rocks inside the mining area will spawn pickaxes that mine for you.";
            }

            levelAndTalent.text = "Level up and talent cards!";
            everyMined.text = "Every mined rock will provide you with XP.";
            youWillReceive.text = "You will receive 1 talent point when leveling up.";
            youCanSpend.text = "You can spend your talent points to reveal the talent cards. You can choose 1 out of 3 talent cards.";

            if (MobileAndTesting.isMobile == false)
            {
                talentCardsProvide.text = "Talent cards provide you with cool and permanent buffs. Once a talent card is chosen, your talent level will increase, this increases the rock durability by 2. You can hover over the talent level text to see the current rock durability.";
            }
            else
            {
                talentCardsProvide.text = "Talent cards provide you with cool and permanent buffs. Once a talent card is chosen, your talent level will increase, this increases the rock durability by 2. You can tap the talent level text to see the current rock durability.";
            }
        }
        #endregion

        #region French
        if (isFrench == true)
        {
            ok = "OK";

            artifactsTut.text = "Artefacts !";
            hereYouCanView.text = "Ici, vous pouvez voir tous les artefacts trouvés.";
            artifactsHave.text = "Les artefacts ont une petite chance d'être attachés à une roche.";
            everyArtifact.text = "Chaque artefact vous donne un bonus passif.";

            theMineTut.text = "La Mine !";
            onceYouHave.text = "Une fois que vous avez acheté la Mine, elle extraira automatiquement des roches pour vous.";
            theMineWill.text = "La Mine extraira des lingots au lieu de minerais.";
            thePercentage.text = "Les pourcentages au-dessus des cadres de lingots à gauche indiquent la chance qu’a la Mine d’extraire ce matériau.";

            theAnvilTut.text = "L'Enclume !";
            hereYouCan.text = "Ici, vous pouvez forger de nouvelles pioches !";
            eachPickaxe.text = "Chaque pioche nécessite un matériau spécifique pour être forgée.";
            eachNew.text = "Chaque nouvelle pioche a des stats différentes. Les stats peuvent être améliorées via l'Arbre de Compétences.";

            oreAndBars.text = "Minerais et lingots !";
            youWill.text = "Vous recevrez des minerais en extrayant des roches.";
            thereAre.text = "Il existe 3 types de roches : normales, morceaux et roches pleines.";
            normalRocks.text = "Les roches normales donnent toujours 1 minerai d'or. Les morceaux en donnent 3 et les roches pleines en donnent 7.";
            oresWillBe.text = "Les minerais seront automatiquement transformés en lingots. 3 minerais = 1 lingot. Avec 1 ou 2 minerais restants, vous fabriquez 1 lingot de plus. Exemple : 10 minerais donnent 4 lingots.";

            welcomeTo.text = "Bienvenue dans Keep on Mining!";
            theGameIsSimple.text = "Le jeu est simple. Une fois la session lancée, survolez les roches pour les extraire.";
           
            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Un cercle suit votre curseur : c’est votre zone de minage. Les roches à l’intérieur génèrent des pioches.";
            }
            else
            {
                aCircle.text = "Un cercle suivra l’endroit où vous touchez l’écran, c’est la zone de minage. Les roches à l’intérieur de cette zone feront apparaître des pioches qui mineront pour vous.";
            }

            onceThe.text = "Une fois le chrono en haut à droite à 0, la session se termine.";

            levelAndTalent.text = "Montez de niveau et cartes de talent !";
            everyMined.text = "Chaque roche extraite vous donne de l’XP.";
            youWillReceive.text = "Vous recevez 1 point de talent à chaque niveau.";
            youCanSpend.text = "Vous pouvez utiliser vos points pour révéler des cartes talent et en choisir 1 sur 3.";
            talentCardsProvide.text = "Les cartes talent donnent des bonus permanents. Chaque carte augmente votre niveau de talent, ce qui augmente la durabilité des roches de 2. Survolez le niveau de talent pour voir la durabilité actuelle.";
        }
        #endregion

        #region Italian
        if (isItalian == true)
        {
            ok = "OK";

            artifactsTut.text = "Artefatti!";
            hereYouCanView.text = "Qui puoi vedere tutti gli artefatti trovati.";
            artifactsHave.text = "Gli artefatti hanno una piccola possibilità di essere attaccati a una roccia.";
            everyArtifact.text = "Ogni artefatto fornisce un bonus passivo.";

            theMineTut.text = "La Miniera!";
            onceYouHave.text = "Quando acquisti la Miniera, minerà automaticamente rocce per te.";
            theMineWill.text = "La Miniera estrae lingotti invece di minerali.";
            thePercentage.text = "Le percentuali sopra i riquadri dei lingotti a sinistra mostrano la possibilità della Miniera di estrarre quel materiale.";

            theAnvilTut.text = "L'Incudine!";
            hereYouCan.text = "Qui puoi forgiare nuove picconi!";
            eachPickaxe.text = "Ogni piccone richiede un materiale specifico per essere creato.";
            eachNew.text = "Ogni nuovo piccone ha statistiche diverse. Le statistiche possono essere aumentate tramite l'Albero Abilità.";

            oreAndBars.text = "Minerali e lingotti!";
            youWill.text = "Ricevi minerali estraendo rocce.";
            thereAre.text = "Ci sono 3 tipi di rocce: normali, a pezzi e piene di materiale.";
            normalRocks.text = "Le rocce normali danno sempre 1 minerale d'oro. Le rocce a pezzi ne danno 3 e quelle piene ne danno 7.";
            oresWillBe.text = "I minerali vengono trasformati in lingotti. 3 minerali = 1 lingotto. Con 1 o 2 minerali extra si crea 1 lingotto aggiuntivo. Esempio: 10 minerali = 4 lingotti.";

            welcomeTo.text = "Benvenuto in Keep on Mining!";
            theGameIsSimple.text = "Il gioco è semplice. All'inizio di una sessione, passa sopra le rocce per estrarle.";
          
            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Un cerchio segue il cursore: è la tua area di miniera. Le rocce all’interno generano picconi.";
            }
            else
            {
                aCircle.text = "Un cerchio seguirà il punto in cui tocchi lo schermo, questa è l’area di estrazione. Le rocce all’interno dell’area faranno comparire picconi che mineranno per te.";
            }

            onceThe.text = "Quando il timer in alto a destra arriva a 0, la sessione termina.";

            levelAndTalent.text = "Livelli e carte talento!";
            everyMined.text = "Ogni roccia estratta ti dà XP.";
            youWillReceive.text = "Ricevi 1 punto talento a ogni livello.";
            youCanSpend.text = "Puoi spendere i punti talento per rivelare carte talento e sceglierne 1 su 3.";
            talentCardsProvide.text = "Le carte talento danno bonus permanenti. Ogni carta aumenta il livello talento, aumentando la durevolezza delle rocce di 2. Passa sopra il livello per vedere la durevolezza.";
        }
        #endregion

        #region German
        if (isGerman == true)
        {
            ok = "OK";

            artifactsTut.text = "Artefakte!";
            hereYouCanView.text = "Hier kannst du alle gefundenen Artefakte ansehen.";
            artifactsHave.text = "Artefakte können mit einer kleinen Chance an einem Felsen sein.";
            everyArtifact.text = "Jedes Artefakt gibt dir einen passiven Bonus.";

            theMineTut.text = "Die Mine!";
            onceYouHave.text = "Sobald du die Mine gekauft hast, baut sie automatisch für dich ab.";
            theMineWill.text = "Die Mine fördert Barren anstelle von Erzen.";
            thePercentage.text = "Die Prozentsätze über den Barren-Frames links zeigen die Chance der Mine, dieses Material zu fördern.";

            theAnvilTut.text = "Der Amboss!";
            hereYouCan.text = "Hier kannst du neue Spitzhacken schmieden!";
            eachPickaxe.text = "Jede Spitzhacke benötigt ein spezielles Material.";
            eachNew.text = "Jede neue Spitzhacke hat eigene Werte. Diese können über den Skilltree verbessert werden.";

            oreAndBars.text = "Erze und Barren!";
            youWill.text = "Du erhältst Erze beim Abbau von Felsen.";
            thereAre.text = "Es gibt 3 Arten von Felsen: normal, Brocken und voll.";
            normalRocks.text = "Normale Felsen geben immer 1 Gold-Erz. Brocken geben 3, volle Felsen 7.";
            oresWillBe.text = "Erze werden automatisch zu Barren verarbeitet. 3 Erze = 1 Barren. Hast du 1-2 übrig, wird 1 extra Barren erstellt. Beispiel: 10 Erze = 4 Barren.";

            welcomeTo.text = "Willkommen bei Keep on Mining!";
            theGameIsSimple.text = "Das Spiel ist einfach: Bewege den Mauszeiger über Felsen, um sie abzubauen.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Ein Kreis folgt deinem Cursor – das ist dein Abbaugebiet. Felsen darin spawnen Spitzhacken.";
            }
            else
            {
                aCircle.text = "Ein Kreis folgt der Stelle, an der du den Bildschirm berührst – dies ist das Abbaugebiet. Felsen innerhalb dieses Bereichs lassen Spitzhacken erscheinen, die für dich abbauen.";
            }
      
            onceThe.text = "Wenn der Timer oben rechts bei 0 ist, endet die Session.";

            levelAndTalent.text = "Level und Talentkarten!";
            everyMined.text = "Jeder abgebaute Felsen gibt dir XP.";
            youWillReceive.text = "Pro Level erhältst du 1 Talentpunkt.";
            youCanSpend.text = "Du kannst Punkte ausgeben, um Talentkarten aufzudecken und 1 von 3 zu wählen.";
            talentCardsProvide.text = "Talentkarten geben dauerhafte Boni. Jede Karte erhöht dein Talentlevel, was die Haltbarkeit der Felsen um 2 erhöht. Fahre über den Talentlevel, um es zu sehen.";
        }
        #endregion

        #region Spanish
        if (isSpanish == true)
        {
            ok = "OK";

            artifactsTut.text = "¡Artefactos!";
            hereYouCanView.text = "Aquí puedes ver todos los artefactos encontrados.";
            artifactsHave.text = "Los artefactos tienen una pequeña probabilidad de estar dentro de una roca.";
            everyArtifact.text = "Cada artefacto te dará una mejora pasiva.";

            theMineTut.text = "¡La Mina!";
            onceYouHave.text = "Cuando compras la Mina, minará automáticamente rocas por ti.";
            theMineWill.text = "La Mina extrae lingotes en lugar de minerales.";
            thePercentage.text = "Los porcentajes sobre los cuadros de lingotes a la izquierda muestran la probabilidad de la Mina de minar ese material.";

            theAnvilTut.text = "¡El Yunque!";
            hereYouCan.text = "Aquí puedes forjar nuevas picas.";
            eachPickaxe.text = "Cada pica necesita un tipo de material específico para forjarse.";
            eachNew.text = "Cada nueva pica tiene estadísticas distintas. Puedes mejorarlas desde el Árbol de Habilidades.";

            oreAndBars.text = "¡Minerales y lingotes!";
            youWill.text = "Recibirás minerales al minar rocas.";
            thereAre.text = "Hay 3 tipos de rocas: normales, rocas con fragmentos y rocas completamente de material.";
            normalRocks.text = "Las rocas normales siempre dan 1 mineral de oro. Las de fragmentos dan 3 y las completas dan 7.";
            oresWillBe.text = "Los minerales se convierten automáticamente en lingotes. 3 minerales = 1 lingote. Si tienes 1 o 2 minerales de sobra, obtendrás 1 lingote extra. Ejemplo: 10 minerales = 4 lingotes.";

            welcomeTo.text = "¡Bienvenido a Keep on Mining!";
            theGameIsSimple.text = "El juego es sencillo. Cuando empiece la sesión, pasa el cursor sobre las rocas para minarlas.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Un círculo sigue tu cursor: esa es tu área de minado. Las rocas dentro del área generan picas.";
            }
            else
            {
                aCircle.text = "Un círculo seguirá el lugar donde toques la pantalla, esta es el área de minería. Las rocas dentro del área generarán picos que minarán por ti.";
            }

            onceThe.text = "Cuando el temporizador llegue a 0, la sesión de minería termina.";

            levelAndTalent.text = "¡Sube de nivel y cartas de talento!";
            everyMined.text = "Cada roca minada te da XP.";
            youWillReceive.text = "Recibirás 1 punto de talento al subir de nivel.";
            youCanSpend.text = "Puedes usar puntos para revelar cartas de talento y elegir 1 de 3.";
            talentCardsProvide.text = "Las cartas de talento dan mejoras permanentes. Cada carta aumenta tu nivel de talento, subiendo la durabilidad de las rocas en 2. Pasa el cursor sobre el nivel para ver la durabilidad.";
        }
        #endregion

        #region Japanese
        if (isJapanese == true)
        {
            ok = "OK";

            artifactsTut.text = "アーティファクト！";
            hereYouCanView.text = "ここでは見つけたアーティファクトを確認できます。";
            artifactsHave.text = "アーティファクトは岩にくっついている可能性があります。";
            everyArtifact.text = "すべてのアーティファクトはパッシブ効果を提供します。";

            theMineTut.text = "マイン！";
            onceYouHave.text = "マインを購入すると、自動的に岩を採掘してくれます。";
            theMineWill.text = "マインは鉱石ではなくバーを採掘します。";
            thePercentage.text = "左側のバー合計の上に表示されているパーセンテージは、マインがその素材を採掘する確率です。";

            theAnvilTut.text = "金床！";
            hereYouCan.text = "ここでは新しいピッケルを作れます！";
            eachPickaxe.text = "各ピッケルには特定の素材が必要です。";
            eachNew.text = "新しいピッケルには異なるステータスがあります。スキルツリーで強化可能です。";

            oreAndBars.text = "鉱石とバー！";
            youWill.text = "岩を採掘すると鉱石を獲得できます。";
            thereAre.text = "3種類の岩が出現します：通常の岩、塊の岩、完全素材の岩です。";
            normalRocks.text = "通常の岩は必ず金鉱石を1つ落とします。塊の岩は3つ、完全素材の岩は7つ落とします。";
            oresWillBe.text = "鉱石は自動でバーに精製されます。3つの鉱石で1バーが作られます。1～2個余っていても1バー作られます。例：鉱石10個 → バー4個。";

            welcomeTo.text = "Keep on Mining! へようこそ！";
            theGameIsSimple.text = "ゲームはシンプルです。採掘セッションが始まったら、カーソルを岩に当てて採掘します。";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "カーソルの周りに円が表示されます。これが採掘エリアです。エリア内の岩は自動でピッケルが採掘してくれます。";
            }
            else
            {
                aCircle.text = "画面をタップした場所に円が追従します。これが採掘エリアです。採掘エリア内の岩からは、あなたの代わりに採掘するツルハシが出現します。";
            }
         
            onceThe.text = "右上のタイマーが0になると採掘セッションは終了です。";

            levelAndTalent.text = "レベルアップとタレントカード！";
            everyMined.text = "岩を採掘するとXPがもらえます。";
            youWillReceive.text = "レベルアップすると1ポイントのタレントポイントを獲得できます。";
            youCanSpend.text = "タレントポイントを使ってカードを開き、3枚から1枚を選びます。";
            talentCardsProvide.text = "タレントカードは強力で恒久的な効果を与えます。選択するとタレントレベルが上がり、岩の耐久度が2増加します。タレントレベルにカーソルを当てると現在の耐久度が見れます。";
        }
        #endregion

        #region Korean
        if (isKorean == true)
        {
            ok = "OK";

            artifactsTut.text = "유물!";
            hereYouCanView.text = "여기서 발견한 모든 유물을 확인할 수 있습니다.";
            artifactsHave.text = "유물은 바위에 붙어 있을 확률이 작게 있습니다.";
            everyArtifact.text = "모든 유물은 영구적인 버프를 제공합니다.";

            theMineTut.text = "마인!";
            onceYouHave.text = "마인을 구매하면 자동으로 바위를 채굴합니다.";
            theMineWill.text = "마인은 광석 대신 바를 채굴합니다.";
            thePercentage.text = "왼쪽의 바 총량 위에 있는 확률은 마인이 해당 자원을 채굴할 확률입니다.";

            theAnvilTut.text = "모루!";
            hereYouCan.text = "여기서 새로운 곡괭이를 제작할 수 있습니다!";
            eachPickaxe.text = "각 곡괭이는 제작에 필요한 특정 자원이 있습니다.";
            eachNew.text = "새 곡괭이는 각기 다른 스탯을 가지고 있으며, 스킬 트리 업그레이드로 강화할 수 있습니다.";

            oreAndBars.text = "광석과 바!";
            youWill.text = "바위를 채굴하면 광석을 획득합니다.";
            thereAre.text = "바위는 일반 바위, 덩어리 바위, 완전 자원 바위의 3종류가 있습니다.";
            normalRocks.text = "일반 바위는 항상 금광석 1개를 줍니다. 덩어리 바위는 3개, 완전 자원 바위는 7개를 줍니다.";
            oresWillBe.text = "광석은 자동으로 바가 됩니다. 3개의 광석이 1개의 바로 제작됩니다. 1~2개의 잉여 광석이 있으면 1개의 추가 바가 만들어집니다. 예: 광석 10개 → 바 4개.";

            welcomeTo.text = "Keep on Mining!에 오신 것을 환영합니다!";
            theGameIsSimple.text = "게임은 간단합니다. 채굴 세션이 시작되면 커서를 바위 위에 올려 채굴하세요.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "커서를 따라 원이 움직입니다. 이 원이 채굴 구역이며, 구역 안의 바위는 곡괭이가 자동으로 채굴합니다.";
            }
            else
            {
                aCircle.text = "화면을 터치한 곳을 따라 원이 이동하며, 이것이 채굴 구역입니다. 채굴 구역 안의 바위에서는 곡괭이가 생성되어 대신 채굴해 줍니다.";
            }

            onceThe.text = "우측 상단의 타이머가 0이 되면 채굴 세션이 종료됩니다.";

            levelAndTalent.text = "레벨업과 탈렌트 카드!";
            everyMined.text = "채굴한 바위마다 XP를 얻습니다.";
            youWillReceive.text = "레벨업 시 1개의 탈렌트 포인트를 획득합니다.";
            youCanSpend.text = "탈렌트 포인트로 카드를 열어 3장 중 1장을 선택할 수 있습니다.";
            talentCardsProvide.text = "탈렌트 카드는 강력하고 영구적인 버프를 제공합니다. 선택하면 탈렌트 레벨이 오르고, 바위 내구도가 2 증가합니다. 탈렌트 레벨에 마우스를 올리면 현재 내구도를 볼 수 있습니다.";
        }
        #endregion

        #region Polish
        if (isPolish == true)
        {
            ok = "OK";

            artifactsTut.text = "Artefakty!";
            hereYouCanView.text = "Tutaj możesz zobaczyć wszystkie znalezione artefakty.";
            artifactsHave.text = "Artefakty mają małą szansę być w środku skały.";
            everyArtifact.text = "Każdy artefakt daje pasywny bonus.";

            theMineTut.text = "Kopalnia!";
            onceYouHave.text = "Po zakupie Kopalnia automatycznie wydobywa skały za ciebie.";
            theMineWill.text = "Kopalnia wydobywa sztabki zamiast rud.";
            thePercentage.text = "Procenty nad ramkami sztabek po lewej pokazują szansę Kopalni na wydobycie danego materiału.";

            theAnvilTut.text = "Kowadło!";
            hereYouCan.text = "Tutaj możesz tworzyć nowe kilofy!";
            eachPickaxe.text = "Każdy kilof wymaga konkretnego materiału do stworzenia.";
            eachNew.text = "Każdy nowy kilof ma inne statystyki. Statystyki możesz zwiększyć w Drzewku Umiejętności.";

            oreAndBars.text = "Rudy i sztabki!";
            youWill.text = "Otrzymujesz rudy z wydobywania skał.";
            thereAre.text = "Są 3 typy skał: normalne, kawałkowe i pełne skały materiałowe.";
            normalRocks.text = "Normalne skały zawsze dają 1 rudę złota. Kawałkowe dają 3, a pełne 7.";
            oresWillBe.text = "Rudy automatycznie przerabiane są na sztabki. 3 rudy = 1 sztabka. Jeśli zostanie 1–2 rudy, powstanie dodatkowa sztabka. Przykład: 10 rud = 4 sztabki.";

            welcomeTo.text = "Witamy w Keep on Mining!";
            theGameIsSimple.text = "Gra jest prosta. Gdy sesja się zacznie, najedź kursorem na skały, by je wydobywać.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Kółko podąża za kursorem – to strefa wydobycia. Skały w środku będą wydobywane przez kilofy.";
            }
            else
            {
                aCircle.text = "Okrąg będzie podążał za miejscem, w którym dotkniesz ekranu – to jest obszar wydobycia. Skały wewnątrz tego obszaru wygenerują kilofy, które będą dla ciebie kopać.";
            }
          
            onceThe.text = "Gdy licznik w prawym górnym rogu dojdzie do zera, sesja się kończy.";

            levelAndTalent.text = "Poziomy i karty talentów!";
            everyMined.text = "Każda wydobyta skała daje XP.";
            youWillReceive.text = "Po awansie dostajesz 1 punkt talentu.";
            youCanSpend.text = "Punkty talentu wydajesz, by odkryć karty i wybrać 1 z 3.";
            talentCardsProvide.text = "Karty talentów dają trwałe bonusy. Każda karta podnosi twój poziom talentu, zwiększając wytrzymałość skał o 2. Najedź na poziom talentu, by sprawdzić wytrzymałość.";
        }
        #endregion

        #region Portugese
        if (isPortugese == true)
        {
            ok = "OK";

            artifactsTut.text = "Artefatos!";
            hereYouCanView.text = "Aqui você pode ver todos os artefatos encontrados.";
            artifactsHave.text = "Os artefatos têm uma pequena chance de estar dentro de uma rocha.";
            everyArtifact.text = "Cada artefato fornece um bônus passivo.";

            theMineTut.text = "A Mina!";
            onceYouHave.text = "Quando você compra a Mina, ela minerará rochas automaticamente para você.";
            theMineWill.text = "A Mina minera barras em vez de minérios.";
            thePercentage.text = "As porcentagens acima dos quadros de barras à esquerda mostram a chance da Mina minerar cada tipo de material.";

            theAnvilTut.text = "A Bigorna!";
            hereYouCan.text = "Aqui você pode forjar novas picaretas!";
            eachPickaxe.text = "Cada picareta precisa de um tipo específico de material para ser forjada.";
            eachNew.text = "Cada nova picareta tem estatísticas diferentes. As estatísticas podem ser melhoradas pela Árvore de Habilidades.";

            oreAndBars.text = "Minérios e barras!";
            youWill.text = "Você recebe minérios ao minerar rochas.";
            thereAre.text = "Existem 3 tipos de rochas: normais, com fragmentos e rochas totalmente de material.";
            normalRocks.text = "Rochas normais sempre soltam 1 minério de ouro. Rochas com fragmentos soltam 3 e rochas completas soltam 7.";
            oresWillBe.text = "Os minérios são automaticamente forjados em barras. 3 minérios = 1 barra. Se você tiver 1 ou 2 extras, ainda forja 1 barra a mais. Exemplo: 10 minérios = 4 barras.";

            welcomeTo.text = "Bem-vindo ao Keep on Mining!";
            theGameIsSimple.text = "O jogo é simples. Quando a sessão começar, passe o cursor sobre as rochas para minerar.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Um círculo seguirá o cursor — essa é sua área de mineração. Rochas dentro dela geram picaretas automaticamente.";
            }
            else
            {
                aCircle.text = "Um círculo seguirá o local onde você tocar na tela, esta é a área de mineração. As rochas dentro da área farão surgir picaretas que mineram para você.";
            }

            onceThe.text = "Quando o cronômetro no canto superior direito chegar a 0, a sessão termina.";

            levelAndTalent.text = "Suba de nível e use cartas de talento!";
            everyMined.text = "Cada rocha minerada fornece XP.";
            youWillReceive.text = "Você recebe 1 ponto de talento ao subir de nível.";
            youCanSpend.text = "Você pode gastar pontos para revelar cartas de talento e escolher 1 entre 3.";
            talentCardsProvide.text = "As cartas de talento dão bônus permanentes. Cada carta aumenta seu nível de talento, o que aumenta a durabilidade das rochas em 2. Passe o cursor sobre o nível de talento para ver a durabilidade atual.";
        }
        #endregion

        #region Russian
        if (isRussian == true)
        {
            ok = "OK";

            artifactsTut.text = "Артефакты!";
            hereYouCanView.text = "Здесь вы можете просмотреть все найденные артефакты.";
            artifactsHave.text = "Артефакты могут быть с небольшой вероятностью внутри камня.";
            everyArtifact.text = "Каждый артефакт даёт вам пассивный бонус.";

            theMineTut.text = "Шахта!";
            onceYouHave.text = "После покупки Шахта будет автоматически добывать камни за вас.";
            theMineWill.text = "Шахта добывает слитки вместо руды.";
            thePercentage.text = "Проценты над рамками слитков слева показывают шанс Шахты добыть этот материал.";

            theAnvilTut.text = "Наковальня!";
            hereYouCan.text = "Здесь можно создавать новые кирки!";
            eachPickaxe.text = "Каждая кирка требует особый материал для создания.";
            eachNew.text = "Каждая новая кирка имеет свои характеристики. Их можно улучшать через Дерево Умений.";

            oreAndBars.text = "Руда и слитки!";
            youWill.text = "Вы получаете руду, добывая камни.";
            thereAre.text = "Существует 3 типа камней: обычные, с включениями и полностью из материала.";
            normalRocks.text = "Обычные камни всегда дают 1 золотую руду. Камни с включениями — 3, полностью из материала — 7.";
            oresWillBe.text = "Руда автоматически переплавляется в слитки. 3 руды = 1 слиток. Если остаётся 1–2 руды, создается ещё 1 слиток. Пример: 10 руды = 4 слитка.";

            welcomeTo.text = "Добро пожаловать в Keep on Mining!";
            theGameIsSimple.text = "Игра проста. Когда начинается сессия, наведите курсор на камни, чтобы их добывать.";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "Вокруг курсора будет круг — это область добычи. Камни внутри круга автоматически добываются кирками.";
            }
            else
            {
                aCircle.text = "Круг будет следовать за местом, где вы коснулись экрана — это зона добычи. Камни внутри этой зоны будут создавать кирки, которые добывают за вас.";
            }

            onceThe.text = "Когда таймер в правом верхнем углу дойдет до нуля, сессия завершается.";

            levelAndTalent.text = "Уровень и карты талантов!";
            everyMined.text = "Каждый добытый камень даёт XP.";
            youWillReceive.text = "При повышении уровня вы получаете 1 очко таланта.";
            youCanSpend.text = "Вы можете потратить очки, чтобы открыть карты и выбрать 1 из 3.";
            talentCardsProvide.text = "Карты талантов дают постоянные бонусы. Каждая карта увеличивает уровень таланта и прочность камней на 2. Наведите курсор на уровень таланта, чтобы увидеть прочность.";
        }
        #endregion

        #region SimplifiedChinese
        if (isSimplefiedChinese == true)
        {
            ok = "好的";

            artifactsTut.text = "神器！";
            hereYouCanView.text = "你可以在这里查看所有已找到的神器。";
            artifactsHave.text = "神器有小概率附着在石头上。";
            everyArtifact.text = "每个神器都会提供一个被动增益效果。";

            theMineTut.text = "矿井！";
            onceYouHave.text = "购买矿井后，它会自动为你开采石头。";
            theMineWill.text = "矿井直接开采锭而不是矿石。";
            thePercentage.text = "左侧总锭数量框上方的百分比显示矿井开采该材料的概率。";

            theAnvilTut.text = "铁砧！";
            hereYouCan.text = "你可以在这里打造新的镐！";
            eachPickaxe.text = "每把镐需要特定材料才能打造。";
            eachNew.text = "每把新镐都有不同的属性，可通过技能树升级进一步提升。";

            oreAndBars.text = "矿石与锭！";
            youWill.text = "采矿石时，你会获得矿石。";
            thereAre.text = "游戏中有三种石头：普通石、矿块石和纯矿石。";
            normalRocks.text = "普通石头总是掉落1个金矿石，矿块石掉落3个，纯矿石掉落7个。";
            oresWillBe.text = "矿石会自动锻造成锭。3个矿石 = 1个锭。如果余下1–2个矿石，也会额外锻造1个锭。示例：10个矿石 = 4个锭。";

            welcomeTo.text = "欢迎来到 Keep on Mining!";
            theGameIsSimple.text = "玩法很简单。矿工开始后，将鼠标悬停在石头上即可开采。";

            if (MobileAndTesting.isMobile == false)
            {
                aCircle.text = "光标周围有一个圆圈，这是采矿范围。范围内的石头会自动生成镐来帮你开采。";
            }
            else
            {
                aCircle.text = "一个圆圈会跟随你点击屏幕的位置，这就是采矿区域。采矿区域内的岩石会生成镐子来为你挖矿。";
            }
         
            onceThe.text = "右上角的计时器归零时，采矿阶段结束。";

            levelAndTalent.text = "升级与天赋卡！";
            everyMined.text = "每采矿石可获得 XP。";
            youWillReceive.text = "每次升级可获得1点天赋点数。";
            youCanSpend.text = "你可以使用天赋点数解锁天赋卡，并从3张卡中选择1张。";
            talentCardsProvide.text = "天赋卡提供永久性增益。选择后，天赋等级会提升，石头耐久度增加2点。将鼠标悬停在天赋等级上可查看当前耐久度。";
        }
        #endregion

        okArtifacts.text = ok;
        okTheMine.text = ok;
        okTheAnvil.text = ok;
        okTalent.text = ok;
        okWelcomeTo.text = ok;
        ok_materialOres.text = ok;
        ok_EndlessOpoUP.text = ok;
    }
    #endregion

    #region Ending texts
    public TextMeshProUGUI craftPickaxe, youCraftedDiamond, thankYOuForPlaying, developedByEnd, musicByEnd, customArtByEnd, againThankYou, aSteamReview, alsoJoin, whatWouldDoNext, exitGameCredits, keepOnMiningCredits;

    public void EndingTexts()
    {
        #region English
        if (isEnglish == true)
        {
            craftPickaxe.text = "Craft Pickaxe";
            youCraftedDiamond.text = "<wave>You crafted the Diamond Pickaxe!</wave>";
            thankYOuForPlaying.text = "<wave>Thank you for playing:</wave>";
            developedByEnd.text = "Developed by: EagleEye Games";
            musicByEnd.text = $"Music by: {musicCreditName1}";
            customArtByEnd.text = "Custom art by: Artisgamemobile";
            againThankYou.text = "Again, thank you for playing Keep on Mining!";
            aSteamReview.text = "A steam review with your thoughts of the game would be much appreciated :)";
            alsoJoin.text = "Also join our Discord and check out more games from EagleEye Games!! :)\n(The icons can be clicked)";
            whatWouldDoNext.text = "What would you like to do next?";
            exitGameCredits.text = "Exit Game";
            keepOnMiningCredits.text = "Keep on Mining!";
        }
        #endregion

        #region French
        if (isFrench == true)
        {
            craftPickaxe.text = "Forger une pioche";
            youCraftedDiamond.text = "<wave>Vous avez forgé la Pioche en diamant !</wave>";
            thankYOuForPlaying.text = "<wave>Merci d'avoir joué :</wave>";
            developedByEnd.text = "Développé par : EagleEye Games";
            musicByEnd.text = $"Musique par : {musicCreditName1}";
            customArtByEnd.text = "Art personnalisé par : Artisgamemobile";
            againThankYou.text = "Encore merci d'avoir joué à Keep on Mining!";
            aSteamReview.text = "Un avis Steam avec vos impressions serait grandement apprécié :)";
            alsoJoin.text = "Rejoignez aussi notre Discord et découvrez d'autres jeux de EagleEye Games !! :)\n(Les icônes sont cliquables)";
            whatWouldDoNext.text = "Que souhaitez-vous faire ensuite ?";
            exitGameCredits.text = "Quitter le jeu";
            keepOnMiningCredits.text = "ALLER MINER !";
        }
        #endregion

        #region Italian
        if (isItalian == true)
        {
            craftPickaxe.text = "Crea una piccone";
            youCraftedDiamond.text = "<wave>Hai creato il Piccone di Diamante!</wave>";
            thankYOuForPlaying.text = "<wave>Grazie per aver giocato:</wave>";
            developedByEnd.text = "Sviluppato da: EagleEye Games";
            musicByEnd.text = $"Musica di: {musicCreditName1}";
            customArtByEnd.text = "Arte personalizzata di: Artisgamemobile";
            againThankYou.text = "Ancora una volta, grazie per aver giocato a Keep on Mining!";
            aSteamReview.text = "Una recensione su Steam con le tue opinioni sarebbe molto apprezzata :)";
            alsoJoin.text = "Unisciti anche al nostro Discord e scopri altri giochi di EagleEye Games!! :)\n(Le icone sono cliccabili)";
            whatWouldDoNext.text = "Cosa vuoi fare ora?";
            exitGameCredits.text = "Esci dal gioco";
            keepOnMiningCredits.text = "VAI A MINARE!";
        }
        #endregion

        #region German
        if (isGerman == true)
        {
            craftPickaxe.text = "Spitzhacke schmieden";
            youCraftedDiamond.text = "<wave>Du hast die Diamant-Spitzhacke geschmiedet!</wave>";
            thankYOuForPlaying.text = "<wave>Danke fürs Spielen:</wave>";
            developedByEnd.text = "Entwickelt von: EagleEye Games";
            musicByEnd.text = $"Musik von: {musicCreditName1}";
            customArtByEnd.text = "Individuelle Kunst von: Artisgamemobile";
            againThankYou.text = "Nochmals vielen Dank, dass du Keep on Mining! gespielt hast!";
            aSteamReview.text = "Eine Steam-Rezension mit deinen Gedanken zum Spiel wäre sehr willkommen :)";
            alsoJoin.text = "Tritt auch unserem Discord bei und entdecke weitere Spiele von EagleEye Games!! :)\n(Die Symbole sind anklickbar)";
            whatWouldDoNext.text = "Was möchtest du als Nächstes tun?";
            exitGameCredits.text = "Spiel beenden";
            keepOnMiningCredits.text = "AB IN DIE MINE!";
        }
        #endregion

        #region Spanish
        if (isSpanish == true)
        {
            craftPickaxe.text = "Forjar pico";
            youCraftedDiamond.text = "<wave>¡Has forjado el Pico de Diamante!</wave>";
            thankYOuForPlaying.text = "<wave>Gracias por jugar:</wave>";
            developedByEnd.text = "Desarrollado por: EagleEye Games";
            musicByEnd.text = $"Música por: {musicCreditName1}";
            customArtByEnd.text = "Arte personalizado por: Artisgamemobile";
            againThankYou.text = "Una vez más, gracias por jugar a Keep on Mining!";
            aSteamReview.text = "Una reseña en Steam con tu opinión sería muy apreciada :)";
            alsoJoin.text = "Únete a nuestro Discord y descubre más juegos de EagleEye Games!! :)\n(Los iconos son clicables)";
            whatWouldDoNext.text = "¿Qué te gustaría hacer ahora?";
            exitGameCredits.text = "Salir del juego";
            keepOnMiningCredits.text = "¡A MINAR!";
        }
        #endregion

        #region Japanese
        if (isJapanese == true)
        {
            craftPickaxe.text = "ピッケルを作る";
            youCraftedDiamond.text = "<wave>ダイヤモンドピッケルを作りました！</wave>";
            thankYOuForPlaying.text = "<wave>プレイしてくれてありがとう：</wave>";
            developedByEnd.text = "開発: EagleEye Games";
            musicByEnd.text = $"音楽: {musicCreditName1}";
            customArtByEnd.text = "カスタムアート: Artisgamemobile";
            againThankYou.text = "改めて、Keep on Mining! をプレイしてくれてありがとう！";
            aSteamReview.text = "Steamで感想を書いていただけるととても嬉しいです :)";
            alsoJoin.text = "ぜひDiscordに参加して、他のEagleEye Gamesのゲームもチェックしてください！！ :)\n（アイコンはクリックできます）";
            whatWouldDoNext.text = "次は何をしますか？";
            exitGameCredits.text = "ゲーム終了";
            keepOnMiningCredits.text = "採掘開始！";
        }
        #endregion

        #region Korean
        if (isKorean == true)
        {
            craftPickaxe.text = "곡괭이 제작";
            youCraftedDiamond.text = "<wave>다이아몬드 곡괭이를 제작했습니다!</wave>";
            thankYOuForPlaying.text = "<wave>플레이해 주셔서 감사합니다:</wave>";
            developedByEnd.text = "개발: EagleEye Games";
            musicByEnd.text = $"음악: {musicCreditName1}";
            customArtByEnd.text = "커스텀 아트: Artisgamemobile";
            againThankYou.text = "다시 한 번, Keep on Mining! 을 플레이해 주셔서 감사합니다!";
            aSteamReview.text = "Steam 리뷰로 게임에 대한 생각을 남겨주시면 큰 힘이 됩니다 :)";
            alsoJoin.text = "Discord에도 참여하고 EagleEye Games의 다른 게임도 확인해 보세요!! :)\n(아이콘은 클릭할 수 있습니다)";
            whatWouldDoNext.text = "이제 무엇을 하시겠습니까?";
            exitGameCredits.text = "게임 종료";
            keepOnMiningCredits.text = "채굴하러 가자!";
        }
        #endregion

        #region Polish
        if (isPolish == true)
        {
            craftPickaxe.text = "Stwórz kilof";
            youCraftedDiamond.text = "<wave>Stworzyłeś Diamentowy Kilof!</wave>";
            thankYOuForPlaying.text = "<wave>Dzięki za grę:</wave>";
            developedByEnd.text = "Twórca: EagleEye Games";
            musicByEnd.text = $"Muzyka: {musicCreditName1}";
            customArtByEnd.text = "Grafika: Artisgamemobile";
            againThankYou.text = "Jeszcze raz dzięki za grę w Keep on Mining!";
            aSteamReview.text = "Recenzja na Steamie z twoją opinią byłaby super mile widziana :)";
            alsoJoin.text = "Dołącz też na naszego Discorda i sprawdź inne gry od EagleEye Games!! :)\n(Ikony są klikalne)";
            whatWouldDoNext.text = "Co chcesz zrobić teraz?";
            exitGameCredits.text = "Wyjdź z gry";
            keepOnMiningCredits.text = "IDŹ KOPAĆ!";
        }
        #endregion

        #region Portugese
        if (isPortugese == true)
        {
            craftPickaxe.text = "Forjar Picareta";
            youCraftedDiamond.text = "<wave>Você forjou a Picareta de Diamante!</wave>";
            thankYOuForPlaying.text = "<wave>Obrigado por jogar:</wave>";
            developedByEnd.text = "Desenvolvido por: EagleEye Games";
            musicByEnd.text = $"Música por: {musicCreditName1}";
            customArtByEnd.text = "Arte customizada por: Artisgamemobile";
            againThankYou.text = "Mais uma vez, obrigado por jogar Keep on Mining!";
            aSteamReview.text = "Uma avaliação na Steam com sua opinião sobre o jogo seria muito bem-vinda :)";
            alsoJoin.text = "Junte-se também ao nosso Discord e conheça mais jogos da EagleEye Games!! :)\n(Os ícones são clicáveis)";
            whatWouldDoNext.text = "O que você quer fazer agora?";
            exitGameCredits.text = "Sair do jogo";
            keepOnMiningCredits.text = "VÁ MINERAR!";
        }
        #endregion

        #region Russian
        if (isRussian == true)
        {
            craftPickaxe.text = "Создать кирку";
            youCraftedDiamond.text = "<wave>Вы создали Алмазную Кирку!</wave>";
            thankYOuForPlaying.text = "<wave>Спасибо за игру:</wave>";
            developedByEnd.text = "Разработано: EagleEye Games";
            musicByEnd.text = $"Музыка: {musicCreditName1}";
            customArtByEnd.text = "Кастом арт: Artisgamemobile";
            againThankYou.text = "Снова спасибо, что играли в Keep on Mining!";
            aSteamReview.text = "Будем очень признательны за отзыв в Steam с вашими впечатлениями :)";
            alsoJoin.text = "Также присоединяйтесь к нашему Discord и смотрите другие игры от EagleEye Games!! :)\n(Иконки можно кликать)";
            whatWouldDoNext.text = "Что хотите сделать дальше?";
            exitGameCredits.text = "Выйти из игры";
            keepOnMiningCredits.text = "ВПЕРЁД ДОБЫВАТЬ!";
        }
        #endregion

        #region SimplifiedChinese
        if (isSimplefiedChinese == true)
        {
            craftPickaxe.text = "锻造镐";
            youCraftedDiamond.text = "<wave>你锻造了钻石镐！</wave>";
            thankYOuForPlaying.text = "<wave>感谢游玩：</wave>";
            developedByEnd.text = "开发者: EagleEye Games";
            musicByEnd.text = $"音乐: {musicCreditName1}";
            customArtByEnd.text = "美术: Artisgamemobile";
            againThankYou.text = "再次感谢你游玩 Keep on Mining!";
            aSteamReview.text = "如果能在Steam上留下你的评论，我们会非常感激 :)";
            alsoJoin.text = "欢迎加入我们的Discord并探索更多 EagleEye Games 的游戏！！ :)\n（图标可点击）";
            whatWouldDoNext.text = "接下来你想做什么？";
            exitGameCredits.text = "退出游戏";
            keepOnMiningCredits.text = "开始挖矿！";
        }
        #endregion
    }
    #endregion

    #region Stats texts
    public TextMeshProUGUI potionsDrank;
    public TextMeshProUGUI chestsOpened;
    public TextMeshProUGUI goldenChestsOpened;
    public TextMeshProUGUI theMine2XTriggered;
    public TextMeshProUGUI theMineDoubleTriggered;
    public TextMeshProUGUI inflateBurstTriggered;
    public TextMeshProUGUI hammersSpawned;
    public TextMeshProUGUI midasTouchSessions;
    public TextMeshProUGUI zeusTriggers;
    public TextMeshProUGUI energiDrinksDrank;
    public TextMeshProUGUI flowersSpawned;
    public TextMeshProUGUI campfiresSpawned;
    public TextMeshProUGUI d100Rolls;

    public TextMeshProUGUI miningSessions, timeSpentMining, totalRocksSpawned, totalRocksMined, pickaxeSpawned, pickaxeHits, oresMined, barsBrafted, bardMinedTheMine, xpGained, totalLevelUps, doubleOredGained, doubleXpGained, X2pickaxePowerHits, instaMineHits;
    public TextMeshProUGUI lightningStrikes;
    public TextMeshProUGUI dynamiteExplosions;
    public TextMeshProUGUI plazmaBallsSpawned;

    public TextMeshProUGUI goldChunkRocks, fullGoldRocks;
    public TextMeshProUGUI copperChunkMined;
    public TextMeshProUGUI fullCopperMined;
    public TextMeshProUGUI ironChunkMined;
    public TextMeshProUGUI fullIronMined;
    public TextMeshProUGUI cobaltChunkMined;
    public TextMeshProUGUI fullCobaltMined;
    public TextMeshProUGUI uraniumChunkMined;
    public TextMeshProUGUI fullUraniumMined;
    public TextMeshProUGUI ismiumChunkMined;
    public TextMeshProUGUI fullIsmiumMined;
    public TextMeshProUGUI iridiumChunkMined;
    public TextMeshProUGUI fullIridiumMined;
    public TextMeshProUGUI painiteChunkMined;
    public TextMeshProUGUI fullPainiteMined;

    public TextMeshProUGUI talentStats, globalStats, rocksMinedStats;

    public void StatsText()
    {
        #region English
        if (isEnglish == true)
        {
            talentStats.text = "Talent Stats";
            globalStats.text = "Global Stats";
            rocksMinedStats.text = "Rocks Mined Stats";

            potionsDrank.text = "Potions drank:";
            chestsOpened.text = "Regular chests opened:";
            goldenChestsOpened.text = "Golden chests opened:";
            theMine2XTriggered.text = "The Mine 2X speed triggers:";
            theMineDoubleTriggered.text = "The Mine double ore triggers:";
            inflateBurstTriggered.text = "Inflate Burst triggers:";
            hammersSpawned.text = "Hammers spawned:";
            midasTouchSessions.text = "Midas touch sessions:";
            zeusTriggers.text = "Zeus triggers:";
            energiDrinksDrank.text = "Energy drinks drank:";
            flowersSpawned.text = "Flowers spawned:";
            campfiresSpawned.text = "Campfires spawned:";
            d100Rolls.text = "D100, total 1, 10 or 100 rolls:";

            miningSessions.text = "Mining sessions:";
            timeSpentMining.text = "Time spent mining:";
            totalRocksSpawned.text = "Total rocks spawned:";
            totalRocksMined.text = "Total rocks mined:";
            pickaxeSpawned.text = "Pickaxes spawned:";
            pickaxeHits.text = "Pickaxe hits:";
            oresMined.text = "Ores mined:";
            barsBrafted.text = "Bars crafted:";
            bardMinedTheMine.text = "Bars mined (The Mine)";
            xpGained.text = "XP gained:";
            totalLevelUps.text = "Total level ups:";
            doubleXpGained.text = "Double XP gained:";
            doubleOredGained.text = "Double ores gained:";
            X2pickaxePowerHits.text = "2X pickaxe power hits:";
            instaMineHits.text = "Insta mine pickaxe hits:";
            lightningStrikes.text = "Lightning strikes:";
            dynamiteExplosions.text = "Dynamite explosions:";
            plazmaBallsSpawned.text = "Plazma balls spawned:";

            goldChunkRocks.text = "Golden chunk rocks:";
            fullGoldRocks.text = "Full gold rocks:";
            copperChunkMined.text = "Copper chunk rocks:";
            fullCopperMined.text = "Full copper rocks:";
            ironChunkMined.text = "Iron chunk rocks:";
            fullIronMined.text = "Full iron rocks:";
            cobaltChunkMined.text = "Cobalt chunk rocks:";
            fullCobaltMined.text = "Full cobalt rocks:";
            uraniumChunkMined.text = "Uranium chunk rocks:";
            fullUraniumMined.text = "Full uranium rocks:";
            ismiumChunkMined.text = "Ismium chunk rocks:";
            fullIsmiumMined.text = "Full ismium rocks:";
            iridiumChunkMined.text = "Iridium chunk rocks:";
            fullIridiumMined.text = "Full iridium rocks:";
            painiteChunkMined.text = "Painite chunk rocks:";
            fullPainiteMined.text = "Full painite rocks:";
        }
        #endregion

        #region French
        if (isFrench == true)
        {
            talentStats.text = "Stats de talent";
            globalStats.text = "Stats globales";
            rocksMinedStats.text = "Stats de roches minées";

            potionsDrank.text = "Potions bues :";
            chestsOpened.text = "Coffres normaux ouverts :";
            goldenChestsOpened.text = "Coffres dorés ouverts :";
            theMine2XTriggered.text = "Déclenchements 2X vitesse (La Mine) :";
            theMineDoubleTriggered.text = "Déclenchements double minerai (La Mine) :";
            inflateBurstTriggered.text = "Déclenchements d’Inflate Burst :";
            hammersSpawned.text = "Marteaux apparus :";
            midasTouchSessions.text = "Sessions Midas Touch :";
            zeusTriggers.text = "Déclenchements de Zeus :";
            energiDrinksDrank.text = "Boissons énergétiques bues :";
            flowersSpawned.text = "Fleurs apparues :";
            campfiresSpawned.text = "Feux de camp apparus :";
            d100Rolls.text = "D100, total de lancers de 1, 10 ou 100 :";

            miningSessions.text = "Sessions de minage :";
            timeSpentMining.text = "Temps passé à miner :";
            totalRocksSpawned.text = "Total de roches apparues :";
            totalRocksMined.text = "Total de roches minées :";
            pickaxeSpawned.text = "Pioches apparues :";
            pickaxeHits.text = "Coups de pioche :";
            oresMined.text = "Minerais minés :";
            barsBrafted.text = "Lingots forgés :";
            bardMinedTheMine.text = "Lingots minés (La Mine) :";
            xpGained.text = "XP gagnée :";
            totalLevelUps.text = "Total de niveaux gagnés :";
            doubleXpGained.text = "XP doublée gagnée :";
            doubleOredGained.text = "Minerais doublés gagnés :";
            X2pickaxePowerHits.text = "Coups de pioche 2X puissance :";
            instaMineHits.text = "Coups de pioche Insta Mine :";
            lightningStrikes.text = "Foudres frappées :";
            dynamiteExplosions.text = "Explosions de dynamite :";
            plazmaBallsSpawned.text = "Boules de plasma apparues :";

            goldChunkRocks.text = "Roches dorées (morceaux) :";
            fullGoldRocks.text = "Roches dorées complètes :";
            copperChunkMined.text = "Roches de cuivre (morceaux) :";
            fullCopperMined.text = "Roches de cuivre complètes :";
            ironChunkMined.text = "Roches de fer (morceaux) :";
            fullIronMined.text = "Roches de fer complètes :";
            cobaltChunkMined.text = "Roches de cobalt (morceaux) :";
            fullCobaltMined.text = "Roches de cobalt complètes :";
            uraniumChunkMined.text = "Roches d’uranium (morceaux) :";
            fullUraniumMined.text = "Roches d’uranium complètes :";
            ismiumChunkMined.text = "Roches d’ismium (morceaux) :";
            fullIsmiumMined.text = "Roches d’ismium complètes :";
            iridiumChunkMined.text = "Roches d’iridium (morceaux) :";
            fullIridiumMined.text = "Roches d’iridium complètes :";
            painiteChunkMined.text = "Roches de painite (morceaux) :";
            fullPainiteMined.text = "Roches de painite complètes :";
        }
        #endregion

        #region Italian
        if (isItalian == true)
        {
            talentStats.text = "Statistiche Talento";
            globalStats.text = "Statistiche Globali";
            rocksMinedStats.text = "Statistiche Rocce Estratte";

            potionsDrank.text = "Pozioni bevute:";
            chestsOpened.text = "Forzieri normali aperti:";
            goldenChestsOpened.text = "Forzieri dorati aperti:";
            theMine2XTriggered.text = "Attivazioni velocità 2X (La Miniera):";
            theMineDoubleTriggered.text = "Attivazioni doppio minerale (La Miniera):";
            inflateBurstTriggered.text = "Attivazioni Inflate Burst:";
            hammersSpawned.text = "Martelli generati:";
            midasTouchSessions.text = "Sessioni Midas Touch:";
            zeusTriggers.text = "Attivazioni di Zeus:";
            energiDrinksDrank.text = "Energy drink bevuti:";
            flowersSpawned.text = "Fiori generati:";
            campfiresSpawned.text = "Falò accesi:";
            d100Rolls.text = "D100, totale tiri di 1, 10 o 100:";

            miningSessions.text = "Sessioni di miniera:";
            timeSpentMining.text = "Tempo trascorso a minare:";
            totalRocksSpawned.text = "Totale rocce generate:";
            totalRocksMined.text = "Totale rocce minate:";
            pickaxeSpawned.text = "Picconi generati:";
            pickaxeHits.text = "Colpi di piccone:";
            oresMined.text = "Minerali estratti:";
            barsBrafted.text = "Lingotti forgiati:";
            bardMinedTheMine.text = "Lingotti estratti (La Miniera):";
            xpGained.text = "XP guadagnata:";
            totalLevelUps.text = "Totale livelli saliti:";
            doubleXpGained.text = "XP doppi guadagnati:";
            doubleOredGained.text = "Minerali doppi guadagnati:";
            X2pickaxePowerHits.text = "Colpi di piccone 2X potenza:";
            instaMineHits.text = "Colpi di piccone Insta Mine:";
            lightningStrikes.text = "Fulmini colpiti:";
            dynamiteExplosions.text = "Esplosioni di dinamite:";
            plazmaBallsSpawned.text = "Sfere di plasma generate:";

            goldChunkRocks.text = "Rocce dorate (frammenti):";
            fullGoldRocks.text = "Rocce dorate complete:";
            copperChunkMined.text = "Rocce di rame (frammenti):";
            fullCopperMined.text = "Rocce di rame complete:";
            ironChunkMined.text = "Rocce di ferro (frammenti):";
            fullIronMined.text = "Rocce di ferro complete:";
            cobaltChunkMined.text = "Rocce di cobalto (frammenti):";
            fullCobaltMined.text = "Rocce di cobalto complete:";
            uraniumChunkMined.text = "Rocce di uranio (frammenti):";
            fullUraniumMined.text = "Rocce di uranio complete:";
            ismiumChunkMined.text = "Rocce di ismio (frammenti):";
            fullIsmiumMined.text = "Rocce di ismio complete:";
            iridiumChunkMined.text = "Rocce di iridio (frammenti):";
            fullIridiumMined.text = "Rocce di iridio complete:";
            painiteChunkMined.text = "Rocce di painite (frammenti):";
            fullPainiteMined.text = "Rocce di painite complete:";
        }
        #endregion

        #region German
        if (isGerman == true)
        {
            talentStats.text = "Talent-Statistiken";
            globalStats.text = "Globale Statistiken";
            rocksMinedStats.text = "Statistiken Abgebaute Steine";

            potionsDrank.text = "Getrunkene Tränke:";
            chestsOpened.text = "Geöffnete normale Truhen:";
            goldenChestsOpened.text = "Geöffnete goldene Truhen:";
            theMine2XTriggered.text = "Die Mine 2X Geschwindigkeit ausgelöst:";
            theMineDoubleTriggered.text = "Die Mine Doppel-Erz ausgelöst:";
            inflateBurstTriggered.text = "Inflate Burst ausgelöst:";
            hammersSpawned.text = "Gespawnte Hämmer:";
            midasTouchSessions.text = "Midas-Touch-Sitzungen:";
            zeusTriggers.text = "Zeus-Auslöser:";
            energiDrinksDrank.text = "Getrunkene Energy Drinks:";
            flowersSpawned.text = "Gespawnte Blumen:";
            campfiresSpawned.text = "Gespawnte Lagerfeuer:";
            d100Rolls.text = "D100, gesamt Würfe mit 1, 10 oder 100:";

            miningSessions.text = "Mining-Sitzungen:";
            timeSpentMining.text = "Gesamte Mining-Zeit:";
            totalRocksSpawned.text = "Gesamt gespawnte Steine:";
            totalRocksMined.text = "Gesamt abgebaut:";
            pickaxeSpawned.text = "Gespawnte Spitzhacken:";
            pickaxeHits.text = "Spitzhacken-Treffer:";
            oresMined.text = "Abgebaute Erze:";
            barsBrafted.text = "Geschmiedete Barren:";
            bardMinedTheMine.text = "Barren abgebaut (Die Mine):";
            xpGained.text = "Erhaltene XP:";
            totalLevelUps.text = "Gesamt Level-Ups:";
            doubleXpGained.text = "Doppelte XP erhalten:";
            doubleOredGained.text = "Doppelte Erze erhalten:";
            X2pickaxePowerHits.text = "2X Spitzhacken-Power Treffer:";
            instaMineHits.text = "Insta-Mine Spitzhacken-Treffer:";
            lightningStrikes.text = "Blitzeinschläge:";
            dynamiteExplosions.text = "Dynamit-Explosionen:";
            plazmaBallsSpawned.text = "Gespawnte Plasmabälle:";

            goldChunkRocks.text = "Goldene Brocken-Steine:";
            fullGoldRocks.text = "Volle Gold-Steine:";
            copperChunkMined.text = "Kupfer Brocken-Steine:";
            fullCopperMined.text = "Volle Kupfer-Steine:";
            ironChunkMined.text = "Eisen Brocken-Steine:";
            fullIronMined.text = "Volle Eisen-Steine:";
            cobaltChunkMined.text = "Kobalt Brocken-Steine:";
            fullCobaltMined.text = "Volle Kobalt-Steine:";
            uraniumChunkMined.text = "Uran Brocken-Steine:";
            fullUraniumMined.text = "Volle Uran-Steine:";
            ismiumChunkMined.text = "Ismium Brocken-Steine:";
            fullIsmiumMined.text = "Volle Ismium-Steine:";
            iridiumChunkMined.text = "Iridium Brocken-Steine:";
            fullIridiumMined.text = "Volle Iridium-Steine:";
            painiteChunkMined.text = "Painit Brocken-Steine:";
            fullPainiteMined.text = "Volle Painit-Steine:";
        }
        #endregion

        #region Spanish
        if (isSpanish == true)
        {
            talentStats.text = "Estadísticas de Talento";
            globalStats.text = "Estadísticas Globales";
            rocksMinedStats.text = "Estadísticas de Rocas Minadas";

            potionsDrank.text = "Pociones bebidas:";
            chestsOpened.text = "Cofres normales abiertos:";
            goldenChestsOpened.text = "Cofres dorados abiertos:";
            theMine2XTriggered.text = "Activaciones 2X velocidad (La Mina):";
            theMineDoubleTriggered.text = "Activaciones doble mineral (La Mina):";
            inflateBurstTriggered.text = "Activaciones de Inflate Burst:";
            hammersSpawned.text = "Martillos generados:";
            midasTouchSessions.text = "Sesiones de Toque de Midas:";
            zeusTriggers.text = "Activaciones de Zeus:";
            energiDrinksDrank.text = "Bebidas energéticas tomadas:";
            flowersSpawned.text = "Flores generadas:";
            campfiresSpawned.text = "Hogueras encendidas:";
            d100Rolls.text = "D100, total de tiradas de 1, 10 o 100:";

            miningSessions.text = "Sesiones de minería:";
            timeSpentMining.text = "Tiempo total minando:";
            totalRocksSpawned.text = "Total de rocas generadas:";
            totalRocksMined.text = "Total de rocas minadas:";
            pickaxeSpawned.text = "Picos generados:";
            pickaxeHits.text = "Golpes de pico:";
            oresMined.text = "Minerales extraídos:";
            barsBrafted.text = "Lingotes forjados:";
            bardMinedTheMine.text = "Lingotes extraídos (La Mina):";
            xpGained.text = "XP ganada:";
            totalLevelUps.text = "Total de niveles subidos:";
            doubleXpGained.text = "XP doble ganada:";
            doubleOredGained.text = "Minerales dobles ganados:";
            X2pickaxePowerHits.text = "Golpes de pico con 2X potencia:";
            instaMineHits.text = "Golpes de pico Insta Mine:";
            lightningStrikes.text = "Rayos invocados:";
            dynamiteExplosions.text = "Explosiones de dinamita:";
            plazmaBallsSpawned.text = "Bolas de plasma generadas:";

            goldChunkRocks.text = "Rocas de oro fragmentadas:";
            fullGoldRocks.text = "Rocas de oro completas:";
            copperChunkMined.text = "Rocas de cobre fragmentadas:";
            fullCopperMined.text = "Rocas de cobre completas:";
            ironChunkMined.text = "Rocas de hierro fragmentadas:";
            fullIronMined.text = "Rocas de hierro completas:";
            cobaltChunkMined.text = "Rocas de cobalto fragmentadas:";
            fullCobaltMined.text = "Rocas de cobalto completas:";
            uraniumChunkMined.text = "Rocas de uranio fragmentadas:";
            fullUraniumMined.text = "Rocas de uranio completas:";
            ismiumChunkMined.text = "Rocas de ismio fragmentadas:";
            fullIsmiumMined.text = "Rocas de ismio completas:";
            iridiumChunkMined.text = "Rocas de iridio fragmentadas:";
            fullIridiumMined.text = "Rocas de iridio completas:";
            painiteChunkMined.text = "Rocas de painita fragmentadas:";
            fullPainiteMined.text = "Rocas de painita completas:";
        }
        #endregion

        #region Japanese
        if (isJapanese == true)
        {
            talentStats.text = "タレント統計";
            globalStats.text = "グローバル統計";
            rocksMinedStats.text = "採掘した岩 統計";

            potionsDrank.text = "飲んだポーション：";
            chestsOpened.text = "開けた通常の宝箱：";
            goldenChestsOpened.text = "開けたゴールデン宝箱：";
            theMine2XTriggered.text = "マイン2倍速発動回数：";
            theMineDoubleTriggered.text = "マイン二重鉱石発動回数：";
            inflateBurstTriggered.text = "インフレバースト発動回数：";
            hammersSpawned.text = "出現したハンマー：";
            midasTouchSessions.text = "マイダスタッチセッション：";
            zeusTriggers.text = "ゼウス発動回数：";
            energiDrinksDrank.text = "飲んだエナジードリンク：";
            flowersSpawned.text = "出現した花：";
            campfiresSpawned.text = "出現した焚き火：";
            d100Rolls.text = "D100：1、10、100が出た回数：";

            miningSessions.text = "採掘セッション数：";
            timeSpentMining.text = "採掘時間：";
            totalRocksSpawned.text = "出現した岩の総数：";
            totalRocksMined.text = "採掘した岩の総数：";
            pickaxeSpawned.text = "出現したピッケル：";
            pickaxeHits.text = "ピッケルヒット数：";
            oresMined.text = "採掘した鉱石：";
            barsBrafted.text = "作成したインゴット：";
            bardMinedTheMine.text = "採掘したインゴット（マイン）：";
            xpGained.text = "獲得XP：";
            totalLevelUps.text = "総レベルアップ数：";
            doubleXpGained.text = "獲得した2倍XP：";
            doubleOredGained.text = "獲得した2倍鉱石：";
            X2pickaxePowerHits.text = "2倍威力ピッケルヒット数：";
            instaMineHits.text = "即採掘ピッケルヒット数：";
            lightningStrikes.text = "雷の発動回数：";
            dynamiteExplosions.text = "ダイナマイト爆発回数：";
            plazmaBallsSpawned.text = "出現したプラズマボール：";

            goldChunkRocks.text = "金鉱石チャンク：";
            fullGoldRocks.text = "フル金鉱石：";
            copperChunkMined.text = "銅鉱石チャンク：";
            fullCopperMined.text = "フル銅鉱石：";
            ironChunkMined.text = "鉄鉱石チャンク：";
            fullIronMined.text = "フル鉄鉱石：";
            cobaltChunkMined.text = "コバルト鉱石チャンク：";
            fullCobaltMined.text = "フルコバルト鉱石：";
            uraniumChunkMined.text = "ウラン鉱石チャンク：";
            fullUraniumMined.text = "フルウラン鉱石：";
            ismiumChunkMined.text = "イスミウム鉱石チャンク：";
            fullIsmiumMined.text = "フルイスミウム鉱石：";
            iridiumChunkMined.text = "イリジウム鉱石チャンク：";
            fullIridiumMined.text = "フルイリジウム鉱石：";
            painiteChunkMined.text = "ペイナイト鉱石チャンク：";
            fullPainiteMined.text = "フルペイナイト鉱石：";
        }
        #endregion

        #region Korean
        if (isKorean == true)
        {
            talentStats.text = "특성 통계";
            globalStats.text = "전체 통계";
            rocksMinedStats.text = "채굴된 바위 통계";

            potionsDrank.text = "마신 물약:";
            chestsOpened.text = "연 일반 상자 개수:";
            goldenChestsOpened.text = "연 황금 상자 개수:";
            theMine2XTriggered.text = "마인 2배 속도 발동:";
            theMineDoubleTriggered.text = "마인 2배 광물 발동:";
            inflateBurstTriggered.text = "인플레이트 버스트 발동:";
            hammersSpawned.text = "생성된 망치:";
            midasTouchSessions.text = "마이다스 터치 세션:";
            zeusTriggers.text = "제우스 발동:";
            energiDrinksDrank.text = "마신 에너지 음료:";
            flowersSpawned.text = "생성된 꽃:";
            campfiresSpawned.text = "생성된 캠프파이어:";
            d100Rolls.text = "D100: 1, 10 또는 100 나온 횟수:";

            miningSessions.text = "채굴 세션:";
            timeSpentMining.text = "채굴한 시간:";
            totalRocksSpawned.text = "총 생성된 바위:";
            totalRocksMined.text = "총 채굴한 바위:";
            pickaxeSpawned.text = "생성된 곡괭이:";
            pickaxeHits.text = "곡괭이 히트 수:";
            oresMined.text = "채굴한 광석:";
            barsBrafted.text = "제작한 바:";
            bardMinedTheMine.text = "채굴한 바 (마인):";
            xpGained.text = "획득한 XP:";
            totalLevelUps.text = "총 레벨 업:";
            doubleXpGained.text = "획득한 2배 XP:";
            doubleOredGained.text = "획득한 2배 광석:";
            X2pickaxePowerHits.text = "2배 곡괭이 파워 히트:";
            instaMineHits.text = "인스턴트 채굴 곡괭이 히트:";
            lightningStrikes.text = "번개 발동:";
            dynamiteExplosions.text = "다이너마이트 폭발:";
            plazmaBallsSpawned.text = "생성된 플라즈마 볼:";

            goldChunkRocks.text = "금 광석 청크:";
            fullGoldRocks.text = "풀 금 광석:";
            copperChunkMined.text = "구리 광석 청크:";
            fullCopperMined.text = "풀 구리 광석:";
            ironChunkMined.text = "철 광석 청크:";
            fullIronMined.text = "풀 철 광석:";
            cobaltChunkMined.text = "코발트 광석 청크:";
            fullCobaltMined.text = "풀 코발트 광석:";
            uraniumChunkMined.text = "우라늄 광석 청크:";
            fullUraniumMined.text = "풀 우라늄 광석:";
            ismiumChunkMined.text = "이스미움 광석 청크:";
            fullIsmiumMined.text = "풀 이스미움 광석:";
            iridiumChunkMined.text = "이리듐 광석 청크:";
            fullIridiumMined.text = "풀 이리듐 광석:";
            painiteChunkMined.text = "페이나이트 광석 청크:";
            fullPainiteMined.text = "풀 페이나이트 광석:";
        }
        #endregion

        #region Polish
        if (isPolish == true)
        {
            talentStats.text = "Statystyki Talentu";
            globalStats.text = "Statystyki Globalne";
            rocksMinedStats.text = "Statystyki Wydobycia Skał";

            potionsDrank.text = "Wypite mikstury:";
            chestsOpened.text = "Otwarte zwykłe skrzynie:";
            goldenChestsOpened.text = "Otwarte złote skrzynie:";
            theMine2XTriggered.text = "Kopalnia 2X prędkość (uruchomienia):";
            theMineDoubleTriggered.text = "Kopalnia podwójna ruda (uruchomienia):";
            inflateBurstTriggered.text = "Uruchomienia Inflate Burst:";
            hammersSpawned.text = "Zespawnowane młoty:";
            midasTouchSessions.text = "Sesje Midas Touch:";
            zeusTriggers.text = "Wyzwolenia Zeusa:";
            energiDrinksDrank.text = "Wypite energy drinki:";
            flowersSpawned.text = "Zespawnowane kwiaty:";
            campfiresSpawned.text = "Zespawnowane ogniska:";
            d100Rolls.text = "D100 — liczba trafień 1, 10 lub 100:";

            miningSessions.text = "Sesje kopania:";
            timeSpentMining.text = "Czas spędzony na kopaniu:";
            totalRocksSpawned.text = "Łączna liczba zespawnowanych skał:";
            totalRocksMined.text = "Łączna liczba wykopanych skał:";
            pickaxeSpawned.text = "Zespawnowane kilofy:";
            pickaxeHits.text = "Uderzenia kilofa:";
            oresMined.text = "Wykopane rudy:";
            barsBrafted.text = "Wytopione sztabki:";
            bardMinedTheMine.text = "Sztabki z kopalni:";
            xpGained.text = "Zdobyte XP:";
            totalLevelUps.text = "Łączne awanse poziomów:";
            doubleXpGained.text = "Zdobyte podwójne XP:";
            doubleOredGained.text = "Zdobyte podwójne rudy:";
            X2pickaxePowerHits.text = "Uderzenia kilofa z mocą 2X:";
            instaMineHits.text = "Insta-mine uderzenia kilofa:";
            lightningStrikes.text = "Wyładowania pioruna:";
            dynamiteExplosions.text = "Eksplozje dynamitu:";
            plazmaBallsSpawned.text = "Zespawnowane kule plazmy:";

            goldChunkRocks.text = "Złote skały (kawałki):";
            fullGoldRocks.text = "Pełne złote skały:";
            copperChunkMined.text = "Miedziane skały (kawałki):";
            fullCopperMined.text = "Pełne miedziane skały:";
            ironChunkMined.text = "Żelazne skały (kawałki):";
            fullIronMined.text = "Pełne żelazne skały:";
            cobaltChunkMined.text = "Kobaltowe skały (kawałki):";
            fullCobaltMined.text = "Pełne kobaltowe skały:";
            uraniumChunkMined.text = "Uranowe skały (kawałki):";
            fullUraniumMined.text = "Pełne uranowe skały:";
            ismiumChunkMined.text = "Ismium skały (kawałki):";
            fullIsmiumMined.text = "Pełne ismium skały:";
            iridiumChunkMined.text = "Irydowe skały (kawałki):";
            fullIridiumMined.text = "Pełne irydowe skały:";
            painiteChunkMined.text = "Painitowe skały (kawałki):";
            fullPainiteMined.text = "Pełne painitowe skały:";
        }
        #endregion

        #region Portugese
        if (isPortugese == true)
        {
            talentStats.text = "Estatísticas de Talento";
            globalStats.text = "Estatísticas Globais";
            rocksMinedStats.text = "Estatísticas de Rochas Mineradas";

            potionsDrank.text = "Poções bebibas:";
            chestsOpened.text = "Baús normais abertos:";
            goldenChestsOpened.text = "Baús dourados abertos:";
            theMine2XTriggered.text = "Ativações 2X velocidade (A Mina):";
            theMineDoubleTriggered.text = "Ativações dobro de minério (A Mina):";
            inflateBurstTriggered.text = "Ativações de Inflate Burst:";
            hammersSpawned.text = "Martelos gerados:";
            midasTouchSessions.text = "Sessões Midas Touch:";
            zeusTriggers.text = "Ativações de Zeus:";
            energiDrinksDrank.text = "Energéticos bebidos:";
            flowersSpawned.text = "Flores geradas:";
            campfiresSpawned.text = "Fogueiras geradas:";
            d100Rolls.text = "D100, total de rolagens de 1, 10 ou 100:";

            miningSessions.text = "Sessões de mineração:";
            timeSpentMining.text = "Tempo minerando:";
            totalRocksSpawned.text = "Total de rochas geradas:";
            totalRocksMined.text = "Total de rochas mineradas:";
            pickaxeSpawned.text = "Picaretas geradas:";
            pickaxeHits.text = "Golpes de picareta:";
            oresMined.text = "Minérios minerados:";
            barsBrafted.text = "Barras forjadas:";
            bardMinedTheMine.text = "Barras mineradas (A Mina):";
            xpGained.text = "XP ganho:";
            totalLevelUps.text = "Total de níveis ganhos:";
            doubleXpGained.text = "XP dobrado ganho:";
            doubleOredGained.text = "Minérios dobrados ganhos:";
            X2pickaxePowerHits.text = "Golpes de picareta 2X poder:";
            instaMineHits.text = "Golpes Insta Mine:";
            lightningStrikes.text = "Raio invocados:";
            dynamiteExplosions.text = "Explosões de dinamite:";
            plazmaBallsSpawned.text = "Bolas de plasma geradas:";

            goldChunkRocks.text = "Rocha de ouro (pedaços):";
            fullGoldRocks.text = "Rocha de ouro completa:";
            copperChunkMined.text = "Rocha de cobre (pedaços):";
            fullCopperMined.text = "Rocha de cobre completa:";
            ironChunkMined.text = "Rocha de ferro (pedaços):";
            fullIronMined.text = "Rocha de ferro completa:";
            cobaltChunkMined.text = "Rocha de cobalto (pedaços):";
            fullCobaltMined.text = "Rocha de cobalto completa:";
            uraniumChunkMined.text = "Rocha de urânio (pedaços):";
            fullUraniumMined.text = "Rocha de urânio completa:";
            ismiumChunkMined.text = "Rocha de ismium (pedaços):";
            fullIsmiumMined.text = "Rocha de ismium completa:";
            iridiumChunkMined.text = "Rocha de irídio (pedaços):";
            fullIridiumMined.text = "Rocha de irídio completa:";
            painiteChunkMined.text = "Rocha de painita (pedaços):";
            fullPainiteMined.text = "Rocha de painita completa:";
        }
        #endregion

        #region Russian
        if (isRussian == true)
        {
            talentStats.text = "Статистика Талантов";
            globalStats.text = "Глобальная Статистика";
            rocksMinedStats.text = "Статистика Добытых Камней";

            potionsDrank.text = "Выпито зелий:";
            chestsOpened.text = "Открыто обычных сундуков:";
            goldenChestsOpened.text = "Открыто золотых сундуков:";
            theMine2XTriggered.text = "Шахта: ускорение 2X активировано:";
            theMineDoubleTriggered.text = "Шахта: двойная руда активирована:";
            inflateBurstTriggered.text = "Inflate Burst сработало:";
            hammersSpawned.text = "Сгенерировано молотов:";
            midasTouchSessions.text = "Сессии Midas Touch:";
            zeusTriggers.text = "Активации Зевса:";
            energiDrinksDrank.text = "Выпито энергетиков:";
            flowersSpawned.text = "Сгенерировано цветов:";
            campfiresSpawned.text = "Разожжено костров:";
            d100Rolls.text = "D100: всего выпадений 1, 10 или 100:";

            miningSessions.text = "Сессии добычи:";
            timeSpentMining.text = "Время добычи:";
            totalRocksSpawned.text = "Всего сгенерировано камней:";
            totalRocksMined.text = "Всего добыто камней:";
            pickaxeSpawned.text = "Сгенерировано кирок:";
            pickaxeHits.text = "Удары киркой:";
            oresMined.text = "Добыто руды:";
            barsBrafted.text = "Переплавлено слитков:";
            bardMinedTheMine.text = "Добыто слитков (Шахта):";
            xpGained.text = "Получено XP:";
            totalLevelUps.text = "Всего уровней:";
            doubleXpGained.text = "Получено двойного XP:";
            doubleOredGained.text = "Добыто двойной руды:";
            X2pickaxePowerHits.text = "Удары киркой с 2X силой:";
            instaMineHits.text = "Insta Mine удары киркой:";
            lightningStrikes.text = "Удары молнии:";
            dynamiteExplosions.text = "Взрывы динамита:";
            plazmaBallsSpawned.text = "Сгенерировано плазменных шаров:";

            goldChunkRocks.text = "Куски золотой руды:";
            fullGoldRocks.text = "Полная золотая руда:";
            copperChunkMined.text = "Куски медной руды:";
            fullCopperMined.text = "Полная медная руда:";
            ironChunkMined.text = "Куски железной руды:";
            fullIronMined.text = "Полная железная руда:";
            cobaltChunkMined.text = "Куски кобальтовой руды:";
            fullCobaltMined.text = "Полная кобальтовая руда:";
            uraniumChunkMined.text = "Куски урановой руды:";
            fullUraniumMined.text = "Полная урановая руда:";
            ismiumChunkMined.text = "Куски измиевой руды:";
            fullIsmiumMined.text = "Полная измиевая руда:";
            iridiumChunkMined.text = "Куски иридиевой руды:";
            fullIridiumMined.text = "Полная иридиевая руда:";
            painiteChunkMined.text = "Куски пейнита:";
            fullPainiteMined.text = "Полный пейнит:";
        }
        #endregion

        #region Simplified Chinese
        if (isSimplefiedChinese == true)
        {
            talentStats.text = "天赋统计";
            globalStats.text = "全局统计";
            rocksMinedStats.text = "挖矿统计";

            potionsDrank.text = "已喝药水：";
            chestsOpened.text = "已开普通宝箱：";
            goldenChestsOpened.text = "已开黄金宝箱：";
            theMine2XTriggered.text = "矿井2倍速触发次数：";
            theMineDoubleTriggered.text = "矿井双倍矿石触发次数：";
            inflateBurstTriggered.text = "膨胀爆发触发次数：";
            hammersSpawned.text = "生成的锤子数：";
            midasTouchSessions.text = "点金之触会话：";
            zeusTriggers.text = "宙斯触发次数：";
            energiDrinksDrank.text = "已喝能量饮料：";
            flowersSpawned.text = "生成的花朵数：";
            campfiresSpawned.text = "生成的篝火数：";
            d100Rolls.text = "D100，掷出1、10或100的总次数：";

            miningSessions.text = "挖矿会话：";
            timeSpentMining.text = "挖矿总时长：";
            totalRocksSpawned.text = "生成的岩石总数：";
            totalRocksMined.text = "已挖岩石总数：";
            pickaxeSpawned.text = "生成的镐数：";
            pickaxeHits.text = "镐击次数：";
            oresMined.text = "已挖矿石：";
            barsBrafted.text = "已锻造锭数：";
            bardMinedTheMine.text = "已开采锭（矿井）：";
            xpGained.text = "获得的XP：";
            totalLevelUps.text = "总升级次数：";
            doubleXpGained.text = "获得的双倍XP：";
            doubleOredGained.text = "获得的双倍矿石：";
            X2pickaxePowerHits.text = "2倍威力镐击次数：";
            instaMineHits.text = "瞬挖镐击次数：";
            lightningStrikes.text = "闪电击中次数：";
            dynamiteExplosions.text = "炸药爆炸次数：";
            plazmaBallsSpawned.text = "生成的等离子球：";

            goldChunkRocks.text = "金矿石块：";
            fullGoldRocks.text = "完整金矿石：";
            copperChunkMined.text = "铜矿石块：";
            fullCopperMined.text = "完整铜矿石：";
            ironChunkMined.text = "铁矿石块：";
            fullIronMined.text = "完整铁矿石：";
            cobaltChunkMined.text = "钴矿石块：";
            fullCobaltMined.text = "完整钴矿石：";
            uraniumChunkMined.text = "铀矿石块：";
            fullUraniumMined.text = "完整铀矿石：";
            ismiumChunkMined.text = "伊斯密矿石块：";
            fullIsmiumMined.text = "完整伊斯密矿石：";
            iridiumChunkMined.text = "铱矿石块：";
            fullIridiumMined.text = "完整铱矿石：";
            painiteChunkMined.text = "帕因石块：";
            fullPainiteMined.text = "完整帕因石：";
        }
        #endregion
    }
    #endregion

    #region All increse variables
    public static int rockSpawnIncrease;
    public static float xpIncrease;
    public static int moreTalentPointsReduce;

    //Rock chance increases
    public static float goldRockChanceIncrease;
    public static float fullGoldRockChanceIncrease;

    public static float copperRockChanceIncrease;
    public static float fullCopperRockChanceIncrease;

    public static float ironRockChanceIncrease;
    public static float fullIronRockChanceIncrease;

    public static float cobaltRockChanceIncrease;
    public static float fullCobaltRockChanceIncrease;

    public static float uraniumRockChanceIncrease;
    public static float fullUraniumRockChanceIncrease;

    public static float ismiumRockChanceIncrease;
    public static float fullIsmiumRockChanceIncrease;

    public static float iridiumRockChanceIncrease;
    public static float fullIridiumRockChanceIncrease;

    public static float painiteRockChanceIncrease;
    public static float fullPainiteRockChanceIncrease;

    public static float improvedPickaxeIncrease;

    public static float miningAreaIncrease;

    public static float spawnEveryRockIncrease;
    public static float spawnEverySecondIncrease;
    public static float spawnWhenMinedIncrease;

    //Materials dropped from rocks
    public static int materialsFromChunkRocksIncrease;
    public static int materialsFromFullRocksIncrease;

    //Materials worth more
    public static float materialsWorthIncrease;

    //Chance to spawn pickaxe
    public static float chanceToMineRandomRockIncrease;
    public static float spawnPickaxeEverySecondIncrease;

    //More time
    public static int moreTimeIncrease;

    public static float doubleXpAndGoldChanceIncrease;

    //Lightning
    public static float lightningTriggerChanceS_Increase, lightningTriggerChancePH_Increase;
    public static float lightningDamageIncrease;
    public static float lightningSizeIncrease;

    //Dynamite
    public static float dynamiteStickChanceIncrease;
    public static float explosionSizeIncrease;
    public static float explosionDamagageIncrease;

    //Plazma ball
    public static float plazmaBallChanceIncrease;
    public static float plazmaBallTimerIncrease;
    public static float plazmaBallTotalSizeIncrease;
    public static float plazmaBallTotalDamageIncrease;

    //Misc
    public static float doubleDamageChanceIncrease;
    public static float instaMineChanceIncrease;
    #endregion

    #region Skill tree texts
    public static double currentSkillTreePrice;

    public void SkillTreeText(string upgradeName, int upgradeType, double upgradePrice, int purchaseCount, int totalPurchaseCount)
    {
        bool isPurchasedMax;
        isPurchasedMax = false;

        if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; }

        #region Spawn more rocks
        if (upgradeType == 1)
        {
            float nextTotalRocks = 0;

            #region Name texts
            if (isEnglish == true)
            {
                skillTreeName_text.text = "More Rocks";
            }

            if (isFrench == true)
            {
                skillTreeName_text.text = "Plus de Roches";
            }

            if (isItalian == true)
            {
                skillTreeName_text.text = "Più Rocce";
            }

            if (isGerman == true)
            {
                skillTreeName_text.text = "Mehr Steine";
            }

            if (isSpanish == true)
            {
                skillTreeName_text.text = "Más Rocas";
            }

            if (isJapanese == true)
            {
                skillTreeName_text.text = "岩を増やす";
            }

            if (isKorean == true)
            {
                skillTreeName_text.text = "암석 추가";
            }

            if (isPolish == true)
            {
                skillTreeName_text.text = "Więcej Skał";
            }

            if (isPortugese == true)
            {
                skillTreeName_text.text = "Mais Rochas";
            }

            if (isRussian == true)
            {
                skillTreeName_text.text = "Больше Камней";
            }

            if (isSimplefiedChinese == true)
            {
                skillTreeName_text.text = "更多岩石";
            }
            #endregion

            if (upgradeName == "Rock1") //15
            {
                rockSpawnIncrease = 4;
            }
            else if (upgradeName == "Rock2") //16
            {
                rockSpawnIncrease = 5;
            }
            else if (upgradeName == "Rock3") //24
            {
                rockSpawnIncrease = 7;
            }
            else if (upgradeName == "Rock4") //30
            {
                rockSpawnIncrease = 8;
            }
            else if (upgradeName == "Rock5") //35
            {
                rockSpawnIncrease = 9;
            }
            else if (upgradeName == "Rock6") //36
            {
                rockSpawnIncrease = 9;
            }
            else if (upgradeName == "Rock7") //39
            {
                rockSpawnIncrease = 12;
            }
            else if (upgradeName == "Rock8") //42
            {
                rockSpawnIncrease = 15;
            }
            else if (upgradeName == "Rock9") //60
            {
                rockSpawnIncrease = 16;
            }

            nextTotalRocks = SkillTree.totalRocksToSpawn + rockSpawnIncrease;

            if (isPurchasedMax == true) 
            {
                #region Texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Total rock spawn count:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Nombre total de roches générées :\n{SkillTree.totalRocksToSpawn}";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Conteggio totale rocce generate:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Gesamtzahl der gespawnten Steine:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Total de rocas generadas:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"岩の総出現数：\n{SkillTree.totalRocksToSpawn}";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"암석 총 생성 수:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Łączna liczba skał:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Total de rochas geradas:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Общее количество камней:\n{SkillTree.totalRocksToSpawn}";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"岩石生成总数：\n{SkillTree.totalRocksToSpawn}";
                }
                #endregion
            }
            else 
            {
                #region Texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"More rocks spawn at the beginning of a mining session:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Plus de roches apparaissent au début d'une session de minage :\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Più rocce compaiono all'inizio di una sessione di scavo:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Mehr Steine erscheinen zu Beginn einer Mining-Session:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Más rocas aparecen al inicio de una sesión de minería:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"採掘セッション開始時に岩が多く出現します：\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"채굴 세션 시작 시 더 많은 암석이 생성됩니다:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Więcej skał pojawia się na początku sesji wydobywczej:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Mais rochas surgem no início de uma sessão de mineração:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Больше камней появляется в начале добычи:\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"在采矿开始时会生成更多岩石：\n{SkillTree.totalRocksToSpawn}->{nextTotalRocks}";
                }
                #endregion
            }
        }
        #endregion

        #region XP and talent Points
        else if (upgradeType == 2)
        {
            float nextXPIncrease = 0;

            if (upgradeName == "XP1")
            {
                xpIncrease = 0.02f;
            }
            else if (upgradeName == "XP2")
            {
                xpIncrease = 0.08f;
            }
            else if (upgradeName == "XP3")
            {
                xpIncrease = 0.36f;
            }
            else if (upgradeName == "XP4")
            {
                xpIncrease = 0.24f;
            }
            else if (upgradeName == "XP5")
            {
                xpIncrease = 0.54f;
            }
            else if (upgradeName == "XP6")
            {
                xpIncrease = 0.8f;
            }
            else if (upgradeName == "XP7")
            {
                xpIncrease = 1.1f;
            }
            else if (upgradeName == "XP8")
            {
                xpIncrease = 2.5f;
            }
            else if (upgradeName == "EndlessXP1")
            {
                xpIncrease = 1.05f;
            }
            else if (upgradeName == "EndlessXP2")
            {
                xpIncrease = 1.05f;
            }

            bool isTalentName = false;

            if (upgradeName == "Talent1")
            {
                isTalentName = true;
                moreTalentPointsReduce = 2;
                if (SkillTree.talentPointsPerXlevel_1_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }
            
            }
            else if (upgradeName == "Talent2")
            {
                isTalentName = true;
                moreTalentPointsReduce = 2;
                if (SkillTree.talentPointsPerXlevel_2_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }
            }
            else if (upgradeName == "Talent3")
            {
                isTalentName = true;
                moreTalentPointsReduce = 1;
              
                if (SkillTree.talentPointsPerXlevel_3_purchaseCount >= 1) { isPurchasedMax = true; moreTalentPointsReduce = 0; }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More XP";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de XP";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più XP";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr XP";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más XP";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "XP増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "XP 증가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej XP";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais XP";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше XP";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多XP";
                }
                #endregion

                nextXPIncrease = LevelMechanics.xpFromRock + xpIncrease;

                if (isPurchasedMax == true) 
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total XP from rocks:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"XP total des roches :\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"XP totale dalle rocce:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamt-XP von Steinen:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"XP total de rocas:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"岩からの総XP：\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"암석에서 획득한 총 XP:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączne XP ze skał:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"XP total das rochas:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий XP с камней:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"来自岩石的总XP：\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}";
                    }
                    #endregion
                }
                else 
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase XP received from mined rocks:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente l'XP reçu des roches extraites :\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta l'XP ottenuta dalle rocce estratte:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht XP von abgebauten Steinen:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la XP obtenida de rocas extraídas:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"採掘した岩から得られるXPが増加：\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"채굴된 암석에서 얻는 XP 증가:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa XP z wydobytych skał:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o XP recebido de rochas mineradas:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает XP за добытые камни:\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提高采矿岩石获得的XP：\n{(LevelMechanics.xpFromRock * 100).ToString("F0")}->{(nextXPIncrease * 100).ToString("F0")}";
                    }
                    #endregion
                }
            }

            if(isTalentName == true)
            {
                #region Name texts and desc

                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Talent Points";
                    skillTreeDesc_text.text = $"Receive 1 extra talent point per {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} levels";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Points de Talent";
                    skillTreeDesc_text.text = $"Recevez 1 point de talent supplémentaire tous les {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} niveaux";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Punti Talento";
                    skillTreeDesc_text.text = $"Ricevi 1 punto talento extra ogni {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} livelli";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Talentpunkte";
                    skillTreeDesc_text.text = $"Erhalte 1 zusätzlichen Talentpunkt alle {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} Level";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Puntos de Talento";
                    skillTreeDesc_text.text = $"Recibe 1 punto de talento extra cada {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} niveles";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "才能ポイント増加";
                    skillTreeDesc_text.text = $"{SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce}レベルごとに追加で才能ポイントを1つ獲得";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "특성 포인트 증가";
                    skillTreeDesc_text.text = $"{SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce}레벨마다 추가 특성 포인트 1개 획득";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Punktów Talentu";
                    skillTreeDesc_text.text = $"Otrzymujesz 1 dodatkowy punkt talentu co {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} poziomów";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Pontos de Talento";
                    skillTreeDesc_text.text = $"Receba 1 ponto de talento extra a cada {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} níveis";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Очков Таланта";
                    skillTreeDesc_text.text = $"Получайте 1 дополнительное очко таланта каждые {SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce} уровней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多天赋点数";
                    skillTreeDesc_text.text = $"每{SkillTree.extraTalentPointPerLevel - moreTalentPointsReduce}级额外获得1个天赋点";
                }

                #endregion
            }

        }
        #endregion

        #region Gold rocks spawn
        else if (upgradeType == 3)
        {
            float nextGoldRockChance = 0;
            float nextFULLGoldRockChance = 0;

            bool isChunk = false;

            if (upgradeName == "GoldChunk1")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.4f;
            }
            else if (upgradeName == "GoldChunk2")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.4f;
            }
            else if (upgradeName == "GoldChunk3")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.5f;
            }
            else if (upgradeName == "GoldChunk4")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.5f;
            }
            else if (upgradeName == "GoldChunk5")
            {
                isChunk = true;
                goldRockChanceIncrease = 0.6f;
            }
            else if (upgradeName == "FullGold1")
            {
                fullGoldRockChanceIncrease = 0.5f;
            }
            else if (upgradeName == "FullGold2")
            {
                fullGoldRockChanceIncrease = 0.6f;
            }
            else if (upgradeName == "FullGold3")
            {
                fullGoldRockChanceIncrease = 0.8f;
            }

            if (isChunk == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Gold Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches Dorées";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce d'Oro";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Gold-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Oro";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "金の岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "금 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Złotych Skał";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ouro";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Золотых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多金矿石";
                }
                #endregion

                nextGoldRockChance = SkillTree.goldRockChance + goldRockChanceIncrease;

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total gold chunk rock spawn chance:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux d'or :\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi d'oro:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Goldbrocken-Steine:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de oro:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"金チャンク岩の出現確率合計：\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"금 조각 암석 총 생성 확률:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się złotych brył:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de ouro:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления золотых глыб:\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"金块岩生成总概率：\n{SkillTree.goldRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the gold chunk rock spawn chance:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux d'or :\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi d'oro:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Goldbrocken-Steine:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de oro:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"金チャンク岩の出現確率を増加：\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"금 조각 암석 생성 확률 증가:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się złotych brył:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de ouro:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления золотых глыб:\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升金块岩生成概率：\n{SkillTree.goldRockChance.ToString("F2")}%->{nextGoldRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Gold Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Or Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce d'Oro Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Gold-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Oro Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "金フル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 금 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Złotych Skał";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ouro Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Золотых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整金矿石";
                }
                #endregion

                nextFULLGoldRockChance = SkillTree.fullGoldRockChance + fullGoldRockChanceIncrease;

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full gold rock spawn chance:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches d'or complètes :\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce d'oro piene:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Gold-Steine:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de oro completas:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"金フル岩の出現確率合計：\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 금 암석 총 생성 확률:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych złotych skał:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de ouro inteiras:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных золотых камней:\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整金矿石生成总概率：\n{SkillTree.fullGoldRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full gold rock spawn chance:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches d'or complètes :\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce d'oro piene:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Gold-Steine:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de oro completas:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"金フル岩の出現確率を増加：\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 금 암석 생성 확률 증가:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych złotych skał:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de ouro inteiras:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных золотых камней:\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整金矿石生成概率：\n{SkillTree.fullGoldRockChance.ToString("F2")}%->{nextFULLGoldRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Copper rocks spawn
        else if (upgradeType == 4)
        {
            float nextCopperRockChance = 0;
            float nextFullCopperRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "CopperSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "CopperChunk1")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "CopperChunk2")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "CopperChunk3")
            {
                isChunk = true;
                copperRockChanceIncrease = 0.4f;
            }
            else if (upgradeName == "FullCopper1")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullCopper2")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullCopper3")
            {
                isChunk = false;
                fullCopperRockChanceIncrease = 0.3f;
            }

            if (isSpawn)
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Copper Rocks";
                    skillTreeDesc_text.text = "Copper rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches de Cuivre";
                    skillTreeDesc_text.text = "Les roches de cuivre commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Rame";
                    skillTreeDesc_text.text = "Le rocce di rame inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Kupfer-Steine erscheinen";
                    skillTreeDesc_text.text = "Kupfer-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Cobre";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de cobre!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "銅岩を生成";
                    skillTreeDesc_text.text = "これから銅の岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "구리 암석 생성";
                    skillTreeDesc_text.text = "이제 구리 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Miedzi";
                    skillTreeDesc_text.text = "Skały miedzi zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Cobre";
                    skillTreeDesc_text.text = "As rochas de cobre começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Медных Камней";
                    skillTreeDesc_text.text = "Медные камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成铜矿石";
                    skillTreeDesc_text.text = "铜矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Copper Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Cuivre";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Rame";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Kupfer-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Cobre";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "銅岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "구리 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Miedzi";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Cobre";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Медных Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多铜矿石";
                }
                #endregion

                nextCopperRockChance = SkillTree.copperRockChance + copperRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total copper chunk rock spawn chance:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux de cuivre :\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di rame:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Kupferbrocken-Steine:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de cobre:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"銅チャンク岩の出現確率合計：\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"구리 조각 암석 총 생성 확률:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się miedzianych brył:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de cobre:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления медных глыб:\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"铜块岩生成总概率：\n{SkillTree.copperRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the copper chunk rock spawn chance:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux de cuivre :\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di rame:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Kupferbrocken-Steine:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de cobre:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"銅チャンク岩の出現確率を増加：\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"구리 조각 암석 생성 확률 증가:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się miedzianych brył:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de cobre:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления медных глыб:\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升铜块岩生成概率：\n{SkillTree.copperRockChance.ToString("F2")}% -> {nextCopperRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Copper Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Cuivre Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Rame Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Kupfer-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Cobre Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "銅フル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 구리 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Miedzi";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Cobre Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Медных Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整铜矿石";
                }
                #endregion

                nextFullCopperRockChance = SkillTree.fullCopperRockChance + fullCopperRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full copper rock spawn chance:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches de cuivre complètes :\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di rame piene:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Kupfer-Steine:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de cobre completas:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"銅フル岩の出現確率合計：\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 구리 암석 총 생성 확률:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał miedzi:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de cobre inteiras:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных медных камней:\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整铜矿石生成总概率：\n{SkillTree.fullCopperRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full copper rock spawn chance:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches de cuivre complètes :\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di rame piene:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Kupfer-Steine:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de cobre completas:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"銅フル岩の出現確率を増加：\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 구리 암석 생성 확률 증가:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał miedzi:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de cobre inteiras:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных медных камней:\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整铜矿石生成概率：\n{SkillTree.fullCopperRockChance.ToString("F2")}% -> {nextFullCopperRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Iron rocks spawn
        else if (upgradeType == 5)
        {
            float nextIronRockChance = 0;
            float nextFullIronRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IronSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IronChunk1")
            {
                isChunk = true;
                ironRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "IronChunk2")
            {
                isChunk = true;
                ironRockChanceIncrease = 0.3f;
            }
            else if (upgradeName == "FullIron1")
            {
                isChunk = false;
                fullIronRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "FullIron2")
            {
                isChunk = false;
                fullIronRockChanceIncrease = 0.2f;
            }

            if (isSpawn)
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Iron Rocks";
                    skillTreeDesc_text.text = "Iron rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches de Fer";
                    skillTreeDesc_text.text = "Les roches de fer commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Ferro";
                    skillTreeDesc_text.text = "Le rocce di ferro inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Eisen-Steine erscheinen";
                    skillTreeDesc_text.text = "Eisen-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Hierro";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de hierro!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "鉄岩を生成";
                    skillTreeDesc_text.text = "これから鉄の岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "철 암석 생성";
                    skillTreeDesc_text.text = "이제 철 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Żelaza";
                    skillTreeDesc_text.text = "Skały żelaza zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Ferro";
                    skillTreeDesc_text.text = "As rochas de ferro começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Железных Камней";
                    skillTreeDesc_text.text = "Железные камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成铁矿石";
                    skillTreeDesc_text.text = "铁矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Iron Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Fer";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Ferro";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Eisen-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Hierro";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "鉄岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "철 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Żelaza";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ferro";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Железных Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多铁矿石";
                }
                #endregion

                nextIronRockChance = SkillTree.ironRockChance + ironRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total iron chunk rock spawn chance:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux de fer :\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di ferro:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Eisenbrocken-Steine:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de hierro:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"鉄チャンク岩の出現確率合計：\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"철 조각 암석 총 생성 확률:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył żelaza:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de ferro:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления железных глыб:\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"铁块岩生成总概率：\n{SkillTree.ironRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the iron chunk rock spawn chance:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux de fer :\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di ferro:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Eisenbrocken-Steine:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de hierro:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"鉄チャンク岩の出現確率を増加：\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"철 조각 암석 생성 확률 증가:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył żelaza:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de ferro:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления железных глыб:\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升铁块岩生成概率：\n{SkillTree.ironRockChance.ToString("F2")}% -> {nextIronRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Iron Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Fer Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Ferro Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Eisen-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Hierro Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "鉄フル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 철 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Żelaza";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ferro Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Железных Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整铁矿石";
                }
                #endregion

                nextFullIronRockChance = SkillTree.fullIronRockChance + fullIronRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full iron rock spawn chance:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches de fer complètes :\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di ferro piene:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Eisen-Steine:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de hierro completas:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"鉄フル岩の出現確率合計：\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 철 암석 총 생성 확률:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał żelaza:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de ferro inteiras:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных железных камней:\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整铁矿石生成总概率：\n{SkillTree.fullIronRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full iron rock spawn chance:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches de fer complètes :\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di ferro piene:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Eisen-Steine:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de hierro completas:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"鉄フル岩の出現確率を増加：\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 철 암석 생성 확률 증가:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał żelaza:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de ferro inteiras:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных железных камней:\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整铁矿石生成概率：\n{SkillTree.fullIronRockChance.ToString("F2")}% -> {nextFullIronRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Cobalt rocks spawn
        else if (upgradeType == 6)
        {
            float nextCobaltRockChance = 0;
            float nextFullCobaltRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "CobaltSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "CobaltChunk1")
            {
                isChunk = true;
                cobaltRockChanceIncrease = 0.2f;
            }
            else if (upgradeName == "CobaltFull1")
            {
                isChunk = false;
                fullCobaltRockChanceIncrease = 0.2f;
            }

            if (isSpawn)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Cobalt Rocks";
                    skillTreeDesc_text.text = "Cobalt rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches de Cobalt";
                    skillTreeDesc_text.text = "Les roches de cobalt commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Cobalto";
                    skillTreeDesc_text.text = "Le rocce di cobalto inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Kobalt-Steine erscheinen";
                    skillTreeDesc_text.text = "Kobalt-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Cobalto";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de cobalto!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "コバルト岩を生成";
                    skillTreeDesc_text.text = "これからコバルトの岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "코발트 암석 생성";
                    skillTreeDesc_text.text = "이제 코발트 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Kobaltu";
                    skillTreeDesc_text.text = "Skały kobaltu zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Cobalto";
                    skillTreeDesc_text.text = "As rochas de cobalto começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Кобальтовых Камней";
                    skillTreeDesc_text.text = "Кобальтовые камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成钴矿石";
                    skillTreeDesc_text.text = "钴矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Cobalt Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Cobalt";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Cobalto";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Kobalt-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Cobalto";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "コバルト岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "코발트 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Kobaltu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Cobalto";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Кобальтовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多钴矿石";
                }
                #endregion

                nextCobaltRockChance = SkillTree.cobaltRockChance + cobaltRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total cobalt chunk rock spawn chance:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux de cobalt :\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Kobaltbrocken-Steine:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"コバルトチャンク岩の出現確率合計：\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"코발트 조각 암석 총 생성 확률:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył kobaltu:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления кобальтовых глыб:\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"钴块岩生成总概率：\n{SkillTree.cobaltRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the cobalt chunk rock spawn chance:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux de cobalt :\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Kobaltbrocken-Steine:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"コバルトチャンク岩の出現確率を増加：\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"코발트 조각 암석 생성 확률 증가:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył kobaltu:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de cobalto:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления кобальтовых глыб:\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升钴块岩生成概率：\n{SkillTree.cobaltRockChance.ToString("F2")}% -> {nextCobaltRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Cobalt Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Cobalt Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Cobalto Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Kobalt-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Cobalto Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "コバルトフル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 코발트 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Kobaltu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Cobalto Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Кобальтовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整钴矿石";
                }
                #endregion

                nextFullCobaltRockChance = SkillTree.fullCobaltRockChance + fullCobaltRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full cobalt rock spawn chance:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches de cobalt complètes :\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di cobalto piene:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Kobalt-Steine:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de cobalto completas:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"コバルトフル岩の出現確率合計：\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 코발트 암석 총 생성 확률:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał kobaltu:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de cobalto inteiras:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных кобальтовых камней:\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整钴矿石生成总概率：\n{SkillTree.fullCobaltRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full cobalt rock spawn chance:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches de cobalt complètes :\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di cobalto piene:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Kobalt-Steine:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de cobalto completas:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"コバルトフル岩の出現確率を増加：\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 코발트 암석 생성 확률 증가:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał kobaltu:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de cobalto inteiras:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных кобальтовых камней:\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整钴矿石生成概率：\n{SkillTree.fullCobaltRockChance.ToString("F2")}% -> {nextFullCobaltRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Uranium rocks spawn
        else if (upgradeType == 7)
        {
            float nextUraniumRockChance = 0;
            float nextFullUraniumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "UraniumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "UraniumChunk1")
            {
                isChunk = true;
                uraniumRockChanceIncrease = 0.1f;
            }
            else if (upgradeName == "FullUranium1")
            {
                isChunk = false;
                fullUraniumRockChanceIncrease = 0.1f;
            }

            if (isSpawn)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Uranium Rocks";
                    skillTreeDesc_text.text = "Uranium rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches d'Uranium";
                    skillTreeDesc_text.text = "Les roches d'uranium commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Uranio";
                    skillTreeDesc_text.text = "Le rocce di uranio inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Uran-Steine erscheinen";
                    skillTreeDesc_text.text = "Uran-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Uranio";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de uranio!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ウラン岩を生成";
                    skillTreeDesc_text.text = "これからウランの岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "우라늄 암석 생성";
                    skillTreeDesc_text.text = "이제 우라늄 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Uranu";
                    skillTreeDesc_text.text = "Skały uranu zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Urânio";
                    skillTreeDesc_text.text = "As rochas de urânio começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Урановых Камней";
                    skillTreeDesc_text.text = "Урановые камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成铀矿石";
                    skillTreeDesc_text.text = "铀矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Uranium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Uranium";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Uranio";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Uran-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Uranio";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ウラン岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "우라늄 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Uranu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Urânio";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Урановых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多铀矿石";
                }
                #endregion

                nextUraniumRockChance = SkillTree.uraniumRockChance + uraniumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total uranium chunk rock spawn chance:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux d'uranium :\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di uranio:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Uranbrocken-Steine:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de uranio:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ウランチャンク岩の出現確率合計：\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"우라늄 조각 암석 총 생성 확률:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył uranu:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de urânio:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления урановых глыб:\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"铀块岩生成总概率：\n{SkillTree.uraniumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the uranium chunk rock spawn chance:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux d'uranium :\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di uranio:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Uranbrocken-Steine:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de uranio:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ウランチャンク岩の出現確率を増加：\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"우라늄 조각 암석 생성 확률 증가:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył uranu:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de urânio:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления урановых глыб:\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升铀块岩生成概率：\n{SkillTree.uraniumRockChance.ToString("F2")}% -> {nextUraniumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Uranium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Uranium Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Uranio Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Uran-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Uranio Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ウランフル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 우라늄 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Uranu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Urânio Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Урановых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整铀矿石";
                }
                #endregion

                nextFullUraniumRockChance = SkillTree.fullUraniumRockChance + fullUraniumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full uranium rock spawn chance:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches d'uranium complètes :\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di uranio piene:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Uran-Steine:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de uranio completas:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ウランフル岩の出現確率合計：\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 우라늄 암석 총 생성 확률:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał uranu:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de urânio inteiras:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных урановых камней:\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整铀矿石生成总概率：\n{SkillTree.fullUraniumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full uranium rock spawn chance:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches d'uranium complètes :\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di uranio piene:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Uran-Steine:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de uranio completas:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ウランフル岩の出現確率を増加：\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 우라늄 암석 생성 확률 증가:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał uranu:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de urânio inteiras:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных урановых камней:\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整铀矿石生成概率：\n{SkillTree.fullUraniumRockChance.ToString("F2")}% -> {nextFullUraniumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Ismium rocks spawn
        else if (upgradeType == 8)
        {
            float nextIsmiumRockChance = 0;
            float nextFullIsmiumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IsmiumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IsmiumChunk1")
            {
                isChunk = true;
                ismiumRockChanceIncrease = 0.09f;
            }
            else if (upgradeName == "FullIsmium1")
            {
                isChunk = false;
                fullIsmiumRockChanceIncrease = 0.08f;
            }

            if (isSpawn)
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Ismium Rocks";
                    skillTreeDesc_text.text = "Ismium rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches d'Ismium";
                    skillTreeDesc_text.text = "Les roches d'ismium commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Ismio";
                    skillTreeDesc_text.text = "Le rocce di ismio inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Ismium-Steine erscheinen";
                    skillTreeDesc_text.text = "Ismium-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Ismio";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de ismio!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イズミウム岩を生成";
                    skillTreeDesc_text.text = "これからイズミウムの岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "이스미움 암석 생성";
                    skillTreeDesc_text.text = "이제 이스미움 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Ismium";
                    skillTreeDesc_text.text = "Skały ismium zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Ismium";
                    skillTreeDesc_text.text = "As rochas de ismium começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Исмиумовых Камней";
                    skillTreeDesc_text.text = "Исмиумовые камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成铱锇矿石";
                    skillTreeDesc_text.text = "铱锇矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Ismium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Ismium";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Ismio";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ismium-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Ismio";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イズミウム岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "이스미움 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Ismium";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ismium";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Исмиумовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多铱锇矿石";
                }
                #endregion

                nextIsmiumRockChance = SkillTree.ismiumRockChance + ismiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total ismium chunk rock spawn chance:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux d'ismium :\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di ismio:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Ismiumbrocken-Steine:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de ismio:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イズミウムチャンク岩の出現確率合計：\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"이스미움 조각 암석 총 생성 확률:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył ismium:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de ismium:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления исмиумовых глыб:\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"铱锇块矿石生成总概率：\n{SkillTree.ismiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the ismium chunk rock spawn chance:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux d'ismium :\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di ismio:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Ismiumbrocken-Steine:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de ismio:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イズミウムチャンク岩の出現確率を増加：\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"이스미움 조각 암석 생성 확률 증가:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył ismium:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de ismium:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления исмиумовых глыб:\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升铱锇块矿石生成概率：\n{SkillTree.ismiumRockChance.ToString("F2")}% -> {nextIsmiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Ismium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Ismium Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Ismio Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Ismium-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Ismio Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イズミウムフル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 이스미움 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Ismium";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Ismium Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Исмиумовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整铱锇矿石";
                }
                #endregion

                nextFullIsmiumRockChance = SkillTree.fullIsmiumRockChance + fullIsmiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full ismium rock spawn chance:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches d'ismium complètes :\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di ismio piene:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Ismium-Steine:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de ismio completas:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イズミウムフル岩の出現確率合計：\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 이스미움 암석 총 생성 확률:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał ismium:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de ismium inteiras:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных исмиумовых камней:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整铱锇矿石生成总概率：\n{SkillTree.fullIsmiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full ismium rock spawn chance:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches d'ismium complètes :\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di ismio piene:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Ismium-Steine:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de ismio completas:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イズミウムフル岩の出現確率を増加：\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 이스미움 암석 생성 확률 증가:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał ismium:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de ismium inteiras:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных исмиумовых камней:\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整铱锇矿石生成概率：\n{SkillTree.fullIsmiumRockChance.ToString("F2")}% -> {nextFullIsmiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Iridium rocks spawn
        else if (upgradeType == 9)
        {
            float nextIridiumRockChance = 0;
            float nextFullIridiumRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "IridiumSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "IridiumChunk1")
            {
                isChunk = true;
                iridiumRockChanceIncrease = 0.08f;
            }
            else if (upgradeName == "IridiumFull1")
            {
                isChunk = false;
                fullIridiumRockChanceIncrease = 0.07f;
            }

            if (isSpawn)
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Iridium Rocks";
                    skillTreeDesc_text.text = "Iridium rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches d'Iridium";
                    skillTreeDesc_text.text = "Les roches d'iridium commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Iridio";
                    skillTreeDesc_text.text = "Le rocce di iridio inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Iridium-Steine erscheinen";
                    skillTreeDesc_text.text = "Iridium-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Iridio";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de iridio!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イリジウム岩を生成";
                    skillTreeDesc_text.text = "これからイリジウムの岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "이리듐 암석 생성";
                    skillTreeDesc_text.text = "이제 이리듐 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Irydowe";
                    skillTreeDesc_text.text = "Skały irydowe zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Irídio";
                    skillTreeDesc_text.text = "As rochas de irídio começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Иридиевых Камней";
                    skillTreeDesc_text.text = "Иридиевые камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成铱矿石";
                    skillTreeDesc_text.text = "铱矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Iridium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Iridium";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Iridio";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Iridium-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Iridio";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イリジウム岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "이리듐 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Irydowych";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Irídio";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Иридиевых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多铱矿石";
                }
                #endregion

                nextIridiumRockChance = SkillTree.iridiumRockChance + iridiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total iridium chunk rock spawn chance:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux d'iridium :\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di iridio:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Iridiumbrocken-Steine:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de iridio:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イリジウムチャンク岩の出現確率合計：\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"이리듐 조각 암석 총 생성 확률:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył irydu:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de irídio:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления иридиевых глыб:\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"铱块矿石生成总概率：\n{SkillTree.iridiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the iridium chunk rock spawn chance:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux d'iridium :\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di iridio:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Iridiumbrocken-Steine:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de iridio:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イリジウムチャンク岩の出現確率を増加：\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"이리듐 조각 암석 생성 확률 증가:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył irydu:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de irídio:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления иридиевых глыб:\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升铱块矿石生成概率：\n{SkillTree.iridiumRockChance.ToString("F2")}% -> {nextIridiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Iridium Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches d'Iridium Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Iridio Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Iridium-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Iridio Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "イリジウムフル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 이리듐 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Irydowych";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Irídio Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Иридиевых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整铱矿石";
                }
                #endregion

                nextFullIridiumRockChance = SkillTree.fullIridiumRockChance + fullIridiumRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full iridium rock spawn chance:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches d'iridium complètes :\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di iridio piene:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Iridium-Steine:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de iridio completas:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イリジウムフル岩の出現確率合計：\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 이리듐 암석 총 생성 확률:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał irydu:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de irídio inteiras:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных иридиевых камней:\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整铱矿石生成总概率：\n{SkillTree.fullIridiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full iridium rock spawn chance:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches d'iridium complètes :\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di iridio piene:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Iridium-Steine:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de iridio completas:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"イリジウムフル岩の出現確率を増加：\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 이리듐 암석 생성 확률 증가:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał irydu:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de irídio inteiras:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных иридиевых камней:\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整铱矿石生成概率：\n{SkillTree.fullIridiumRockChance.ToString("F2")}% -> {nextFullIridiumRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Painite rocks spawn
        else if (upgradeType == 10)
        {
            float nextPainiteRockChance = 0;
            float nextFullPainiteRockChance = 0;

            bool isSpawn = false;
            bool isChunk = false;

            if (upgradeName == "PainiteSpawn")
            {
                isSpawn = true;
            }
            else if (upgradeName == "PainiteChunk1")
            {
                isChunk = true;
                painiteRockChanceIncrease = 0.06f;
            }
            else if (upgradeName == "FullPainite1")
            {
                isChunk = false;
                fullPainiteRockChanceIncrease = 0.05f;
            }

            if (isSpawn)
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Spawn Painite Rocks";
                    skillTreeDesc_text.text = "Painite rocks will now start spawning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Apparition des Roches de Painite";
                    skillTreeDesc_text.text = "Les roches de painite commenceront maintenant à apparaître !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Genera Rocce di Painite";
                    skillTreeDesc_text.text = "Le rocce di painite inizieranno a comparire!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Painit-Steine erscheinen";
                    skillTreeDesc_text.text = "Painit-Steine erscheinen jetzt!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Generar Rocas de Painita";
                    skillTreeDesc_text.text = "¡Ahora comenzarán a aparecer rocas de painita!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ペイン石岩を生成";
                    skillTreeDesc_text.text = "これからペイン石の岩が出現します！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "페인石 암석 생성";
                    skillTreeDesc_text.text = "이제 페인石 암석이 생성됩니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Generuj Skały Painitu";
                    skillTreeDesc_text.text = "Skały painitu zaczną się teraz pojawiać!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Gerar Rochas de Painita";
                    skillTreeDesc_text.text = "As rochas de painita começarão a aparecer!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Появление Пайнитовых Камней";
                    skillTreeDesc_text.text = "Пайнитовые камни теперь будут появляться!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "生成电气石矿石";
                    skillTreeDesc_text.text = "电气石矿石现在会开始生成！";
                }
                #endregion
            }
            else if (isChunk)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Painite Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Painite";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Painite";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Painit-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Painita";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ペイン石岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "페인石 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Painitu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Painita";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Пайнитовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多电气石矿石";
                }
                #endregion

                nextPainiteRockChance = SkillTree.painiteRockChance + painiteRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total painite chunk rock spawn chance:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches à morceaux de painite :\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce a pezzi di painite:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für Painitbrocken-Steine:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de trozos de painita:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ペイン石チャンク岩の出現確率合計：\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"페인石 조각 암석 총 생성 확률:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się brył painitu:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de pedaços de painita:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления пайнитовых глыб:\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"电气石块矿石生成总概率：\n{SkillTree.painiteRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the painite chunk rock spawn chance:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches à morceaux de painite :\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce a pezzi di painite:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für Painitbrocken-Steine:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de trozos de painita:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ペイン石チャンク岩の出現確率を増加：\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"페인石 조각 암석 생성 확률 증가:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się brył painitu:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de pedaços de painita:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления пайнитовых глыб:\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升电气石块矿石生成概率：\n{SkillTree.painiteRockChance.ToString("F2")}% -> {nextPainiteRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Full Painite Rocks";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches de Painite Complètes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Painite Piene";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Ganze Painit-Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Painita Completas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ペイン石フル岩増加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "전체 페인石 암석 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Pełnych Skał Painitu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Painita Inteiras";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Полных Пайнитовых Камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多完整电气石矿石";
                }
                #endregion

                nextFullPainiteRockChance = SkillTree.fullPainiteRockChance + fullPainiteRockChanceIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total full painite rock spawn chance:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition totale des roches de painite complètes :\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di spawn di rocce di painite piene:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance für ganze Painit-Steine:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de aparición de rocas de painita completas:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ペイン石フル岩の出現確率合計：\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 페인石 암석 총 생성 확률:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się pełnych skał painitu:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de surgimento de rochas de painita inteiras:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс появления полных пайнитовых камней:\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"完整电气石矿石生成总概率：\n{SkillTree.fullPainiteRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the full painite rock spawn chance:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la chance d'apparition des roches de painite complètes :\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilità di spawn di rocce di painite piene:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Spawn-Chance für ganze Painit-Steine:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de rocas de painita completas:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ペイン石フル岩の出現確率を増加：\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"전체 페인石 암석 생성 확률 증가:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa szansę na pojawienie się pełnych skał painitu:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta a chance de surgimento de rochas de painita inteiras:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает шанс появления полных пайнитовых камней:\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"提升完整电气石矿石生成概率：\n{SkillTree.fullPainiteRockChance.ToString("F2")}% -> {nextFullPainiteRockChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Lightning Beam Upgrades
        else if (upgradeType == 11)
        {
            bool isLightningS = false;
            bool isLightningPH = false;

            if (upgradeName == "LightningChanceS1")
            {
                lightningTriggerChanceS_Increase = 10;
                isLightningS = true;
            }
            else if (upgradeName == "LightningChanceS2")
            {
                lightningTriggerChanceS_Increase = 10;
                isLightningS = true;
            }
            else if (upgradeName == "LightningChancePH1")
            {
                lightningTriggerChancePH_Increase = 0.07f;
                isLightningPH = true;
            }
            else if (upgradeName == "LightningChancePH2")
            {
                lightningTriggerChancePH_Increase = 0.08f;
                isLightningPH = true;
            }

            float nextLightningSChance = 0;
            nextLightningSChance = SkillTree.lightningTriggerChanceS + lightningTriggerChanceS_Increase;

            float nextLightningPHChance = 0;
            nextLightningPHChance = SkillTree.lightningTriggerChancePH + lightningTriggerChancePH_Increase;

            if (isLightningS == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Lightning Beam!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Rayon Fulgurant !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Raggio Fulmineo!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Blitzstrahl!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Rayo Relámpago!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ライトニングビーム！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "번개 빔!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Promień Błyskawicy!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Raio Relâmpago!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Луч Молнии!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "闪电光束！";
                }
                #endregion

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total chance to spawn a lightning beam every second:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance totale de générer un rayon fulgurant chaque seconde :\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di generare un raggio fulmineo ogni secondo:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance, jede Sekunde einen Blitzstrahl zu erzeugen:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de generar un rayo relámpago cada segundo:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"毎秒ライトニングビームが発生する総確率：\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"매초 번개 빔이 생성될 총 확률:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na wywołanie promienia błyskawicy co sekundę:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de gerar um raio relâmpago a cada segundo:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс вызвать луч молнии каждую секунду:\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每秒触发闪电光束的总概率：\n{SkillTree.lightningTriggerChanceS.ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Every second, chance to spawn a lightning beam at a random rock.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% The beam deals 3X your pickaxe power";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Chaque seconde, chance de générer un rayon fulgurant sur une roche aléatoire.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% Le rayon inflige 3X la puissance de votre pioche";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Ogni secondo, possibilità di generare un raggio fulmineo su una roccia casuale.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% Il raggio infligge 3X la potenza del tuo piccone";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Jede Sekunde Chance, einen Blitzstrahl auf einen zufälligen Stein zu erzeugen.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% Der Strahl verursacht 3X deine Spitzhackenstärke";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Cada segundo, probabilidad de generar un rayo relámpago en una roca aleatoria.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% El rayo inflige 3X la potencia de tu pico";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"<size=24>毎秒、ランダムな岩にライトニングビームを発生させる確率。\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% ビームはピッケルのパワーの3倍のダメージを与える";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"매초 무작위 암석에 번개 빔이 생성될 확률.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% 빔은 곡괭이 파워의 3배 피해를 입힘";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"<size=24>Co sekundę szansa na pojawienie się promienia błyskawicy na losowej skale.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% Promień zadaje 3X moc kilofa";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"<size=24>A cada segundo, chance de gerar um raio relâmpago em uma rocha aleatória.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% O raio causa 3X o poder da sua picareta";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"<size=24>Каждую секунду шанс вызвать луч молнии на случайном камне.\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% Луч наносит 3X силу вашей кирки";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每秒有机会在随机岩石上生成闪电光束。\n{SkillTree.lightningTriggerChanceS.ToString("F0")}% -> {nextLightningSChance.ToString("F0")}% 光束造成相当于你镐子威力3倍的伤害";
                    }
                    #endregion
                }
            }
            if (isLightningPH == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Pickaxe Lightning!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Foudre de Pioche !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Fulmine del Piccone!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Spitzhacken-Blitz!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Rayo del Pico!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ピッケルライトニング！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "곡괭이 번개!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Błyskawica Kilofa!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Relâmpago da Picareta!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Молния Кирки!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "镐子闪电！";
                }
                #endregion

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total chance to spawn a lightning beam every pickaxe hit:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance totale de générer un rayon fulgurant à chaque coup de pioche :\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di generare un raggio fulmineo a ogni colpo di piccone:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance, bei jedem Spitzhacken-Schlag einen Blitzstrahl zu erzeugen:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de generar un rayo relámpago con cada golpe de pico:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケルの一振りごとにライトニングビームが発生する総確率：\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 타격마다 번개 빔이 생성될 총 확률:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na wywołanie promienia błyskawicy przy każdym uderzeniu kilofa:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de gerar um raio relâmpago a cada golpe de picareta:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс вызвать луч молнии при каждом ударе киркой:\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每次镐子敲击时生成闪电光束的总概率：\n{SkillTree.lightningTriggerChancePH.ToString("F1")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Every pickaxe hit, chance to spawn a lightning beam at a close rock\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% The beam deals 2X your pickaxe power";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>À chaque coup de pioche, chance de générer un rayon fulgurant sur une roche proche\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% Le rayon inflige 2X la puissance de votre pioche";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>A ogni colpo di piccone, possibilità di generare un raggio fulmineo su una roccia vicina\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% Il raggio infligge 2X la potenza del tuo piccone";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Bei jedem Spitzhacken-Schlag Chance, einen Blitzstrahl auf einen nahen Stein zu erzeugen\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% Der Strahl verursacht 2X deine Spitzhackenstärke";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Con cada golpe de pico, probabilidad de generar un rayo relámpago en una roca cercana\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% El rayo inflige 2X la potencia de tu pico";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>ピッケルの一振りごとに近くの岩にライトニングビームが発生する確率\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% ビームはピッケルのパワーの2倍のダメージを与える";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 타격마다 근처 암석에 번개 빔이 생성될 확률\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% 빔은 곡괭이 파워의 2배 피해를 입힘";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Przy każdym uderzeniu kilofa szansa na wywołanie promienia błyskawicy na pobliskiej skale\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% Promień zadaje 2X moc kilofa";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>A cada golpe de picareta, chance de gerar um raio relâmpago em uma rocha próxima\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% O raio causa 2X o poder da sua picareta";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>При каждом ударе киркой шанс вызвать луч молнии на ближайшем камне\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% Луч наносит 2X силу вашей кирки";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每次镐子敲击时，有机会在附近岩石上生成闪电光束\n{SkillTree.lightningTriggerChancePH.ToString("F2")}% -> {nextLightningPHChance.ToString("F2")}% 光束造成相当于你镐子威力2倍的伤害";
                    }
                    #endregion
                }
            }
            else
            {
                if (upgradeName == "LightningSpawnAnotherChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning = Lightning";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% chance to spawn another lightning beam after each lightning beam hit";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Foudre = Foudre";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% de chance de générer un autre rayon fulgurant après chaque impact de rayon";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Fulmine = Fulmine";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% di possibilità di generare un altro raggio fulmineo dopo ogni colpo di raggio";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitz = Blitz";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% Chance, nach jedem Blitzstrahl-Treffer einen weiteren zu erzeugen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Rayo = Rayo";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% de probabilidad de generar otro rayo relámpago después de cada impacto de rayo";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニング = ライトニング";
                        skillTreeDesc_text.text = $"ライトニングビーム命中後、{SkillTree.triggerAnotherLighntingChance.ToString("F0")}%の確率で別のビームを発生";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 = 번개";
                        skillTreeDesc_text.text = $"번개 빔이 적중할 때마다 {SkillTree.triggerAnotherLighntingChance.ToString("F0")}% 확률로 추가 번개 빔 생성";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Błyskawica = Błyskawica";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% szansy na wygenerowanie kolejnego promienia po każdym trafieniu promieniem";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Relâmpago = Relâmpago";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% de chance de gerar outro raio após cada impacto de raio";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Молния = Молния";
                        skillTreeDesc_text.text = $"{SkillTree.triggerAnotherLighntingChance.ToString("F0")}% шанс вызвать ещё один луч молнии после каждого попадания луча";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电 = 闪电";
                        skillTreeDesc_text.text = $"每次闪电光束命中后有 {SkillTree.triggerAnotherLighntingChance.ToString("F0")}% 的几率再生成一道闪电光束";
                    }
                    #endregion
                }
                else if (upgradeName == "LightningSplash")
                {
                    #region Name texts desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Electricity Sparks";
                        skillTreeDesc_text.text = $"Every lightning beam has a {SkillTree.lightningSplashChance.ToString("F0")}% chance to spawn 3-5 electricity sparks.\nEach spark deals {SkillTree.lightningSparkDamage}% of the lightning beam's power";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Étincelles Électriques";
                        skillTreeDesc_text.text = $"Chaque rayon fulgurant a {SkillTree.lightningSplashChance.ToString("F0")}% de chance de générer 3 à 5 étincelles électriques.\nChaque étincelle inflige {SkillTree.lightningSparkDamage}% de la puissance du rayon";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Scintille Elettriche";
                        skillTreeDesc_text.text = $"Ogni raggio fulmineo ha il {SkillTree.lightningSplashChance.ToString("F0")}% di probabilità di generare 3-5 scintille elettriche.\nOgni scintilla infligge il {SkillTree.lightningSparkDamage}% della potenza del raggio";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Elektrische Funken";
                        skillTreeDesc_text.text = $"Jeder Blitzstrahl hat eine Chance von {SkillTree.lightningSplashChance.ToString("F0")}%, 3–5 elektrische Funken zu erzeugen.\nJeder Funke verursacht {SkillTree.lightningSparkDamage}% der Strahlstärke";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Chispas Eléctricas";
                        skillTreeDesc_text.text = $"Cada rayo relámpago tiene un {SkillTree.lightningSplashChance.ToString("F0")}% de probabilidad de generar de 3 a 5 chispas eléctricas.\nCada chispa inflige el {SkillTree.lightningSparkDamage}% de la potencia del rayo";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "エレクトリックスパーク";
                        skillTreeDesc_text.text = $"ライトニングビームごとに{SkillTree.lightningSplashChance.ToString("F0")}%の確率で3〜5個の電気スパークを生成。\n各スパークはビームパワーの{SkillTree.lightningSparkDamage}%のダメージを与える";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "전기 스파크";
                        skillTreeDesc_text.text = $"번개 빔마다 {SkillTree.lightningSplashChance.ToString("F0")}% 확률로 3~5개의 전기 스파크 생성.\n각 스파크는 빔 파워의 {SkillTree.lightningSparkDamage}% 피해를 입힘";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Iskry Elektryczne";
                        skillTreeDesc_text.text = $"Każdy promień błyskawicy ma {SkillTree.lightningSplashChance.ToString("F0")}% szansy na wygenerowanie 3–5 iskr elektrycznych.\nKażda iskra zadaje {SkillTree.lightningSparkDamage}% mocy promienia";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Faíscas Elétricas";
                        skillTreeDesc_text.text = $"Cada raio relâmpago tem {SkillTree.lightningSplashChance.ToString("F0")}% de chance de gerar 3 a 5 faíscas elétricas.\nCada faísca causa {SkillTree.lightningSparkDamage}% do poder do raio";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Электрические Искры";
                        skillTreeDesc_text.text = $"Каждый луч молнии имеет {SkillTree.lightningSplashChance.ToString("F0")}% шанс породить 3–5 электрических искр.\nКаждая искра наносит {SkillTree.lightningSparkDamage}% силы луча";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "电火花";
                        skillTreeDesc_text.text = $"每道闪电光束有 {SkillTree.lightningSplashChance.ToString("F0")}% 的几率生成 3-5 个电火花。\n每个火花造成光束威力的 {SkillTree.lightningSparkDamage}% 伤害";
                    }
                    #endregion
                }
                else if (upgradeName == "LightningSpawnRockChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning = Rocks";
                        skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningSpawnRockChance.ToString("F0")}% chance to spawn a rock.";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Foudre = Roches";
                        skillTreeDesc_text.text = $"Chaque impact de rayon fulgurant a {SkillTree.lightningSpawnRockChance.ToString("F0")}% de chance de générer une roche.";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Fulmine = Rocce";
                        skillTreeDesc_text.text = $"Ogni colpo di raggio fulmineo ha il {SkillTree.lightningSpawnRockChance.ToString("F0")}% di probabilità di generare una roccia.";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitz = Steine";
                        skillTreeDesc_text.text = $"Jeder Blitzstrahl-Treffer hat eine Chance von {SkillTree.lightningSpawnRockChance.ToString("F0")}%, einen Stein zu erzeugen.";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Rayo = Rocas";
                        skillTreeDesc_text.text = $"Cada impacto de rayo relámpago tiene un {SkillTree.lightningSpawnRockChance.ToString("F0")}% de probabilidad de generar una roca.";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニング = 岩";
                        skillTreeDesc_text.text = $"ライトニングビーム命中ごとに{SkillTree.lightningSpawnRockChance.ToString("F0")}%の確率で岩を生成。";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 = 암석";
                        skillTreeDesc_text.text = $"번개 빔이 적중할 때마다 {SkillTree.lightningSpawnRockChance.ToString("F0")}% 확률로 암석 생성.";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Błyskawica = Skały";
                        skillTreeDesc_text.text = $"Każde trafienie promieniem błyskawicy ma {SkillTree.lightningSpawnRockChance.ToString("F0")}% szansy na wygenerowanie skały.";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Relâmpago = Rochas";
                        skillTreeDesc_text.text = $"Cada impacto de raio relâmpago tem {SkillTree.lightningSpawnRockChance.ToString("F0")}% de chance de gerar uma rocha.";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Молния = Камни";
                        skillTreeDesc_text.text = $"Каждое попадание луча молнии имеет {SkillTree.lightningSpawnRockChance.ToString("F0")}% шанс породить камень.";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电 = 岩石";
                        skillTreeDesc_text.text = $"每次闪电光束命中有 {SkillTree.lightningSpawnRockChance.ToString("F0")}% 的几率生成一块岩石。";
                    }
                    #endregion
                }
                else if (upgradeName == "LightningExplosionChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning Explosion";
                        skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% chance to trigger a dynamite explosion";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Explosion Fulgurante";
                        skillTreeDesc_text.text = $"<size=19>Chaque impact de rayon fulgurant a {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% de chance de déclencher une explosion de dynamite";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Esplosione Fulminea";
                        skillTreeDesc_text.text = $"<size=21>Ogni colpo di raggio fulmineo ha il {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% di probabilità di attivare un'esplosione di dinamite";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitzexplosion";
                        skillTreeDesc_text.text = $"<size=22>Jeder Blitzstrahl-Treffer hat eine Chance von {SkillTree.lightningSpawnExplosionChance.ToString("F0")}%, eine Dynamitexplosion auszulösen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Explosión Relámpago";
                        skillTreeDesc_text.text = $"<size=22>Cada impacto de rayo relámpago tiene un {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% de probabilidad de activar una explosión de dinamita";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニングエクスプロージョン";
                        skillTreeDesc_text.text = $"ライトニングビーム命中ごとに{SkillTree.lightningSpawnExplosionChance.ToString("F0")}%の確率でダイナマイト爆発を発生させる";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 폭발";
                        skillTreeDesc_text.text = $"번개 빔이 적중할 때마다 {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% 확률로 다이너마이트 폭발 발생";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Eksplozja Błyskawicy";
                        skillTreeDesc_text.text = $"<size=22>Każde trafienie promieniem błyskawicy ma {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% szansy na wywołanie eksplozji dynamitu";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Explosão Relâmpago";
                        skillTreeDesc_text.text = $"<size=22>Cada impacto de raio relâmpago tem {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% de chance de ativar uma explosão de dinamite";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Молниеносный Взрыв";
                        skillTreeDesc_text.text = $"Каждое попадание луча молнии имеет {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% шанс вызвать взрыв динамита";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电爆炸";
                        skillTreeDesc_text.text = $"每次闪电光束命中有 {SkillTree.lightningSpawnExplosionChance.ToString("F0")}% 的几率触发炸药爆炸";
                    }
                    #endregion
                }
                else if (upgradeName == "LightningAddTimeChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning = Time";
                        skillTreeDesc_text.text = $"Every lightning beam hit has a {SkillTree.lightningAddTimeChance.ToString("F1")}% chance to add 1 second to the timer";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Foudre = Temps";
                        skillTreeDesc_text.text = $"<size=22>Chaque impact de rayon fulgurant a {SkillTree.lightningAddTimeChance.ToString("F1")}% de chance d'ajouter 1 seconde au minuteur";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Fulmine = Tempo";
                        skillTreeDesc_text.text = $"<size=22>Ogni colpo di raggio fulmineo ha il {SkillTree.lightningAddTimeChance.ToString("F1")}% di probabilità di aggiungere 1 secondo al timer";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitz = Zeit";
                        skillTreeDesc_text.text = $"<size=22>Jeder Blitzstrahl-Treffer hat eine Chance von {SkillTree.lightningAddTimeChance.ToString("F1")}%, 1 Sekunde zum Timer hinzuzufügen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Rayo = Tiempo";
                        skillTreeDesc_text.text = $"<size=22>Cada impacto de rayo relámpago tiene un {SkillTree.lightningAddTimeChance.ToString("F1")}% de probabilidad de añadir 1 segundo al temporizador";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニング = タイム";
                        skillTreeDesc_text.text = $"ライトニングビーム命中ごとに{SkillTree.lightningAddTimeChance.ToString("F1")}%の確率でタイマーに1秒追加";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 = 시간";
                        skillTreeDesc_text.text = $"번개 빔이 적중할 때마다 {SkillTree.lightningAddTimeChance.ToString("F1")}% 확률로 타이머에 1초 추가";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Błyskawica = Czas";
                        skillTreeDesc_text.text = $"<size=22>Każde trafienie promieniem błyskawicy ma {SkillTree.lightningAddTimeChance.ToString("F1")}% szansy na dodanie 1 sekundy do timera";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Relâmpago = Tempo";
                        skillTreeDesc_text.text = $"<size=22>Cada impacto de raio relâmpago tem {SkillTree.lightningAddTimeChance.ToString("F1")}% de chance de adicionar 1 segundo ao cronômetro";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Молния = Время";
                        skillTreeDesc_text.text = $"<size=23>Каждое попадание луча молнии имеет {SkillTree.lightningAddTimeChance.ToString("F1")}% шанс добавить 1 секунду к таймеру";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电 = 时间";
                        skillTreeDesc_text.text = $"每次闪电光束命中有 {SkillTree.lightningAddTimeChance.ToString("F1")}% 的几率为计时器增加 1 秒";
                    }
                    #endregion
                }
                else if (upgradeName == "LightningDamage")
                {
                    #region Name texts
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning Damage";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Dégâts de Foudre";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Danno Fulmineo";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitzschaden";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Daño de Rayo";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニングダメージ";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 피해";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Obrażenia Błyskawicy";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Dano de Relâmpago";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Урон Молнии";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电伤害";
                    }
                    #endregion

                    lightningDamageIncrease = 0.2f;

                    float nextLightningBeamDamage = SkillTree.lightningDamage + 1 + lightningDamageIncrease;

                    if (isPurchasedMax == true)
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Total lightning beam damage:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Dégâts totaux du rayon fulgurant :\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Danno totale del raggio fulmineo:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Gesamter Blitzstrahl-Schaden:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Daño total del rayo relámpago:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ライトニングビームの総ダメージ：\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"번개 빔 총 피해량:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Łączne obrażenia promienia błyskawicy:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Dano total do raio relâmpago:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Общий урон луча молнии:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"闪电光束总伤害：\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                    else
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Increase the lightning beam damage:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Augmente les dégâts du rayon fulgurant :\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta il danno del raggio fulmineo:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Erhöht den Blitzstrahl-Schaden:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta el daño del rayo relámpago:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ライトニングビームのダメージを増加：\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"번개 빔 피해량 증가:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Zwiększa obrażenia promienia błyskawicy:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta o dano do raio relâmpago:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Увеличивает урон луча молнии:\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"提升闪电光束伤害：\n{((SkillTree.lightningDamage + 1) * 100).ToString("F0")}% -> {(nextLightningBeamDamage * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                }
                else if (upgradeName == "LightningSize")
                {
                    #region Name texts
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Lightning Size";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Taille de la Foudre";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Dimensione Fulminea";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Blitzgröße";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Tamaño del Rayo";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ライトニングサイズ";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "번개 크기";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Rozmiar Błyskawicy";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Tamanho do Relâmpago";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Размер Молнии";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "闪电大小";
                    }
                    #endregion

                    lightningSizeIncrease = 0.25f;

                    float nextLightningBeamSize = SkillTree.lightningSize + lightningSizeIncrease;

                    if (isPurchasedMax == true)
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Total lightning beam size:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Taille totale du rayon fulgurant :\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Dimensione totale del raggio fulmineo:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Gesamtgröße des Blitzstrahls:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Tamaño total del rayo relámpago:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ライトニングビームのサイズ合計：\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"번개 빔 총 크기:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Łączny rozmiar promienia błyskawicy:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Tamanho total do raio relâmpago:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Общий размер луча молнии:\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"闪电光束总大小：\n{(SkillTree.lightningSize * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                    else
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Increase the lightning beam size:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Augmente la taille du rayon fulgurant :\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta la dimensione del raggio fulmineo:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Erhöht die Größe des Blitzstrahls:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta el tamaño del rayo relámpago:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ライトニングビームのサイズを増加：\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"번개 빔 크기 증가:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Zwiększa rozmiar promienia błyskawicy:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta o tamanho do raio relâmpago:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Увеличивает размер луча молнии:\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"提升闪电光束大小：\n{(SkillTree.lightningSize * 100).ToString("F0")}% -> {(nextLightningBeamSize * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion

        #region Dynamite
        else if (upgradeType == 12)
        {
            bool isChanceToStick = false;

            if (upgradeName == "DynamiteStickChance1")
            {
                dynamiteStickChanceIncrease = 0.1f;
                isChanceToStick = true;
            }
            if (upgradeName == "DynamiteStickChance2")
            {
                isChanceToStick = true;
                dynamiteStickChanceIncrease = 0.2f;
            }

            float nextDynamiteStickChance = SkillTree.dynamiteStickChance + dynamiteStickChanceIncrease;

            if (isChanceToStick == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Sticky Dynamite";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Dynamite Collante";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Dinamite Appiccicosa";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Klebe-Dynamit";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Dinamita Pegajosa";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "スティッキーダイナマイト";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "끈적한 다이너마이트";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Lepka Dynamit";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Dinamite Grudenta";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Липкий Динамит";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "粘性炸药";
                }
                #endregion

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total dynamite stick chance:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance totale de coller une dynamite :\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di attaccare una dinamite:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance, Dynamit zu heften:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de pegar dinamita:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ダイナマイトがくっつく総確率：\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"다이너마이트 붙는 총 확률:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na przyklejenie dynamitu:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de grudar dinamite:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс прикрепить динамит:\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"粘附炸药总概率：\n{SkillTree.dynamiteStickChance.ToString("F1")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Every pickaxe hit has a chance to stick a dynamite.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. The dynamite explosion deals 1.2X your pickaxe power.";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chaque coup de pioche a une chance de coller une dynamite.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. L'explosion inflige 1,2X les dégâts de votre pioche.";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Ogni colpo di piccone ha una probabilità di attaccare una dinamite.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. L'esplosione infligge 1,2X il danno del tuo piccone.";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Jeder Spitzhacken-Schlag hat eine Chance, Dynamit zu heften.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. Die Explosion verursacht 1,2X deinen Spitzhackenschaden.";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Cada golpe de pico tiene una probabilidad de pegar dinamita.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}%. La explosión inflige 1,2X el daño de tu pico.";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケルの一振りごとにダイナマイトがくっつく確率がある。\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% 爆発はピッケルダメージの1.2倍を与える。";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 타격마다 다이너마이트가 붙을 확률이 있음.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% 폭발은 곡괭이 피해의 1.2배를 입힘.";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Każde uderzenie kilofa ma szansę przykleić dynamit.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% Eksplozja zadaje 1,2X obrażeń twojego kilofa.";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Cada golpe de picareta tem chance de grudar uma dinamite.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% A explosão causa 1,2X o dano da sua picareta.";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Каждый удар киркой может прикрепить динамит.\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% Взрыв наносит 1,2X урона вашей кирки.";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每次镐子敲击都有几率粘附炸药。\n{SkillTree.dynamiteStickChance.ToString("F1")}% -> {nextDynamiteStickChance.ToString("F1")}% 爆炸造成你镐子伤害的 1.2 倍。";
                    }
                    #endregion
                }
            }
            else
            {
                if(upgradeName == "DynamiteSpawn2SmallChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Explosion = Explosion";
                        skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.spawn2DynamiteChance.ToString("F0")}% chance to spawn 2 small explosions.\nThe small explosion deals 33% of the big explosion power.";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Explosion = Explosion";
                        skillTreeDesc_text.text = $"<size=23>Chaque explosion de dynamite a {SkillTree.spawn2DynamiteChance.ToString("F0")}% de chance de générer 2 petites explosions.\nChaque petite explosion inflige 33% de la puissance de la grande explosion.";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Esplosione = Esplosione";
                        skillTreeDesc_text.text = $"<size=23>Ogni esplosione di dinamite ha il {SkillTree.spawn2DynamiteChance.ToString("F0")}% di probabilità di generare 2 piccole esplosioni.\nOgni piccola esplosione infligge il 33% della potenza dell'esplosione grande.";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Explosion = Explosion";
                        skillTreeDesc_text.text = $"<size=22>Jede Dynamitexplosion hat eine Chance von {SkillTree.spawn2DynamiteChance.ToString("F0")}%, 2 kleine Explosionen zu erzeugen.\nJede kleine Explosion verursacht 33% der Kraft der großen Explosion.";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Explosión = Explosión";
                        skillTreeDesc_text.text = $"<size=18>Cada explosión de dinamita tiene un {SkillTree.spawn2DynamiteChance.ToString("F0")}% de probabilidad de generar 2 explosiones pequeñas.\nCada explosión pequeña inflige el 33% de la potencia de la explosión grande.";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "エクスプロージョン = エクスプロージョン";
                        skillTreeDesc_text.text = $"ダイナマイト爆発ごとに{SkillTree.spawn2DynamiteChance.ToString("F0")}%の確率で小さな爆発が2つ発生。\n小爆発は大爆発パワーの33%のダメージを与える。";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "폭발 = 폭발";
                        skillTreeDesc_text.text = $"다이너마이트 폭발마다 {SkillTree.spawn2DynamiteChance.ToString("F0")}% 확률로 작은 폭발 2개 생성.\n작은 폭발은 큰 폭발 파워의 33% 피해를 입힘.";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Eksplozja = Eksplozja";
                        skillTreeDesc_text.text = $"<size=22>Każda eksplozja dynamitu ma {SkillTree.spawn2DynamiteChance.ToString("F0")}% szansy na stworzenie 2 małych eksplozji.\nMała eksplozja zadaje 33% mocy dużej eksplozji.";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Explosão = Explosão";
                        skillTreeDesc_text.text = $"<size=22>Cada explosão de dinamite tem {SkillTree.spawn2DynamiteChance.ToString("F0")}% de chance de gerar 2 pequenas explosões.\nCada pequena explosão causa 33% do poder da grande explosão.";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Взрыв = Взрыв";
                        skillTreeDesc_text.text = $"<size=23>Каждый взрыв динамита имеет {SkillTree.spawn2DynamiteChance.ToString("F0")}% шанс породить 2 маленьких взрыва.\nМаленький взрыв наносит 33% силы большого взрыва.";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "爆炸 = 爆炸";
                        skillTreeDesc_text.text = $"每次炸药爆炸有 {SkillTree.spawn2DynamiteChance.ToString("F0")}% 的几率生成 2 次小爆炸。\n小爆炸造成大爆炸威力的 33%。";
                    }
                    #endregion
                }
                else if (upgradeName == "DynamiteSpawnRockChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Explosion = Rock";
                        skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% chance to spawn a rock";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Explosion = Roche";
                        skillTreeDesc_text.text = $"Chaque explosion de dynamite a {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% de chance de générer une roche";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Esplosione = Roccia";
                        skillTreeDesc_text.text = $"Ogni esplosione di dinamite ha il {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% di probabilità di generare una roccia";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Explosion = Stein";
                        skillTreeDesc_text.text = $"Jede Dynamitexplosion hat eine Chance von {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% einen Stein zu erzeugen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Explosión = Roca";
                        skillTreeDesc_text.text = $"Cada explosión de dinamita tiene un {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% de probabilidad de generar una roca";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "エクスプロージョン = 岩";
                        skillTreeDesc_text.text = $"ダイナマイト爆発ごとに{SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}%の確率で岩を生成";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "폭발 = 암석";
                        skillTreeDesc_text.text = $"다이너마이트 폭발마다 {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% 확률로 암석 생성";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Eksplozja = Skała";
                        skillTreeDesc_text.text = $"Każda eksplozja dynamitu ma {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% szansy na wygenerowanie skały";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Explosão = Rocha";
                        skillTreeDesc_text.text = $"Cada explosão de dinamite tem {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% de chance de gerar uma rocha";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Взрыв = Камень";
                        skillTreeDesc_text.text = $"Каждый взрыв динамита имеет {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% шанс породить камень";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "爆炸 = 岩石";
                        skillTreeDesc_text.text = $"每次炸药爆炸有 {SkillTree.chanceToSpawnRockFromExplosion.ToString("F0")}% 的几率生成岩石";
                    }
                    #endregion
                }
                else if (upgradeName == "DynamiteAddTimeChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Explosion = Time";
                        skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.explosionAdd1SecondChance.ToString("F2")}% chance to add 1 second to the timer";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Explosion = Temps";
                        skillTreeDesc_text.text = $"Chaque explosion de dynamite a {SkillTree.explosionAdd1SecondChance.ToString("F2")}% de chance d'ajouter 1 seconde au minuteur";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Esplosione = Tempo";
                        skillTreeDesc_text.text = $"Ogni esplosione di dinamite ha il {SkillTree.explosionAdd1SecondChance.ToString("F2")}% di probabilità di aggiungere 1 secondo al timer";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Explosion = Zeit";
                        skillTreeDesc_text.text = $"Jede Dynamitexplosion hat eine Chance von {SkillTree.explosionAdd1SecondChance.ToString("F2")}%, 1 Sekunde zum Timer hinzuzufügen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Explosión = Tiempo";
                        skillTreeDesc_text.text = $"Cada explosión de dinamita tiene un {SkillTree.explosionAdd1SecondChance.ToString("F2")}% de probabilidad de añadir 1 segundo al temporizador";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "エクスプロージョン = タイム";
                        skillTreeDesc_text.text = $"ダイナマイト爆発ごとに{SkillTree.explosionAdd1SecondChance.ToString("F2")}%の確率でタイマーに1秒追加";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "폭발 = 시간";
                        skillTreeDesc_text.text = $"다이너마이트 폭발마다 {SkillTree.explosionAdd1SecondChance.ToString("F2")}% 확률로 타이머에 1초 추가";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Eksplozja = Czas";
                        skillTreeDesc_text.text = $"Każda eksplozja dynamitu ma {SkillTree.explosionAdd1SecondChance.ToString("F2")}% szansy na dodanie 1 sekundy do timera";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Explosão = Tempo";
                        skillTreeDesc_text.text = $"Cada explosão de dinamite tem {SkillTree.explosionAdd1SecondChance.ToString("F2")}% de chance de adicionar 1 segundo ao cronômetro";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Взрыв = Время";
                        skillTreeDesc_text.text = $"Каждый взрыв динамита имеет {SkillTree.explosionAdd1SecondChance.ToString("F2")}% шанс добавить 1 секунду к таймеру";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "爆炸 = 时间";
                        skillTreeDesc_text.text = $"每次炸药爆炸有 {SkillTree.explosionAdd1SecondChance.ToString("F2")}% 的几率为计时器增加 1 秒";
                    }
                    #endregion
                }
                else if (upgradeName == "DynamiteSpawnLightningChance")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Explosion = Lightning";
                        skillTreeDesc_text.text = $"Every dynamite explosion has a {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% chance to spawn a lightning beam";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Explosion = Foudre";
                        skillTreeDesc_text.text = $"Chaque explosion de dynamite a {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% de chance de générer un rayon fulgurant";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Esplosione = Fulmine";
                        skillTreeDesc_text.text = $"Ogni esplosione di dinamite ha il {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% di probabilità di generare un raggio fulmineo";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Explosion = Blitz";
                        skillTreeDesc_text.text = $"Jede Dynamitexplosion hat eine Chance von {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}%, einen Blitzstrahl zu erzeugen";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Explosión = Rayo";
                        skillTreeDesc_text.text = $"Cada explosión de dinamita tiene un {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% de probabilidad de generar un rayo relámpago";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "エクスプロージョン = ライトニング";
                        skillTreeDesc_text.text = $"ダイナマイト爆発ごとに{SkillTree.explosionChanceToSpawnLightning.ToString("F0")}%の確率でライトニングビームを生成";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "폭발 = 번개";
                        skillTreeDesc_text.text = $"다이너마이트 폭발마다 {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% 확률로 번개 빔 생성";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Eksplozja = Błyskawica";
                        skillTreeDesc_text.text = $"Każda eksplozja dynamitu ma {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% szansy na wygenerowanie promienia błyskawicy";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Explosão = Relâmpago";
                        skillTreeDesc_text.text = $"Cada explosão de dinamite tem {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% de chance de gerar um raio relâmpago";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Взрыв = Молния";
                        skillTreeDesc_text.text = $"Каждый взрыв динамита имеет {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% шанс породить луч молнии";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "爆炸 = 闪电";
                        skillTreeDesc_text.text = $"每次炸药爆炸有 {SkillTree.explosionChanceToSpawnLightning.ToString("F0")}% 的几率生成闪电光束";
                    }
                    #endregion
                }
                else if (upgradeName == "DynamiteDamage")
                {
                    explosionDamagageIncrease = 0.25f;

                    float nextDynamiteDamage = SkillTree.explosionDamagage + explosionDamagageIncrease + 1;

                    #region Name texts
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Dynamite Damage";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Dégâts de Dynamite";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Danno Dinamite";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Dynamitschaden";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Daño de Dinamita";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ダイナマイトダメージ";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "다이너마이트 피해";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Obrażenia Dynamitu";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Dano de Dinamite";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Урон Динамита";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "炸药伤害";
                    }
                    #endregion

                    if (isPurchasedMax == true)
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Total dynamite damage:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Dégâts totaux de dynamite :\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Danno totale da dinamite:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Gesamtschaden durch Dynamit:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Daño total de dinamita:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ダイナマイトの総ダメージ：\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"다이너마이트 총 피해량:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Łączne obrażenia dynamitu:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Dano total da dinamite:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Общий урон динамита:\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"炸药总伤害：\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                    else
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Increase the dynamite damage\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Augmente les dégâts de la dynamite\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta il danno della dinamite\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Erhöht den Dynamitschaden\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta el daño de la dinamita\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ダイナマイトのダメージを増加\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"다이너마이트 피해량 증가\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Zwiększa obrażenia dynamitu\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta o dano da dinamite\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Увеличивает урон динамита\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"提升炸药伤害\n{((SkillTree.explosionDamagage + 1) * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                }
                else if (upgradeName == "DynamiteSize")
                {
                    explosionSizeIncrease = 0.2f;

                    float nextDynamiteDamage = SkillTree.explosionSize + explosionSizeIncrease;

                    #region Name texts
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Dynamite Explosion Size";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "<size=28>Taille de l'Explosion de Dynamite";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Dimensione Esplosione Dinamite";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Dynamit-Explosionsgröße";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Tamaño de la Explosión de Dinamita";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "ダイナマイト爆発サイズ";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "다이너마이트 폭발 크기";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Rozmiar Eksplozji Dynamitu";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Tamanho da Explosão de Dinamite";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Размер Взрыва Динамита";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "炸药爆炸范围";
                    }
                    #endregion

                    if (isPurchasedMax == true)
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Total dynamite explosion size:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Taille totale de l'explosion de dynamite :\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Dimensione totale esplosione dinamite:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Gesamtgröße der Dynamitexplosion:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Tamaño total de la explosión de dinamita:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ダイナマイトの爆発サイズ合計：\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"다이너마이트 폭발 총 크기:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Łączny rozmiar eksplozji dynamitu:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Tamanho total da explosão de dinamite:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Общий размер взрыва динамита:\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"炸药爆炸总范围：\n{(SkillTree.explosionSize * 100).ToString("F0")}%";
                        }
                        #endregion
                    }
                    else
                    {
                        #region Desc texts
                        if (isEnglish == true)
                        {
                            skillTreeDesc_text.text = $"Increase the dynamite explosion size\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isFrench == true)
                        {
                            skillTreeDesc_text.text = $"Augmente la taille de l'explosion de dynamite\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isItalian == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta la dimensione dell'esplosione di dinamite\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isGerman == true)
                        {
                            skillTreeDesc_text.text = $"Erhöht die Größe der Dynamitexplosion\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isSpanish == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta el tamaño de la explosión de dinamita\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isJapanese == true)
                        {
                            skillTreeDesc_text.text = $"ダイナマイトの爆発サイズを増加\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isKorean == true)
                        {
                            skillTreeDesc_text.text = $"다이너마이트 폭발 크기 증가\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isPolish == true)
                        {
                            skillTreeDesc_text.text = $"Zwiększa rozmiar eksplozji dynamitu\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isPortugese == true)
                        {
                            skillTreeDesc_text.text = $"Aumenta o tamanho da explosão de dinamite\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isRussian == true)
                        {
                            skillTreeDesc_text.text = $"Увеличивает размер взрыва динамита\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }

                        if (isSimplefiedChinese == true)
                        {
                            skillTreeDesc_text.text = $"提升炸药爆炸范围\n{(SkillTree.explosionSize * 100).ToString("F0")}% -> {(nextDynamiteDamage * 100).ToString("F1")}%";
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion

        #region Plazma ball
        else if (upgradeType == 13)
        {
            bool isChanceToSpawnPlazma = false;

            if (upgradeName == "PlazmaBallChance1")
            {
                plazmaBallChanceIncrease = 4f;
                isChanceToSpawnPlazma = true;
            }
            else if (upgradeName == "PlazmaBallChance2")
            {
                plazmaBallChanceIncrease = 5f;
                isChanceToSpawnPlazma = true;
            }

            float nextPlazmaBallChance = SkillTree.plazmaBallChance + plazmaBallChanceIncrease;

            if (isChanceToSpawnPlazma == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Plazma Balls";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Boules de Plazma";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Sfere di Plazma";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Plazma-Kugeln";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Bolas de Plazma";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "プラズマボール";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "플라즈마 볼";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Kule Plazmy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Bolas de Plazma";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Плазменные Шары";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等离子球";
                }
                #endregion

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Plazma ball spawn chance:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance d'apparition de boule de plazma :\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di generare una sfera di plazma:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Plazma-Kugel Spawn-Chance:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de aparición de bola de plazma:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボール出現確率：\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 생성 확률:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na pojawienie się kuli plazmy:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de surgimento da bola de plazma:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс появления шара плазмы:\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"等离子球生成概率：\n{SkillTree.plazmaBallChance.ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Every second, chance to spawn a plazma ball that moves across the screen.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. The ball lasts {SkillTree.plazmaBallTimer} seconds and deals 0.75X your pickaxe power";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Chaque seconde, chance de générer une boule de plazma qui traverse l'écran.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. La boule dure {SkillTree.plazmaBallTimer} secondes et inflige 0,75X la puissance de votre pioche";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Ogni secondo, possibilità di generare una sfera di plazma che attraversa lo schermo.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. La sfera dura {SkillTree.plazmaBallTimer} secondi e infligge 0,75X la potenza del tuo piccone";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Jede Sekunde Chance, eine Plazma-Kugel zu erzeugen, die über den Bildschirm fliegt.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. Die Kugel hält {SkillTree.plazmaBallTimer} Sekunden und verursacht 0,75X deine Spitzhackenstärke";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Cada segundo, probabilidad de generar una bola de plazma que cruza la pantalla.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%. La bola dura {SkillTree.plazmaBallTimer} segundos y causa 0,75X la potencia de tu pico";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"毎秒、画面を横切るプラズマボールが発生する確率。\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}%。ボールは{SkillTree.plazmaBallTimer}秒間持続し、ピッケルパワーの0.75倍のダメージを与える";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"매초 화면을 가로지르는 플라즈마 볼 생성 확률.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}% 볼은 {SkillTree.plazmaBallTimer}초 동안 유지되며 곡괭이 파워의 0.75배 피해를 입힘";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Co sekundę szansa na wygenerowanie kuli plazmy, która przelatuje przez ekran.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}% Kula trwa {SkillTree.plazmaBallTimer} sekund i zadaje 0,75X mocy twojego kilofa";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>A cada segundo, chance de gerar uma bola de plazma que atravessa a tela.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}% A bola dura {SkillTree.plazmaBallTimer} segundos e causa 0,75X o poder da sua picareta";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Каждую секунду шанс породить шар плазмы, движущийся по экрану.\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}% Шар существует {SkillTree.plazmaBallTimer} секунд и наносит 0,75X урона вашей кирки";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每秒有几率生成一个横穿屏幕的等离子球。\n{SkillTree.plazmaBallChance.ToString("F0")}% -> {nextPlazmaBallChance.ToString("F0")}% 球持续 {SkillTree.plazmaBallTimer} 秒，造成你镐子威力的 0.75 倍伤害";
                    }
                    #endregion
                }
            }
            else if (upgradeName == "PlazmaBallTime")
            {
                plazmaBallTimerIncrease = 1;

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Plazma Ball Time";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Durée de la Boule de Plazma";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Durata Sfera di Plazma";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Plazma-Kugel Zeit";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Tiempo de Bola de Plazma";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "プラズマボール時間";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "플라즈마 볼 지속시간";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Czas Kuli Plazmy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Duração da Bola de Plazma";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Время Шара Плазмы";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等离子球持续时间";
                }
                #endregion

                float nextPlazmaballTime = SkillTree.plazmaBallTimer + plazmaBallTimerIncrease;

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Plazma ball on screen time:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Durée d'affichage de la boule de plazma :\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Tempo sullo schermo della sfera di plazma:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Anzeigedauer der Plazma-Kugel:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Tiempo en pantalla de la bola de plazma:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボール画面時間：\n{SkillTree.plazmaBallTimer.ToString("F0")}秒";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 화면 지속 시간:\n{SkillTree.plazmaBallTimer.ToString("F0")}초";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Czas widoczności kuli plazmy:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Tempo na tela da bola de plazma:\n{SkillTree.plazmaBallTimer.ToString("F0")}s";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Время шара плазмы на экране:\n{SkillTree.plazmaBallTimer.ToString("F0")}с";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"等离子球在屏幕上的时间：\n{SkillTree.plazmaBallTimer.ToString("F0")}秒";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase how long the plazma ball is on screen\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la durée d'affichage de la boule de plazma\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la durata della sfera di plazma sullo schermo\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Verlängert die Zeit, in der die Plazma-Kugel auf dem Bildschirm ist\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta el tiempo que la bola de plazma permanece en pantalla\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボールが画面に残る時間を延長\n{SkillTree.plazmaBallTimer.ToString("F0")}秒 -> {nextPlazmaballTime.ToString("F0")}秒";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 화면 유지 시간 증가\n{SkillTree.plazmaBallTimer.ToString("F0")}초 -> {nextPlazmaballTime.ToString("F0")}초";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Wydłuża czas, w którym kula plazmy jest widoczna\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o tempo em que a bola de plazma fica na tela\n{SkillTree.plazmaBallTimer.ToString("F0")}s -> {nextPlazmaballTime.ToString("F0")}s";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает время нахождения шара плазмы на экране\n{SkillTree.plazmaBallTimer.ToString("F0")}с -> {nextPlazmaballTime.ToString("F0")}с";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"延长等离子球在屏幕上的时间\n{SkillTree.plazmaBallTimer.ToString("F0")}秒 -> {nextPlazmaballTime.ToString("F0")}秒";
                    }
                    #endregion
                }
            }
            else if (upgradeName == "PlazmaBallSize")
            {
                plazmaBallTotalSizeIncrease = 0.2f;

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Plazma Ball Size";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Taille de la Boule de Plazma";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Dimensione Sfera di Plazma";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Plazma-Kugel Größe";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Tamaño de Bola de Plazma";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "プラズマボールサイズ";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "플라즈마 볼 크기";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Rozmiar Kuli Plazmy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Tamanho da Bola de Plazma";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Размер Шара Плазмы";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等离子球大小";
                }
                #endregion

                float nextPlazmaBallSize = SkillTree.plazmaBallTotalSize + plazmaBallTotalSizeIncrease;

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total plazma ball size increase:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmentation totale de la taille de la boule de plazma :\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumento totale dimensione sfera di plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamte Plazma-Kugel Größensteigerung:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumento total de tamaño de bola de plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボールのサイズ合計増加：\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 총 크기 증가:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączny wzrost rozmiaru kuli plazmy:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumento total do tamanho da bola de plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общее увеличение размера шара плазмы:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"等离子球总大小增幅：\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}%";
                    }

                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the size of the plazma ball:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la taille de la boule de plazma :\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la dimensione della sfera di plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Größe der Plazma-Kugel:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta el tamaño de la bola de plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボールのサイズを増加：\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 크기 증가:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa rozmiar kuli plazmy:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o tamanho da bola de plazma:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает размер шара плазмы:\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"增加等离子球的大小：\n{(SkillTree.plazmaBallTotalSize * 100).ToString("F0")}% -> {(nextPlazmaBallSize * 100).ToString("F0")}%";
                    }
                    #endregion
                }
            }
            else if (upgradeName == "PlazmaBallDamage")
            {
                plazmaBallTotalDamageIncrease = 0.2f;

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Plazma Ball Damage";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Dégâts de Boule de Plazma";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Danno Sfera di Plazma";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Plazma-Kugel Schaden";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Daño de Bola de Plazma";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "プラズマボールダメージ";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "플라즈마 볼 피해";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Obrażenia Kuli Plazmy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Dano da Bola de Plazma";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Урон Шара Плазмы";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等离子球伤害";
                }
                #endregion

                float nextPlazmaBallDamage = SkillTree.plazmaBallTotalDamage + plazmaBallTotalDamageIncrease;

                if (isPurchasedMax == true)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total plazma ball damage:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Dégâts totaux de la boule de plazma :\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Danno totale della sfera di plazma:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamter Plazma-Kugel-Schaden:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Daño total de la bola de plazma:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボールの総ダメージ：\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 총 피해량:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączne obrażenia kuli plazmy:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Dano total da bola de plazma:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий урон шара плазмы:\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"等离子球总伤害：\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the plazma ball damage: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente les dégâts de la boule de plazma : \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta i danni della sfera di plazma: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht den Schaden der Plazma-Kugel: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta el daño de la bola de plazma: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"プラズマボールのダメージを増加: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"플라즈마 볼 피해량 증가: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa obrażenia kuli plazmy: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o dano da bola de plazma: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает урон шара плазмы: \n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"增加等离子球伤害：\n{(SkillTree.plazmaBallTotalDamage * 100).ToString("F0")}% -> {(nextPlazmaBallDamage * 100).ToString("F0")}%";
                    }
                    #endregion
                }
            }
            else if (upgradeName == "PlazmaBallExplosionChance")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Plazma Ball Explosion";
                    skillTreeDesc_text.text = $"{(SkillTree.plazmaballExplosionChance).ToString("F0")}% chance to cause a dynamite explosion when a plazma ball despawns";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Explosion Boule de Plazma";
                    skillTreeDesc_text.text = $"<size=17>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% de chance de déclencher une explosion de dynamite quand une boule de plazma disparaît";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Esplosione Sfera di Plazma";
                    skillTreeDesc_text.text = $"<size=20>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% di probabilità di causare un'esplosione di dinamite quando una sfera di plazma scompare";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Plazma-Kugel Explosion";
                    skillTreeDesc_text.text = $"<size=22>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% Chance auf eine Dynamitexplosion, wenn eine Plazma-Kugel verschwindet";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Explosión Bola de Plazma";
                    skillTreeDesc_text.text = $"<size=21>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% de probabilidad de provocar una explosión de dinamita cuando una bola de plazma desaparece";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "プラズマボール爆発";
                    skillTreeDesc_text.text = $"プラズマボールが消えるときに{(SkillTree.plazmaballExplosionChance).ToString("F0")}%の確率でダイナマイト爆発を起こす";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "플라즈마 볼 폭발";
                    skillTreeDesc_text.text = $"플라즈마 볼이 사라질 때 {SkillTree.plazmaballExplosionChance.ToString("F0")}% 확률로 다이너마이트 폭발 발생";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Eksplozja Kuli Plazmy";
                    skillTreeDesc_text.text = $"<size=21>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% szansy na wywołanie eksplozji dynamitu, gdy kula plazmy znika";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Explosão Bola de Plazma";
                    skillTreeDesc_text.text = $"<size=21>{(SkillTree.plazmaballExplosionChance).ToString("F0")}% de chance de causar uma explosão de dinamite quando uma bola de plazma desaparece";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Взрыв Шара Плазмы";
                    skillTreeDesc_text.text = $"{(SkillTree.plazmaballExplosionChance).ToString("F0")}% шанс вызвать взрыв динамита при исчезновении шара плазмы";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等离子球爆炸";
                    skillTreeDesc_text.text = $"等离子球消失时有 {(SkillTree.plazmaballExplosionChance).ToString("F0")}% 的几率引发炸药爆炸";
                }
                #endregion
            }
            else if (upgradeName == "PlazmbaBallSpawnSmallChance")
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Tiny Plazma Balls";
                    skillTreeDesc_text.text = $"The plazma ball has a {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% chance to spawn a small ball\nevery second that it is on screen. It has the same stats as the big plazma ball.";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Mini Boules de Plazma";
                    skillTreeDesc_text.text = $"<size=19>La boule de plazma a {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% de chance d'engendrer une petite boule\nchaque seconde où elle est à l'écran. Elle a les mêmes stats que la grande boule de plazma.";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Mini Sfere di Plazma";
                    skillTreeDesc_text.text = $"<size=19>La sfera di plazma ha il {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% di probabilità di generare una sfera piccola\nogni secondo in cui è sullo schermo. Ha le stesse statistiche della grande sfera di plazma.";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mini Plazma-Kugeln";
                    skillTreeDesc_text.text = $"<size=16>Die Plazma-Kugel hat eine Chance von {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% jede Sekunde,\nwährend sie auf dem Bildschirm ist, eine kleine Kugel zu erzeugen. Diese hat dieselben Werte wie die große Plazma-Kugel.";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Mini Bolas de Plazma";
                    skillTreeDesc_text.text = $"<size=19>La bola de plazma tiene un {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% de probabilidad de generar una bola pequeña\ncada segundo que esté en pantalla. Tiene las mismas estadísticas que la bola de plazma grande.";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ミニプラズマボール";
                    skillTreeDesc_text.text = $"プラズマボールは画面に出ている間、毎秒{(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}%の確率で\n小さなボールを生成する。同じステータスを持つ。";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "작은 플라즈마 볼";
                    skillTreeDesc_text.text = $"플라즈마 볼은 화면에 있는 동안 매초 {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% 확률로\n작은 볼을 생성합니다. 작은 볼은 큰 플라즈마 볼과 동일한 스탯을 가집니다.";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Małe Kule Plazmy";
                    skillTreeDesc_text.text = $"<size=20>Kula plazmy ma {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% szansy na wygenerowanie małej kuli\nco sekundę, gdy jest widoczna. Ma takie same statystyki jak duża kula plazmy.";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mini Bolas de Plazma";
                    skillTreeDesc_text.text = $"<size=21>A bola de plazma tem {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% de chance de gerar uma bola pequena\na cada segundo em que estiver na tela. A bola pequena tem os mesmos atributos da grande.";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Маленькие Шары Плазмы";
                    skillTreeDesc_text.text = $"<size=20>Шар плазмы имеет {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% шанс создать маленький шар\nкаждую секунду, пока он на экране. Маленький шар имеет те же характеристики, что и большой.";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "小型等离子球";
                    skillTreeDesc_text.text = $"等离子球在屏幕上每秒有 {(SkillTree.plazmaBallSpawnSmallBallChance).ToString("F0")}% 的几率生成一个小球。\n小球与大等离子球拥有相同的属性。";
                }
                #endregion
            }
            else if (upgradeName == "PlazmaBallChanceToSpawnPickaxe")
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Tiny Plazma Pickaxe";
                    skillTreeDesc_text.text = $"{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% chance to spawn a pickaxe every time the plazma ball hits a rock";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Pioche de Plazma Mini";
                    skillTreeDesc_text.text = $"<size=18>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% de chance de générer une pioche chaque fois qu'une boule de plazma touche un rocher";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Piccone Plazma Mini";
                    skillTreeDesc_text.text = $"<size=18>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% di probabilità di generare un piccone ogni volta che la sfera di plazma colpisce una roccia";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mini Plazma-Spitzhacke";
                    skillTreeDesc_text.text = $"<size=20>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% Chance, eine Spitzhacke zu erzeugen, wenn die Plazma-Kugel einen Stein trifft";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Pico de Plazma Mini";
                    skillTreeDesc_text.text = $"<size=20>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% de probabilidad de generar un pico cada vez que la bola de plazma golpea una roca";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ミニプラズマピッケル";
                    skillTreeDesc_text.text = $"プラズマボールが岩に当たるたびに{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}%の確率でピッケルを生成";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "작은 플라즈마 곡괭이";
                    skillTreeDesc_text.text = $"플라즈마 볼이 바위를 칠 때마다 {(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% 확률로 곡괭이 생성";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Mini Kilof Plazmy";
                    skillTreeDesc_text.text = $"<size=22>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% szansy na stworzenie kilofa, gdy kula plazmy uderzy w skałę";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Picareta Plazma Mini";
                    skillTreeDesc_text.text = $"<size=22>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% de chance de gerar uma picareta toda vez que a bola de plazma acerta uma rocha";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Маленький Кирка Плазмы";
                    skillTreeDesc_text.text = $"<size=22>{(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% шанс создать кирку каждый раз, когда шар плазмы ударяет камень";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "小型等离子镐";
                    skillTreeDesc_text.text = $"等离子球每次击中岩石时有 {(SkillTree.plazmaBallChanceToSpawnPickaxe).ToString("F0")}% 的几率生成一把镐子";
                }
                #endregion
            }
        }
        #endregion

        #region More Materials Per Rock
        else if (upgradeType == 14)
        {
            int nextMoreMaterials = 0;

            if (upgradeName == "MaterialsPerRock1")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock2")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock3")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 1;
            }
            else if (upgradeName == "MaterialsPerRock4")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 2;
            }
            else if (upgradeName == "MaterialsPerRock5")
            {
                materialsFromChunkRocksIncrease = 1;
                materialsFromFullRocksIncrease = 2;
            }

            nextMoreMaterials = SkillTree.materialsFromChunkRocks + materialsFromChunkRocksIncrease;
            int nextMoreMaterialsFULL = SkillTree.materialsFromFullRocks + materialsFromFullRocksIncrease;

            #region Name texts
            if (isEnglish == true)
            {
                skillTreeName_text.text = "More Ores From Rocks";
            }

            if (isFrench == true)
            {
                skillTreeName_text.text = "Plus de Minerais des Roches";
            }

            if (isItalian == true)
            {
                skillTreeName_text.text = "Più Minerali dalle Rocce";
            }

            if (isGerman == true)
            {
                skillTreeName_text.text = "Mehr Erze aus Steinen";
            }

            if (isSpanish == true)
            {
                skillTreeName_text.text = "Más Minerales de las Rocas";
            }

            if (isJapanese == true)
            {
                skillTreeName_text.text = "岩から鉱石増加";
            }

            if (isKorean == true)
            {
                skillTreeName_text.text = "암석에서 광석 추가 획득";
            }

            if (isPolish == true)
            {
                skillTreeName_text.text = "Więcej Rudy ze Skał";
            }

            if (isPortugese == true)
            {
                skillTreeName_text.text = "Mais Minérios das Rochas";
            }

            if (isRussian == true)
            {
                skillTreeName_text.text = "Больше Руды из Камней";
            }

            if (isSimplefiedChinese == true)
            {
                skillTreeName_text.text = "岩石产出更多矿石";
            }
            #endregion

            if (isPurchasedMax)
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Ores mined from chunk rocks: {SkillTree.materialsFromChunkRocks}\nOres mined from full material rocks: {SkillTree.materialsFromFullRocks}";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Minerais extraits des roches riches : {SkillTree.materialsFromChunkRocks}\nMinerais extraits des roches pleines : {SkillTree.materialsFromFullRocks}";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Minerali estratti dalle rocce a blocchi: {SkillTree.materialsFromChunkRocks}\nMinerali estratti dalle rocce piene: {SkillTree.materialsFromFullRocks}";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Erze aus Brockensteinen: {SkillTree.materialsFromChunkRocks}\nErze aus vollen Materialsteinen: {SkillTree.materialsFromFullRocks}";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Minerales extraídos de rocas con vetas: {SkillTree.materialsFromChunkRocks}\nMinerales extraídos de rocas completas: {SkillTree.materialsFromFullRocks}";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"塊状岩から採掘される鉱石: {SkillTree.materialsFromChunkRocks}\nフル鉱石岩から採掘される鉱石: {SkillTree.materialsFromFullRocks}";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"덩어리 암석에서 채굴된 광석: {SkillTree.materialsFromChunkRocks}\n전체 암석에서 채굴된 광석: {SkillTree.materialsFromFullRocks}";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Ruda z blokowych skał: {SkillTree.materialsFromChunkRocks}\nRuda z pełnych skał: {SkillTree.materialsFromFullRocks}";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Minérios extraídos de rochas com blocos: {SkillTree.materialsFromChunkRocks}\nMinérios extraídos de rochas completas: {SkillTree.materialsFromFullRocks}";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Руда из кусковых камней: {SkillTree.materialsFromChunkRocks}\nРуда из цельных камней: {SkillTree.materialsFromFullRocks}";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"从块状岩石中采集的矿石: {SkillTree.materialsFromChunkRocks}\n从整块矿石岩石中采集的矿石: {SkillTree.materialsFromFullRocks}";
                }
                #endregion
            }
            else
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Ores mined from chunk rocks: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nOres mined from full material rocks: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Minerais extraits des roches riches : {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nMinerais extraits des roches pleines : {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Minerali estratti dalle rocce a blocchi: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nMinerali estratti dalle rocce piene: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Erze aus Brockensteinen: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nErze aus vollen Materialsteinen: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Minerales extraídos de rocas con vetas: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nMinerales extraídos de rocas completas: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"塊状岩から採掘される鉱石: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nフル鉱石岩から採掘される鉱石: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"덩어리 암석에서 채굴된 광석: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\n전체 암석에서 채굴된 광석: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Ruda z blokowych skał: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nRuda z pełnych skał: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Minérios extraídos de rochas com blocos: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nMinérios extraídos de rochas completas: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Руда из кусковых камней: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\nРуда из цельных камней: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"从块状岩石中采集的矿石: {SkillTree.materialsFromChunkRocks} -> {nextMoreMaterials}\n从整块矿石岩石中采集的矿石: {SkillTree.materialsFromFullRocks} -> {nextMoreMaterialsFULL}";
                }
                #endregion
            }
        }
        #endregion

        #region Materials Worth More
        else if (upgradeType == 15)
        {
            float nextMaterialsWorthMore = 0f;

            if (upgradeName == "MaterialsWorthMore1")
            {
                materialsWorthIncrease = 1;
            }
            else if (upgradeName == "MaterialsWorthMore2")
            {
                materialsWorthIncrease = 2f;
            }
            else if (upgradeName == "MaterialsWorthMore3")
            {
                materialsWorthIncrease = 3f;
            }
            else if (upgradeName == "MaterialsWorthMore4")
            {
                materialsWorthIncrease = 9f;
            }
            else if (upgradeName == "MaterialsWorthMore5")
            {
                materialsWorthIncrease = 12f;
            }
            else if (upgradeName == "MaterialsWorthMore6")
            {
                materialsWorthIncrease = 4;
            }
            else if (upgradeName == "MaterialsWorthMore7")
            {
                materialsWorthIncrease = 6f;
            }
            else if (upgradeName == "MaterialsWorthMore8")
            {
                materialsWorthIncrease = 18f;
            }
            else if (upgradeName == "EndlessGold1")
            {
                materialsWorthIncrease = 12f;
            }
            else if (upgradeName == "EndlessGold2")
            {
                materialsWorthIncrease = 12f;
            }

            nextMaterialsWorthMore = SkillTree.materialsTotalWorth + materialsWorthIncrease;

            #region Name texts
            if (isEnglish == true)
            {
                skillTreeName_text.text = "Ore Value";
            }

            if (isFrench == true)
            {
                skillTreeName_text.text = "Valeur du Minerai";
            }

            if (isItalian == true)
            {
                skillTreeName_text.text = "Valore del Minerale";
            }

            if (isGerman == true)
            {
                skillTreeName_text.text = "Erzwert";
            }

            if (isSpanish == true)
            {
                skillTreeName_text.text = "Valor del Mineral";
            }

            if (isJapanese == true)
            {
                skillTreeName_text.text = "鉱石価値";
            }

            if (isKorean == true)
            {
                skillTreeName_text.text = "광석 가치";
            }

            if (isPolish == true)
            {
                skillTreeName_text.text = "Wartość Rudy";
            }

            if (isPortugese == true)
            {
                skillTreeName_text.text = "Valor do Minério";
            }

            if (isRussian == true)
            {
                skillTreeName_text.text = "Ценность Руды";
            }

            if (isSimplefiedChinese == true)
            {
                skillTreeName_text.text = "矿石价值";
            }
            #endregion

            if (isPurchasedMax)
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Total value of mined ores:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Valeur totale des minerais extraits :\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Valore totale dei minerali estratti:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Gesamtwert der abgebauten Erze:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Valor total de los minerales extraídos:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"採掘した鉱石の総価値：\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"채굴된 광석의 총 가치:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Łączna wartość wydobytej rudy:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Valor total dos minérios extraídos:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Общая ценность добытой руды:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"采集矿石的总价值：\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}%";
                }
                #endregion
            }
            else
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Increase the value of every mined ore:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Augmente la valeur de chaque minerai extrait :\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Aumenta il valore di ogni minerale estratto:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Erhöht den Wert jedes abgebauten Erzes:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Aumenta el valor de cada mineral extraído:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"採掘した鉱石の価値を増加：\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"채굴된 광석의 가치 증가:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Zwiększa wartość każdej wydobytej rudy:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Aumenta o valor de cada minério extraído:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Увеличивает ценность каждой добытой руды:\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"提升每块采集矿石的价值：\n{(SkillTree.materialsTotalWorth * 100).ToString("F0")}% -> {(nextMaterialsWorthMore * 100).ToString("F0")}%";
                }
                #endregion
            }
        }
        #endregion

        #region Improved Pickaxe
        else if (upgradeType == 16)
        {
            bool isF1 = false;

            float nextPickaxeStrength = 0;

            if (upgradeName == "ImprovedPickaxe1")
            {
                improvedPickaxeIncrease = 0.032f;
            }
            else if (upgradeName == "ImprovedPickaxe2")
            {
                improvedPickaxeIncrease = 0.035f;
            }
            else if (upgradeName == "ImprovedPickaxe3")
            {
                improvedPickaxeIncrease = 0.04f;
            }
            else if (upgradeName == "ImprovedPickaxe4")
            {
                improvedPickaxeIncrease = 0.047f;
            }
            else if (upgradeName == "ImprovedPickaxe5")
            {
                improvedPickaxeIncrease = 0.062f;
            }
            else if (upgradeName == "ImprovedPickaxe6")
            {
                improvedPickaxeIncrease = 0.07f;
            }
            else if (upgradeName == "EndlessPickaxe1")
            {
                isF1 = true;
                improvedPickaxeIncrease = 0.002f;
            }
            else if (upgradeName == "EndlessPickaxe2")
            {
                isF1 = true;
                improvedPickaxeIncrease = 0.002f;
            }

            #region Name texts
            if (isEnglish == true)
            {
                skillTreeName_text.text = "Improved Pickaxe";
            }

            if (isFrench == true)
            {
                skillTreeName_text.text = "Pioche Améliorée";
            }

            if (isItalian == true)
            {
                skillTreeName_text.text = "Piccone Potenziato";
            }

            if (isGerman == true)
            {
                skillTreeName_text.text = "Verbesserte Spitzhacke";
            }

            if (isSpanish == true)
            {
                skillTreeName_text.text = "Pico Mejorado";
            }

            if (isJapanese == true)
            {
                skillTreeName_text.text = "改良ピッケル";
            }

            if (isKorean == true)
            {
                skillTreeName_text.text = "개선된 곡괭이";
            }

            if (isPolish == true)
            {
                skillTreeName_text.text = "Ulepszony Kilof";
            }

            if (isPortugese == true)
            {
                skillTreeName_text.text = "Picareta Aprimorada";
            }

            if (isRussian == true)
            {
                skillTreeName_text.text = "Улучшенная Кирка";
            }

            if (isSimplefiedChinese == true)
            {
                skillTreeName_text.text = "强化镐子";
            }
            #endregion

            nextPickaxeStrength = SkillTree.improvedPickaxeStrength + improvedPickaxeIncrease;

            string f1string = "F0";
            if(isF1 == true)
            {
                f1string = "F1";
            }

            if (isPurchasedMax)
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Total pickaxe stat increase:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Augmentation totale des stats de la pioche :\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Aumento totale delle statistiche del piccone:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Gesamte Spitzhacken-Wert-Steigerung:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Aumento total de estadísticas del pico:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"ピッケルのステータス合計増加：\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"곡괭이 스탯 총 증가량:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Łączny wzrost statystyk kilofa:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Aumento total de atributos da picareta:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Общее увеличение характеристик кирки:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"镐子属性总提升：\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}%";
                }
                #endregion
            }
            else
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Increase all pickaxe stats:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Augmente toutes les stats de la pioche :\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Aumenta tutte le statistiche del piccone:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Erhöht alle Spitzhacken-Werte:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Aumenta todas las estadísticas del pico:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"全てのピッケルのステータスを強化：\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"모든 곡괭이 스탯 강화:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Zwiększa wszystkie statystyki kilofa:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Aumenta todos os atributos da picareta:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Увеличивает все характеристики кирки:\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"提升所有镐子属性：\n{(SkillTree.improvedPickaxeStrength * 100).ToString("F1")}% -> {(nextPickaxeStrength * 100).ToString("F1")}%";
                }
                #endregion
            }
        }
        #endregion

        #region Bigger Mining Area
        else if (upgradeType == 17)
        {
            float nextMiningArea = 0;

            bool isFunctional = false;

            if (upgradeName == "BiggerMiningErea1")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea2")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea3")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "BiggerMiningErea4")
            {
                miningAreaIncrease = 0.02f;
            }
            else if (upgradeName == "ShootCircle")
            {
                isFunctional = true;
            }
            else if (upgradeName == "IncreaseAndDecreaseCircle")
            {
                isFunctional = true;
            }

            if (isFunctional)
            {
                if (upgradeName == "ShootCircle")
                {
                    #region Name texts and desc
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "Circle Shots";
                        skillTreeDesc_text.text = $"Every second, a small circle has a {SkillTree.circleShootChance}% chance to shoot in a random direction.\nRocks inside this circle will be mined.";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Tirs Circulaires";
                        skillTreeDesc_text.text = $"<size=21>Chaque seconde, un petit cercle a {SkillTree.circleShootChance}% de chance de tirer dans une direction aléatoire.\nLes roches à l'intérieur seront minées.";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Colpi Circolari";
                        skillTreeDesc_text.text = $"<size=21>Ogni secondo, un piccolo cerchio ha il {SkillTree.circleShootChance}% di probabilità di sparare in una direzione casuale.\nLe rocce all'interno saranno estratte.";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Kreis-Schüsse";
                        skillTreeDesc_text.text = $"<size=21>Jede Sekunde hat ein kleiner Kreis eine Chance von {SkillTree.circleShootChance}%, in eine zufällige Richtung zu schießen.\nSteine im Kreis werden abgebaut.";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Disparos Circulares";
                        skillTreeDesc_text.text = $"<size=21>Cada segundo, un pequeño círculo tiene un {SkillTree.circleShootChance}% de probabilidad de disparar en una dirección aleatoria.\nLas rocas dentro del círculo serán minadas.";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "サークルショット";
                        skillTreeDesc_text.text = $"毎秒、小さなサークルが{SkillTree.circleShootChance}%の確率でランダム方向に発射します。\nサークル内の岩は採掘されます。";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "서클 샷";
                        skillTreeDesc_text.text = $"매초 작은 원이 {SkillTree.circleShootChance}% 확률로 랜덤 방향으로 발사됩니다.\n원 안의 바위는 채굴됩니다.";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "Strzały Okręgu";
                        skillTreeDesc_text.text = $"Co sekundę mały okrąg ma {SkillTree.circleShootChance}% szansy na strzał w losowym kierunku.\nSkały w środku zostaną wydobyte.";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Disparos em Círculo";
                        skillTreeDesc_text.text = $"<size=22>A cada segundo, um pequeno círculo tem {SkillTree.circleShootChance}% de chance de disparar em uma direção aleatória.\nPedras dentro dele serão mineradas.";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Круговые Выстрелы";
                        skillTreeDesc_text.text = $"<size=23>Каждую секунду маленький круг имеет {SkillTree.circleShootChance}% шанс выстрелить в случайном направлении.\nКамни внутри будут добыты.";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "圆形射击";
                        skillTreeDesc_text.text = $"每秒小圆圈有 {SkillTree.circleShootChance}% 的几率向随机方向发射。\n圆圈内的岩石会被开采。";
                    }
                    #endregion
                }
                else if (upgradeName == "IncreaseAndDecreaseCircle")
                {
                    #region Name and desc texts
                    if (isEnglish == true)
                    {
                        skillTreeName_text.text = "In and Out";
                        skillTreeDesc_text.text = "The mining area will increase and decrease in size:\n110%-95%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeName_text.text = "Va-et-vient";
                        skillTreeDesc_text.text = "La zone de minage va s'agrandir et rétrécir :\n110%-95%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeName_text.text = "Dentro e Fuori";
                        skillTreeDesc_text.text = "L'area di scavo si espanderà e si ridurrà di dimensione:\n110%-95%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeName_text.text = "Rein und Raus";
                        skillTreeDesc_text.text = "Das Abbaugebiet wird sich vergrößern und verkleinern:\n110%-95%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeName_text.text = "Dentro y Fuera";
                        skillTreeDesc_text.text = "El área de minado aumentará y disminuirá de tamaño:\n110%-95%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeName_text.text = "イン＆アウト";
                        skillTreeDesc_text.text = "採掘エリアが拡大・縮小します：\n110%-95%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeName_text.text = "인 앤 아웃";
                        skillTreeDesc_text.text = "채굴 범위가 커졌다 작아졌다 합니다:\n110%-95%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeName_text.text = "W Tę i Z Powrotem";
                        skillTreeDesc_text.text = "Obszar wydobycia będzie się powiększać i zmniejszać:\n110%-95%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeName_text.text = "Dentro e Fora";
                        skillTreeDesc_text.text = "A área de mineração vai aumentar e diminuir de tamanho:\n110%-95%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeName_text.text = "Туда и Обратно";
                        skillTreeDesc_text.text = "Зона добычи будет увеличиваться и уменьшаться:\n110%-95%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeName_text.text = "收缩扩张";
                        skillTreeDesc_text.text = "采矿范围会放大和缩小：\n110%-95%";
                    }
                    #endregion
                }
            }
            else
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Bigger Mining Area";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Zone de Minage Agrandie";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Area di Scavo Maggiore";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Größeres Abbaugebiet";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Área de Minado Mayor";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "採掘エリア拡大";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "채굴 범위 확장";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Większy Obszar Wydobycia";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Área de Mineração Maior";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Увеличить Зону Добычи";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更大采矿范围";
                }
                #endregion

                nextMiningArea = SkillTree.miningAreaSize + miningAreaIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total mining area size increase:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmentation totale de la zone de minage :\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumento totale dell'area di scavo:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtsteigerung der Abbaugebietsgröße:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumento total del área de minado:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"採掘エリアの総拡大率：\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"채굴 범위 총 증가량:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączne zwiększenie obszaru wydobycia:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumento total da área de mineração:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общее увеличение зоны добычи:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"采矿范围总增幅：\n{(SkillTree.miningAreaSize * 100).ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the mining area size:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la taille de la zone de minage :\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta l'area di scavo:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Größe des Abbaugebiets:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta el tamaño del área de minado:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"採掘エリアのサイズを拡大：\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"채굴 범위 크기 증가:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Zwiększa obszar wydobycia:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o tamanho da área de mineração:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает размер зоны добычи:\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"扩大采矿范围：\n{(SkillTree.miningAreaSize * 100).ToString("F0")}% -> {(nextMiningArea * 100).ToString("F0")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Chance to spawn rock
        else if (upgradeType == 18)
        {
            float nextValue = 0;

            bool isEveryRock = false;
            bool isEverySecond = false;
            bool isWhenMined = false;

            if (upgradeName == "EveryXRockSpawnRock1")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }
            else if (upgradeName == "EveryXRockSpawnRock2")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }
            else if (upgradeName == "EveryXRockSpawnRock3")
            {
                isEveryRock = true;
                spawnEveryRockIncrease = 1f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEveryRockIncrease = 0f; }
            }


            else if (upgradeName == "SpawnRockEveryXSecond1")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.7f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }
            else if (upgradeName == "SpawnRockEveryXSecond2")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.7f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }
            else if (upgradeName == "SpawnRockEveryXSecond3")
            {
                isEverySecond = true;
                spawnEverySecondIncrease = 0.4f;
                if (purchaseCount >= totalPurchaseCount) { isPurchasedMax = true; spawnEverySecondIncrease = 0; }
            }


            else if (upgradeName == "ChanceToSpawnRockWhenMined1")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 2f; // * 6 = 12
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined2")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 3 = 9
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined3")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 3f; // * 3 = 9
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined4")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 4f; // * 3 = 16
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined5")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 5f; // * 3 = 15
            }
            else if (upgradeName == "ChanceToSpawnRockWhenMined6")
            {
                isWhenMined = true;
                spawnWhenMinedIncrease = 4f;  // * 1 = 4
            }

            if (isEveryRock)
            {
                nextValue = SkillTree.spawnRockEveryXRock - spawnEveryRockIncrease;

                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Rocks Into More Rocks";
                    skillTreeDesc_text.text = $"Spawn 1 rock for every {nextValue} rocks mined";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Roches en Plus de Roches";
                    skillTreeDesc_text.text = $"Fait apparaître 1 roche pour chaque {nextValue} roches extraites";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Rocce in Altre Rocce";
                    skillTreeDesc_text.text = $"Genera 1 roccia ogni {nextValue} rocce estratte";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Steine zu Mehr Steinen";
                    skillTreeDesc_text.text = $"Spawnt 1 Stein für je {nextValue} abgebaute Steine";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Rocas en Más Rocas";
                    skillTreeDesc_text.text = $"Genera 1 roca por cada {nextValue} rocas extraídas";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "岩からさらに岩";
                    skillTreeDesc_text.text = $"採掘した{nextValue}個の岩ごとに1個の岩を生成";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "바위에서 더 많은 바위";
                    skillTreeDesc_text.text = $"{nextValue}개의 바위를 캘 때마다 1개의 바위 생성";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Skały w Więcej Skał";
                    skillTreeDesc_text.text = $"Tworzy 1 skałę za każde wydobyte {nextValue} skał";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Rochas em Mais Rochas";
                    skillTreeDesc_text.text = $"Gera 1 rocha a cada {nextValue} rochas mineradas";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Камни в Ещё Камни";
                    skillTreeDesc_text.text = $"Создаёт 1 камень за каждые {nextValue} добытых камней";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "岩石变更多岩石";
                    skillTreeDesc_text.text = $"每开采 {nextValue} 块岩石生成 1 块新岩石";
                }
                #endregion
            }
            else if (isEverySecond)
            {
                nextValue = SkillTree.spawnXRockEveryXSecond - spawnEverySecondIncrease;

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Wait For More Rocks";
                    skillTreeDesc_text.text = $"Spawn 1 rock every {nextValue.ToString("F1")} second";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Attendre Plus de Roches";
                    skillTreeDesc_text.text = $"Fait apparaître 1 roche toutes les {nextValue.ToString("F1")} secondes";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Aspetta Altre Rocce";
                    skillTreeDesc_text.text = $"Genera 1 roccia ogni {nextValue.ToString("F1")} secondi";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Warten auf Mehr Steine";
                    skillTreeDesc_text.text = $"Spawnt 1 Stein alle {nextValue.ToString("F1")} Sekunden";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Esperar Más Rocas";
                    skillTreeDesc_text.text = $"Genera 1 roca cada {nextValue.ToString("F1")} segundos";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "待って岩を増やす";
                    skillTreeDesc_text.text = $"毎{nextValue.ToString("F1")}秒ごとに1個の岩を生成";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "기다려서 바위 생성";
                    skillTreeDesc_text.text = $"{nextValue.ToString("F1")}초마다 바위 1개 생성";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Czekaj na Więcej Skał";
                    skillTreeDesc_text.text = $"Tworzy 1 skałę co {nextValue.ToString("F1")} sekundy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Esperar por Mais Rochas";
                    skillTreeDesc_text.text = $"Gera 1 rocha a cada {nextValue.ToString("F1")} segundo";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Ждать Больше Камней";
                    skillTreeDesc_text.text = $"Создаёт 1 камень каждые {nextValue.ToString("F1")} секунды";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "等待生成更多岩石";
                    skillTreeDesc_text.text = $"每 {nextValue.ToString("F1")} 秒生成 1 块岩石";
                }
                #endregion
            }
            else if (isWhenMined)
            {
                nextValue = SkillTree.chanceToSpawnRockWhenMined + spawnWhenMinedIncrease;

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Rock Spawn Chance";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Chance d'Apparition de Roche";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Probabilità Generazione Roccia";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Stein-Spawn-Chance";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Probabilidad de Aparición de Roca";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "岩出現確率";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "바위 생성 확률";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Szansa Pojawienia Skały";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Chance de Surgimento de Rocha";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Шанс Спавна Камня";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "岩石生成概率";
                }
                #endregion

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total spawn 1 rock when a rock is mined chance:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance totale de générer 1 roche quand une roche est extraite :\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di generare 1 roccia quando una roccia viene estratta:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance, 1 Stein zu spawnen, wenn ein Stein abgebaut wird:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de generar 1 roca cuando se extrae una roca:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"岩を採掘した時に岩が1個生成される総確率：\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"바위를 캘 때 바위 1개 생성 총 확률:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na pojawienie się 1 skały po wydobyciu skały:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de gerar 1 rocha ao minerar uma rocha:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс заспавнить 1 камень при добыче камня:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"开采岩石时生成 1 块新岩石的总概率：\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Chance to spawn 1 rock when a rock is mined:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance de générer 1 roche quand une roche est extraite :\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di generare 1 roccia quando una roccia viene estratta:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Chance, 1 Stein zu spawnen, wenn ein Stein abgebaut wird:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de generar 1 roca cuando se extrae una roca:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"岩を採掘した時に岩が1個生成される確率：\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"바위를 캘 때 바위 1개 생성 확률:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na pojawienie się 1 skały po wydobyciu skały:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de gerar 1 rocha ao minerar uma rocha:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс заспавнить 1 камень при добыче камня:\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"开采岩石时生成 1 块新岩石的几率：\n{SkillTree.chanceToSpawnRockWhenMined.ToString("F1")}% -> {nextValue.ToString("F1")}%";
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Chance to Spawn Pickaxe
        else if (upgradeType == 19)
        {
            float nextMineRandomChance = 0f;
            float nextPickaxeSpawnRate = 0f;

            bool isMineRandom = false;
            bool isSpawnPickaxe = false;

            if (upgradeName == "ChanceToMineRandomRock1")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 1f;
            }
            else if (upgradeName == "ChanceToMineRandomRock2")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 1f;
            }
            else if (upgradeName == "ChanceToMineRandomRock3")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 2f;
            }
            else if (upgradeName == "ChanceToMineRandomRock4")
            {
                isMineRandom = true;
                chanceToMineRandomRockIncrease = 3f;
            }


            else if (upgradeName == "SpawnPickaxeEverySecond1")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.2f;
            }
            else if (upgradeName == "SpawnPickaxeEverySecond2")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.3f;
            }
            else if (upgradeName == "SpawnPickaxeEverySecond3")
            {
                isSpawnPickaxe = true;
                spawnPickaxeEverySecondIncrease = 0.3f;
            }

            if (isMineRandom)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Mine Random Rock";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Miner Roche Aléatoire";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Scava Roccia Casuale";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Zufälligen Stein Abbauen";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Minar Roca Aleatoria";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ランダム岩採掘";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "랜덤 바위 채굴";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Wydobądź Losową Skałę";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Minerar Rocha Aleatória";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Добыть Случайный Камень";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "开采随机岩石";
                }
                #endregion

                nextMineRandomChance = SkillTree.chanceToMineRandomRock + chanceToMineRandomRockIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total pickaxe spawn chance:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance totale de génération de pioche :\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità totale di generare una piccone:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamtchance, eine Spitzhacke zu spawnen:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad total de generar un pico:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケル生成の総確率：\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"총 곡괭이 생성 확률:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączna szansa na stworzenie kilofa:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance total de gerar picareta:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общий шанс создания кирки:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"镐子生成总概率：\n{SkillTree.chanceToMineRandomRock.ToString("F2")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Every pickaxe hit has a chance to spawn a pickaxe and mine a random rock:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"<size=19>Chaque coup de pioche a une chance de générer une pioche et miner une roche aléatoire :\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"<size=19>Ogni colpo di piccone ha una probabilità di generare un piccone e scavare una roccia casuale:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"<size=18>Jeder Schlag mit der Spitzhacke hat eine Chance, eine Spitzhacke zu spawnen und einen zufälligen Stein abzubauen:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Cada golpe de pico tiene una probabilidad de generar un pico y minar una roca aleatoria:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケルのヒットごとにピッケルを生成しランダムな岩を採掘する確率：\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 타격 시 곡괭이를 생성하고 랜덤 바위를 채굴할 확률:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Każde uderzenie kilofa ma szansę na stworzenie kilofa i wydobycie losowej skały:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"<size=22>Cada golpe de picareta tem chance de gerar uma picareta e minerar uma rocha aleatória:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"<size=23>Каждый удар киркой даёт шанс создать кирку и добыть случайный камень:\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"每次镐击都有几率生成一把镐子并开采随机岩石：\n{SkillTree.chanceToMineRandomRock.ToString("F2")}% -> {nextMineRandomChance.ToString("F2")}%";
                    }
                    #endregion
                }
            }
            else if (isSpawnPickaxe)
            {
                nextPickaxeSpawnRate = SkillTree.spawnPickaxeEverySecond - spawnPickaxeEverySecondIncrease;
                if (isPurchasedMax) { nextPickaxeSpawnRate = SkillTree.spawnPickaxeEverySecond; }

                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Auto Mining";
                    skillTreeDesc_text.text = $"Mine a random rock every:\n{nextPickaxeSpawnRate.ToString("F2")} sec";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Minage Automatique";
                    skillTreeDesc_text.text = $"Mine une roche aléatoire toutes les :\n{nextPickaxeSpawnRate.ToString("F2")} sec";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Estrazione Automatica";
                    skillTreeDesc_text.text = $"Estrai una roccia casuale ogni:\n{nextPickaxeSpawnRate.ToString("F2")} sec";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Automatischer Abbau";
                    skillTreeDesc_text.text = $"Baut alle {nextPickaxeSpawnRate.ToString("F2")} Sekunden einen zufälligen Stein ab";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Minería Automática";
                    skillTreeDesc_text.text = $"Mina una roca aleatoria cada:\n{nextPickaxeSpawnRate.ToString("F2")} seg";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "自動採掘";
                    skillTreeDesc_text.text = $"ランダムな岩を自動採掘：\n{nextPickaxeSpawnRate.ToString("F2")}秒ごと";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "자동 채굴";
                    skillTreeDesc_text.text = $"랜덤 바위를 자동 채굴:\n{nextPickaxeSpawnRate.ToString("F2")}초마다";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Automatyczne Wydobycie";
                    skillTreeDesc_text.text = $"Wydobywa losową skałę co:\n{nextPickaxeSpawnRate.ToString("F2")} sek";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mineração Automática";
                    skillTreeDesc_text.text = $"Minerar uma rocha aleatória a cada:\n{nextPickaxeSpawnRate.ToString("F2")} seg";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Авто-Добыча";
                    skillTreeDesc_text.text = $"Добывает случайный камень каждые:\n{nextPickaxeSpawnRate.ToString("F2")} сек";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "自动采矿";
                    skillTreeDesc_text.text = $"每隔 {nextPickaxeSpawnRate.ToString("F2")} 秒自动开采一块随机岩石";
                }
                #endregion
            }
        }
        #endregion

        #region More Time
        else if (upgradeType == 20)
        {
            float nextMoreTime = 0f;

            bool isAddTime = false;
            bool isChancePerSecond = false;
            bool isChanceWhenMined = false;

            if (upgradeName == "MoreTime1")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime2")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime3")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "MoreTime4")
            {
                isAddTime = true;
                moreTimeIncrease = 1;
            }
            else if (upgradeName == "ChanceAdd1SecondEverySecond")
            {
                isChancePerSecond = true;
            }
            else if (upgradeName == "ChanceAdd1SecondEveryRockMined")
            {
                isChanceWhenMined = true;
            }

            if (isAddTime)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Time";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Temps";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Tempo";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Zeit";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Tiempo";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "時間延長";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "더 많은 시간";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Czasu";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Tempo";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Времени";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多时间";
                }
                #endregion

                nextMoreTime = SkillTree.mineSessionTime + moreTimeIncrease;

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Total mining session time:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Durée totale de la session de minage :\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Durata totale della sessione di scavo:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Gesamte Abbauzeit pro Session:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Duración total de la sesión de minería:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"採掘セッションの総時間：\n{SkillTree.mineSessionTime.ToString("F0")}秒";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"채굴 세션 총 시간:\n{SkillTree.mineSessionTime.ToString("F0")}초";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Łączny czas sesji wydobycia:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Tempo total da sessão de mineração:\n{SkillTree.mineSessionTime.ToString("F0")}s";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Общее время сессии добычи:\n{SkillTree.mineSessionTime.ToString("F0")}с";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"采矿总时长：\n{SkillTree.mineSessionTime.ToString("F0")}秒";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Increase the mining session time:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Augmente la durée de la session de minage :\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la durata della sessione di scavo:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Erhöht die Abbauzeit pro Session:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta la duración de la sesión de minería:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"採掘セッション時間を延長：\n{SkillTree.mineSessionTime.ToString("F0")}秒 -> {nextMoreTime.ToString("F0")}秒";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"채굴 세션 시간을 증가:\n{SkillTree.mineSessionTime.ToString("F0")}초 -> {nextMoreTime.ToString("F0")}초";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Wydłuża czas sesji wydobycia:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Aumenta o tempo da sessão de mineração:\n{SkillTree.mineSessionTime.ToString("F0")}s -> {nextMoreTime.ToString("F0")}s";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Увеличивает время сессии добычи:\n{SkillTree.mineSessionTime.ToString("F0")}с -> {nextMoreTime.ToString("F0")}с";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"延长采矿时长：\n{SkillTree.mineSessionTime.ToString("F0")}秒 -> {nextMoreTime.ToString("F0")}秒";
                    }
                    #endregion
                }
            }
            else if (isChancePerSecond)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% chance to add 1 second to the timer every second";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% de chance d'ajouter 1 seconde au chrono chaque seconde";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% di probabilità di aggiungere 1 secondo al timer ogni secondo";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% Chance, jede Sekunde 1 Sekunde zum Timer hinzuzufügen";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% de probabilidad de añadir 1 segundo al temporizador cada segundo";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"毎秒{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}%の確率でタイマーに1秒追加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"매초 {SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% 확률로 타이머에 1초 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% szansy na dodanie 1 sekundy do licznika co sekundę";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% de chance de adicionar 1 segundo ao cronômetro a cada segundo";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% шанс добавить 1 секунду к таймеру каждую секунду";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "1S=1S";
                    skillTreeDesc_text.text = $"每秒有 {SkillTree.chanceToAdd1SecEverySec.ToString("F0")}% 的几率为计时器增加 1 秒";
                }
                #endregion
            }
            else if (isChanceWhenMined)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Mined Rock = Time";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% chance to add 1 second to the timer when a rock is mined";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Roche Minée = Temps";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% de chance d'ajouter 1 seconde au chrono quand une roche est extraite";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Roccia Scavata = Tempo";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% di probabilità di aggiungere 1 secondo al timer quando si estrae una roccia";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Abgebauter Stein = Zeit";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% Chance, beim Abbau eines Steins 1 Sekunde zum Timer hinzuzufügen";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Roca Minada = Tiempo";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% de probabilidad de añadir 1 segundo al temporizador al minar una roca";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "採掘岩 = 時間";
                    skillTreeDesc_text.text = $"岩を採掘すると{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}%の確率でタイマーに1秒追加";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "채굴한 바위 = 시간";
                    skillTreeDesc_text.text = $"바위를 캘 때 {SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% 확률로 타이머에 1초 추가";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Wydobyta Skała = Czas";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% szansy na dodanie 1 sekundy do licznika po wydobyciu skały";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Rocha Minerada = Tempo";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% de chance de adicionar 1 segundo ao cronômetro ao minerar uma rocha";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Добытый Камень = Время";
                    skillTreeDesc_text.text = $"{SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% шанс добавить 1 секунду к таймеру при добыче камня";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "采矿岩石 = 时间";
                    skillTreeDesc_text.text = $"每开采一块岩石有 {SkillTree.chanceToAdd1SecEveryRockMined.ToString("F3")}% 的几率为计时器增加 1 秒";
                }
                #endregion
            }
        }
        #endregion

        #region Double XP and Gold Chance
        else if (upgradeType == 21)
        {
            float nextDoubleChance = 0f;

            if (upgradeName == "DoubleXpAndMaterial1")
            {
                doubleXpAndGoldChanceIncrease = 1f;
            }
            else if (upgradeName == "DoubleXpAndMaterial2")
            {
                doubleXpAndGoldChanceIncrease = 2f;
            }
            else if (upgradeName == "DoubleXpAndMaterial3")
            {
                doubleXpAndGoldChanceIncrease = 3f;
            }
            else if (upgradeName == "DoubleXpAndMaterial4")
            {
                doubleXpAndGoldChanceIncrease = 4f;
            }
            else if (upgradeName == "DoubleXpAndMaterial5")
            {
                doubleXpAndGoldChanceIncrease = 5f;
            }
            else if (upgradeName == "DoubleEndless1")
            {
                doubleXpAndGoldChanceIncrease = 0.5f;
            }
            else if (upgradeName == "DoubleEndless2")
            {
                doubleXpAndGoldChanceIncrease = 0.5f;
            }

            nextDoubleChance = SkillTree.doubleXpAndGoldChance + doubleXpAndGoldChanceIncrease;

            #region Name texts
            if (isEnglish == true)
            {
                skillTreeName_text.text = "Double Double!";
            }

            if (isFrench == true)
            {
                skillTreeName_text.text = "Double Double !";
            }

            if (isItalian == true)
            {
                skillTreeName_text.text = "Doppio Doppio!";
            }

            if (isGerman == true)
            {
                skillTreeName_text.text = "Doppel Doppel!";
            }

            if (isSpanish == true)
            {
                skillTreeName_text.text = "Doble Doble!";
            }

            if (isJapanese == true)
            {
                skillTreeName_text.text = "ダブルダブル！";
            }

            if (isKorean == true)
            {
                skillTreeName_text.text = "더블 더블!";
            }

            if (isPolish == true)
            {
                skillTreeName_text.text = "Podwójne Podwójne!";
            }

            if (isPortugese == true)
            {
                skillTreeName_text.text = "Duplo Duplo!";
            }

            if (isRussian == true)
            {
                skillTreeName_text.text = "Двойной Двойной!";
            }

            if (isSimplefiedChinese == true)
            {
                skillTreeName_text.text = "双倍双倍！";
            }
            #endregion

            if (isPurchasedMax)
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Total double ore and XP chance:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Chance totale de doubler minerais et XP :\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Probabilità totale di raddoppiare minerali e XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Gesamtchance auf doppeltes Erz und XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Probabilidad total de duplicar minerales y XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"鉱石とXPを2倍にする総確率：\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"광석과 XP 두 배 총 확률:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Łączna szansa na podwojenie rudy i XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Chance total de dobrar minério e XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Общий шанс удвоить руду и XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"双倍矿石与 XP 的总几率：\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}%";
                }
                #endregion
            }
            else
            {
                #region Desc texts
                if (isEnglish == true)
                {
                    skillTreeDesc_text.text = $"Chance to double the value of ores and XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isFrench == true)
                {
                    skillTreeDesc_text.text = $"Chance de doubler la valeur des minerais et de l'XP :\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isItalian == true)
                {
                    skillTreeDesc_text.text = $"Probabilità di raddoppiare il valore di minerali e XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isGerman == true)
                {
                    skillTreeDesc_text.text = $"Chance, den Wert von Erzen und XP zu verdoppeln:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeDesc_text.text = $"Probabilidad de duplicar el valor de minerales y XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeDesc_text.text = $"鉱石とXPの価値を2倍にする確率：\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isKorean == true)
                {
                    skillTreeDesc_text.text = $"광석과 XP 가치를 두 배로 만들 확률:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isPolish == true)
                {
                    skillTreeDesc_text.text = $"Szansa na podwojenie wartości rudy i XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeDesc_text.text = $"Chance de dobrar o valor dos minérios e XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isRussian == true)
                {
                    skillTreeDesc_text.text = $"Шанс удвоить ценность руды и XP:\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeDesc_text.text = $"双倍矿石与 XP 的几率：\n{SkillTree.doubleXpAndGoldChance.ToString("F2")}% -> {nextDoubleChance.ToString("F2")}%";
                }
                #endregion
            }
        }
        #endregion

        #region Misc and FINAL
        else if (upgradeType == 22)
        {
            bool isDoubleDamageChance = false;
            bool isInstaMineChance = false;

            if (upgradeName == "DoubleDamageChance1")
            {
                isDoubleDamageChance = true;
                doubleDamageChanceIncrease = 1f;
            }

            if (upgradeName == "DoubleDamageChance2")
            {
                isDoubleDamageChance = true;
                doubleDamageChanceIncrease = 2f;
            }

            if (upgradeName == "InstaMine1")
            {
                isInstaMineChance = true;
                instaMineChanceIncrease = 1f;
            }
            if (upgradeName == "InstaMine2")
            {
                isInstaMineChance = true;
                instaMineChanceIncrease = 1f;
            }

            float nextDoubleDamage = SkillTree.doubleDamageChance + doubleDamageChanceIncrease;
            float nextInstaMine = SkillTree.instaMineChance + instaMineChanceIncrease;

            if (isDoubleDamageChance == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Double Pickaxe Power";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Double Puissance Pioche";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Doppia Potenza Piccone";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Doppelte Spitzhacken-Power";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Doble Poder de Pico";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ピッケルパワー2倍";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "곡괭이 파워 2배";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Podwójna Moc Kilofa";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Poder Duplo da Picareta";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Двойная Сила Кирки";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "双倍镐子威力";
                }
                #endregion

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Double pickaxe power chance:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance de doubler la puissance de la pioche :\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di raddoppiare la potenza del piccone:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Chance auf doppelte Spitzhacken-Power:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de duplicar el poder del pico:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケルパワーを2倍にする確率：\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 파워 2배 확률:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na podwójną moc kilofa:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de dobrar o poder da picareta:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс удвоить силу кирки:\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"镐子威力翻倍几率：\n{SkillTree.doubleDamageChance.ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Double pickaxe power chance:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance de doubler la puissance de la pioche :\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di raddoppiare la potenza del piccone:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Chance auf doppelte Spitzhacken-Power:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de duplicar el poder del pico:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"ピッケルパワーを2倍にする確率：\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"곡괭이 파워 2배 확률:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na podwójną moc kilofa:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de dobrar o poder da picareta:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс удвоить силу кирки:\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"镐子威力翻倍几率：\n{SkillTree.doubleDamageChance.ToString("F0")}% -> {nextDoubleDamage.ToString("F0")}%";
                    }
                    #endregion
                }
            }
            else if (isInstaMineChance == true)
            {
                #region Name texts
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Insta Mine!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Mine Instantanée !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Scavo Istantaneo!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Sofort Abbauen!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Minado Instantáneo!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "即採掘！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "즉시 채굴!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Natychmiastowe Wydobycie!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mineração Instantânea!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Мгновенная Добыча!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "秒采！";
                }
                #endregion

                if (isPurchasedMax)
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Insta mine rock chance:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance de mine instantanée :\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di scavo istantaneo:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Sofortabbau-Chance:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de minado instantáneo:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"即採掘確率：\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"즉시 채굴 확률:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na natychmiastowe wydobycie:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de mineração instantânea:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс мгновенной добычи:\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"秒采几率：\n{SkillTree.instaMineChance.ToString("F0")}%";
                    }
                    #endregion
                }
                else
                {
                    #region Desc texts
                    if (isEnglish == true)
                    {
                        skillTreeDesc_text.text = $"Chance to instantly mine a rock:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isFrench == true)
                    {
                        skillTreeDesc_text.text = $"Chance de miner une roche instantanément :\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isItalian == true)
                    {
                        skillTreeDesc_text.text = $"Probabilità di estrarre istantaneamente una roccia:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isGerman == true)
                    {
                        skillTreeDesc_text.text = $"Chance, einen Stein sofort abzubauen:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isSpanish == true)
                    {
                        skillTreeDesc_text.text = $"Probabilidad de minar una roca instantáneamente:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isJapanese == true)
                    {
                        skillTreeDesc_text.text = $"岩を即座に採掘する確率：\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isKorean == true)
                    {
                        skillTreeDesc_text.text = $"바위를 즉시 채굴할 확률:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isPolish == true)
                    {
                        skillTreeDesc_text.text = $"Szansa na natychmiastowe wydobycie skały:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isPortugese == true)
                    {
                        skillTreeDesc_text.text = $"Chance de minerar uma rocha instantaneamente:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isRussian == true)
                    {
                        skillTreeDesc_text.text = $"Шанс мгновенно добыть камень:\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }

                    if (isSimplefiedChinese == true)
                    {
                        skillTreeDesc_text.text = $"瞬间开采岩石的几率：\n{SkillTree.instaMineChance.ToString("F0")}% -> {nextInstaMine.ToString("F0")}%";
                    }
                    #endregion
                }
            }
            else if (upgradeName == "AllProjectleDoubleDamageChance")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Double Trouble";
                    skillTreeDesc_text.text = $"Lightning, dynamite and plazma ball double damage chance:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Double Problème";
                    skillTreeDesc_text.text = $"Chance de double dégâts pour foudre, dynamite et boule de plazma :\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Doppio Problema";
                    skillTreeDesc_text.text = $"Probabilità di danno doppio per fulmine, dinamite e sfera di plazma:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Doppelt Ärger";
                    skillTreeDesc_text.text = $"Chance auf doppelten Schaden für Blitz, Dynamit und Plasmakugel:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Doble Problema";
                    skillTreeDesc_text.text = $"Probabilidad de daño doble para rayo, dinamita y bola de plazma:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "ダブルトラブル";
                    skillTreeDesc_text.text = $"雷・ダイナマイト・プラズマボールのダメージ2倍確率：\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "더블 트러블";
                    skillTreeDesc_text.text = $"번개, 다이너마이트, 플라즈마 볼 2배 피해 확률:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Podwójne Kłopoty";
                    skillTreeDesc_text.text = $"Szansa na podwójne obrażenia od błyskawicy, dynamitu i kuli plazmy:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Duplo Problema";
                    skillTreeDesc_text.text = $"Chance de dano dobrado para raio, dinamite e bola de plazma:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Двойные Проблемы";
                    skillTreeDesc_text.text = $"Шанс двойного урона от молнии, динамита и плазменного шара:\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "双倍麻烦";
                    skillTreeDesc_text.text = $"闪电、炸药和等离子球双倍伤害几率：\n{SkillTree.allProjectileDoubleDamageIncrease.ToString("F0")}%";
                }
                #endregion
            }
            else if (upgradeName == "IncreaseAllProjectileChance")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Trigger Chance";
                    skillTreeDesc_text.text = $"Lightning, dynamite and plazma ball trigger chance increase:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% of their current trigger chance";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Chance de Déclenchement";
                    skillTreeDesc_text.text = $"<size=19>Augmente la chance de déclenchement de la foudre, de la dynamite et de la boule de plazma :\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% de leur chance actuelle";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Probabilità di Attivazione";
                    skillTreeDesc_text.text = $"Aumenta la probabilità di attivazione di fulmine, dinamite e sfera di plazma:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% del valore attuale";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Auslöser-Chance";
                    skillTreeDesc_text.text = $"Erhöht die Auslöse-Chance für Blitz, Dynamit und Plasmakugel:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% ihres aktuellen Werts";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Probabilidad de Activación";
                    skillTreeDesc_text.text = $"Aumenta la probabilidad de activación de rayo, dinamita y bola de plazma:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% de su valor actual";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "発動確率";
                    skillTreeDesc_text.text = $"雷・ダイナマイト・プラズマボールの発動確率を増加：\n現在の確率の+{SkillTree.allProjcetileTriggerChance.ToString("F0")}%";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "트리거 확률";
                    skillTreeDesc_text.text = $"번개, 다이너마이트, 플라즈마 볼 발동 확률 증가:\n현재 확률의 +{SkillTree.allProjcetileTriggerChance.ToString("F0")}%";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Szansa Aktywacji";
                    skillTreeDesc_text.text = $"Zwiększa szansę na aktywację błyskawicy, dynamitu i kuli plazmy:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% ich aktualnej szansy";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Chance de Acionamento";
                    skillTreeDesc_text.text = $"Aumenta a chance de acionar raio, dinamite e bola de plazma:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% da chance atual";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Шанс Срабатывания";
                    skillTreeDesc_text.text = $"Увеличивает шанс срабатывания молнии, динамита и плазменного шара:\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% от текущего значения";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "触发概率";
                    skillTreeDesc_text.text = $"增加闪电、炸药和等离子球的触发概率：\n+{SkillTree.allProjcetileTriggerChance.ToString("F0")}% 当前触发几率";
                }
                #endregion
            }
            else if (upgradeName == "IncreaseAllRockSpawnChance")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "More Material Rocks";
                    skillTreeDesc_text.text = $"Increase all material rock spawn chance by:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% of their current spawn chance";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Plus de Roches Matériaux";
                    skillTreeDesc_text.text = $"Augmente la chance d'apparition de toutes les roches matériaux de :\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% de leur chance actuelle";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Più Rocce di Materiale";
                    skillTreeDesc_text.text = $"Aumenta la probabilità di apparizione di tutte le rocce di materiale di:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% del loro valore attuale";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Materialsteine";
                    skillTreeDesc_text.text = $"Erhöht die Spawn-Chance aller Materialsteine um:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% ihres aktuellen Werts";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Más Rocas de Material";
                    skillTreeDesc_text.text = $"Aumenta la probabilidad de aparición de todas las rocas de material en:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% de su valor actual";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "素材岩増加";
                    skillTreeDesc_text.text = $"すべての素材岩の出現確率を増加：\n現在の確率の{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}%";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "자원 암석 증가";
                    skillTreeDesc_text.text = $"모든 자원 암석의 생성 확률 증가:\n현재 확률의 {SkillTree.allRockSpawnChanceIncrease.ToString("F0")}%";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Skał Materiałowych";
                    skillTreeDesc_text.text = $"Zwiększa szansę pojawienia się wszystkich skał materiałowych o:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% ich aktualnej wartości";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Mais Rochas de Materiais";
                    skillTreeDesc_text.text = $"Aumenta a chance de surgimento de todas as rochas de material em:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% do valor atual";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Больше Материальных Камней";
                    skillTreeDesc_text.text = $"Увеличивает шанс появления всех материальных камней на:\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% от текущего значения";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多材料岩石";
                    skillTreeDesc_text.text = $"提升所有材料岩石的生成概率：\n{SkillTree.allRockSpawnChanceIncrease.ToString("F0")}% 当前生成概率";
                }
                #endregion
            }
            else if (upgradeName == "2GoldBarsCraft")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Craft More!";
                    skillTreeDesc_text.text = $"It now only takes 2 ores to craft a bar!";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Fabriquez Plus !";
                    skillTreeDesc_text.text = $"Il ne faut maintenant que 2 minerais pour fabriquer un lingot !";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Crea di Più!";
                    skillTreeDesc_text.text = $"Ora servono solo 2 minerali per forgiare una barra!";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Mehr Herstellen!";
                    skillTreeDesc_text.text = $"Es werden jetzt nur 2 Erze benötigt, um einen Barren zu schmieden!";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "¡Fabricar Más!";
                    skillTreeDesc_text.text = $"¡Ahora solo necesitas 2 minerales para crear una barra!";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "もっとクラフト！";
                    skillTreeDesc_text.text = $"今ではインゴットを作るのに鉱石2つだけ！";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "더 많이 제작!";
                    skillTreeDesc_text.text = $"이제 광석 2개만으로 바를 제작할 수 있습니다!";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Więcej Wytwarzania!";
                    skillTreeDesc_text.text = $"Teraz wystarczą tylko 2 rudy, aby stworzyć sztabkę!";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Produza Mais!";
                    skillTreeDesc_text.text = $"Agora só precisa de 2 minérios para forjar uma barra!";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Крафти Больше!";
                    skillTreeDesc_text.text = $"Теперь нужно всего 2 руды, чтобы создать слиток!";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "更多锻造！";
                    skillTreeDesc_text.text = $"现在只需 2 个矿石就能锻造一个锭！";
                }
                #endregion
            }
            else if (upgradeName == "FinalUpgrade")
            {
                #region Name texts and desc
                if (isEnglish == true)
                {
                    skillTreeName_text.text = "Big Rock";
                    skillTreeDesc_text.text = $"You can now mine the big rock.";
                }

                if (isFrench == true)
                {
                    skillTreeName_text.text = "Gros Rocher";
                    skillTreeDesc_text.text = $"Vous pouvez maintenant miner le gros rocher.";
                }

                if (isItalian == true)
                {
                    skillTreeName_text.text = "Grande Roccia";
                    skillTreeDesc_text.text = $"Ora puoi scavare la grande roccia.";
                }

                if (isGerman == true)
                {
                    skillTreeName_text.text = "Großer Felsen";
                    skillTreeDesc_text.text = $"Du kannst jetzt den großen Felsen abbauen.";
                }

                if (isSpanish == true)
                {
                    skillTreeName_text.text = "Roca Grande";
                    skillTreeDesc_text.text = $"Ahora puedes minar la gran roca.";
                }

                if (isJapanese == true)
                {
                    skillTreeName_text.text = "巨大な岩";
                    skillTreeDesc_text.text = $"大きな岩を採掘できるようになりました。";
                }

                if (isKorean == true)
                {
                    skillTreeName_text.text = "큰 바위";
                    skillTreeDesc_text.text = $"이제 큰 바위를 채굴할 수 있습니다.";
                }

                if (isPolish == true)
                {
                    skillTreeName_text.text = "Wielka Skała";
                    skillTreeDesc_text.text = $"Możesz teraz wydobywać wielką skałę.";
                }

                if (isPortugese == true)
                {
                    skillTreeName_text.text = "Grande Rocha";
                    skillTreeDesc_text.text = $"Agora você pode minerar a grande rocha.";
                }

                if (isRussian == true)
                {
                    skillTreeName_text.text = "Большой Камень";
                    skillTreeDesc_text.text = $"Теперь можно добывать большой камень.";
                }

                if (isSimplefiedChinese == true)
                {
                    skillTreeName_text.text = "巨岩";
                    skillTreeDesc_text.text = $"现在你可以开采大岩石了。";
                }
                #endregion
            }
        }
        #endregion

        currentSkillTreePrice = upgradePrice;

        skillTreePrice_text.text = LocalizationScript.price + " " + FormatNumbers.FormatPoints(currentSkillTreePrice);

        if (isEnglish == true) 
        {
            skillTreePurchased_text.text = $"Purchased: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isFrench == true)
        {
            skillTreePurchased_text.text = $"Acheté : {purchaseCount}/{totalPurchaseCount}";
        }

        if (isItalian == true)
        {
            skillTreePurchased_text.text = $"Acquistato: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isGerman == true)
        {
            skillTreePurchased_text.text = $"Gekauft: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isSpanish == true)
        {
            skillTreePurchased_text.text = $"Comprado: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isJapanese == true)
        {
            skillTreePurchased_text.text = $"購入済み: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isKorean == true)
        {
            skillTreePurchased_text.text = $"구매됨: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isPolish == true)
        {
            skillTreePurchased_text.text = $"Zakupiono: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isPortugese == true)
        {
            skillTreePurchased_text.text = $"Comprado: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isRussian == true)
        {
            skillTreePurchased_text.text = $"Куплено: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isSimplefiedChinese == true)
        {
            skillTreePurchased_text.text = $"已购买: {purchaseCount}/{totalPurchaseCount}";
        }

        if (isPurchasedMax == true)
        {
            skillTreePrice_text.gameObject.SetActive(false);
            skillTreePurchased_text.gameObject.transform.localScale = new Vector2(1.2f, 1.2f);
            skillTreePurchased_text.gameObject.transform.localPosition = new Vector2(0, -64f);
        }
        else
        {
            skillTreePrice_text.gameObject.SetActive(true);
            skillTreePurchased_text.gameObject.transform.localScale = new Vector2(0.8f, 0.8f);
            skillTreePurchased_text.gameObject.transform.localPosition = new Vector2(0, -85f);
        }
    }
    #endregion

    #region Artifact texts
    public string artifactTooltipName;
    public string artifactDescName;

    public TextMeshProUGUI artifactName_text;
    public TextMeshProUGUI artifactDesc_text;

    public GameObject horn_tooltipImage;
    public GameObject ancientDevice_tooltipImage;
    public GameObject bone_tooltipImage;
    public GameObject meteorieOre_tooltipImage;
    public GameObject book_tooltipImage;
    public GameObject goldStack_tooltipImage;
    public GameObject goldRing_tooltipImage;
    public GameObject purpleRing_tooltipImage;
    public GameObject ancientDice_tooltipImage;
    public GameObject cheese_tooltipImage;
    public GameObject wolfClaw_tooltipImage;
    public GameObject axe_tooltipImage;
    public GameObject rune_tooltipImage;
    public GameObject skull_tooltipImage;

    public void ArtifactsTooltipText(int artifactNumber)
    {
        horn_tooltipImage.SetActive(false);
        ancientDevice_tooltipImage.SetActive(false);
        bone_tooltipImage.SetActive(false);
        meteorieOre_tooltipImage.SetActive(false);
        book_tooltipImage.SetActive(false);
        goldStack_tooltipImage.SetActive(false);
        goldRing_tooltipImage.SetActive(false);
        purpleRing_tooltipImage.SetActive(false);
        ancientDice_tooltipImage.SetActive(false);
        cheese_tooltipImage.SetActive(false);
        wolfClaw_tooltipImage.SetActive(false);
        axe_tooltipImage.SetActive(false);
        rune_tooltipImage.SetActive(false);
        skull_tooltipImage.SetActive(false);

        if (artifactNumber == 1)
        {
            float hornStats = Artifacts.hornRockDecrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                hornStats *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { hornStats *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { hornStats *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = horn;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Reduces the durability of all rocks by {hornStats * 100}%";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Réduit la durabilité de toutes les roches de {hornStats * 100}%";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Riduce la durabilità di tutte le rocce del {hornStats * 100}%";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Reduziert die Haltbarkeit aller Steine um {hornStats * 100}%";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Reduce la durabilidad de todas las rocas en {hornStats * 100}%";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"すべての岩の耐久度を{hornStats * 100}%減少させる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"모든 바위의 내구도를 {hornStats * 100}% 감소시킴";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Zmniejsza wytrzymałość wszystkich skał o {hornStats * 100}%";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Reduz o durabilidade de todas as rochas em {hornStats * 100}%";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Уменьшает прочность всех камней на {hornStats * 100}%";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"减少所有岩石的耐久度 {hornStats * 100}%";
            }
            #endregion

            horn_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 2)
        {
            float ancientDeviceStats = Artifacts.ancientDeviceTimeReduction;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                ancientDeviceStats *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { ancientDeviceStats *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { ancientDeviceStats *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = device;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Improved The Mine. It now mines {ancientDeviceStats * 100}% faster";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Améliore La Mine. Elle extrait maintenant {ancientDeviceStats * 100}% plus vite";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Migliora La Miniera. Ora estrae il {ancientDeviceStats * 100}% più velocemente";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Verbessert Die Mine. Sie baut jetzt {ancientDeviceStats * 100}% schneller ab";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Mejora La Mina. Ahora mina un {ancientDeviceStats * 100}% más rápido";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"ザ・マインを強化。採掘速度が{ancientDeviceStats * 100}%アップ";
            }

            if (isKorean == true)
            {
                artifactDescName = $"광산이 강화됨. 이제 {ancientDeviceStats * 100}% 더 빨리 채굴함";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Ulepsza Kopalnię. Teraz wydobywa o {ancientDeviceStats * 100}% szybciej";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Aprimora A Mina. Agora minera {ancientDeviceStats * 100}% mais rápido";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Улучшает Шахту. Теперь добывает на {ancientDeviceStats * 100}% быстрее";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"强化了矿井，开采速度提高 {ancientDeviceStats * 100}%";
            }
            #endregion

            ancientDevice_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 3)
        {
            float boneIncrease = Artifacts.bonePickaxeIncrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                boneIncrease *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { boneIncrease *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { boneIncrease *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = bone;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Improves all pickaxe stats by {boneIncrease * 100}%";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Améliore toutes les stats de la pioche de {boneIncrease * 100}%";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Migliora tutte le statistiche del piccone del {boneIncrease * 100}%";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Verbessert alle Spitzhacken-Werte um {boneIncrease * 100}%";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Mejora todas las estadísticas del pico en {boneIncrease * 100}%";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"すべてのピッケルのステータスを{boneIncrease * 100}%強化";
            }

            if (isKorean == true)
            {
                artifactDescName = $"모든 곡괭이 능력치를 {boneIncrease * 100}% 향상시킴";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Zwiększa wszystkie statystyki kilofa o {boneIncrease * 100}%";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Melhora todas as estatísticas da picareta em {boneIncrease * 100}%";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Улучшает все характеристики кирки на {boneIncrease * 100}%";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"所有镐子属性提高 {boneIncrease * 100}%";
            }
            #endregion

            bone_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 4)
        {
            float meteoriteIncrease = Artifacts.meteoriteRockSpawnIncrease;
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                meteoriteIncrease *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { meteoriteIncrease *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { meteoriteIncrease *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = meteorite;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Increases the spawn chance of all full material rocks by {meteoriteIncrease * 100}% of their current chance";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Augmente la chance d'apparition de toutes les roches complètes de {meteoriteIncrease * 100}% de leur chance actuelle";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Aumenta la probabilità di generazione di tutte le rocce piene del {meteoriteIncrease * 100}% del loro valore attuale";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Erhöht die Spawn-Chance aller vollen Materialsteine um {meteoriteIncrease * 100}% ihres aktuellen Werts";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Aumenta la probabilidad de aparición de todas las rocas completas en un {meteoriteIncrease * 100}% de su valor actual";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"すべてのフル素材岩の出現確率を現在の確率の{meteoriteIncrease * 100}%増加させる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"모든 완전 자원 암석의 생성 확률을 현재 확률의 {meteoriteIncrease * 100}%만큼 증가시킴";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Zwiększa szansę pojawienia się wszystkich pełnych skał materiałowych o {meteoriteIncrease * 100}% ich aktualnej szansy";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Aumenta a chance de surgimento de todas as rochas completas em {meteoriteIncrease * 100}% da chance atual";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Увеличивает шанс появления всех полных материальных камней на {meteoriteIncrease * 100}% от текущего значения";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"所有完整材料岩石的生成概率提高其当前概率的 {meteoriteIncrease * 100}%";
            }
            #endregion

            meteorieOre_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 5)
        {
            artifactTooltipName = book;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = "Gives 1 extra talent point per 5 levels";
            }

            if (isFrench == true)
            {
                artifactDescName = "Donne 1 point de talent supplémentaire tous les 5 niveaux";
            }

            if (isItalian == true)
            {
                artifactDescName = "Dà 1 punto talento extra ogni 5 livelli";
            }

            if (isGerman == true)
            {
                artifactDescName = "Gibt 1 zusätzlichen Talentpunkt alle 5 Level";
            }

            if (isSpanish == true)
            {
                artifactDescName = "Otorga 1 punto de talento extra cada 5 niveles";
            }

            if (isJapanese == true)
            {
                artifactDescName = "5レベルごとに追加で才能ポイントを1獲得";
            }

            if (isKorean == true)
            {
                artifactDescName = "5레벨마다 추가 재능 포인트 1개 제공";
            }

            if (isPolish == true)
            {
                artifactDescName = "Daje 1 dodatkowy punkt talentu co 5 poziomów";
            }

            if (isPortugese == true)
            {
                artifactDescName = "Concede 1 ponto de talento extra a cada 5 níveis";
            }

            if (isRussian == true)
            {
                artifactDescName = "Дает 1 дополнительный очко таланта за каждые 5 уровней";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = "每升 5 级额外获得 1 点天赋点";
            }
            #endregion

            book_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 6)
        {
            int rockToDouble = 25;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                rockToDouble = 22;
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { rockToDouble = 23; }
                if (Artifacts.rune_found) { rockToDouble = 24; }
            }

            artifactTooltipName = sack;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Every {rockToDouble} mined ore will be worth double";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Chaque {rockToDouble} matériau extrait vaudra le double";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Ogni {rockToDouble} materiale estratto varrà il doppio";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Jedes {rockToDouble}. abgebautes Material ist doppelt so viel wert";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Cada {rockToDouble} material extraído valdrá el doble";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"採掘した素材{rockToDouble}個ごとに価値が2倍になる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"채굴한 자원 {rockToDouble}개마다 가치가 2배가 됨";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Co {rockToDouble} wydobyty materiał jest wart dwa razy więcej";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Cada {rockToDouble} material minerado valerá o dobro";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Каждый {rockToDouble}-й добытый материал будет стоить вдвое дороже";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"每开采 {rockToDouble} 个材料，其价值翻倍";
            }
            #endregion

            goldStack_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 7)
        {
            float ringChance = Artifacts.goldRingCraftChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                ringChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { ringChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { ringChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = goldRing;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"At the end of a mining session, every ore mined has a {ringChance.ToString("F1")}% chance of only using 1 ore to craft a bar";
            }

            if (isFrench == true)
            {
                artifactDescName = $"À la fin d'une session, chaque minerai extrait a {ringChance.ToString("F1")}% de chance de n'utiliser qu'1 minerai pour fabriquer un lingot";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Alla fine di una sessione, ogni minerale estratto ha il {ringChance.ToString("F1")}% di probabilità di usare solo 1 minerale per forgiare una barra";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Am Ende einer Sitzung hat jedes Erz {ringChance.ToString("F1")}% Chance, nur 1 Erz für einen Barren zu verbrauchen";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Al final de una sesión, cada mineral extraído tiene un {ringChance.ToString("F1")}% de probabilidad de usar solo 1 mineral para forjar una barra";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"採掘セッション終了時、採掘した鉱石ごとに{ringChance.ToString("F1")}%の確率で鉱石1つだけでインゴットを作れる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"채굴 세션 종료 시, 채굴한 광석마다 {ringChance.ToString("F1")}% 확률로 광석 1개만으로 바를 제작함";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Na końcu sesji każdy wydobyty minerał ma {ringChance.ToString("F1")}% szansy, że do stworzenia sztabki użyje się tylko 1 minerału";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"No final de uma sessão, cada minério minerado tem {ringChance.ToString("F1")}% de chance de usar apenas 1 minério para forjar uma barra";
            }

            if (isRussian == true)
            {
                artifactDescName = $"В конце сессии каждая добытая руда имеет {ringChance.ToString("F1")}% шанс использовать только 1 руду для создания слитка";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"采矿结束时，每个矿石有 {ringChance.ToString("F1")}% 的几率只用 1 个矿石锻造一个锭";
            }
            #endregion

            goldRing_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 8)
        {
            float purpleRignChance = Artifacts.purpleRingChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                purpleRignChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { purpleRignChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { purpleRignChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = royalRing;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"{purpleRignChance}% chance to receive double XP from mined rocks";
            }

            if (isFrench == true)
            {
                artifactDescName = $"{purpleRignChance}% de chance de recevoir le double d'XP des roches extraites";
            }

            if (isItalian == true)
            {
                artifactDescName = $"{purpleRignChance}% di probabilità di ricevere XP doppia dalle rocce estratte";
            }

            if (isGerman == true)
            {
                artifactDescName = $"{purpleRignChance}% Chance, doppelte XP aus abgebauten Steinen zu erhalten";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"{purpleRignChance}% de probabilidad de recibir XP doble de las rocas extraídas";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"採掘した岩から{purpleRignChance}%の確率でXPが2倍になる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"채굴한 바위에서 {purpleRignChance}% 확률로 XP 2배 획득";
            }

            if (isPolish == true)
            {
                artifactDescName = $"{purpleRignChance}% szansy na podwójne XP z wydobytych skał";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"{purpleRignChance}% de chance de receber XP em dobro das rochas mineradas";
            }

            if (isRussian == true)
            {
                artifactDescName = $"{purpleRignChance}% шанс получить двойной XP с добытых камней";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"从采矿岩石中获得双倍 XP 的几率：{purpleRignChance}%";
            }
            #endregion

            purpleRing_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 9)
        {
            float diceTime = Artifacts.diceTime;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                diceTime *= (1 - LevelMechanics.archeologistIncreaseDISPLAY - Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { diceTime *= (1 - LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { diceTime *= (1 - Artifacts.runeImproveAll); }
            }

            artifactTooltipName = dice;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Spawn 1 rock every {diceTime} second";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Fait apparaître 1 roche toutes les {diceTime} secondes";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Genera 1 roccia ogni {diceTime} secondi";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Spawnt alle {diceTime} Sekunden 1 Stein";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Genera 1 roca cada {diceTime} segundo";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"{diceTime}秒ごとに岩を1個生成する";
            }

            if (isKorean == true)
            {
                artifactDescName = $"{diceTime}초마다 바위 1개 생성";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Generuje 1 skałę co {diceTime} sekund";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Gera 1 rocha a cada {diceTime} segundo";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Создает 1 камень каждые {diceTime} секунд";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"每 {diceTime} 秒生成 1 块岩石";
            }
            #endregion

            ancientDice_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 10)
        {
            float cheeseChance = Artifacts.cheeseChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                cheeseChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { cheeseChance *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { cheeseChance *= (1 + Artifacts.runeImproveAll); }
            }

            artifactTooltipName = cheese;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Every pickaxe hit has a {cheeseChance.ToString("F2")}% chance to drop 1 ore";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Chaque coup de pioche a {cheeseChance.ToString("F2")}% de chance de faire tomber 1 minerai";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Ogni colpo di piccone ha il {cheeseChance.ToString("F2")}% di probabilità di far cadere 1 minerale";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Jeder Schlag mit der Spitzhacke hat eine Chance von {cheeseChance.ToString("F2")}%, 1 Erz fallen zu lassen";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Cada golpe de pico tiene un {cheeseChance.ToString("F2")}% de probabilidad de soltar 1 mineral";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"ピッケルのヒットごとに{cheeseChance.ToString("F2")}%の確率で鉱石1個をドロップ";
            }

            if (isKorean == true)
            {
                artifactDescName = $"곡괭이 타격 시 {cheeseChance.ToString("F2")}% 확률로 광석 1개 드랍";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Każde uderzenie kilofa ma {cheeseChance.ToString("F2")}% szansy na upuszczenie 1 rudy";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Cada golpe de picareta tem {cheeseChance.ToString("F2")}% de chance de soltar 1 minério";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Каждый удар киркой даёт {cheeseChance.ToString("F2")}% шанс сбросить 1 руду";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"每次镐击有 {cheeseChance.ToString("F2")}% 的几率掉落 1 个矿石";
            }
            #endregion

            cheese_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 11)
        {
            float claw = Artifacts.clawChance;

            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found)
            {
                claw *= (1 + LevelMechanics.archeologistIncreaseDISPLAY + Artifacts.runeImproveAll);
            }
            else
            {
                if (LevelMechanics.archaeologist_chosen) { claw *= (1 + LevelMechanics.archeologistIncreaseDISPLAY); }
                if (Artifacts.rune_found) { claw *= (1 + Artifacts.runeImproveAll); }
            }
            artifactTooltipName = wolf;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Increase the pickaxe power by {claw * 100}%";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Augmente la puissance de la pioche de {claw * 100}%";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Aumenta la potenza del piccone del {claw * 100}%";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Erhöht die Spitzhacken-Power um {claw * 100}%";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Aumenta el poder del pico en {claw * 100}%";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"ピッケルのパワーを{claw * 100}%増加させる";
            }

            if (isKorean == true)
            {
                artifactDescName = $"곡괭이 파워 {claw * 100}% 증가";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Zwiększa moc kilofa o {claw * 100}%";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Aumenta o poder da picareta em {claw * 100}%";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Увеличивает силу кирки на {claw * 100}%";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"镐子威力提升 {claw * 100}%";
            }
            #endregion

            wolfClaw_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 12)
        {
            float doubleChanceIncrease = 2f * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);
            float instaDecrese = 1 * (1 + Artifacts.runeImproveAll + LevelMechanics.archeologistIncrease);

            artifactTooltipName = axe;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% chance to deal double pickaxe power and {instaDecrese}% chance to insta mine rocks";
            }

            if (isFrench == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% de chance d'infliger le double de puissance de pioche et {instaDecrese}% de chance de miner instantanément les roches";
            }

            if (isItalian == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% di probabilità di infliggere doppia potenza con il piccone e {instaDecrese}% di probabilità di scavare istantaneamente le rocce";
            }

            if (isGerman == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% Chance auf doppelte Spitzhacken-Power und {instaDecrese}% Chance, Steine sofort abzubauen";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% de probabilidad de hacer doble poder de pico y {instaDecrese}% de probabilidad de minar instantáneamente rocas";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"{doubleChanceIncrease}%の確率でピッケルパワー2倍、さらに{instaDecrese}%の確率で岩を即採掘";
            }

            if (isKorean == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% 확률로 곡괭이 파워 2배, {instaDecrese}% 확률로 바위 즉시 채굴";
            }

            if (isPolish == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% szansy na podwójną moc kilofa i {instaDecrese}% szansy na natychmiastowe wydobycie skał";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% de chance de dar poder duplo da picareta e {instaDecrese}% de chance de minerar rochas instantaneamente";
            }

            if (isRussian == true)
            {
                artifactDescName = $"{doubleChanceIncrease}% шанс нанести двойной урон киркой и {instaDecrese}% шанс мгновенно добыть камни";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"有 {doubleChanceIncrease}% 几率造成双倍镐子威力，并有 {instaDecrese}% 几率瞬间开采岩石";
            }
            #endregion

            axe_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 13)
        {
            artifactTooltipName = runestone;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"Improves the stats of all artifacts by {Artifacts.runeIncrease_forDisplay}% of their current stats";
            }

            if (isFrench == true)
            {
                artifactDescName = $"Améliore les stats de tous les artefacts de {Artifacts.runeIncrease_forDisplay}% de leurs stats actuelles";
            }

            if (isItalian == true)
            {
                artifactDescName = $"Migliora le statistiche di tutti gli artefatti del {Artifacts.runeIncrease_forDisplay}% delle loro statistiche attuali";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Verbessert die Werte aller Artefakte um {Artifacts.runeIncrease_forDisplay}% ihrer aktuellen Werte";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Mejora las estadísticas de todos los artefactos en un {Artifacts.runeIncrease_forDisplay}% de sus estadísticas actuales";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"すべてのアーティファクトのステータスを現在の{Artifacts.runeIncrease_forDisplay}%分強化";
            }

            if (isKorean == true)
            {
                artifactDescName = $"모든 유물의 스탯을 현재 스탯의 {Artifacts.runeIncrease_forDisplay}%만큼 향상";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Zwiększa statystyki wszystkich artefaktów o {Artifacts.runeIncrease_forDisplay}% ich obecnych statystyk";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"Melhora as estatísticas de todos os artefatos em {Artifacts.runeIncrease_forDisplay}% de seus valores atuais";
            }

            if (isRussian == true)
            {
                artifactDescName = $"Улучшает характеристики всех артефактов на {Artifacts.runeIncrease_forDisplay}% от их текущих значений";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"提升所有神器属性 {Artifacts.runeIncrease_forDisplay}%（基于当前属性）";
            }
            #endregion

            rune_tooltipImage.SetActive(true);
        }
        if (artifactNumber == 14)
        {
            int rocksSpawn = 10;
            if (LevelMechanics.archaeologist_chosen) { rocksSpawn = 11; }
            if (LevelMechanics.archaeologist_chosen && Artifacts.rune_found) { rocksSpawn = 11; }

            artifactTooltipName = skull;

            #region Artifact desc texts
            if (isEnglish == true)
            {
                artifactDescName = $"{rocksSpawn} more rocks spawn at the beginning of a mining session";
            }

            if (isFrench == true)
            {
                artifactDescName = $"{rocksSpawn} roches supplémentaires apparaissent au début d'une session de minage";
            }

            if (isItalian == true)
            {
                artifactDescName = $"{rocksSpawn} rocce in più compaiono all'inizio di una sessione di scavo";
            }

            if (isGerman == true)
            {
                artifactDescName = $"Zu Beginn einer Session erscheinen {rocksSpawn} zusätzliche Steine";
            }

            if (isSpanish == true)
            {
                artifactDescName = $"Aparecen {rocksSpawn} rocas más al inicio de una sesión de minería";
            }

            if (isJapanese == true)
            {
                artifactDescName = $"採掘セッション開始時に{rocksSpawn}個の岩が追加で出現する";
            }

            if (isKorean == true)
            {
                artifactDescName = $"채굴 세션 시작 시 바위 {rocksSpawn}개 추가 생성";
            }

            if (isPolish == true)
            {
                artifactDescName = $"Na początku sesji pojawia się {rocksSpawn} dodatkowych skał";
            }

            if (isPortugese == true)
            {
                artifactDescName = $"No início de uma sessão, surgem mais {rocksSpawn} rochas";
            }

            if (isRussian == true)
            {
                artifactDescName = $"В начале сессии появляется на {rocksSpawn} камней больше";
            }

            if (isSimplefiedChinese == true)
            {
                artifactDescName = $"采矿开始时额外生成 {rocksSpawn} 块岩石";
            }
            #endregion

            skull_tooltipImage.SetActive(true);
        }

        artifactName_text.text = artifactTooltipName;
        artifactDesc_text.text = artifactDescName;
    }
    #endregion

    #region potion texts
    public TextMeshProUGUI potionTooltipName, potionTooltipDesc;

    public void PotionText(string potionName)
    {
        if(potionName == "materialIncrease")
        {
            #region Ore potion
            if (isEnglish == true)
            {
                potionTooltipName.text = "Ore Potion";
                potionTooltipDesc.text = $"Ores are worth {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% more";
            }

            if (isFrench == true)
            {
                potionTooltipName.text = "Potion de Minerai";
                potionTooltipDesc.text = $"Les minerais valent {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% de plus";
            }

            if (isItalian == true)
            {
                potionTooltipName.text = "Pozione del Minerale";
                potionTooltipDesc.text = $"I minerali valgono il {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% in più";
            }

            if (isGerman == true)
            {
                potionTooltipName.text = "Erztrank";
                potionTooltipDesc.text = $"Erze sind {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% mehr wert";
            }

            if (isSpanish == true)
            {
                potionTooltipName.text = "Poción de Mineral";
                potionTooltipDesc.text = $"Los minerales valen {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% más";
            }

            if (isJapanese == true)
            {
                potionTooltipName.text = "鉱石ポーション";
                potionTooltipDesc.text = $"鉱石の価値が{(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}%増加する";
            }

            if (isKorean == true)
            {
                potionTooltipName.text = "광석 포션";
                potionTooltipDesc.text = $"광석 가치가 {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% 증가";
            }

            if (isPolish == true)
            {
                potionTooltipName.text = "Mikstura Rudy";
                potionTooltipDesc.text = $"Rudy są warte o {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% więcej";
            }

            if (isPortugese == true)
            {
                potionTooltipName.text = "Poção de Minério";
                potionTooltipDesc.text = $"Os minérios valem {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% mais";
            }

            if (isRussian == true)
            {
                potionTooltipName.text = "Зелье Руды";
                potionTooltipDesc.text = $"Руда стоит на {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}% дороже";
            }

            if (isSimplefiedChinese == true)
            {
                potionTooltipName.text = "矿石药水";
                potionTooltipDesc.text = $"矿石价值提升 {(SetRockScreen.potionMaterialWorthMore_increase * 100).ToString("F0")}%";
            }
            #endregion
        }
        if (potionName == "pickaxeIncrease")
        {
            #region Pickaxe potion
            if (isEnglish == true)
            {
                potionTooltipName.text = "Pickaxe Potion";
                potionTooltipDesc.text = $"Pickaxe stats are increased by {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isFrench == true)
            {
                potionTooltipName.text = "Potion de Pioche";
                potionTooltipDesc.text = $"Les stats de la pioche sont augmentées de {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isItalian == true)
            {
                potionTooltipName.text = "Pozione del Piccone";
                potionTooltipDesc.text = $"Le statistiche del piccone sono aumentate del {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isGerman == true)
            {
                potionTooltipName.text = "Spitzhacken-Trank";
                potionTooltipDesc.text = $"Spitzhacken-Werte steigen um {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isSpanish == true)
            {
                potionTooltipName.text = "Poción de Pico";
                potionTooltipDesc.text = $"Las estadísticas del pico aumentan un {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isJapanese == true)
            {
                potionTooltipName.text = "ピッケルポーション";
                potionTooltipDesc.text = $"ピッケルのステータスが{(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%増加する";
            }

            if (isKorean == true)
            {
                potionTooltipName.text = "곡괭이 포션";
                potionTooltipDesc.text = $"곡괭이 스탯이 {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}% 증가";
            }

            if (isPolish == true)
            {
                potionTooltipName.text = "Mikstura Kilofa";
                potionTooltipDesc.text = $"Statystyki kilofa zwiększone o {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isPortugese == true)
            {
                potionTooltipName.text = "Poção de Picareta";
                potionTooltipDesc.text = $"Os atributos da picareta aumentam em {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isRussian == true)
            {
                potionTooltipName.text = "Зелье Кирки";
                potionTooltipDesc.text = $"Характеристики кирки увеличены на {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }

            if (isSimplefiedChinese == true)
            {
                potionTooltipName.text = "镐子药水";
                potionTooltipDesc.text = $"镐子属性提高 {(SetRockScreen.potionPickaxeStats_increase * 100).ToString("F0")}%";
            }
            #endregion
        }
        if (potionName == "xpIncrease")
        {
            #region Xp potion
            if (isEnglish == true)
            {
                potionTooltipName.text = "XP Potion";
                potionTooltipDesc.text = $"Rocks give {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% more XP";
            }

            if (isFrench == true)
            {
                potionTooltipName.text = "Potion d'XP";
                potionTooltipDesc.text = $"Les roches donnent {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% d'XP en plus";
            }

            if (isItalian == true)
            {
                potionTooltipName.text = "Pozione XP";
                potionTooltipDesc.text = $"Le rocce danno il {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% di XP in più";
            }

            if (isGerman == true)
            {
                potionTooltipName.text = "XP-Trank";
                potionTooltipDesc.text = $"Steine geben {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% mehr XP";
            }

            if (isSpanish == true)
            {
                potionTooltipName.text = "Poción de XP";
                potionTooltipDesc.text = $"Las rocas dan {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% más XP";
            }

            if (isJapanese == true)
            {
                potionTooltipName.text = "XPポーション";
                potionTooltipDesc.text = $"岩が与えるXPが{(SetRockScreen.potionXp_increase * 100).ToString("F0")}%増加する";
            }

            if (isKorean == true)
            {
                potionTooltipName.text = "XP 포션";
                potionTooltipDesc.text = $"바위가 {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% 더 많은 XP 제공";
            }

            if (isPolish == true)
            {
                potionTooltipName.text = "Mikstura XP";
                potionTooltipDesc.text = $"Skały dają o {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% więcej XP";
            }

            if (isPortugese == true)
            {
                potionTooltipName.text = "Poção de XP";
                potionTooltipDesc.text = $"As rochas dão {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% mais XP";
            }

            if (isRussian == true)
            {
                potionTooltipName.text = "Зелье XP";
                potionTooltipDesc.text = $"Камни дают на {(SetRockScreen.potionXp_increase * 100).ToString("F0")}% больше XP";
            }

            if (isSimplefiedChinese == true)
            {
                potionTooltipName.text = "XP药水";
                potionTooltipDesc.text = $"岩石提供的XP提高 {(SetRockScreen.potionXp_increase * 100).ToString("F0")}%";
            }
            #endregion
        }
        if (potionName == "doubleXpAndMaterialIncrease")
        {
            #region Double potion
            if (isEnglish == true)
            {
                potionTooltipName.text = "Double Chance Potion";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% higher chance for ores and XP to give double";
            }

            if (isFrench == true)
            {
                potionTooltipName.text = "Potion Double Chance";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% de chance en plus pour que minerais et XP doublent";
            }

            if (isItalian == true)
            {
                potionTooltipName.text = "Pozione Doppia Probabilità";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% di probabilità in più che minerali e XP raddoppino";
            }

            if (isGerman == true)
            {
                potionTooltipName.text = "Doppel-Chance-Trank";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% höhere Chance, dass Erze und XP doppelt zählen";
            }

            if (isSpanish == true)
            {
                potionTooltipName.text = "Poción Doble Oportunidad";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% más de probabilidad de que minerales y XP se dupliquen";
            }

            if (isJapanese == true)
            {
                potionTooltipName.text = "ダブルチャンスポーション";
                potionTooltipDesc.text = $"鉱石とXPが2倍になる確率が{SetRockScreen.potionDoubleChance_increase}%増加";
            }

            if (isKorean == true)
            {
                potionTooltipName.text = "더블 찬스 포션";
                potionTooltipDesc.text = $"광석과 XP가 2배가 될 확률이 {SetRockScreen.potionDoubleChance_increase}% 증가";
            }

            if (isPolish == true)
            {
                potionTooltipName.text = "Mikstura Podwójnej Szansy";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% większa szansa na podwojenie rudy i XP";
            }

            if (isPortugese == true)
            {
                potionTooltipName.text = "Poção de Chance Dupla";
                potionTooltipDesc.text = $"{SetRockScreen.potionDoubleChance_increase}% mais chance de minérios e XP dobrarem";
            }

            if (isRussian == true)
            {
                potionTooltipName.text = "Зелье Двойного Шанса";
                potionTooltipDesc.text = $"Шанс, что руда и XP удвоятся, увеличен на {SetRockScreen.potionDoubleChance_increase}%";
            }

            if (isSimplefiedChinese == true)
            {
                potionTooltipName.text = "双倍机会药水";
                potionTooltipDesc.text = $"矿石和XP双倍的几率提高 {SetRockScreen.potionDoubleChance_increase}%";
            }
            #endregion
        }
    }
    #endregion

    #region Talent texts
    public string talentNameString, talentDescString;

    public TextMeshProUGUI talentName_tooltip, talentDesc_tooltip;

    public TextMeshProUGUI card_potionDrinker, card_potionDrinkerNAME;
    public TextMeshProUGUI card_potionChugger, card_potionChuggerNAME;
    public TextMeshProUGUI card_chests, card_chestsNAME;
    public TextMeshProUGUI card_goldenChests, card_goldenChestsNAME;
    public TextMeshProUGUI card_skilledMiners, card_skilledMinersNAME;
    public TextMeshProUGUI card_itsASign, card_itsASignNAME;
    public TextMeshProUGUI card_efficientBlacksmith, card_efficientBlacksmithNAME;
    public TextMeshProUGUI card_steamSale, card_steamSaleNAME;
    public TextMeshProUGUI card_inflationBurst, card_inflationBurstNAME;
    public TextMeshProUGUI card_itsHammerTime, card_itsHammerTimeNAME;
    public TextMeshProUGUI card_midasTouch, card_midasTouchNAME;
    public TextMeshProUGUI card_zeusWrath, card_zeusWrathNAME;
    public TextMeshProUGUI card_shapeShifter, card_shapeShifterNAME;
    public TextMeshProUGUI card_xMarksTheSpot, card_xMarksTheSpotNAME;
    public TextMeshProUGUI card_explorer, card_explorerNAME;
    public TextMeshProUGUI card_archaeologist, card_archaeologistNAME;
    public TextMeshProUGUI card_energyDrinker, card_energyDrinkerNAME;
    public TextMeshProUGUI card_springSeason, card_springSeasonNAME;
    public TextMeshProUGUI card_camper, card_camperNAME;
    public TextMeshProUGUI card_d100, card_d100NAME;

    public void TalentTexts(int talentNumber)
    {
        #region Potion Drinker
        if (talentNumber == 1)
        {
            if (isEnglish == true)
            {
                talentNameString = "Potion Drinker";
                talentDescString = "At the beginning of a mining session, you will drink 1 out of 4 possible potions. The potion contains a buff that lasts the entire mining session";
            }

            if (isFrench == true)
            {
                talentNameString = "Buveur de Potions";
                talentDescString = "Au début d'une session de minage, vous buvez 1 des 4 potions possibles. La potion donne un bonus qui dure toute la session";
            }

            if (isItalian == true)
            {
                talentNameString = "Bevitore di Pozioni";
                talentDescString = "All'inizio di una sessione di scavo, bevi 1 delle 4 pozioni disponibili. La pozione dà un potenziamento che dura per tutta la sessione";
            }

            if (isGerman == true)
            {
                talentNameString = "Tranktrinker";
                talentDescString = "Zu Beginn einer Abbau-Session trinkst du 1 von 4 möglichen Tränken. Der Trank verleiht einen Buff für die gesamte Session";
            }

            if (isSpanish == true)
            {
                talentNameString = "Bebedor de Pociones";
                talentDescString = "Al inicio de una sesión de minería, bebes 1 de las 4 pociones posibles. La poción otorga un beneficio durante toda la sesión";
            }

            if (isJapanese == true)
            {
                talentNameString = "ポーションドリンカー";
                talentDescString = "採掘セッションの開始時に、4種類のポーションのうち1つを飲みます。そのポーションの効果はセッション中ずっと続きます";
            }

            if (isKorean == true)
            {
                talentNameString = "포션 드링커";
                talentDescString = "채굴 세션 시작 시 4가지 포션 중 하나를 마십니다. 포션의 효과는 세션 내내 지속됩니다";
            }

            if (isPolish == true)
            {
                talentNameString = "Pijak Mikstur";
                talentDescString = "Na początku sesji wydobycia wypijasz 1 z 4 możliwych mikstur. Mikstura daje wzmocnienie na całą sesję";
            }

            if (isPortugese == true)
            {
                talentNameString = "Bebedor de Poções";
                talentDescString = "No início de uma sessão de mineração, você bebe 1 de 4 poções possíveis. A poção concede um bônus que dura toda a sessão";
            }

            if (isRussian == true)
            {
                talentNameString = "Пьющий Зелья";
                talentDescString = "В начале сессии добычи вы выпиваете 1 из 4 возможных зелий. Зелье даёт бафф на всю сессию";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "药水饮用者";
                talentDescString = "在采矿开始时，你会喝下 4 种可能药水中的一种，药水效果会持续整个采矿阶段";
            }

            card_potionDrinkerNAME.text = talentNameString;
            card_potionDrinker.text = talentDescString;
        }
        #endregion

        #region Potion Chugger
        if (talentNumber == 2)
        {
            if (isEnglish == true)
            {
                talentNameString = "Potion Chugger";
                talentDescString = "At the beginning of a mining session, you will drink all 4 potions!";
            }

            if (isFrench == true)
            {
                talentNameString = "Buveur Frénétique";
                talentDescString = "Au début d'une session de minage, vous buvez les 4 potions !";
            }

            if (isItalian == true)
            {
                talentNameString = "Bevitore Vorace";
                talentDescString = "All'inizio di una sessione di scavo, bevi tutte e 4 le pozioni!";
            }

            if (isGerman == true)
            {
                talentNameString = "Trank-Schlucker";
                talentDescString = "Zu Beginn einer Abbau-Session trinkst du alle 4 Tränke!";
            }

            if (isSpanish == true)
            {
                talentNameString = "Beber Pociones";
                talentDescString = "Al inicio de una sesión de minería, bebes las 4 pociones!";
            }

            if (isJapanese == true)
            {
                talentNameString = "ポーションガブ飲み";
                talentDescString = "採掘セッション開始時に4種類すべてのポーションを飲みます！";
            }

            if (isKorean == true)
            {
                talentNameString = "포션 폭음자";
                talentDescString = "채굴 세션 시작 시 4가지 포션을 전부 마십니다!";
            }

            if (isPolish == true)
            {
                talentNameString = "Łykacz Mikstur";
                talentDescString = "Na początku sesji wydobycia wypijasz wszystkie 4 mikstury!";
            }

            if (isPortugese == true)
            {
                talentNameString = "Beber Tudo";
                talentDescString = "No início de uma sessão de mineração, você bebe todas as 4 poções!";
            }

            if (isRussian == true)
            {
                talentNameString = "Зельевар-Глотатель";
                talentDescString = "В начале сессии добычи вы выпиваете все 4 зелья!";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "药水狂饮者";
                talentDescString = "在采矿开始时，你会喝下全部 4 种药水！";
            }

            card_potionChuggerNAME.text = talentNameString;
            card_potionChugger.text = talentDescString;
        }
        #endregion

        #region Chests
        if (talentNumber == 3)
        {
            if (isEnglish == true)
            {
                talentNameString = "Rock? No, it's a chest!";
                talentDescString = $"Every rock has a {LevelMechanics.rockSpawnChance}% chance to be replaced with a treasure chest that contains {LevelMechanics.totalChestMaterials} random ores.";
            }

            if (isFrench == true)
            {
                talentNameString = "Roche ? Non, un coffre !";
                talentDescString = $"Chaque roche a {LevelMechanics.rockSpawnChance}% de chance d'être remplacée par un coffre au trésor contenant {LevelMechanics.totalChestMaterials} minerais aléatoires.";
            }

            if (isItalian == true)
            {
                talentNameString = "Roccia? No, è un forziere!";
                talentDescString = $"Ogni roccia ha il {LevelMechanics.rockSpawnChance}% di probabilità di essere sostituita da un forziere contenente {LevelMechanics.totalChestMaterials} minerali casuali.";
            }

            if (isGerman == true)
            {
                talentNameString = "Stein? Nein, eine Truhe!";
                talentDescString = $"Jeder Stein hat eine Chance von {LevelMechanics.rockSpawnChance}%, durch eine Schatztruhe ersetzt zu werden, die {LevelMechanics.totalChestMaterials} zufällige Erze enthält.";
            }

            if (isSpanish == true)
            {
                talentNameString = "¿Roca? ¡No, es un cofre!";
                talentDescString = $"Cada roca tiene un {LevelMechanics.rockSpawnChance}% de probabilidad de ser reemplazada por un cofre del tesoro con {LevelMechanics.totalChestMaterials} minerales aleatorios.";
            }

            if (isJapanese == true)
            {
                talentNameString = "岩？いいえ、宝箱！";
                talentDescString = $"すべての岩には{LevelMechanics.rockSpawnChance}%の確率で{LevelMechanics.totalChestMaterials}個のランダムな鉱石が入った宝箱に置き換わるチャンスがある。";
            }

            if (isKorean == true)
            {
                talentNameString = "바위? 아니, 보물상자!";
                talentDescString = $"모든 바위는 {LevelMechanics.rockSpawnChance}% 확률로 {LevelMechanics.totalChestMaterials}개의 랜덤 광석이 들어있는 보물상자로 대체됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Skała? Nie, to skrzynia!";
                talentDescString = $"Każda skała ma {LevelMechanics.rockSpawnChance}% szansy na zamianę w skrzynię skarbów zawierającą {LevelMechanics.totalChestMaterials} losowych rud.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Rocha? Não, é um baú!";
                talentDescString = $"Cada rocha tem {LevelMechanics.rockSpawnChance}% de chance de ser substituída por um baú do tesouro com {LevelMechanics.totalChestMaterials} minérios aleatórios.";
            }

            if (isRussian == true)
            {
                talentNameString = "Камень? Нет, это сундук!";
                talentDescString = $"Каждый камень имеет {LevelMechanics.rockSpawnChance}% шанс быть заменённым сундуком с {LevelMechanics.totalChestMaterials} случайными рудами.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "岩石？不，是宝箱！";
                talentDescString = $"每块岩石有 {LevelMechanics.rockSpawnChance}% 几率变成一个宝箱，内含 {LevelMechanics.totalChestMaterials} 个随机矿石。";
            }

            card_chestsNAME.text = talentNameString;
            card_chests.text = talentDescString;
        }
        #endregion

        #region Golden Chests
        if (talentNumber == 4)
        {
            if (isEnglish == true)
            {
                talentNameString = "Gilded Chest";
                talentDescString = $"At the start of a mining session, there is a 50% chance to spawn a golden treasure chest that contains {LevelMechanics.totalGoldenChestMaterials} random ores.";
            }

            if (isFrench == true)
            {
                talentNameString = "Coffre Doré";
                talentDescString = $"Au début d'une session de minage, il y a 50% de chance de faire apparaître un coffre au trésor doré contenant {LevelMechanics.totalGoldenChestMaterials} minerais aléatoires.";
            }

            if (isItalian == true)
            {
                talentNameString = "Forziere Dorato";
                talentDescString = $"All'inizio di una sessione di scavo, c'è il 50% di probabilità di generare un forziere dorato contenente {LevelMechanics.totalGoldenChestMaterials} minerali casuali.";
            }

            if (isGerman == true)
            {
                talentNameString = "Vergoldete Truhe";
                talentDescString = $"Zu Beginn einer Abbau-Session gibt es eine 50% Chance, eine goldene Schatztruhe mit {LevelMechanics.totalGoldenChestMaterials} zufälligen Erzen zu spawnen.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Cofre Dorado";
                talentDescString = $"Al inicio de una sesión de minería, hay un 50% de probabilidad de aparecer un cofre del tesoro dorado con {LevelMechanics.totalGoldenChestMaterials} minerales aleatorios.";
            }

            if (isJapanese == true)
            {
                talentNameString = "黄金の宝箱";
                talentDescString = $"採掘セッション開始時に、{LevelMechanics.totalGoldenChestMaterials}個のランダム鉱石が入った黄金の宝箱が50%の確率で出現する。";
            }

            if (isKorean == true)
            {
                talentNameString = "황금 상자";
                talentDescString = $"채굴 세션 시작 시 50% 확률로 {LevelMechanics.totalGoldenChestMaterials}개의 랜덤 광석이 들어있는 황금 보물상자가 생성됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Złota Skrzynia";
                talentDescString = $"Na początku sesji wydobycia jest 50% szansy na pojawienie się złotej skrzyni z {LevelMechanics.totalGoldenChestMaterials} losowymi rudami.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Baú Dourado";
                talentDescString = $"No início de uma sessão de mineração, há 50% de chance de surgir um baú do tesouro dourado com {LevelMechanics.totalGoldenChestMaterials} minérios aleatórios.";
            }

            if (isRussian == true)
            {
                talentNameString = "Золотой Сундук";
                talentDescString = $"В начале сессии добычи есть 50% шанс появления золотого сундука с {LevelMechanics.totalGoldenChestMaterials} случайными рудами.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "镀金宝箱";
                talentDescString = $"采矿开始时，有 50% 几率生成一个包含 {LevelMechanics.totalGoldenChestMaterials} 个随机矿石的金色宝箱。";
            }

            card_goldenChestsNAME.text = talentNameString;
            card_goldenChests.text = talentDescString;
        }
        #endregion

        #region Skilled Miners
        if (talentNumber == 5)
        {
            if (isEnglish == true)
            {
                talentNameString = "Skilled Miners";
                talentDescString = $"The Mine has a {LevelMechanics.skilledMinersFastChance}% chance to mine twice as fast and a {LevelMechanics.skilledMinersDoubleChance}% chance to mine 2X bars.";
            }

            if (isFrench == true)
            {
                talentNameString = "Mineurs Experts";
                talentDescString = $"La Mine a {LevelMechanics.skilledMinersFastChance}% de chance de miner deux fois plus vite et {LevelMechanics.skilledMinersDoubleChance}% de chance de produire 2X lingots.";
            }

            if (isItalian == true)
            {
                talentNameString = "Minatori Esperti";
                talentDescString = $"La Miniera ha il {LevelMechanics.skilledMinersFastChance}% di probabilità di estrarre il doppio più veloce e il {LevelMechanics.skilledMinersDoubleChance}% di probabilità di produrre 2X barre.";
            }

            if (isGerman == true)
            {
                talentNameString = "Erfahrene Bergleute";
                talentDescString = $"Die Mine hat eine Chance von {LevelMechanics.skilledMinersFastChance}%, doppelt so schnell zu arbeiten, und {LevelMechanics.skilledMinersDoubleChance}% Chance, doppelt so viele Barren zu fördern.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Mineros Expertos";
                talentDescString = $"La Mina tiene un {LevelMechanics.skilledMinersFastChance}% de probabilidad de minar el doble de rápido y un {LevelMechanics.skilledMinersDoubleChance}% de probabilidad de producir 2X barras.";
            }

            if (isJapanese == true)
            {
                talentNameString = "熟練の鉱夫";
                talentDescString = $"ザ・マインは{LevelMechanics.skilledMinersFastChance}%の確率で採掘速度が2倍になり、{LevelMechanics.skilledMinersDoubleChance}%の確率で2倍のインゴットを採掘する。";
            }

            if (isKorean == true)
            {
                talentNameString = "숙련된 광부들";
                talentDescString = $"광산은 {LevelMechanics.skilledMinersFastChance}% 확률로 2배 속도로 채굴하며, {LevelMechanics.skilledMinersDoubleChance}% 확률로 2배 바를 생산합니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Wykwalifikowani Górnicy";
                talentDescString = $"Kopalnia ma {LevelMechanics.skilledMinersFastChance}% szansy na dwukrotnie szybsze wydobycie i {LevelMechanics.skilledMinersDoubleChance}% szansy na wydobycie 2X sztabek.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Mineiros Habilidosos";
                talentDescString = $"A Mina tem {LevelMechanics.skilledMinersFastChance}% de chance de minerar duas vezes mais rápido e {LevelMechanics.skilledMinersDoubleChance}% de chance de gerar 2X barras.";
            }

            if (isRussian == true)
            {
                talentNameString = "Опытные Шахтёры";
                talentDescString = $"Шахта имеет {LevelMechanics.skilledMinersFastChance}% шанс работать в 2 раза быстрее и {LevelMechanics.skilledMinersDoubleChance}% шанс добывать 2X слитков.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "熟练矿工";
                talentDescString = $"矿井有 {LevelMechanics.skilledMinersFastChance}% 几率采矿速度翻倍，且有 {LevelMechanics.skilledMinersDoubleChance}% 几率产出双倍锭。";
            }

            card_skilledMinersNAME.text = talentNameString;
            card_skilledMiners.text = talentDescString;
        }
        #endregion

        #region It's a Sign!
        if (talentNumber == 6)
        {
            if (isEnglish == true)
            {
                talentNameString = "It's a Sign!";
                talentDescString = $"A sign with a written buff will appear next to The Mine. The buff changes every 5 minutes.";
            }

            if (isFrench == true)
            {
                talentNameString = "C'est un Signe !";
                talentDescString = $"Un panneau avec un bonus écrit apparaît à côté de La Mine. Le bonus change toutes les 5 minutes.";
            }

            if (isItalian == true)
            {
                talentNameString = "È un Segno!";
                talentDescString = $"Un cartello con un potenziamento scritto appare accanto alla Miniera. Il bonus cambia ogni 5 minuti.";
            }

            if (isGerman == true)
            {
                talentNameString = "Ein Zeichen!";
                talentDescString = $"Ein Schild mit einem geschriebenen Buff erscheint neben der Mine. Der Buff wechselt alle 5 Minuten.";
            }

            if (isSpanish == true)
            {
                talentNameString = "¡Es una Señal!";
                talentDescString = $"Un cartel con un beneficio escrito aparecerá junto a La Mina. El beneficio cambia cada 5 minutos.";
            }

            if (isJapanese == true)
            {
                talentNameString = "これはサインだ！";
                talentDescString = $"ザ・マインの隣にバフが書かれた看板が出現します。バフは5分ごとに変わります。";
            }

            if (isKorean == true)
            {
                talentNameString = "이건 신호다!";
                talentDescString = $"광산 옆에 버프가 적힌 표지판이 나타납니다. 버프는 5분마다 변경됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "To Znak!";
                talentDescString = $"Obok Kopalni pojawi się znak z zapisanym buffem. Buff zmienia się co 5 minut.";
            }

            if (isPortugese == true)
            {
                talentNameString = "É um Sinal!";
                talentDescString = $"Um sinal com um buff escrito aparecerá ao lado da Mina. O buff muda a cada 5 minutos.";
            }

            if (isRussian == true)
            {
                talentNameString = "Это Знак!";
                talentDescString = $"Рядом с Шахтой появится табличка с баффом. Бафф меняется каждые 5 минут.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "这是一个标志！";
                talentDescString = $"矿井旁会出现一个写有增益的牌子，增益每 5 分钟更换一次。";
            }

            card_itsASignNAME.text = talentNameString;
            card_itsASign.text = talentDescString;
        }
        #endregion

        #region Efficient Blacksmith
        if (talentNumber == 7)
        {
            float blackSmithDecrease = 1 - LevelMechanics.blacksmithDecreaseDISPLAY;

            if (isEnglish == true)
            {
                talentNameString = "Efficient Blacksmith";
                talentDescString = $"Crafting a pickaxe takes {(blackSmithDecrease * 100).ToString("F0")}% less bars.";
            }

            if (isFrench == true)
            {
                talentNameString = "Forgeron Efficace";
                talentDescString = $"Fabriquer une pioche nécessite {(blackSmithDecrease * 100).ToString("F0")}% de barres en moins.";
            }

            if (isItalian == true)
            {
                talentNameString = "Fabbro Efficiente";
                talentDescString = $"Forgiare un piccone richiede il {(blackSmithDecrease * 100).ToString("F0")}% di barre in meno.";
            }

            if (isGerman == true)
            {
                talentNameString = "Effizienter Schmied";
                talentDescString = $"Das Schmieden einer Spitzhacke benötigt {(blackSmithDecrease * 100).ToString("F0")}% weniger Barren.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Herrero Eficiente";
                talentDescString = $"Fabricar un pico requiere {(blackSmithDecrease * 100).ToString("F0")}% menos barras.";
            }

            if (isJapanese == true)
            {
                talentNameString = "効率の良い鍛冶屋";
                talentDescString = $"ピッケルの作成に必要なインゴットが{(blackSmithDecrease * 100).ToString("F0")}%少なくなる。";
            }

            if (isKorean == true)
            {
                talentNameString = "효율적인 대장장이";
                talentDescString = $"곡괭이 제작 시 바 소모량이 {(blackSmithDecrease * 100).ToString("F0")}% 감소.";
            }

            if (isPolish == true)
            {
                talentNameString = "Wydajny Kowal";
                talentDescString = $"Tworzenie kilofa zużywa o {(blackSmithDecrease * 100).ToString("F0")}% mniej sztabek.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Ferreiro Eficiente";
                talentDescString = $"Forjar uma picareta usa {(blackSmithDecrease * 100).ToString("F0")}% menos barras.";
            }

            if (isRussian == true)
            {
                talentNameString = "Эффективный Кузнец";
                talentDescString = $"Создание кирки требует на {(blackSmithDecrease * 100).ToString("F0")}% меньше слитков.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "高效铁匠";
                talentDescString = $"打造镐子所需锭数减少 {(blackSmithDecrease * 100).ToString("F0")}% 。";
            }

            card_efficientBlacksmithNAME.text = talentNameString;
            card_efficientBlacksmith.text = talentDescString;
        }
        #endregion

        #region Steam Sale
        if (talentNumber == 8)
        {
            float discount = (1 - LevelMechanics.steamSaleDiscount) * 100;

            if(discount == 0) { discount = 7; }

            if (isEnglish == true)
            {
                talentNameString = "Steam Sale";
                talentDescString = $"Reduces the price of all skill tree upgrades by {discount.ToString("F0")}%.";
            }

            if (isFrench == true)
            {
                talentNameString = "Promo Steam";
                talentDescString = $"Réduit le prix de toutes les améliorations de l'arbre de compétences de {discount.ToString("F0")}%.";
            }

            if (isItalian == true)
            {
                talentNameString = "Sconto Steam";
                talentDescString = $"Riduce il costo di tutti i potenziamenti dell'albero abilità del {discount.ToString("F0")}%.";
            }

            if (isGerman == true)
            {
                talentNameString = "Steam-Sale";
                talentDescString = $"Reduziert die Kosten aller Skilltree-Upgrades um {discount.ToString("F0")}%.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Oferta Steam";
                talentDescString = $"Reduce el precio de todas las mejoras del árbol de habilidades en un {discount.ToString("F0")}%.";
            }

            if (isJapanese == true)
            {
                talentNameString = "スチームセール";
                talentDescString = $"スキルツリーのすべてのアップグレード価格を{discount.ToString("F0")}%割引する。";
            }

            if (isKorean == true)
            {
                talentNameString = "스팀 세일";
                talentDescString = $"스킬 트리 업그레이드 가격이 {discount.ToString("F0")}% 감소합니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Wyprzedaż Steam";
                talentDescString = $"Obniża cenę wszystkich ulepszeń w drzewku umiejętności o {discount.ToString("F0")}%.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Promoção Steam";
                talentDescString = $"Reduz o preço de todos os upgrades da árvore de habilidades em {discount.ToString("F0")}%.";
            }

            if (isRussian == true)
            {
                talentNameString = "Распродажа Steam";
                talentDescString = $"Снижает цену всех улучшений дерева навыков на {discount.ToString("F0")}%.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "Steam 大促销";
                talentDescString = $"所有技能树升级价格降低 {discount.ToString("F0")}%。";
            }

            card_steamSaleNAME.text = talentNameString;
            card_steamSale.text = talentDescString;
        }
        #endregion

        #region Inflation Burst
        if (talentNumber == 9)
        {
            if (isEnglish == true)
            {
                talentNameString = "Inflate Burst";
                talentDescString = $"Every second, the mining area has a {LevelMechanics.bigMiningAreaChance}% chance of increasing in size by {LevelMechanics.inflationBurstIncrease * 100}% for {LevelMechanics.bigMiningAreaTime} seconds.";
            }

            if (isFrench == true)
            {
                talentNameString = "Explosion d'Expansion";
                talentDescString = $"Chaque seconde, la zone de minage a {LevelMechanics.bigMiningAreaChance}% de chance de s'agrandir de {LevelMechanics.inflationBurstIncrease * 100}% pendant {LevelMechanics.bigMiningAreaTime} secondes.";
            }

            if (isItalian == true)
            {
                talentNameString = "Scoppio di Espansione";
                talentDescString = $"Ogni secondo, l'area di scavo ha il {LevelMechanics.bigMiningAreaChance}% di probabilità di aumentare di dimensione del {LevelMechanics.inflationBurstIncrease * 100}% per {LevelMechanics.bigMiningAreaTime} secondi.";
            }

            if (isGerman == true)
            {
                talentNameString = "Größen-Explosion";
                talentDescString = $"Jede Sekunde hat der Minenbereich eine Chance von {LevelMechanics.bigMiningAreaChance}%, sich um {LevelMechanics.inflationBurstIncrease * 100}% zu vergrößern für {LevelMechanics.bigMiningAreaTime} Sekunden.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Explosión de Expansión";
                talentDescString = $"Cada segundo, el área de minería tiene un {LevelMechanics.bigMiningAreaChance}% de probabilidad de aumentar su tamaño en un {LevelMechanics.inflationBurstIncrease * 100}% durante {LevelMechanics.bigMiningAreaTime} segundos.";
            }

            if (isJapanese == true)
            {
                talentNameString = "バースト拡張";
                talentDescString = $"毎秒、採掘エリアは{LevelMechanics.bigMiningAreaChance}%の確率で{LevelMechanics.inflationBurstIncrease * 100}%拡大し、{LevelMechanics.bigMiningAreaTime}秒間持続する。";
            }

            if (isKorean == true)
            {
                talentNameString = "확장 폭발";
                talentDescString = $"매초 광구는 {LevelMechanics.bigMiningAreaChance}% 확률로 {LevelMechanics.inflationBurstIncrease * 100}% 커지며 {LevelMechanics.bigMiningAreaTime}초 동안 유지됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Impuls Rozszerzenia";
                talentDescString = $"Co sekundę obszar wydobycia ma {LevelMechanics.bigMiningAreaChance}% szansy na powiększenie się o {LevelMechanics.inflationBurstIncrease * 100}% na {LevelMechanics.bigMiningAreaTime} sekund.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Explosão de Expansão";
                talentDescString = $"A cada segundo, a área de mineração tem {LevelMechanics.bigMiningAreaChance}% de chance de aumentar {LevelMechanics.inflationBurstIncrease * 100}% de tamanho por {LevelMechanics.bigMiningAreaTime} segundos.";
            }

            if (isRussian == true)
            {
                talentNameString = "Взрыв Расширения";
                talentDescString = $"Каждую секунду зона добычи имеет {LevelMechanics.bigMiningAreaChance}% шанс увеличиться на {LevelMechanics.inflationBurstIncrease * 100}% на {LevelMechanics.bigMiningAreaTime} секунд.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "膨胀爆发";
                talentDescString = $"每秒采矿区域有 {LevelMechanics.bigMiningAreaChance}% 概率增大 {LevelMechanics.inflationBurstIncrease * 100}% ，持续 {LevelMechanics.bigMiningAreaTime} 秒。";
            }

            card_inflationBurstNAME.text = talentNameString;
            card_inflationBurst.text = talentDescString;
        }
        #endregion

        #region It's Hammer Time!
        if (talentNumber == 10)
        {
            if (isEnglish == true)
            {
                talentNameString = "It's Hammer Time!";
                talentDescString = $"Every pickaxe has a {LevelMechanics.hammerChance}% chance to turn into a hammer. Rocks hit with the hammer will be insta mined and the mined ores will be worth double.";
            }

            if (isFrench == true)
            {
                talentNameString = "C'est l'Heure du Marteau !";
                talentDescString = $"Chaque pioche a {LevelMechanics.hammerChance}% de chance de se transformer en marteau. Les roches frappées avec le marteau seront instantanément minées et vaudront le double.";
            }

            if (isItalian == true)
            {
                talentNameString = "È Tempo di Martello!";
                talentDescString = $"Ogni piccone ha il {LevelMechanics.hammerChance}% di probabilità di trasformarsi in un martello. Le rocce colpite con il martello saranno scavate istantaneamente e i minerali varranno il doppio.";
            }

            if (isGerman == true)
            {
                talentNameString = "Hammerzeit!";
                talentDescString = $"Jede Spitzhacke hat eine Chance von {LevelMechanics.hammerChance}%, sich in einen Hammer zu verwandeln. Steine, die mit dem Hammer getroffen werden, werden sofort abgebaut und sind doppelt so viel wert.";
            }

            if (isSpanish == true)
            {
                talentNameString = "¡Hora del Martillo!";
                talentDescString = $"Cada pico tiene un {LevelMechanics.hammerChance}% de probabilidad de convertirse en martillo. Las rocas golpeadas con el martillo se minarán al instante y valdrán el doble.";
            }

            if (isJapanese == true)
            {
                talentNameString = "ハンマータイム！";
                talentDescString = $"すべてのピッケルは{LevelMechanics.hammerChance}%の確率でハンマーに変化する。ハンマーで叩かれた岩は即座に採掘され、鉱石の価値は2倍になる。";
            }

            if (isKorean == true)
            {
                talentNameString = "망치 타임!";
                talentDescString = $"모든 곡괭이는 {LevelMechanics.hammerChance}% 확률로 망치로 변합니다. 망치로 맞은 바위는 즉시 채굴되며, 채굴된 광석은 2배 가치가 됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Czas na Młot!";
                talentDescString = $"Każdy kilof ma {LevelMechanics.hammerChance}% szansy na zamianę w młot. Skały uderzone młotem są natychmiast wydobywane, a rudy warte są dwa razy więcej.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Hora do Martelo!";
                talentDescString = $"Cada picareta tem {LevelMechanics.hammerChance}% de chance de virar um martelo. Rochas atingidas com o martelo serão mineradas instantaneamente e os minérios valerão o dobro.";
            }

            if (isRussian == true)
            {
                talentNameString = "Время Молота!";
                talentDescString = $"Каждая кирка имеет {LevelMechanics.hammerChance}% шанс превратиться в молот. Камни, ударенные молотом, будут мгновенно добыты, а руды будут стоить вдвое дороже.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "锤子时间！";
                talentDescString = $"每把镐子有 {LevelMechanics.hammerChance}% 概率变成锤子，用锤子敲击的岩石会被瞬间开采，且矿石价值翻倍。";
            }

            card_itsHammerTimeNAME.text = talentNameString;
            card_itsHammerTime.text = talentDescString;
        }
        #endregion

        #region Midas Touch
        if (talentNumber == 11)
        {
            if (isEnglish == true)
            {
                talentNameString = "Midas Touch";
                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"At the start of every mining session, your cursor has a {LevelMechanics.midasTouchChance}% chance to turn gold. This causes each pickaxe hit to have a {LevelMechanics.midasTouchSpawnChance}% chance to spawn an ore.";
                }
                else
                {
                    talentDescString = $"At the start of every mining session, your mining area has a {LevelMechanics.midasTouchChance}% chance to turn gold. This causes each pickaxe hit to have a {LevelMechanics.midasTouchSpawnChance}% chance to spawn an ore.";
                }
            }

            if (isFrench == true)
            {
                talentNameString = "Toucher de Midas";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"Au début de chaque session de minage, votre curseur a {LevelMechanics.midasTouchChance}% de chance de devenir doré. Chaque coup de pioche aura alors {LevelMechanics.midasTouchSpawnChance}% de chance de générer un minerai.";
                }
                else
                {
                    talentDescString = $"Au début de chaque session de minage, votre zone de minage a {LevelMechanics.midasTouchChance}% de chance de devenir dorée. Cela fait que chaque coup de pioche a {LevelMechanics.midasTouchSpawnChance}% de chance de faire apparaître un minerai.";
                }
            }

            if (isItalian == true)
            {
                talentNameString = "Tocco di Mida";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"All'inizio di ogni sessione di scavo, il cursore ha il {LevelMechanics.midasTouchChance}% di probabilità di diventare dorato. Questo fa sì che ogni colpo di piccone abbia il {LevelMechanics.midasTouchSpawnChance}% di probabilità di generare un minerale.";
                }
                else
                {
                    talentDescString = $"All'inizio di ogni sessione di estrazione, la tua area di estrazione ha una probabilità del {LevelMechanics.midasTouchChance}% di diventare dorata. Questo fa sì che ogni colpo di piccone abbia una probabilità del {LevelMechanics.midasTouchSpawnChance}% di generare un minerale.";
                }

            }

            if (isGerman == true)
            {
                talentNameString = "Midas' Berührung";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"Zu Beginn jeder Abbau-Session hat dein Cursor eine Chance von {LevelMechanics.midasTouchChance}%, goldfarben zu werden. Dadurch hat jeder Spitzhackenschlag eine Chance von {LevelMechanics.midasTouchSpawnChance}%, Erz zu spawnen.";
                }
                else
                {
                    talentDescString = $"Zu Beginn jeder Minensitzung hat dein Abbaugebiet eine Chance von {LevelMechanics.midasTouchChance}%, golden zu werden. Dadurch hat jeder Spitzhackenhieb eine Chance von {LevelMechanics.midasTouchSpawnChance}%, ein Erz zu erzeugen.";
                }

            }

            if (isSpanish == true)
            {
                talentNameString = "Toque de Midas";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"Al inicio de cada sesión de minería, tu cursor tiene un {LevelMechanics.midasTouchChance}% de probabilidad de volverse dorado. Esto hace que cada golpe de pico tenga un {LevelMechanics.midasTouchSpawnChance}% de probabilidad de generar un mineral.";

                }
                else
                {
                    talentDescString = $"Al comienzo de cada sesión de minería, tu área de minería tiene un {LevelMechanics.midasTouchChance}% de probabilidad de volverse dorada. Esto hace que cada golpe de pico tenga un {LevelMechanics.midasTouchSpawnChance}% de probabilidad de generar un mineral.";
                }
            }

            if (isJapanese == true)
            {
                talentNameString = "ミダスタッチ";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"採掘セッション開始時に、カーソルが{LevelMechanics.midasTouchChance}%の確率で黄金になる。これにより、ピッケルのヒットごとに{LevelMechanics.midasTouchSpawnChance}%の確率で鉱石が生成される。";

                }
                else
                {
                    talentDescString = $"採掘セッションの開始時に、採掘エリアが{LevelMechanics.midasTouchChance}%の確率で黄金に変わります。これにより、ツルハシの一撃ごとに{LevelMechanics.midasTouchSpawnChance}%の確率で鉱石が出現します。";
                }
            }

            if (isKorean == true)
            {
                talentNameString = "마이더스 터치";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"채굴 세션 시작 시 커서가 {LevelMechanics.midasTouchChance}% 확률로 금색으로 변합니다. 그 상태에서는 곡괭이 타격마다 {LevelMechanics.midasTouchSpawnChance}% 확률로 광석이 생성됩니다.";
                }
                else
                {
                    talentDescString = $"각 채굴 세션이 시작될 때, 채굴 구역이 {LevelMechanics.midasTouchChance}% 확률로 황금으로 변합니다. 이렇게 되면 곡괭이 타격마다 {LevelMechanics.midasTouchSpawnChance}% 확률로 광석이 생성됩니다.";
                }
            }

            if (isPolish == true)
            {
                talentNameString = "Dotyk Midasa";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"Na początku każdej sesji wydobycia twój kursor ma {LevelMechanics.midasTouchChance}% szansy na zamianę w złoty. Każde uderzenie kilofa ma wtedy {LevelMechanics.midasTouchSpawnChance}% szansy na pojawienie się rudy.";
                }
                else
                {
                    talentDescString = $"Na początku każdej sesji wydobywczej twoja strefa wydobycia ma {LevelMechanics.midasTouchChance}% szans na zamianę w złotą. Powoduje to, że każde uderzenie kilofa ma {LevelMechanics.midasTouchSpawnChance}% szans na wydobycie rudy.";
                }

            }

            if (isPortugese == true)
            {
                talentNameString = "Toque de Midas";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"No início de cada sessão de mineração, seu cursor tem {LevelMechanics.midasTouchChance}% de chance de ficar dourado. Isso faz cada golpe de picareta ter {LevelMechanics.midasTouchSpawnChance}% de chance de gerar um minério.";
                }
                else
                {
                    talentDescString = $"No início de cada sessão de mineração, sua área de mineração tem {LevelMechanics.midasTouchChance}% de chance de se tornar dourada. Isso faz com que cada golpe da picareta tenha {LevelMechanics.midasTouchSpawnChance}% de chance de gerar um minério.";
                }
            }

            if (isRussian == true)
            {
                talentNameString = "Прикосновение Мидаса";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"В начале каждой сессии добычи твой курсор имеет {LevelMechanics.midasTouchChance}% шанс стать золотым. Это даёт каждому удару кирки {LevelMechanics.midasTouchSpawnChance}% шанс создать руду.";
                }
                else
                {
                    talentDescString = $"В начале каждой сессии добычи ваша зона добычи имеет {LevelMechanics.midasTouchChance}% шанс стать золотой. Это приводит к тому, что каждый удар киркой имеет {LevelMechanics.midasTouchSpawnChance}% шанс породить руду.";
                }
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "点金之触";

                if (MobileAndTesting.isMobile == false)
                {
                    talentDescString = $"每次采矿开始时，光标有 {LevelMechanics.midasTouchChance}% 概率变为金色。此时每次镐击有 {LevelMechanics.midasTouchSpawnChance}% 概率生成一块矿石。";
                }
                else
                {
                    talentDescString = $"在每次采矿会话开始时，你的采矿区域有 {LevelMechanics.midasTouchChance}% 的几率变成黄金。这会使每次镐子的攻击有 {LevelMechanics.midasTouchSpawnChance}% 的几率生成一块矿石。";
                }
            }

            card_midasTouchNAME.text = talentNameString;
            card_midasTouch.text = talentDescString;
        }
        #endregion

        #region Zeus Wrath
        if (talentNumber == 12)
        {
            if (isEnglish == true)
            {
                talentNameString = "Zeus Wrath";
                talentDescString = $"Every second, there is a {LevelMechanics.zeusChance}% chance to spawn {LevelMechanics.zeusLightningAmount} lightning beams that target random rocks.";
            }

            if (isFrench == true)
            {
                talentNameString = "Colère de Zeus";
                talentDescString = $"Chaque seconde, il y a {LevelMechanics.zeusChance}% de chance de faire apparaître {LevelMechanics.zeusLightningAmount} éclairs qui frappent des roches au hasard.";
            }

            if (isItalian == true)
            {
                talentNameString = "Ira di Zeus";
                talentDescString = $"Ogni secondo, c'è il {LevelMechanics.zeusChance}% di probabilità di generare {LevelMechanics.zeusLightningAmount} fulmini che colpiscono rocce casuali.";
            }

            if (isGerman == true)
            {
                talentNameString = "Zornsblitz des Zeus";
                talentDescString = $"Jede Sekunde besteht eine Chance von {LevelMechanics.zeusChance}%, {LevelMechanics.zeusLightningAmount} Blitze zu erzeugen, die zufällige Steine treffen.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Ira de Zeus";
                talentDescString = $"Cada segundo hay un {LevelMechanics.zeusChance}% de probabilidad de invocar {LevelMechanics.zeusLightningAmount} rayos que impactan rocas aleatorias.";
            }

            if (isJapanese == true)
            {
                talentNameString = "ゼウスの怒り";
                talentDescString = $"毎秒、{LevelMechanics.zeusChance}%の確率で{LevelMechanics.zeusLightningAmount}本の稲妻がランダムな岩を攻撃する。";
            }

            if (isKorean == true)
            {
                talentNameString = "제우스의 분노";
                talentDescString = $"매초 {LevelMechanics.zeusChance}% 확률로 무작위 바위를 목표로 {LevelMechanics.zeusLightningAmount}개의 번개가 떨어집니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Gniew Zeusa";
                talentDescString = $"Co sekundę jest {LevelMechanics.zeusChance}% szansy na przywołanie {LevelMechanics.zeusLightningAmount} piorunów, które uderzają w losowe skały.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Ira de Zeus";
                talentDescString = $"A cada segundo, há {LevelMechanics.zeusChance}% de chance de gerar {LevelMechanics.zeusLightningAmount} raios que atingem rochas aleatórias.";
            }

            if (isRussian == true)
            {
                talentNameString = "Гнев Зевса";
                talentDescString = $"Каждую секунду есть {LevelMechanics.zeusChance}% шанс вызвать {LevelMechanics.zeusLightningAmount} молний, которые поражают случайные камни.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "宙斯之怒";
                talentDescString = $"每秒有 {LevelMechanics.zeusChance}% 的几率召唤 {LevelMechanics.zeusLightningAmount} 道闪电击中随机岩石。";
            }

            card_zeusWrathNAME.text = talentNameString;
            card_zeusWrath.text = talentDescString;
        }
        #endregion

        #region Shape Shifter
        if (talentNumber == 13)
        {
            float shapeIncrease = LevelMechanics.shapeShifterSizeIncreaseDISPLAY * 100;

            if (isEnglish == true)
            {
                talentNameString = "Shape Shifter";
                talentDescString = $"Increase the mining area by {shapeIncrease.ToString("F0")}%. Every mining session, the mining area will either be a circle, square, or hexagon. The square and hexagon shapes cover more area than the circle.";
            }

            if (isFrench == true)
            {
                talentNameString = "Changeur de Forme";
                talentDescString = $"Augmente la zone de minage de {shapeIncrease.ToString("F0")}%. À chaque session, la zone de minage sera un cercle, un carré ou un hexagone.";
            }

            if (isItalian == true)
            {
                talentNameString = "Mutamento di Forma";
                talentDescString = $"Aumenta l'area di scavo del {shapeIncrease.ToString("F0")}%. Ad ogni sessione, l'area sarà un cerchio, un quadrato o un esagono.";
            }

            if (isGerman == true)
            {
                talentNameString = "Formwandler";
                talentDescString = $"Erhöht den Minenbereich um {shapeIncrease.ToString("F0")}%. Bei jeder Session ist die Form entweder ein Kreis, Quadrat oder Hexagon.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Cambiaformas";
                talentDescString = $"Aumenta el área de minería en un {shapeIncrease.ToString("F0")}%. En cada sesión, el área será un círculo, un cuadrado o un hexágono.";
            }

            if (isJapanese == true)
            {
                talentNameString = "シェイプシフター";
                talentDescString = $"採掘エリアを{shapeIncrease.ToString("F0")}%拡大する。毎回、エリアの形は円形、四角形、または六角形になる。";
            }

            if (isKorean == true)
            {
                talentNameString = "형태 변환자";
                talentDescString = $"채굴 영역 크기를 {shapeIncrease.ToString("F0")}% 증가시킵니다. 세션마다 채굴 영역은 원형, 사각형 또는 육각형이 됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Zmieniacz Kształtu";
                talentDescString = $"Zwiększa obszar wydobycia o {shapeIncrease.ToString("F0")}%. W każdej sesji obszar będzie miał kształt koła, kwadratu lub sześciokąta.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Muda-Forma";
                talentDescString = $"Aumenta a área de mineração em {shapeIncrease.ToString("F0")}%. A cada sessão, a área será um círculo, quadrado ou hexágono.";
            }

            if (isRussian == true)
            {
                talentNameString = "Меняющий Форму";
                talentDescString = $"Увеличивает область добычи на {shapeIncrease.ToString("F0")}%. В каждой сессии форма будет круг, квадрат или шестиугольник.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "形态变换者";
                talentDescString = $"采矿区域扩大 {shapeIncrease.ToString("F0")}%。每次采矿时，区域形状将在圆形、方形或六边形之间变化。";
            }

            card_shapeShifterNAME.text = talentNameString;
            card_shapeShifter.text = talentDescString;
        }
        #endregion

        #region X Marks The Spot
        if (talentNumber == 14)
        {
            if (isEnglish == true)
            {
                talentNameString = "X Marks The Spot";
                talentDescString = "Higher chance to find artifacts!";
            }

            if (isFrench == true)
            {
                talentNameString = "X Marque l'Endroit";
                talentDescString = "Plus de chance de trouver des artefacts !";
            }

            if (isItalian == true)
            {
                talentNameString = "X Segna il Punto";
                talentDescString = "Probabilità più alta di trovare artefatti!";
            }

            if (isGerman == true)
            {
                talentNameString = "X Markiert den Schatz";
                talentDescString = "Höhere Chance, Artefakte zu finden!";
            }

            if (isSpanish == true)
            {
                talentNameString = "X Marca el Lugar";
                talentDescString = "Mayor probabilidad de encontrar artefactos!";
            }

            if (isJapanese == true)
            {
                talentNameString = "Xが場所を示す";
                talentDescString = "アーティファクトが見つかる確率が上昇！";
            }

            if (isKorean == true)
            {
                talentNameString = "X 표시된 장소";
                talentDescString = "유물을 찾을 확률이 증가합니다!";
            }

            if (isPolish == true)
            {
                talentNameString = "X Oznacza Miejsce";
                talentDescString = "Większa szansa na znalezienie artefaktów!";
            }

            if (isPortugese == true)
            {
                talentNameString = "X Marca o Local";
                talentDescString = "Mais chance de encontrar artefatos!";
            }

            if (isRussian == true)
            {
                talentNameString = "X Отмечает Место";
                talentDescString = "Больше шанс найти артефакты!";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "X标记之处";
                talentDescString = "更高几率找到神器！";
            }

            card_xMarksTheSpotNAME.text = talentNameString;
            card_xMarksTheSpot.text = talentDescString;
        }
        #endregion

        #region Explorer
        if (talentNumber == 15)
        {
            if (isEnglish == true)
            {
                talentNameString = "Explorer";
                talentDescString = "Greater chance to find artifacts!";
            }

            if (isFrench == true)
            {
                talentNameString = "Explorateur";
                talentDescString = "Encore plus de chance de trouver des artefacts !";
            }

            if (isItalian == true)
            {
                talentNameString = "Esploratore";
                talentDescString = "Probabilità ancora maggiore di trovare artefatti!";
            }

            if (isGerman == true)
            {
                talentNameString = "Entdecker";
                talentDescString = "Noch höhere Chance, Artefakte zu finden!";
            }

            if (isSpanish == true)
            {
                talentNameString = "Explorador";
                talentDescString = "Mayor probabilidad de encontrar artefactos!";
            }

            if (isJapanese == true)
            {
                talentNameString = "エクスプローラー";
                talentDescString = "さらにアーティファクトが見つかる確率が上昇！";
            }

            if (isKorean == true)
            {
                talentNameString = "탐험가";
                talentDescString = "유물을 찾을 확률이 더욱 증가합니다!";
            }

            if (isPolish == true)
            {
                talentNameString = "Odkrywca";
                talentDescString = "Jeszcze większa szansa na znalezienie artefaktów!";
            }

            if (isPortugese == true)
            {
                talentNameString = "Explorador";
                talentDescString = "Ainda mais chance de encontrar artefatos!";
            }

            if (isRussian == true)
            {
                talentNameString = "Исследователь";
                talentDescString = "Ещё больше шанс найти артефакты!";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "探险家";
                talentDescString = "找到神器的几率更高！";
            }

            card_explorerNAME.text = talentNameString;
            card_explorer.text = talentDescString;
        }
        #endregion

        #region Archaeologist
        if (talentNumber == 16)
        {
            float archeologistIncrease = LevelMechanics.archeologistIncreaseDISPLAY * 100;

            if (isEnglish == true)
            {
                talentNameString = "Archaeologist";
                talentDescString = $"The stats from all artifacts are improved by {archeologistIncrease}%.";
            }

            if (isFrench == true)
            {
                talentNameString = "Archéologue";
                talentDescString = $"Les stats de tous les artefacts sont améliorées de {archeologistIncrease}%.";
            }

            if (isItalian == true)
            {
                talentNameString = "Archeologo";
                talentDescString = $"Le statistiche di tutti gli artefatti sono aumentate del {archeologistIncrease}%.";
            }

            if (isGerman == true)
            {
                talentNameString = "Archäologe";
                talentDescString = $"Die Werte aller Artefakte werden um {archeologistIncrease}% verbessert.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Arqueólogo";
                talentDescString = $"Las estadísticas de todos los artefactos se mejoran en un {archeologistIncrease}%.";
            }

            if (isJapanese == true)
            {
                talentNameString = "考古学者";
                talentDescString = $"すべてのアーティファクトのステータスが{archeologistIncrease}%向上する。";
            }

            if (isKorean == true)
            {
                talentNameString = "고고학자";
                talentDescString = $"모든 유물의 스탯이 {archeologistIncrease}% 향상됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Archeolog";
                talentDescString = $"Statystyki wszystkich artefaktów są zwiększone o {archeologistIncrease}%.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Arqueólogo";
                talentDescString = $"As estatísticas de todos os artefatos são melhoradas em {archeologistIncrease}%.";
            }

            if (isRussian == true)
            {
                talentNameString = "Археолог";
                talentDescString = $"Характеристики всех артефактов улучшаются на {archeologistIncrease}%.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "考古学家";
                talentDescString = $"所有神器属性提高 {archeologistIncrease}%。";
            }

            card_archaeologistNAME.text = talentNameString;
            card_archaeologist.text = talentDescString;
        }
        #endregion

        #region Energy Drinker
        if (talentNumber == 17)
        {
            if (isEnglish == true)
            {
                talentNameString = "Energy Drinker";
                talentDescString = $"Every second, you have a {LevelMechanics.energiDrinkChance}% chance to drink an energy drink, which doubles your mining speed for {LevelMechanics.energiDrinkTime} seconds.";
            }

            if (isFrench == true)
            {
                talentNameString = "Buveur d'Énergie";
                talentDescString = $"Chaque seconde, vous avez {LevelMechanics.energiDrinkChance}% de chance de boire une boisson énergétique, doublant votre vitesse de minage pendant {LevelMechanics.energiDrinkTime} secondes.";
            }

            if (isItalian == true)
            {
                talentNameString = "Bevitore di Energia";
                talentDescString = $"Ogni secondo hai il {LevelMechanics.energiDrinkChance}% di probabilità di bere una bevanda energetica che raddoppia la tua velocità di scavo per {LevelMechanics.energiDrinkTime} secondi.";
            }

            if (isGerman == true)
            {
                talentNameString = "Energie-Trinker";
                talentDescString = $"Jede Sekunde hast du eine Chance von {LevelMechanics.energiDrinkChance}%, einen Energydrink zu trinken, der deine Abbaugeschwindigkeit für {LevelMechanics.energiDrinkTime} Sekunden verdoppelt.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Bebedor de Energía";
                talentDescString = $"Cada segundo tienes un {LevelMechanics.energiDrinkChance}% de probabilidad de beber una bebida energética, duplicando tu velocidad de minería durante {LevelMechanics.energiDrinkTime} segundos.";
            }

            if (isJapanese == true)
            {
                talentNameString = "エナジードリンカー";
                talentDescString = $"毎秒、{LevelMechanics.energiDrinkChance}%の確率でエナジードリンクを飲み、{LevelMechanics.energiDrinkTime}秒間採掘速度が2倍になる。";
            }

            if (isKorean == true)
            {
                talentNameString = "에너지 드링커";
                talentDescString = $"매초 {LevelMechanics.energiDrinkChance}% 확률로 에너지 드링크를 마셔서 {LevelMechanics.energiDrinkTime}초 동안 채굴 속도가 2배로 증가합니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Pijak Energii";
                talentDescString = $"Co sekundę masz {LevelMechanics.energiDrinkChance}% szansy na wypicie napoju energetycznego, co podwaja prędkość wydobycia na {LevelMechanics.energiDrinkTime} sekund.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Bebedor de Energia";
                talentDescString = $"A cada segundo, você tem {LevelMechanics.energiDrinkChance}% de chance de beber um energético que dobra sua velocidade de mineração por {LevelMechanics.energiDrinkTime} segundos.";
            }

            if (isRussian == true)
            {
                talentNameString = "Пьющий Энергетик";
                talentDescString = $"Каждую секунду у вас есть {LevelMechanics.energiDrinkChance}% шанс выпить энергетик, который удвоит скорость добычи на {LevelMechanics.energiDrinkTime} секунд.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "能量饮料狂人";
                talentDescString = $"每秒有 {LevelMechanics.energiDrinkChance}% 概率喝下能量饮料，采矿速度翻倍，持续 {LevelMechanics.energiDrinkTime} 秒。";
            }

            card_energyDrinkerNAME.text = talentNameString;
            card_energyDrinker.text = talentDescString;
        }
        #endregion

        #region Spring Season
        if (talentNumber == 18)
        {
            float flowerIncrease = LevelMechanics.flowerIncrease * 100;

            if (isEnglish == true)
            {
                talentNameString = "Spring Season";
                talentDescString = $"At the start of a mining session, 2–17 flowers will appear. Each flower provides a {flowerIncrease.ToString("F1")}% XP increase.";
            }

            if (isFrench == true)
            {
                talentNameString = "Saison du Printemps";
                talentDescString = $"Au début d'une session de minage, 2 à 17 fleurs apparaissent. Chaque fleur augmente l'XP de {flowerIncrease.ToString("F1")}% .";
            }

            if (isItalian == true)
            {
                talentNameString = "Stagione di Primavera";
                talentDescString = $"All'inizio di una sessione di scavo, appariranno da 2 a 17 fiori. Ogni fiore fornisce un aumento XP del {flowerIncrease.ToString("F1")}% .";
            }

            if (isGerman == true)
            {
                talentNameString = "Frühlingssaison";
                talentDescString = $"Zu Beginn einer Abbau-Session erscheinen 2–17 Blumen. Jede Blume erhöht die XP um {flowerIncrease.ToString("F1")}% .";
            }

            if (isSpanish == true)
            {
                talentNameString = "Temporada de Primavera";
                talentDescString = $"Al inicio de una sesión de minería, aparecerán de 2 a 17 flores. Cada flor otorga un {flowerIncrease.ToString("F1")}% más de XP.";
            }

            if (isJapanese == true)
            {
                talentNameString = "春の季節";
                talentDescString = $"採掘セッション開始時に2～17本の花が出現する。花1本ごとにXPが{flowerIncrease.ToString("F1")}%増加する。";
            }

            if (isKorean == true)
            {
                talentNameString = "봄 시즌";
                talentDescString = $"채굴 세션 시작 시 2~17개의 꽃이 나타납니다. 꽃 하나마다 XP가 {flowerIncrease.ToString("F1")}% 증가합니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Sezon Wiosenny";
                talentDescString = $"Na początku sesji wydobycia pojawi się od 2 do 17 kwiatów. Każdy kwiat zwiększa XP o {flowerIncrease.ToString("F1")}% .";
            }

            if (isPortugese == true)
            {
                talentNameString = "Estação da Primavera";
                talentDescString = $"No início de uma sessão de mineração, aparecerão de 2 a 17 flores. Cada flor aumenta o XP em {flowerIncrease.ToString("F1")}% .";
            }

            if (isRussian == true)
            {
                talentNameString = "Весенний Сезон";
                talentDescString = $"В начале сессии добычи появляется от 2 до 17 цветов. Каждый цветок увеличивает XP на {flowerIncrease.ToString("F1")}% .";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "春季";
                talentDescString = $"采矿开始时会出现 2–17 朵花。每朵花提供 {flowerIncrease.ToString("F1")}% 的 XP 加成。";
            }

            card_springSeasonNAME.text = talentNameString;
            card_springSeason.text = talentDescString;
        }
        #endregion

        #region Camper
        if (talentNumber == 19)
        {
            if (isEnglish == true)
            {
                talentNameString = "Camper";
                talentDescString = "At the start of a mining session, a campfire will spawn. The fire insta mines rocks.";
            }

            if (isFrench == true)
            {
                talentNameString = "Campeur";
                talentDescString = "Au début d'une session de minage, un feu de camp apparaît. Le feu mine instantanément les roches.";
            }

            if (isItalian == true)
            {
                talentNameString = "Campeggiatore";
                talentDescString = "All'inizio di una sessione di scavo, compare un falò. Il fuoco estrae istantaneamente le rocce.";
            }

            if (isGerman == true)
            {
                talentNameString = "Camper";
                talentDescString = "Zu Beginn einer Abbau-Session erscheint ein Lagerfeuer. Das Feuer baut Steine sofort ab.";
            }

            if (isSpanish == true)
            {
                talentNameString = "Campista";
                talentDescString = "Al inicio de una sesión de minería, aparece una fogata. El fuego mina rocas al instante.";
            }

            if (isJapanese == true)
            {
                talentNameString = "キャンパー";
                talentDescString = "採掘セッション開始時に焚き火が出現する。火は岩を即座に採掘する。";
            }

            if (isKorean == true)
            {
                talentNameString = "캠퍼";
                talentDescString = "채굴 세션 시작 시 모닥불이 생성됩니다. 불은 바위를 즉시 채굴합니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "Obozowicz";
                talentDescString = "Na początku sesji wydobycia pojawi się ognisko. Ogień natychmiast wydobywa skały.";
            }

            if (isPortugese == true)
            {
                talentNameString = "Campista";
                talentDescString = "No início de uma sessão de mineração, surge uma fogueira. O fogo minera rochas instantaneamente.";
            }

            if (isRussian == true)
            {
                talentNameString = "Кемпер";
                talentDescString = "В начале сессии добычи появляется костёр. Огонь мгновенно добывает камни.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "露营者";
                talentDescString = "采矿开始时会出现一个篝火。火焰会瞬间开采岩石。";
            }

            card_camperNAME.text = talentNameString;
            card_camper.text = talentDescString;
        }
        #endregion

        #region D100
        if (talentNumber == 20)
        {
            if (isEnglish == true)
            {
                talentNameString = "D100";
                talentDescString = "At the end of a mining session, a D100 will roll and if it hits 1, 10 or 100, all ores mined during that session are multiplied by 5X";
            }

            if (isFrench == true)
            {
                talentNameString = "D100";
                talentDescString = "À la fin d'une session de minage, un D100 sera lancé. Si le résultat est 1, 10 ou 100, tous les minerais extraits pendant cette session seront multipliés par 5.";
            }

            if (isItalian == true)
            {
                talentNameString = "D100";
                talentDescString = "Alla fine di una sessione di miniera, verrà lanciato un D100 e se esce 1, 10 o 100, tutti i minerali estratti durante quella sessione saranno moltiplicati per 5.";
            }

            if (isGerman == true)
            {
                talentNameString = "D100";
                talentDescString = "Am Ende einer Minensitzung wird ein D100 geworfen. Bei einem Wurf von 1, 10 oder 100 werden alle in dieser Sitzung abgebauten Erze mit 5X multipliziert.";
            }

            if (isSpanish == true)
            {
                talentNameString = "D100";
                talentDescString = "Al final de una sesión de minería, se lanzará un D100 y si sale 1, 10 o 100, todos los minerales extraídos en esa sesión se multiplicarán por 5.";
            }

            if (isJapanese == true)
            {
                talentNameString = "D100";
                talentDescString = "採掘セッション終了時にD100が振られ、1、10、または100が出た場合、そのセッション中に採掘したすべての鉱石が5倍になります。";
            }

            if (isKorean == true)
            {
                talentNameString = "D100";
                talentDescString = "채굴 세션이 끝날 때 D100을 굴리고, 1, 10 또는 100이 나오면 그 세션 동안 채굴한 모든 광물이 5배가 됩니다.";
            }

            if (isPolish == true)
            {
                talentNameString = "D100";
                talentDescString = "Na koniec sesji wydobywczej rzucony zostanie D100. Jeśli wypadnie 1, 10 lub 100, wszystkie rudy wydobyte w tej sesji zostaną pomnożone razy 5.";
            }

            if (isPortugese == true)
            {
                talentNameString = "D100";
                talentDescString = "No final de uma sessão de mineração, um D100 será lançado e, se cair 1, 10 ou 100, todos os minérios extraídos nessa sessão serão multiplicados por 5.";
            }

            if (isRussian == true)
            {
                talentNameString = "D100";
                talentDescString = "В конце сеанса добычи бросается D100. Если выпадает 1, 10 или 100, все добытые в этом сеансе руды умножаются на 5.";
            }

            if (isSimplefiedChinese == true)
            {
                talentNameString = "D100";
                talentDescString = "在采矿会话结束时，掷一个D100，如果掷出1、10或100，该会话中获得的所有矿石将乘以5倍。";
            }

            card_d100NAME.text = talentNameString;
            card_d100.text = talentDescString;
        }
        #endregion

        talentName_tooltip.text = talentNameString;
        talentDesc_tooltip.text = talentDescString;
    }
    #endregion

    #region Mine upgrades
    public TextMeshProUGUI timeToMine, timeToMineUpgraded;
    public TextMeshProUGUI materialsMined, materialsMinedUpgraded;

    public void TheMineTexts(bool isMineSpeed)
    {
        float miningTime = TheMine.miningTime;
        float miningTimeDecrease = TheMine.miningTime / 18;
        float miningTimeUpgraded = TheMine.miningTime - miningTimeDecrease;

        int mined = TheMine.barsMined;
        int minedUpgraded = TheMine.barsMined + TheMine.bersMinedIncrease;

        if (isMineSpeed)
        {
            #region Texts
            if (isEnglish == true)
            {
                timeToMine.text = $"Mining time: {miningTime.ToString("F2")} sec";
                timeToMineUpgraded.text = $"Upgraded: {miningTimeUpgraded.ToString("F2")} sec";
            }

            if (isFrench == true)
            {
                timeToMine.text = $"Temps de minage : {miningTime.ToString("F2")} sec";
                timeToMineUpgraded.text = $"Amélioré : {miningTimeUpgraded.ToString("F2")} sec";
            }

            if (isItalian == true)
            {
                timeToMine.text = $"Tempo di scavo: {miningTime.ToString("F2")} sec";
                timeToMineUpgraded.text = $"Potenz.: {miningTimeUpgraded.ToString("F2")} sec";
            }

            if (isGerman == true)
            {
                timeToMine.text = $"Abbauzeit: {miningTime.ToString("F2")} Sek.";
                timeToMineUpgraded.text = $"Verbessert: {miningTimeUpgraded.ToString("F2")} Sek.";
            }

            if (isSpanish == true)
            {
                timeToMine.text = $"Tiempo de minería: {miningTime.ToString("F2")} seg";
                timeToMineUpgraded.text = $"Mejorado: {miningTimeUpgraded.ToString("F2")} seg";
            }

            if (isJapanese == true)
            {
                timeToMine.text = $"採掘時間: {miningTime.ToString("F2")}秒";
                timeToMineUpgraded.text = $"アップグレード: {miningTimeUpgraded.ToString("F2")}秒";
            }

            if (isKorean == true)
            {
                timeToMine.text = $"채굴 시간: {miningTime.ToString("F2")}초";
                timeToMineUpgraded.text = $"업그레이드됨: {miningTimeUpgraded.ToString("F2")}초";
            }

            if (isPolish == true)
            {
                timeToMine.text = $"Czas wydobycia: {miningTime.ToString("F2")} sek";
                timeToMineUpgraded.text = $"Ulepszone: {miningTimeUpgraded.ToString("F2")} sek";
            }

            if (isPortugese == true)
            {
                timeToMine.text = $"Tempo de mineração: {miningTime.ToString("F2")} seg";
                timeToMineUpgraded.text = $"Aprimorado: {miningTimeUpgraded.ToString("F2")} seg";
            }

            if (isRussian == true)
            {
                timeToMine.text = $"Время добычи: {miningTime.ToString("F2")} сек";
                timeToMineUpgraded.text = $"Улучшено: {miningTimeUpgraded.ToString("F2")} сек";
            }

            if (isSimplefiedChinese == true)
            {
                timeToMine.text = $"采矿时间：{miningTime.ToString("F2")} 秒";
                timeToMineUpgraded.text = $"升级后：{miningTimeUpgraded.ToString("F2")} 秒";
            }
            #endregion
        }
        else
        {
            #region Texts
            if (isEnglish == true)
            {
                materialsMined.text = $"Bars mined: {mined}";
                materialsMinedUpgraded.text = $"Upgraded: {minedUpgraded}";
            }

            if (isFrench == true)
            {
                materialsMined.text = $"Lingots minés : {mined}";
                materialsMinedUpgraded.text = $"Amélioré : {minedUpgraded}";
            }

            if (isItalian == true)
            {
                materialsMined.text = $"Lingotti estratti: {mined}";
                materialsMinedUpgraded.text = $"Potenziato: {minedUpgraded}";
            }

            if (isGerman == true)
            {
                materialsMined.text = $"Barren abgebaut: {mined}";
                materialsMinedUpgraded.text = $"Verbessert: {minedUpgraded}";
            }

            if (isSpanish == true)
            {
                materialsMined.text = $"Lingotes minados: {mined}";
                materialsMinedUpgraded.text = $"Mejorado: {minedUpgraded}";
            }

            if (isJapanese == true)
            {
                materialsMined.text = $"採掘バー数: {mined}";
                materialsMinedUpgraded.text = $"アップグレード: {minedUpgraded}";
            }

            if (isKorean == true)
            {
                materialsMined.text = $"채굴된 바: {mined}";
                materialsMinedUpgraded.text = $"업그레이드됨: {minedUpgraded}";
            }

            if (isPolish == true)
            {
                materialsMined.text = $"Wydobyte sztabki: {mined}";
                materialsMinedUpgraded.text = $"Ulepszone: {minedUpgraded}";
            }

            if (isPortugese == true)
            {
                materialsMined.text = $"Barras mineradas: {mined}";
                materialsMinedUpgraded.text = $"Aprimorado: {minedUpgraded}";
            }

            if (isRussian == true)
            {
                materialsMined.text = $"Добыто слитков: {mined}";
                materialsMinedUpgraded.text = $"Улучшено: {minedUpgraded}";
            }

            if (isSimplefiedChinese == true)
            {
                materialsMined.text = $"开采锭数：{mined}";
                materialsMinedUpgraded.text = $"升级后：{minedUpgraded}";
            }
            #endregion
        }
    }
    #endregion

    #region Talent 2 or less left
    public string talentCardsLeftString;
    public TextMeshProUGUI talentLeft1, talentLeft2, talentLeft3;

    public void TalentCardsLeftText()
    {
        if(LevelMechanics.cardsLeft == 2)
        {
            #region only 2 left
            if (isEnglish == true)
            {
                talentCardsLeftString = "There are only 2 more talent cards remaining!";
            }

            if (isFrench == true)
            {
                talentCardsLeftString = "Il ne reste plus que 2 cartes de talent !";
            }

            if (isItalian == true)
            {
                talentCardsLeftString = "Rimangono solo 2 carte talento!";
            }

            if (isGerman == true)
            {
                talentCardsLeftString = "Es sind nur noch 2 Talentkarten übrig!";
            }

            if (isSpanish == true)
            {
                talentCardsLeftString = "¡Solo quedan 2 cartas de talento!";
            }

            if (isJapanese == true)
            {
                talentCardsLeftString = "残りのタレントカードはあと2枚です！";
            }

            if (isKorean == true)
            {
                talentCardsLeftString = "남은 탈렌트 카드가 2장뿐입니다!";
            }

            if (isPolish == true)
            {
                talentCardsLeftString = "Pozostały tylko 2 karty talentów!";
            }

            if (isPortugese == true)
            {
                talentCardsLeftString = "Restam apenas 2 cartas de talento!";
            }

            if (isRussian == true)
            {
                talentCardsLeftString = "Осталось всего 2 карты талантов!";
            }

            if (isSimplefiedChinese == true)
            {
                talentCardsLeftString = "只剩下 2 张天赋卡了！";
            }
            #endregion
        }
        if (LevelMechanics.cardsLeft == 1)
        {
            #region only 1 left
            if (isEnglish == true)
            {
                talentCardsLeftString = "There is only 1 more talent card remaining!";
            }

            if (isFrench == true)
            {
                talentCardsLeftString = "Il ne reste plus qu'une seule carte de talent !";
            }

            if (isItalian == true)
            {
                talentCardsLeftString = "Rimane solo 1 carta talento!";
            }

            if (isGerman == true)
            {
                talentCardsLeftString = "Es ist nur noch 1 Talentkarte übrig!";
            }

            if (isSpanish == true)
            {
                talentCardsLeftString = "¡Solo queda 1 carta de talento!";
            }

            if (isJapanese == true)
            {
                talentCardsLeftString = "残りのタレントカードはあと1枚です！";
            }

            if (isKorean == true)
            {
                talentCardsLeftString = "남은 탈렌트 카드가 1장뿐입니다!";
            }

            if (isPolish == true)
            {
                talentCardsLeftString = "Pozostała tylko 1 karta talentów!";
            }

            if (isPortugese == true)
            {
                talentCardsLeftString = "Resta apenas 1 carta de talento!";
            }

            if (isRussian == true)
            {
                talentCardsLeftString = "Осталась всего 1 карта талантов!";
            }

            if (isSimplefiedChinese == true)
            {
                talentCardsLeftString = "只剩下 1 张天赋卡了！";
            }
            #endregion
        }
        if (LevelMechanics.cardsLeft == 0)
        {
            #region chosen all cards
            if (isEnglish == true)
            {
                talentCardsLeftString = "You have chosen all the talent cards, no more remain!";
            }

            if (isFrench == true)
            {
                talentCardsLeftString = "Vous avez choisi toutes les cartes de talent, il n'en reste plus !";
            }

            if (isItalian == true)
            {
                talentCardsLeftString = "Hai scelto tutte le carte talento, non ne restano più!";
            }

            if (isGerman == true)
            {
                talentCardsLeftString = "Du hast alle Talentkarten gewählt, es bleiben keine mehr übrig!";
            }

            if (isSpanish == true)
            {
                talentCardsLeftString = "¡Has elegido todas las cartas de talento, no queda ninguna más!";
            }

            if (isJapanese == true)
            {
                talentCardsLeftString = "すべてのタレントカードを選びました。もう残っていません！";
            }

            if (isKorean == true)
            {
                talentCardsLeftString = "모든 탈렌트 카드를 선택했습니다. 더 이상 남지 않았습니다!";
            }

            if (isPolish == true)
            {
                talentCardsLeftString = "Wybrałeś wszystkie karty talentów, żadnych już nie ma!";
            }

            if (isPortugese == true)
            {
                talentCardsLeftString = "Você escolheu todas as cartas de talento, não resta mais nenhuma!";
            }

            if (isRussian == true)
            {
                talentCardsLeftString = "Вы выбрали все карты талантов, больше не осталось!";
            }

            if (isSimplefiedChinese == true)
            {
                talentCardsLeftString = "你已选择了所有天赋卡，已无更多可选！";
            }
            #endregion
        }

        talentLeft1.text = talentCardsLeftString.ToString();
        talentLeft2.text = talentCardsLeftString.ToString();
        talentLeft3.text = talentCardsLeftString.ToString();
    }
    #endregion


    private void OnApplicationQuit()
    {
        //languageChosen = 1;
        //ChooseLanguage(false);
    }
}
