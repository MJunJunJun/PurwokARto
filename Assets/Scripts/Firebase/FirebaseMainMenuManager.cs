using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using TMPro;
using System.Linq;

public class FirebaseMainMenuManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    //Login variables
    [Header("Login")]
    bool signedIn;

    [Header("Profil")]
    public TMP_Text usernameText;
    public TMP_Text levelText;
    public TMP_Text winText;
    public TMP_Text loseText;

    [Header("Setup Awal Monster")]
    public int urutanMonster;
    string elemen;

    [Header("Scoreboard")]
    public GameObject scoreElement;
    public Transform scoreboardContent;
    public LanguageManagerMainMenu managerBahasa;


    #region Setup Awal
    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
                

            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
        

    }



    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        

    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != User)
        {
            signedIn = User != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && User != null)
            {
                Debug.Log("Signed out " + User.UserId);
            }
            User = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + User.UserId);
                //GetValueGlobal();

              //  ButtonGetValueProfile();
            }

        }
    }

    #endregion


    public void Test()
    {
        StartCoroutine(TestGetData("halo"));
    }
    private IEnumerator TestGetData(string halo)
    {


        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.Log("FAILED REGISTER " + halo);
        }
        else if (DBTask.Result.Value == null)
        {
            Debug.Log("NULL VALUE");
        }
        else
        {
            Debug.Log("ISI");
        }
    }
    #region Profil
    public void ButtonGetValueProfile()
    {
        StartCoroutine(GetValueProfile());
    }

    private IEnumerator GetValueProfile()
    {
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            levelText.text = "0";
            winText.text = "0";
            loseText.text = "0";
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;
            usernameText.text = User.DisplayName;
            
            levelText.text = snapshot.Child("xp").Value.ToString();
            winText.text = snapshot.Child("kills").Value.ToString();
            loseText.text = snapshot.Child("deaths").Value.ToString();
            PlayerPrefs.SetString("levelxp", snapshot.Child("xp").Value.ToString());
            PlayerPrefs.SetString("menangwin", snapshot.Child("kills").Value.ToString());
            PlayerPrefs.SetString("kalahlose", snapshot.Child("deaths").Value.ToString());
            PlayerPrefs.SetString("urutanmonster", snapshot.Child("urutanmonster").Value.ToString());
            managerBahasa.GantiBahasa();
        }
    }


   


    #endregion






    #region scoreboard
    public void ScoreboardButton()
    {
        StartCoroutine(LoadScoreboardData());
    }

    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").OrderByChild("kills").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string username = childSnapshot.Child("username").Value.ToString();
                int kills = int.Parse(childSnapshot.Child("kills").Value.ToString());
                int deaths = int.Parse(childSnapshot.Child("deaths").Value.ToString());
                int xp = int.Parse(childSnapshot.Child("xp").Value.ToString());

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, kills, deaths, xp);
            }

            //Go to scoareboard screen
            //UIManager.instance.ScoreboardScreen();
        }
    }
    #endregion

    public void SignOutButton()
    {
        auth.SignOut();

    }

    #region monster
    public void SubmitPilihMonster()
    {
        
        if (urutanMonster == 1)
            elemen = "api";
        else if (urutanMonster == 2)
            elemen = "air";
        else if (urutanMonster == 3)
            elemen = "tanah";
        else if (urutanMonster == 4)
            elemen = "angin";
        else if (urutanMonster == 5)
            elemen = "cahaya";
        else if (urutanMonster == 6)
            elemen = "kegelapan";

        StartCoroutine(Monsters(elemen, 1));
        StartCoroutine(SetUpMonsterAwal(urutanMonster));
        Debug.Log(urutanMonster);
        UIManagerMainMenu.instance.MainMenuScreen();


    }
    private IEnumerator SetUpMonsterAwal(int urutan)
    {
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("urutanmonster").SetValueAsync(urutan);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
            PlayerPrefs.SetInt("cekmonster", 1);
            Debug.Log(PlayerPrefs.GetInt("cekmonster"));

            
        }
    }

    private IEnumerator Monsters(string elemen, int _level)
    {
        //Set the currently logged in user xp
        //var DBTask = DBreference.Child("users").Child(User.UserId).Child("xp").SetValueAsync(_xp);

        var DBTask = DBreference.Child("users").Child(User.UserId).Child("monsters").Child(elemen).SetValueAsync(_level);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Xp is now updated
        }
    }



    #endregion






}
