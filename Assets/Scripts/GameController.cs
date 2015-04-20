using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static Canvas userScreen;
    public static UserScreen screen;
    public static AlertBG alertBG;
    public static Light lightClock;
    public static Light lightClock2;
    public static Score scoredisplay;
    public static Anvil anvil;
    public static Clock clock;
    public static DoorHinge doorHinge;
    public static WardrobeDarkness wardrobeDarkness;
    public static Door door;

    public const int STATE_MAINMENU = 0;
    public const int STATE_PLAYING = 1;
    public const int STATE_TRANSITION = 2;
    public const int STATE_END = 3;
    public const int STATE_HELP = 4;

    public static int gameState = STATE_MAINMENU;
    public static float gameStateTimer = 0.0f;
    public static int scheduledState = -1;
    
    public static List<int> typingProgress = new List<int>();
    public static List<string> typingOptions = new List<string>();
    public static List<List<Image>> typingIndicators = new List<List<Image>>();
    
    public static Animator CameraAnimator;
    public static Animator ClockAnimator;
    
    public static int commandStage = 0;
    public static bool moreCommands = true;

    public static GameController gameController;

    public static int score = 0;

    public static float timePass = 0.0f;

	// Use this for initialization
	void Start () {
	    setState(STATE_MAINMENU);
        gameController = this;
        score = 0;
	}

    public static void registerCommand(string command, float x, float y){
        string commandSimple = command.Replace(" ", "");
        typingOptions.Add(commandSimple);
        typingProgress.Add(0);
        typingIndicators.Add(new List<Image>());
        for(int i = 0; i < command.Length; i++){
            string letter = ""+command[i];
            if(letter != " "){
                GameObject keyIndicator = Instantiate(Resources.Load("key", typeof(GameObject))) as GameObject;
                if(!userScreen){
                    userScreen = GameObject.Find("UserScreen").GetComponent<Canvas>();
                }
                keyIndicator.transform.SetParent(userScreen.transform);

                //Material newMat = Resources.Load("key"+letter, typeof(Material)) as Material;
                Image img = keyIndicator.GetComponent<Image>();
                img.sprite = Resources.Load<Sprite>("Keys/"+letter);
                img.rectTransform.anchoredPosition = new Vector2(0.5f, 1.0f);
                img.rectTransform.position = new Vector2(x + (i * 60), y);
                typingIndicators[typingIndicators.Count - 1].Add(img);
            }

        }
    }

    public static void addCommand(){
        for(int i = 0; i < typingIndicators.Count; i++){
            foreach(Image img in typingIndicators[i]){
                if(img && img.gameObject){
                    Key k = img.gameObject.GetComponent<Key>();
                    k.die = true;
                    Debug.Log("DIE1");
                }
            }
        }
        typingIndicators.Clear();
        typingProgress.Clear();
        typingOptions.Clear();
        List<string> cmds = new List<string>();
        int cmdNum = 0;
        string cmd = "";
        float cmdWidth = 0.0f;
        float x = 0.0f;
        float y = 0.0f;
        switch(commandStage){
            case 0:
                cmds.Add("bzzt");
                cmds.Add("ring ring");
                cmds.Add("woo");
                cmds.Add("alarm");
                cmds.Add("panic");
                cmds.Add("aaa");
                cmds.Add("good morning");
                cmds.Add("morning");
                cmds.Add("hi");
                cmds.Add("hello");
                cmds.Add("greetings");
                cmds.Add("wake up");
                cmds.Add("hey");
                cmds.Add("oi");
                cmds.Add("get up");
                cmds.Add("hurry up");
                cmds.Add("it is time");
                cmds.Add("it is morning");
                cmds.Add("time to get up");
                cmds.Add("oi oi oi");
                cmdNum = Random.Range(0, cmds.Count);
                cmd = cmds[cmdNum];
                
                cmdWidth = cmd.Length * 50 + (cmd.Length - 1) * 10;

                x = (Screen.width / 2) - (cmdWidth / 2);
                y = Random.Range(100, 0.9f * Screen.height);

                registerCommand(cmd, x, y);
            break;
            case 1:
                cmds.Add("waking");
                cmds.Add("bedroom");
                cmds.Add("bed");
                cmds.Add("pillow");
                cmds.Add("wardrobe");
                cmds.Add("sleepy");
                cmds.Add("waking up");
                cmds.Add("want sleep");
                cmds.Add("carpet");
                cmds.Add("floor");
                cmds.Add("flooring");
                cmds.Add("curtains");
                cmds.Add("drapes");
                cmds.Add("shutters");
                cmds.Add("window");
                cmds.Add("blinds");
                cmds.Add("wallpaper");
                cmds.Add("single bed");
                cmds.Add("double bed");
                cmds.Add("twin beds");
                cmds.Add("bunk bed");
                cmds.Add("four-poster");
                cmds.Add("sofa bed");
                cmds.Add("bedside table");
                cmds.Add("chest of drawers");
                cmds.Add("dressing table");
                cmds.Add("cupboard");
                cmds.Add("desk");
                cmds.Add("chair");
                cmds.Add("stool");
                cmds.Add("bedspread");
                cmds.Add("quilt");
                cmds.Add("duvet");
                cmds.Add("blanket");
                cmds.Add("sheet");
                cmds.Add("pillowcase");
                cmds.Add("pillow slip");
                cmds.Add("drawer");
                cmds.Add("pyjamas");
                cmds.Add("dressing gown");
                cmds.Add("slippers");
                cmds.Add("alarm clock");
                cmds.Add("radio alarm");
                cmds.Add("hi fi");
                cmds.Add("rug");
                cmds.Add("mirror");
                cmds.Add("coat hanger");
                cmds.Add("bookcase");
                cmds.Add("lamp");
                cmds.Add("bedside lamp");
                cmds.Add("desk lamp");
                cmds.Add("lampshade");
                cmds.Add("armchair");
                cmds.Add("shelves");
                cmdNum = Random.Range(0, cmds.Count);
                cmd = cmds[cmdNum];
                
                cmdWidth = cmd.Length * 50 + (cmd.Length - 1) * 10;

                x = (Screen.width / 2) - (cmdWidth / 2);
                y = Random.Range(100, 0.9f * Screen.height);

                registerCommand(cmd, x, y);


            break;
            case 2:
                cmds.Add("anorak");
                cmds.Add("apron");
                cmds.Add("baseball cap");
                cmds.Add("belt");
                cmds.Add("bikini");
                cmds.Add("blazer");
                cmds.Add("blouse");
                cmds.Add("boots");
                cmds.Add("bow tie");
                cmds.Add("boxer shorts");
                cmds.Add("boxers");
                cmds.Add("bra");
                cmds.Add("cardigen");
                cmds.Add("coat");
                cmds.Add("dinner jacket");
                cmds.Add("dress");
                cmds.Add("dressing gown");
                cmds.Add("gloves");
                cmds.Add("hat");
                cmds.Add("high heels");
                cmds.Add("jacket");
                cmds.Add("jeans");
                cmds.Add("jumper");
                cmds.Add("knickers");
                cmds.Add("leather jacket");
                cmds.Add("miniskirt");
                cmds.Add("nightie");
                cmds.Add("overalls");
                cmds.Add("pyjamas");
                cmds.Add("raincoat");
                cmds.Add("sandals");
                cmds.Add("scarf");
                cmds.Add("shirt");
                cmds.Add("shoelace");
                cmds.Add("shoes");
                cmds.Add("pair of shoes");
                cmds.Add("shorts");
                cmds.Add("skirt");
                cmds.Add("slippers");
                cmds.Add("socks");
                cmds.Add("stilettos");
                cmds.Add("stockings");
                cmds.Add("suit");
                cmds.Add("sweater");
                cmds.Add("swimming costume");
                cmds.Add("swimming trunks");
                cmds.Add("thong");
                cmds.Add("tie");
                cmds.Add("tights");
                cmds.Add("top");
                cmds.Add("tracksuit");
                cmds.Add("trainers");
                cmds.Add("trousers");
                cmds.Add("pair of trousers");
                cmds.Add("t shirt");
                cmds.Add("underpants");
                cmds.Add("underwear");
                cmds.Add("undies");
                cmds.Add("vest");
                cmds.Add("welingtons");
                cmds.Add("bracelet");
                cmds.Add("cufflinks");
                cmds.Add("comb");
                cmds.Add("earrings");
                cmds.Add("engagement ring");
                cmds.Add("glasses");
                cmds.Add("handbag");
                cmds.Add("handkershief");
                cmds.Add("hair tie");
                cmds.Add("hairbrush");
                cmds.Add("keys");
                cmds.Add("keyring");
                cmds.Add("lipstick");
                cmds.Add("makeup");
                cmds.Add("purse");
                cmds.Add("ring");
                cmds.Add("sunglasses");
                cmds.Add("walking stick");
                cmds.Add("wallet");
                cmds.Add("watch");
                cmds.Add("wedding ring");
                cmdNum = Random.Range(0, cmds.Count);
                cmd = cmds[cmdNum];
                
                cmdWidth = cmd.Length * 50 + (cmd.Length - 1) * 10;

                x = (Screen.width / 2) - (cmdWidth / 2);
                y = Random.Range(100, 0.9f * Screen.height);

                registerCommand(cmd, x, y);


            break;
        }
    }
	
    public void setState(int newState){
        gameState = newState;
        gameStateTimer = 0.0f;
        Debug.Log("state change = "+newState);
        clearScreen();
        switch(gameState){
            case STATE_MAINMENU:
                GameObject.Find("Instructions").GetComponent<Text>().enabled = true;
                typingOptions = new List<string>();
                typingProgress = new List<int>();
                typingIndicators.Clear();
                registerCommand("start game", 100, 260);
                registerCommand("help", 100, 200);
                registerCommand("exit", 100, 140);
            break;
            case STATE_HELP:
                GameObject.Find("Instructions").GetComponent<Text>().enabled = false;
                typingOptions = new List<string>();
                typingProgress = new List<int>();
                typingIndicators.Clear();
                registerCommand("just type the", 50, 440);
                registerCommand("text on screen", 50, 380);
                registerCommand("correct phrase", 50, 320);
                registerCommand("doubles score", 50, 260);
                registerCommand("mistakes remove", 50, 200);
                registerCommand("score", 50, 140);
                registerCommand("back", 50, 60);
            break;
        }
    }

    void handleGameState(){
        switch(gameState){
            case STATE_TRANSITION:
                if(gameStateTimer <= 1.0f){
                    foreach(Image i in userScreen.GetComponentsInChildren<Image>()){
                        Color c = i.color;
                        if(c.r > 0.9f && c.g > 0.9f && c.b < 0.9f){
                            c.a = Mathf.Min(1.0f, 2.0f - 2*gameStateTimer);
                        }else{
                            c.a = Mathf.Max(0.0f, 1.0f - (2*gameStateTimer));
                        }
                        i.color = c;
                    }
                }else{
                    foreach(Image i in userScreen.GetComponentsInChildren<Image>()){
                        Destroy(i.gameObject);
                    }
                    setState(scheduledState);
                }
            break;
            case STATE_MAINMENU:
                if(gameStateTimer <= 1.0f){
                    foreach(Image i in userScreen.GetComponentsInChildren<Image>()){
                        Color c = i.color;
                        c.a = gameStateTimer;
                        i.color = c;
                    }
                }else{
                    foreach(Image i in userScreen.GetComponentsInChildren<Image>()){
                        Color c = i.color;
                        c.a = 1.0f;
                        i.color = c;
                    }
                }


            break;
        }
    }

    void scheduleState(int newState){
        scheduledState = newState;
        setState(STATE_TRANSITION);
        GameObject.Find("Instructions").GetComponent<Text>().enabled = false;
    }

    public static void clearScreen(){
        for(int i = 0; i < typingIndicators.Count; i++){
            foreach(Image img in typingIndicators[i]){
                if(img.IsDestroyed()){
                    continue;
                }
                Key k = img.gameObject.GetComponent<Key>();
                k.die = true;
            }
        }
        typingOptions.Clear();
        typingProgress.Clear();
        typingIndicators.Clear();
    }

    void displayHelp(){

    }

    void performAction(string action){
        Debug.Log("action perform = "+action);
        switch(action){
            case "startgame":
                typingOptions.Clear();
                typingProgress.Clear();
                typingIndicators.Clear();
                scheduleState(STATE_PLAYING);
                CameraAnimator.SetInteger("CameraState", 1);
                ClockAnimator.SetInteger("ClockState", 1);
            break;
            case "playagain":
                Application.LoadLevel(0);
            break;
            case "help":
                setState(STATE_HELP);
            break;
            case "back":
                setState(STATE_MAINMENU);
            break;
            case "exit":
                Application.Quit();
            break;
            default:
                
                if(gameState == STATE_PLAYING){
                    for(int i = 0; i < typingIndicators.Count; i++){
                        foreach(Image img in typingIndicators[i]){
                            Key k = img.gameObject.GetComponent<Key>();
                            k.die = true;
                            score++;
                            screen.addScore("+ 1", img.rectTransform.position.x, img.rectTransform.position.y, new Color(0.0f, 0.5f, 0.0f));
                        }
                    }
                    typingOptions.Clear();
                    typingProgress.Clear();
                    typingIndicators.Clear();
                    if(moreCommands){
                        addCommand();
                    }
                }else{
                    for(int i = 0; i < typingProgress.Count; i++){
                        typingProgress[i] = 0;
                    }
                }
            break;
        };
    }

	// Update is called once per frame
	void Update () {
        if(!userScreen){
            userScreen = GameObject.Find("UserScreen").GetComponent<Canvas>();
        }

	    gameStateTimer += Time.deltaTime;
        handleGameState();
        timePass += Time.deltaTime;
        if(timePass > 4.0f){
            timePass = 0;
            if(commandStage == 1){
                addCommand();
            }
        }

        string[] keysToCheck = new string[]{"a","b","c","d","e","f","g","h","i",
            "j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
        foreach(string key in keysToCheck){
            if (Input.GetKeyDown(key)){
                for(int i = 0; i < typingOptions.Count; i++){
                    string typingOption = typingOptions[i];
                    int progress = typingProgress[i];
                    string nextChar = ""+typingOption[progress];
                    if(nextChar.ToLower() == key.ToLower()){
                        if(gameState == STATE_PLAYING){
                            score++;
                            screen.addScore("+ 1", typingIndicators[i][typingProgress[i]].rectTransform.position.x, typingIndicators[i][typingProgress[i]].rectTransform.position.y, Color.green);
                        }
                        Color c = typingIndicators[i][typingProgress[i]].color;
                        c.r = 0.5f;
                        c.b = 0.5f;
                        typingIndicators[i][typingProgress[i]].color = c;
                        typingProgress[i] += 1;
                        if(typingProgress[i] == typingOptions[i].Length){
                            string action = typingOptions[i];
                            foreach(Image img in typingIndicators[i]){
                                Color c2 = img.color;
                                c2.r = 1.0f;
                                c2.g = 1.0f;
                                c2.b = 0.7f;
                                img.color = c2;
                            }
                            performAction(action);
                        }
                    }else{
                        if(gameState == STATE_PLAYING){
                            if(progress > 0){
                                for(int j = 0; j < typingIndicators.Count; j++){
                                    foreach(Image img in typingIndicators[j]){
                                        Key k = img.gameObject.GetComponent<Key>();
                                        k.die = true;
                                        score--;
                                        screen.addScore("- 1", img.rectTransform.position.x, img.rectTransform.position.y, new Color(0.5f, 0.0f, 0.0f));
                                    }
                                }
                                Color c = typingIndicators[i][typingProgress[i]].color;
                                c.r = 1.0f;
                                c.b = 0.5f;
                                c.g = 0.5f;
                                typingIndicators[i][typingProgress[i]].color = c;
                                switch(commandStage){
                                    case 0:
                                    case 2:
                                        addCommand();
                                    break;
                                }
                            }
                        }else{
                            while(typingProgress[i] > 0){
                                typingProgress[i]--;
                                Color c = typingIndicators[i][typingProgress[i]].color;
                                c.r = 1.0f;
                                c.b = 1.0f;
                                typingIndicators[i][typingProgress[i]].color = c;
                            }
                        }
                    }
                }
            }
        }
	}
}
