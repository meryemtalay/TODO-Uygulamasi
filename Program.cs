using System;
using System.Collections.Generic;

//Bu uygulamayı daha iyi anlayabilmek adına README.md'de bulunan dokümantasyonu inceleyebilirsiniz.

namespace console_programming
{
    // Kart Büyüklükleri için Enum 
    public enum KartBuyuklugu
    {
        XS = 1,
        S,
        M,
        L,
        XL
    }

    // Takım Üyesi temsil eden sınıf
    public class TakimUyesi
    {
        public int ID { get; set; }
        public string Ad { get; set; }
    }

    // Kartı temsil eden sınıf
    public class Kart
    {
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public TakimUyesi AtananKisi { get; set; }
        public KartBuyuklugu Buyukluk { get; set; }
        public string Satir { get; set; }
    }

    // Board'ı temsil eden sınıf
    public class Board
    {
        public List<Kart> TODO { get; set; } = new List<Kart>();
        public List<Kart> IN_PROGRESS { get; set; } = new List<Kart>();
        public List<Kart> DONE { get; set; } = new List<Kart>();
    }

    // Ana Program
    class Program
    {
        public static void ShowBoard(Board board)
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            foreach (var card in board.TODO)
            {
                Console.WriteLine($"Başlık      : {card.Baslik}");
                Console.WriteLine($"İçerik      : {card.Icerik}");
                Console.WriteLine($"Atanan Kişi : {card.AtananKisi.Ad}");
                Console.WriteLine($"Büyüklük    : {card.Buyukluk}");
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");
            foreach (var card in board.IN_PROGRESS)
            {
                Console.WriteLine($"Başlık      : {card.Baslik}");
                Console.WriteLine($"İçerik      : {card.Icerik}");
                Console.WriteLine($"Atanan Kişi : {card.AtananKisi.Ad}");
                Console.WriteLine($"Büyüklük    : {card.Buyukluk}");
                Console.WriteLine("----------------------------");
            }

            //Biten İşler
            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");
            foreach (var card in board.DONE)
            {
                Console.WriteLine($"Başlık      : {card.Baslik}");
                Console.WriteLine($"İçerik      : {card.Icerik}");
                Console.WriteLine($"Atanan Kişi : {card.AtananKisi.Ad}");
                Console.WriteLine($"Büyüklük    : {card.Buyukluk}");
                Console.WriteLine("----------------------------");
            }
        }

        public static void AddCardToBoard(Board board, Kart kart)
        {
            switch (kart.Satir)
            {
                case "TODO":
                    board.TODO.Add(kart);
                    break;
                case "IN PROGRESS":
                    board.IN_PROGRESS.Add(kart);
                    break;
                case "DONE":
                    board.DONE.Add(kart);
                    break;
                default:
                    Console.WriteLine("Geçersiz satır. Kart eklenemedi.");
                    break;
            }
        }

        //Kart Silme
        public static void RemoveCardFromBoard(Board board, string baslik)
        {
            bool removed = false;
            foreach (var card in board.TODO)
            {
                if (card.Baslik == baslik)
                {
                    board.TODO.Remove(card);
                    removed = true;
                    break;
                }
            }

            if (!removed)
            {
                foreach (var card in board.IN_PROGRESS)
                {
                    if (card.Baslik == baslik)
                    {
                        board.IN_PROGRESS.Remove(card);
                        removed = true;
                        break;
                    }
                }
            }

            if (!removed)
            {
                foreach (var card in board.DONE)
                {
                    if (card.Baslik == baslik)
                    {
                        board.DONE.Remove(card);
                        removed = true;
                        break;
                    }
                }
            }

            if (removed)
            {
                Console.WriteLine($"{baslik} başlıklı kart başarıyla silindi.");
            }
            else
            {
                Console.WriteLine($"{baslik} başlıklı kart bulunamadı.");
            }
        }

