# PROJE-2 : Console ToDo Uygulaması

Bu proje, bir 3 kolondan oluşan bir ToDo uygulamasını içerir. Uygulamada temel olarak aşağıdaki işlemler gerçekleştirilebilir:

- Kart Ekle
- Kart Güncelle
- Kart Sil
- Kart Taşı
- Board Listeleme

## Kart İçeriği

- Başlık
- İçerik
- Atanan Kişi (Takım üyeleri arasından biri olmalı)
- Büyüklük (XS, S, M, L, XL)

## Açıklama

Board, TODO - IN PROGRESS - DONE olmak üzere üç kolondan oluşmalıdır. Varsayılan olarak bir board tanımlı olmalı ve her biri 3 kart barındırmalıdır.

## Nasıl Kullanılır

Uygulama başladığında kullanıcıya yapmak istediği işlem seçtirilir:

```plaintext
Lütfen yapmak istediğiniz işlemi seçiniz :) 
******************************************* 
(1) Board Listelemek 
(2) Board'a Kart Eklemek 
(3) Board'dan Kart Silmek 
(4) Kart Taşımak

## Board Listelemek

```plaintext
TODO Line
************************
Başlık      :
İçerik      :
Atanan Kişi :
Büyüklük    :
-
Başlık      :
İçerik      :
Atanan Kişi :
Büyüklük    :

IN PROGRESS Line
************************
Başlık      :
İçerik      :
Atanan Kişi :
Büyüklük    :
-
Başlık      :
İçerik      :
Atanan Kişi :
Büyüklük    :

DONE Line
************************
~ BOŞ ~

## Board'a Kart Eklemek

```plaintext
Başlık Giriniz          : 
İçerik Giriniz          :
Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :
Kişi Seçiniz            : 

Notlar:

- Büyüklükler Enum olarak saklanmalıdır. Kart üzerinde gösterilirken XS olarak gösterilmelidir. Giriş yapılırken kullanıcıdan 1 alınmalıdır.

- Takım üyeleri mevcut bir listede daha önceden tanımlanmalıdır. Program içerisinde dinamik tanımlamaya gerek yoktur. Kart tanımlarken takım üyesinin ID'si istenmelidir. Tanımlı bir ID değilse "Hatalı girişler yaptınız!" uyarısı ile işlem iptal edilebilir.
## Board'dan Kart Silmek

Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor. Lütfen kart başlığını yazınız: 

**Not:**

- Aynı isimde birden fazla kart bulunursa her ikisi de silinebilir.

## Kart Taşımak

Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor. Lütfen kart başlığını yazınız: 

**Notlar:**

- Eğer kart bulunamazsa, "Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız." mesajı görüntülenir.

- Eğer kart bulunursa, kullanıcıya taşımak istediği Line'ı seçmesi için seçenek sunulur.

## Uygulama Yapısı

- Board 3 tane Line'dan oluşur.
- Her bir Line bir kart listesi tutar.
- Kartların büyüklükleri pre-defined olan bir enum'da tutulur.
- Kart sadece takım üyelerinden birine atanabilir.
- Takım üyeleri daha önceden varsayılan olarak tanımlanmış bir listede olmalıdır. Struct, class ya da bir koleksiyon kullanılabilir.
