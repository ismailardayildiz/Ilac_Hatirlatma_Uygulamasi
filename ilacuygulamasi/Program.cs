using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata;
using System.Threading;

class Program
{
    static void Main()
    {
        while (true)
        {
            string adminUser = "admin";  // sabit kullanıcı adı ve şifre tanımladım (admin girişi)
            string adminPsw = "admin";
            string kullaniciAdi = "arda";  // sabit kullanıcı adı ve şifre tanımladım
            string sifre = "admin";

            Console.WriteLine("Kullanıcı Adınız");
            string girilenKullaniciAdi = Console.ReadLine(); // girilenKullaniciAdi na kullanıcı adı atadım

            Console.WriteLine("Şifreniz");
            string girilenSifre = sifeliyaz(); // girilenSifre yi sifreyaz() da bazı işlemlere sokmak için gönderdim

            if (girilenKullaniciAdi == adminUser && girilenSifre == adminPsw)
            {
                Console.WriteLine("\nAdmin Giriş başarılı!");  //kullanıcıy bilgi verildi
                Thread.Sleep(1000);
                Console.WriteLine("Yapım aşamasında");
                Thread.Sleep(2000);
                //myApp();  // giriş başarılı olunca asıl programa atıyor
            }
            else if (girilenKullaniciAdi == kullaniciAdi && girilenSifre == sifre) // basit kullanıcı adı ve şifre kontrol if bloğu yaptım
            {
                Console.WriteLine("\nGiriş başarılı!");  //kullanıcıy bilgi verildi
                Thread.Sleep(1000);
                myApp();  // giriş başarılı olunca asıl programa atıyor
            }
            else
            {
                Console.WriteLine("\nHatalı kullanıcı adı veya şifre. Tekrar deneyiniz");  // kullanıcıy bilgi verildi
            }
        }
        Console.ReadKey();

    }

    private static string sifeliyaz() //  şifre sansür kod bloğu
    {
        string pass = "";
        do
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (true);
        return pass;
    }