        public static void MoveCard(Board board, string baslik, string hedefSatir)
        {
            Kart kart = null;
            foreach (var card in board.TODO)
            {
                if (card.Baslik == baslik)
                {
                    kart = card;
                    board.TODO.Remove(card);
                    break;
                }
            }

            if (kart == null)
            {
                foreach (var card in board.IN_PROGRESS)
                {
                    if (card.Baslik == baslik)
                    {
                        kart = card;
                        board.IN_PROGRESS.Remove(card);
                        break;
                    }
                }
            }

            if (kart == null)
            {
                foreach (var card in board.DONE)
                {
                    if (card.Baslik == baslik)
                    {
                        kart = card;
                        board.DONE.Remove(card);
                        break;
                    }
                }
            }

            if (kart != null)
            {
                switch (hedefSatir)
                {
                    case "TODO":
                        board.TODO.Add(kart);
                        break;
                    case "IN PROGRESS":
                        board.IN_PROGRESS.Add(kart);
                        break;
                    case "DONE":
                        board.DONE.Add(kart);
                        break;
                    default:
                        Console.WriteLine("Geçersiz hedef satır. Kart taşınamadı.");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{baslik} başlıklı kart bulunamadı.");
            }
        }

        static void Main(string[] args)
        {
            // Varsayılan takım üyeleri
            List<TakimUyesi> takimUyeleri = new List<TakimUyesi>
            {
                new TakimUyesi { ID = 1, Ad = "Selim Can" },
                new TakimUyesi { ID = 2, Ad = "Kerim Mustafa" },
                new TakimUyesi { ID = 3, Ad = "Ömer Faruk" }
            };

            // Varsayılan kartlar
            Kart kart1 = new Kart
            {
                Baslik = "Görev 1",
                Icerik = "Görev 1 İçerik",
                AtananKisi = takimUyeleri[0],
                Buyukluk = KartBuyuklugu.S,
                Satir = "TODO"
            };

            Kart kart2 = new Kart
            {
                Baslik = "Görev 2",
                Icerik = "Görev 2 İçerik",
                AtananKisi = takimUyeleri[1],
                Buyukluk = KartBuyuklugu.M,
                Satir = "IN PROGRESS"
            };

            Kart kart3 = new Kart
            {
                Baslik = "Görev 3",
                Icerik = "Görev 3 İçerik",
                AtananKisi = takimUyeleri[2],
                Buyukluk = KartBuyuklugu.L,
                Satir = "DONE"
            };

            Board board = new Board();
            board.TODO.Add(kart1);
            board.IN_PROGRESS.Add(kart2);
            board.DONE.Add(kart3);

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("******************************************");
                Console.WriteLine("(1) Board Listelemek");
                Console.WriteLine("(2) Board'a kart eklemek");
                Console.WriteLine("(3) Board'dan Kart Silmek");
                Console.WriteLine("(4) Kart Taşımak");
                Console.WriteLine("(exit) Çıkış");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        ShowBoard(board);
                        break;
                    case "2":
                        Console.Write("Başlık Giriniz                                  : ");
                        string baslik = Console.ReadLine();
                        Console.Write("İçerik Giriniz                                  : ");
                        string icerik = Console.ReadLine();
                        Console.WriteLine("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
                        int buyuklukSecim = Convert.ToInt32(Console.ReadLine());
                        KartBuyuklugu buyukluk = (KartBuyuklugu)buyuklukSecim;
                        Console.Write("Kişi Seçiniz                                    : ");
                        int takimUyesiID = Convert.ToInt32(Console.ReadLine());

                        TakimUyesi secilenUye = takimUyeleri.Find(u => u.ID == takimUyesiID);

                        if (secilenUye == null)
                        {
                            Console.WriteLine("Hatalı giriş yaptınız! Kart eklenemedi.");
                            break;
                        }

                        Kart yeniKart = new Kart
                        {
                            Baslik = baslik,
                            Icerik = icerik,
                            AtananKisi = secilenUye,
                            Buyukluk = buyukluk,
                            Satir = "TODO"
                        };

                        AddCardToBoard(board, yeniKart);
                        break;
                    case "3":
                        Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
                        string silinecekKartBasligi = Console.ReadLine();
                        RemoveCardFromBoard(board, silinecekKartBasligi);
                        break;
                    case "4":
                        Console.Write("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
                        string tasinacakKartBasligi = Console.ReadLine();
                        Console.Write("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE ");
                        int hedefLineSecim = Convert.ToInt32(Console.ReadLine());
                        string hedefLine = "";

                        switch (hedefLineSecim)
                        {
                            case 1:
                                hedefLine = "TODO";
                                break;
                            case 2:
                                hedefLine = "IN PROGRESS";
                                break;
                            case 3:
                                hedefLine = "DONE";
                                break;
                            default:
                                Console.WriteLine("Hatalı bir seçim yaptınız! Kart taşınamadı.");
                                break;
                        }

                        MoveCard(board, tasinacakKartBasligi, hedefLine);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
