using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageWelcome : MonoBehaviour
{
    [Header("Pilih Bahasa")]
    public TMP_Text btn_textNext;
    public int a;

    [Header("Login")]
    public TMP_Text text_SapaanLoginPage;
    public TMP_Text text_emailField;
    public TMP_Text text_passwordField;
    public TMP_Text btn_textLogin;
    public TMP_Text btn_textRegistrasi;
    

    [Header("Register")]
    public TMP_Text text_SapaanRegisterPage;
    public TMP_Text text_userNameFieldRegister;
    public TMP_Text text_emailFieldRegister;
    public TMP_Text text_passwordFieldRegister;
    public TMP_Text text_passwordConfirmationFieldRegister;
    public TMP_Text btn_textCreateAccount;
    

    [Header("Loading")]
    public TMP_Text text_warning;
    public TMP_Text SelamatDatang_Nama;
    public TMP_Text kalimatBerjelajah;
    public TMP_Text kalimatPenjaga1, kalimatPenjaga2;
    public TMP_Text kalimatElemen1, kalimatElemen2;

    private void Start()
    {
        GantiBahasa();
    }

    public void GantiBahasa()
    {
        a = PlayerPrefs.GetInt("bahasa");
        if (a == 0)
        {
            //IND
            btn_textNext.text = "Selanjutnya";
            //Debug.Log("Selanjutnya");
            //login
            text_SapaanLoginPage.text = "Halaman Login";
            text_emailField.text = "Masukan Email. . .";
            text_passwordField.text = "Masukan Password. . .";
            btn_textLogin.text = "Masuk";
            btn_textRegistrasi.text = "Daftar";
            //regioster
            text_SapaanRegisterPage.text = "Membuat Akun";
            text_userNameFieldRegister.text = "Masukan Username. . .";
            text_emailFieldRegister.text = "Masukan Email. . .";
            text_passwordFieldRegister.text = "Masukan password. . .";
            text_passwordConfirmationFieldRegister.text = "Konfirmasi kembali password. . .";
            btn_textCreateAccount.text = "Buat Akun";


            //loading
            text_warning.text = "Aplikasi menggunakan Augmented Reality. Tetap waspada terhadap lingkungan sekitar";
            SelamatDatang_Nama.text = "Selamat datang " + PlayerPrefs.GetString("namalengkap");
            kalimatBerjelajah.text = "Hai Aku Purwo<br>Aku adalah <b> Asisten Virtualmu.";
            kalimatPenjaga1.text = "lengkapi pengalaman interaktif berkeliling purwokerto bersama";
            kalimatPenjaga2.text = "kamu dapat melihat dunia gabungan dunia nyata dan virtual dalam aplikasi";
            kalimatElemen1.text = "Kamu dapat berkompetisi bersama temanmu memainkan game yang ada didalam aplikasi";
            kalimatElemen2.text = "untuk sementara kamu dapat memainkan game gasing tradisional";

        }
        else if(a==1)
        {
            //ENG
            btn_textNext.text = "Next";
            Debug.Log("NEXT");
            //login
            text_SapaanLoginPage.text = "Login Page";
            text_emailField.text = "Enter Email. . .";
            text_passwordField.text = "Enter Password. . .";
            btn_textLogin.text = "Login";
            btn_textRegistrasi.text = "Register";
            //register
            text_SapaanRegisterPage.text = "Create Account";
            text_userNameFieldRegister.text = "Enter username. . .";
            text_emailFieldRegister.text = "Enter Email. . .";
            text_passwordFieldRegister.text = "Enter password. . .";
            text_passwordConfirmationFieldRegister.text = "Confirm password. . .";
            btn_textCreateAccount.text = "Create Account";

            //loading
            text_warning.text = "Application using Augmented Reality. Stay aware of your surroundings";
            SelamatDatang_Nama.text = "Welcome " + PlayerPrefs.GetString("namalengkap");
            kalimatBerjelajah.text = "Hi I'm Purwo<br>I am <b>your Virtual Assistant.";
            kalimatPenjaga1.text = "Complete the interactive experience of traveling around Purwokerto together";
            kalimatPenjaga2.text = "You can see the real and virtual world combined in the application";
            kalimatElemen1.text = "You can compete with your friends playing the games in the application";
            kalimatElemen2.text = "for a while you can play traditional tops games";

        }

    }


}