    static void myApp()
    {

        DateTime anlikTarihSaat = DateTime.Now;  // Anlık tarih ve saat bilgisini almak için DateTime.Now 


        Console.WriteLine(anlikTarihSaat);  // Tarih ve saat bilgisini ekrana yazdırma


        List<hatırlat> hatırlatıcılar = new List<hatırlat>(); // generic bir liste oluşturulur

        while (true)
        {
        up:
            CheckReminders(hatırlatıcılar);
            Console.WriteLine("1. Hatırlatıcı Ekle");
            Console.WriteLine("2. Hatırlatıcı Sil");
            Console.WriteLine("3. Hatırlatıcı Düzenle");
            Console.WriteLine("4. Çıkış");
            Console.WriteLine("Lütfen yapacağınız işlemi seçiniz"); ;

            string sec = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (char.IsDigit(key.KeyChar))
                {
                    Console.Write(key.KeyChar);
                    sec += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Backspace && sec.Length > 0)
                {
                    // Backspace tuşuna basıldığında bir karakteri sil
                    Console.Write("\b \b");
                    sec = sec.Substring(0, sec.Length - 1);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break; // Enter tuşuna basıldığında girişi tamamla
                }
                // Diğer durumlar için isteğe bağlı işlemler eklenebilir.

            } while (true);

            //Console.WriteLine("\nGirilen sayı: " + sec);
            //string sec = Console.ReadLine();
            if (sec == "")
            {
                Console.WriteLine("Boş bırakılamaz");
                Thread.Sleep(1000);
                goto up;
            }

            Console.WriteLine($"\nSeçtiğiniz işlem no: {sec}, Emin misiniz? (Y/N)");
            string choise = Console.ReadLine().ToUpper();
            if (choise == "Y")
            {
                switch (sec)
                {
                    case "1":
                        Console.Clear();                 // konsolu temizler
                        AddReminder(hatırlatıcılar);     // addReminder'atar
                        break;
                    case "2":
                        Console.Clear();                  // konsolu temizler
                        RemoveReminder(hatırlatıcılar);   // RemoveReminder'atar
                        break;
                    case "3":
                        Console.Clear();                  // konsolu temizler
                        refactor(hatırlatıcılar);   // RemoveReminder'atar
                        break;
                    case "4":
                        Console.Clear();                  // konsolu temizler
                        Environment.Exit(0);              // çıkış yapar
                        break;
                    default:
                        Console.Clear();                  // konsolu temizler
                        Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                        break;
                }
            }
            else if (choise == "N")
            {
                Console.Clear();
                Console.WriteLine("Ana Menü'ye gidiliyor");
                goto up;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Yanlış tuşlama tekrar deneyiniz");
            }
            //Thread.Sleep(4000); // İşlemcinin kullanımını azaltmak.
            //Console.Clear(); // Konsol ekranını temizle
        }
    }

    static void AddReminder(List<hatırlat> hatırlatıcılar)  // Bu kısım, metoda parametre olarak geçirilen bir liste alır.List<hatırlat>
                                                            // ifadesi, generic bir liste tipini temsil eder ve hatırlat türündeki nesneleri içerir
    {

    ilac:
        Console.WriteLine("İlaç adını girin:");
        string medicineName = Console.ReadLine();

        if (medicineName == "")
        {
            Console.Clear();
            Console.WriteLine("Boş bırakılamaz");
            goto ilac;
        }

    name:
        Console.WriteLine("Kimin için");
        string whois = Console.ReadLine();

        if (whois == "")
        {
            Console.Clear();
            Console.WriteLine("Boş bırakılamaz");
            goto name;
        }

    days:
        Console.WriteLine("hangi günler: (Örn: pazartesi)");
        string day = Console.ReadLine().ToLower();

        if (day == "")
        {
            Console.Clear();
            Console.WriteLine("Boş bırakılamaz");
            goto days;
        }


        while (true)
        {
            Console.WriteLine("Hatırlatma zamanını girin (örnek: 13:30):");
            string timeString = Console.ReadLine();
            if (DateTime.TryParseExact(timeString, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime reminderTime))
            {
                hatırlat newHatırlat = new hatırlat // hatırlat classından nesne türettim 
                {
                    ilacIsmi = medicineName,        // ilacIsmi ne kullanıcıdan aldığım değeri atadım
                    hatırlatıcıZaman = reminderTime,// hatırlatıcıZaman ı kullanıcıdan aldığım değeri atadım
                    kim = whois,                     // kim i kullanıcıdan aldığım değeri atadım
                    day = day
                };

                hatırlatıcılar.Add(newHatırlat);    // hatırlatıcılar' türettiğim nesneyi ekledim

                Console.Clear();    // konsol temizlenir
                Console.WriteLine("Hatırlatıcı başarıyla eklendi.");    // kullanıcıya bigi verildi


                if (false)
                {    // SMTP bilgilerinizi buraya girin
                    string smtpServer = "smtp.gmail.com";
                    int smtpPort = 587 / 465;
                    string smtpUsername = "arda421903@gmail.com";
                    string smtpPassword = "";

                    // Alıcı e-posta adresini belirleyin
                    string to = "@gmail.com";

                    // E-posta gönderme işlemini gerçekleştirin
                    SendEmail(smtpServer, smtpPort, smtpUsername, smtpPassword, to);

                }

                //Thread.Sleep(10000);
                break;
            }
            else
            {
                Console.Clear();    // konsol temizlenir
                Console.WriteLine("Geçersiz zaman formatı. Lütfen tekrar deneyin : ");   // kullanıcıya bigi verildi
            }
        }
    }

    static void RemoveReminder(List<hatırlat> hatırlatıcılar)// Bu kısım, metoda parametre olarak geçirilen bir liste alır.List<hatırlat>
                                                             // ifadesi, generic bir liste tipini temsil eder ve hatırlat türündeki nesneleri içerir
    {
        if (hatırlatıcılar.Count == 0) // hatırlatıcıların içi boş ise kullanıcıya boş olduğu bilgisi verilir
        {
            Console.WriteLine("Silinecek hatırlatıcı yok.");
            return;
        }
        Console.WriteLine("Silinecek hatırlatıcının numarasını girin:");
        int index = Convert.ToInt32(Console.ReadLine());  // index değerini int dönüşümü yaparak aldım

        if (index >= 1 && index <= hatırlatıcılar.Count) // index değerini sağlamasını yapıp silindi bilgisi için içeri alır
        {
            hatırlat hatırlatıcı = hatırlatıcılar[index - 1];  //  hatırlat türündeki bir değişken olan hatırlatıcı'ya, hatırlatıcılar listesindeki belirli bir konumda bulunan öğeyi atar.
                                                               //  index - 1 ifadesi, listenin sıfır tabanlı indeksleme nedeniyle belirli bir konumun indeksini temsil eder.
            while (true)
            {
                Console.WriteLine("Silinecek... Emin misin? (Y/N)");
                string choise = Console.ReadLine().ToUpper();
                if (choise == "Y")
                {
                    hatırlatıcılar.Remove(hatırlatıcı);  // hatırlatıcılardan gelen indexli list öğesini silmek için
                    Console.Clear();                     // konsol temizlenir
                    Console.WriteLine($"Hatırlatıcı başarıyla silindi. Silinen Hatırlatıcı: {hatırlatıcı.ilacIsmi}");
                    break;
                }
                else if (choise == "N")
                {
                    Console.WriteLine("İşlem iptal edildi");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş... Tekrar deneyiniz");
                }
            }
        }
        else
        {
            Console.Clear();                     // konsol temizlenir
            Console.WriteLine("Geçersiz hatırlatıcı numarası. Lütfen tekrar deneyin.");
            Thread.Sleep(3000);
        }
    }
    static void refactor(List<hatırlat> hatırlatıcılar)// Bu kısım, metoda parametre olarak geçirilen bir liste alır.List<hatırlat>
                                                       // ifadesi, generic bir liste tipini temsil eder ve hatırlat türündeki nesneleri içerir
    {
        CheckReminders(hatırlatıcılar);

        if (hatırlatıcılar.Count == 0) // hatırlatıcıların içi boş ise kullanıcıya boş olduğu bilgisi verilir
        {
            Console.WriteLine("Düzenlenecek hatırlatıcı yok.");
            return;
        }
        Console.WriteLine("Düzenlenecek hatırlatıcının numarasını girin: ");
        int index = Convert.ToInt32(Console.ReadLine());  // index değerini int dönüşümü yaparak aldım

        if (index >= 1 && index <= hatırlatıcılar.Count) // index değerini sağlamasını yapıp silindi bilgisi için içeri alır
        {
            hatırlat hatırlatıcı = hatırlatıcılar[index - 1];  //  hatırlat türündeki bir değişken olan hatırlatıcı'ya, hatırlatıcılar listesindeki belirli bir konumda bulunan öğeyi atar.
                                                               //  index - 1 ifadesi, listenin sıfır tabanlı indeksleme nedeniyle belirli bir konumun indeksini temsil eder.
            while (true)
            {
                Console.WriteLine("Düzenlenecek... Emin misin? (Y/N)");
                string choise = Console.ReadLine().ToUpper();
                if (choise == "Y")
                {
                    hatırlatıcılar.Remove(hatırlatıcı);  // hatırlatıcılardan gelen indexli list öğesini silmek için
                    Console.Clear();                     // konsol temizlenir
                    AddReminder(hatırlatıcılar);
                    break;
                }
                else if (choise == "N")
                {
                    Console.WriteLine("İşlem iptal edildi");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş... Tekrar deneyiniz");
                }
            }
        }
        else
        {
            Console.Clear();                     // konsol temizlenir
            Console.WriteLine("Geçersiz hatırlatıcı numarası. Lütfen tekrar deneyin.");
            Thread.Sleep(4000);
        }
    }

    static void CheckReminders(List<hatırlat> reminders)
    {
        Console.Clear();       // konsol temizlenir   
        Console.WriteLine("------- Hatırlatıcılar -------");
        if (reminders.Count == 0) // hatırlatıcıların içi boş ise kullanıcıya boş olduğu bilgisi verilir
        {
            Console.WriteLine("Listelenecek hatırlatıcıyok.");

        }
        foreach (var reminder in reminders)  // foreach ile reminders içinde reminder ile index index döndüm
        {
            int index = reminders.IndexOf(reminder) + 1;  // gelecek index değeri 0 dan başlayacağı için kullanıcı dostu görünüm elde etmek için 1 den başlattım
            Console.WriteLine($"NO:{index} İlaç Adı: {reminder.ilacIsmi} | Günler: {reminder.day} | Hatırlatma Zamanı: {reminder.hatırlatıcıZaman.ToString("HH:mm")} |" + " Kim için :" + reminder.kim);
            // kullanıcının eklediği bilgileri tek satırda çıktı verdim
        }


        Console.WriteLine("-------------------------------");
    }

    // e-mail
    static void SendEmail(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword, string to)
    {
        using (SmtpClient client = new SmtpClient(smtpServer, smtpPort))
        {
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpUsername);
            mailMessage.To.Add(to);
            mailMessage.Subject = "Test E-postası";
            mailMessage.Body = "Merhaba, bu bir test e-postasıdır.";
            mailMessage.IsBodyHtml = true;

            try
            {
                client.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.ToString());
            }
        }
    }

}



class hatırlat  // class tanımladım
{
    public string ilacIsmi { get; set; }  // public erişim belirteçli ilacIsmi içinde ilaç adını tutmak için kullandım
    public DateTime hatırlatıcıZaman { get; set; }  // public erişim belirteçli hatırlatıcıZaman içinde ilaç adını tutmak için kullandım
    public string kim { get; set; }  // public erişim belirteçli kim içinde ilaç adını tutmak için kullandım
    // getter ve setter için  sınıf dışından (ilacIsmi,hatırlatıcıZaman,kim) özelliğine değer atama veya değer okuma işlemleri otomatik olarak yönetilir.
    public string day { get; set; }

}
