using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageManagerMainMenu : MonoBehaviour
{

    [Header("Pilih Character")]
    public TMP_Text text_PilihPenjaga;
    public TMP_Text textbutton_next;
    [Header("MainMenu")]
    public TMP_Text mainmenu_nama;
    public TMP_Text mainmenu_tagline;
    public TMP_Text mainmenu_quots;
    [Header("Koleksi")]
    public TMP_Text koleksi_textMenu;
    public TMP_Text koleksi_isidata;
    public GameObject[] Profile;
    public TMP_Text deskripsi;
    [Header("Leaderboard")]
    public TMP_Text header_Leaderboard;
    public TMP_Text menang_leaderboard;
    public TMP_Text kalah_leaderboard;
    public TMP_Text level_leaderboard;
    [Header("Profil")]
    public TMP_Text nama_Profil;
    public TMP_Text level_Profil;
    public TMP_Text menang_Profil;
    public TMP_Text kalah_Profil;

    //public FirebaseMainMenuManager firebaseManager;
    string nama;
    string quots;
    string urutanmonster;
    int pengubah;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //nama = firebaseManager.User.DisplayName;
        nama = PlayerPrefs.GetString("namalengkap");
        QuotsAPPs();
        GantiBahasa();
        urutanmonster = PlayerPrefs.GetString("urutanmonster");
        //Debug.Log("monster sekarang " + urutanmonster);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GantiBahasa()
    {
        int a = PlayerPrefs.GetInt("bahasa");

        if (a == 0)
        {
            //IND
            //pilih monster
            text_PilihPenjaga.text = "Pilih Penjaga";
            textbutton_next.text = "Selanjutnya";
            //mainmenu
            mainmenu_nama.text = "Hai " + nama;
            mainmenu_tagline.text = "Mari Berwisata bersama di <b>Purwokerto";
            mainmenu_quots.text = quots;
            koleksi_textMenu.text = "Nama <br>Level <br>Menang <br>Kalah";
            koleksi_isidata.text = PlayerPrefs.GetString("namalengkap")+"<br>"+ PlayerPrefs.GetString("levelxp") +"<br>" + PlayerPrefs.GetString("menangwin") + "<br>" + PlayerPrefs.GetString("kalahlose");

            //leaderboard
            header_Leaderboard.text = "Papan Peringkat";
            menang_leaderboard.text = "Menang";
            kalah_leaderboard.text = "Kalah";
            level_leaderboard.text = "Level";

            //Profil
            nama_Profil.text = "Nama";
            level_Profil.text = "Level";
            menang_Profil.text = "Menang";
            kalah_Profil.text = "Kalah";




        }
        else if (a == 1)
        {
            //ENG
            //pilih monster
            text_PilihPenjaga.text = "Choose Guard";
            textbutton_next.text = "Next";
            //mainmenu
            mainmenu_nama.text = "Hi " + nama;
            mainmenu_tagline.text = "Let's Travel together in <b>Purwokerto";
            mainmenu_quots.text = quots;
            koleksi_textMenu.text = "Name <br>Level <br>Win <br>Lose";
            koleksi_isidata.text = PlayerPrefs.GetString("namalengkap") + "<br>" + PlayerPrefs.GetString("levelxp") + "<br>" + PlayerPrefs.GetString("menangwin") + "<br>" + PlayerPrefs.GetString("kalahlose"); ;

            //leaderboard
            header_Leaderboard.text = "Leaderboard";
            menang_leaderboard.text = "win";
            kalah_leaderboard.text = "lose";
            level_leaderboard.text = "Level";

            //Profil
            nama_Profil.text = "Name";
            level_Profil.text = "Level";
            menang_Profil.text = "Win";
            kalah_Profil.text = "Lose";




        }
        UrutanMonstersField();


    }


    void QuotsAPPs()
    {
        int a=Random.RandomRange(1,11);

        if (PlayerPrefs.GetInt("bahasa") ==0)
        {
            if (a == 1)
            {
                quots = "Pekerjaan mengisi saku , dan Petualangan mengisi jiwamu";
            }
            else if (a == 2)
            {
                quots = "Setiap jalan keluar adalah jalan masuk di tempat lain";
            }
            else if (a == 3)
            {
                quots = "Hidup bergerak cukup cepat. Jika kamu tidak berhenti dan melihat-lihat sebentar, kamu bisa melewatkannya";
            }
            else if (a == 4)
            {
                quots = "Hal terindah di dunia, tentu saja, adalah dunia itu sendiri";
            }
            else if (a == 5)
            {
                quots = "Hidup adalah petualangan yang berani atau tidak sama sekali";
            }
            else if (a == 6)
            {
                quots = "kamu tidak harus kaya untuk bepergian dengan baik";
            }
            else if (a == 7)
            {
                quots = "Jika itu membuat kamu takut, mungkin itu merupakan hal yang baik untuk dicoba";
            }
            else if (a == 8)
            {
                quots = "Hidup ini singkat dan dunia ini luas";
            }
            else if (a == 9)
            {
                quots = "Kemana pun kamu pergi, lakukanlah dengan segenap hati";
            }
            else if (a == 10)
            {
                quots = "Setahun sekali, pergilah ke suatu tempat yang belum pernah kamu kunjungi sebelumnya";
            }
            else if (a == 11)
            {
                quots = "Hidup akan menjadi petualangan yang sangat besar";
            }
        }
        else
        {
            if (a == 1)
            {
                quots = "Jobs fill your pocket, Adventures fill your soul";
            }
            else if (a == 2)
            {
                quots = "Every exit is an entry somewhere else";
            }
            else if (a == 3)
            {
                quots = "Life moves pretty fast. If you don't stop and look around for a while, you could miss it.";
            }
            else if (a == 4)
            {
                quots = "The most beautiful thing in the world is, of course, the world itself";
            }
            else if (a == 5)
            {
                quots = "Life is either a daring adventure or nothing at all";
            }
            else if (a == 6)
            {
                quots = "You don’t have to be rich to travel well";
            }
            else if (a == 7)
            {
                quots = "If it scares you, it may be a good thing to try";
            }
            else if (a == 8)
            {
                quots = "Life is short and the world is wide";
            }
            else if (a == 9)
            {
                quots = "Wherever you go, go with all your heart";
            }
            else if (a == 10)
            {
                quots = "Once a year, go someplace you've never been before";
            }
            else if (a == 11)
            {
                quots = "Once a year, go someplace you've never been before";
            }
        }


    }

    void UrutanMonstersField()
    {
        int a = PlayerPrefs.GetInt("bahasa");
        //int indexUrutanMonsters = (int)urutanmonster;
        
        if (urutanmonster == "0")
        {
            pengubah = 0;
        }
        else if (urutanmonster == "1")
        {
            pengubah = 1;
        }
        else if (urutanmonster == "2")
        {
            pengubah = 2;
        }
        else if (urutanmonster == "3")
        {
            pengubah = 3;
        }
        else if (urutanmonster == "4")
        {
            pengubah = 4;
        }
        else if (urutanmonster == "5")
        {
            pengubah = 5;
        }
        else if (urutanmonster == "6")
        {
            pengubah = 6;
        }
        
        foreach(GameObject propil in Profile)
        {
            propil.SetActive(false);
        }
        Debug.Log(pengubah);
        Profile[pengubah].SetActive(true);
        
        int cek= pengubah ;

        if (cek == 1)
        {
            if (a == 0)
            {
                deskripsi.text = "Fireto adalah mahluk penjaga mitologi yang berasal dari gua tepi utara gunung slamet. Fireto akan melindungimu dengan kekuatan api yang dia dapatkan dari kekuatan api lahar gunung slamet. Bersama api Fireto yang menyala nyala akan meningkatkan semangat berpetualangmu.<br><br>Lawan natural dari Fireto adalah wateto, sebuah mahluk mutologi penjaga tepi barat sungai pelus gunung slamet.Selalu waspada dengan mahluk mitologi air!";

            }
            else {
                deskripsi.text = "Fireto is a mythological guardian creature who comes from a cave on the north edge of Mount Slamet. Fireto will protect you with the power of fire that he gets from the power of Mount Slamet's lava fire. Together with Fireto's burning fire, it will increase your adventurous spirit.<br><br>Fireto's natural opponent is wateto, a mutological creature that guards the west bank of the Pelus Gunung Slamet river. Always be on the lookout for water mythological creatures!";
            }
        }else if (cek == 2)
        {
            if (a == 0)
            {
                deskripsi.text = "Wateto adalah mahluk mutologi penjaga tepi barat sungai pelus gunung slamet. Wateto secara alamia memiliki kakuatan pengendali air secara turun temurun dari nenek moyang yang hidup diair. Bersama Wateto kamu akan dapat mengendalikan diri lebih baik dan mengendalikan Air seperti bagian tubuh yang lain.<br><br>Lawan dari wateto adalah windto, sebuah mahluk mitologi penjaga selatan hutan rimba gunung slamet. Selalu waspada dengan mahluk mitologi angin!";

            }
            else
            {
                deskripsi.text = "Wateto is a mutological creature that guards the west bank of the Pelus Gunung Slamet River. Wateto naturally has the power to control water that has been passed down from generation to generation from their ancestors who lived in water. With Wateto you will be able to control yourself better and control Water like any other part of your body. <br><br>Wateto's opponent is Windto, a mythological creature that guards the southern forests of Mount Slamet. Always be on the lookout for wind mythological creatures!";
            }
        }
        else if (cek == 3)
        {
            if (a == 0)
            {
                deskripsi.text = "Groundto adalah mahluk mitologi penjaga reruntuhan kerajaan kagunungan slamet.Groundto memiliki daya tahan dan kekuatan yang luar biasa karena dialah satu-satunya mahluk yang selamat meskipun tertimpa rerentuhan kerajaan akibat gunung slamet yang meletus. Bersama groundto kamu akan mendapatkan tekad yang kuat untuk berpetualang.<br><br> Lawan dari Groundto adalah fireto, mahluk penjaga mitologi yang berasal dari gua tepi utara gunung slamet. Selalu waspada dengan mahluk mitologi api!";

            }
            else
            {
                deskripsi.text = "Groundto is a mythological creature that guards the ruins of the Kagunungan Slamet kingdom. Groundto has extraordinary endurance and strength because he is the only creature that survived despite being crushed by the ruins of the kingdom due to the eruption of Mount Slamet. Together with groundto you will get a strong determination to adventure. <br><br>Groundto's opponent is fireto, a mythological guardian creature who comes from a cave on the north edge of Mount Slamet. Always be on the lookout for fire mythological creatures!";
            }
        }
        else if (cek == 4)
        {
            if (a == 0)
            {
                deskripsi.text = "Windto adalah mahluk mitologi penjaga tepi selatan hutan rimba gunung slamet.Dengan memnggunakan kekuatan angin yang mampu memporak - porandakan sekitar windto mampu menerbangkan semua musuh yang tidak memiliki keseimbangan yang baik. Bersama windto kamu akan mendapatkan energi lebih untuk bereksplorasi. < br >< br > Lawan dari windto adalah grounto, sebuah mahluk mitologi penjaga reruntuhan kerajaan kagunungan slamet yang memiliki daya tahan dan kekuatan yang luar biasa hebat.selalu waspada dengan mahluk mitologi tanah!";

            }
            else
            {
                deskripsi.text = "Windto is a mythological creature that guards the southern edge of the jungle of Mount Slamet. By using the power of the wind which is capable of ravaging around the windto is able to blow away all enemies that do not have a good balance. With Windto you will get more energy to explore. <br><br>Windto's opponent is Grounto, a mythological creature that guards the ruins of the Kagunungan Slamet kingdom who has extraordinary endurance and strength. Always be wary of mythological creatures from the land!";
            }
        }
        else if (cek == 5)
        {
            if (a == 0)
            {
                deskripsi.text = "Lighto adalah mahluk penjaga mitologi yang berasal dari puncak gunung slamet. Lighto bertugas menjaga gunung slamet agar tidak Meletus dengan bantuan cahaya matahari yang agung. Bersama lighto kamu akan mendapatkan cahaya penerang untuk menemanimu berpetualang dalam gelapnya dunia.<br><br>Lawan dari lighto adalah darkto, sebuah mahluk mitologi yang berasal dari lembah-lembah kegelapan dilereng gunung slamet. Selalu waspada dengan mahluk mitologi berelemen kegelapan!";

            }
            else
            {
                deskripsi.text = "Lighto is a mythological guardian creature who comes from the top of Mount Slamet. Lighto is in charge of keeping Mount Slamet from erupting with the help of the great sun. Together with Lighto you will get a shining light to accompany you on an adventure in the dark world. <br><br>Lighto's opponent is Darkto, a mythological creature who comes from the valleys of darkness on the slopes of Mount Slamet. Always be on the lookout for mythological creatures of the dark element!";
            }
        }
        else if (cek == 6)
        {
            if (a == 0)
            {
                deskripsi.text = "Darkto adalah mahluk penjaga mitologi yang berasal dari lembah - lembah kegelapan dilereng gunung selamet. darkto akan melindungikamu menggunakan ilmu kegelapan. Meskipun berelemen kegelapan darkto akan mengikuti semua perintah dari kamu termasuk melakukan kebaikan sekalipun. < br >< br > Lawan natural dari darkto adalah lighto sebuah mahluk mitologi penjaga dari puncak gunung selamet.selalu waspada dengan mahluk mitologi berelemen cahaya!";

            }
            else
            {
                deskripsi.text = "Darkto is a mythological guardian creature who comes from the valleys of darkness on the slopes of Mount Selamat. darkto will protect you using dark magic. Even though he has the dark element, Darkto will follow all orders from you, including even doing good. < br >< br > Darkto's natural opponent is Lighto, a mythological creature that guards from the top of Mount Selamat.Always be on the lookout for light elemental mythological creatures!";
            }
            
        }
        else
        {
            deskripsi.text = "";
        }
    }
}
