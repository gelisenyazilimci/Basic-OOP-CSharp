# C# Static Anahtar Kelimesi

C# dilinde **static** anahtar kelimesi, bir üyenin veya sınıfın örnekten bağımsız bir şekilde kullanılmasını sağlar. Static, hem performans avantajı sunar hem de belirli bir veri veya işlevselliği tek bir ortak erişim noktasıyla sınırlamak için kullanılır. Bu yazıda, static kavramını, kullanım alanlarını ve yeni C# sürümlerinde gelen özellikleri detaylı bir şekilde inceleyeceğiz.

---

## Static Nedir?

`static`, bir sınıfın veya üyenin örnekten bağımsız olarak çalışmasını sağlayan bir anahtar kelimedir. Static üyeler ve sınıflar, uygulama süresi boyunca yalnızca bir kez bellekte yer alır. Bu nedenle, belirli bir durumun veya işlevselliğin global olarak paylaşılması gerektiğinde static kullanılır.

---

## Static Üyeler

Bir sınıfın bir üyesi `static` olarak işaretlenirse, bu üye sınıfın bir örneği olmadan erişilebilir hale gelir.

### Örnek:

```csharp
class Matematik
{
    public static double Pi = 3.14159;

    public static double KareAl(double sayi)
    {
        return sayi * sayi;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Pi: {Matematik.Pi}");
        Console.WriteLine($"4'ün karesi: {Matematik.KareAl(4)}");
    }
}
```

### Çıktı:
```
Pi: 3.14159
4'ün karesi: 16
```

Bu örnekte, `Matematik` sınıfının bir örneği oluşturulmadan static üyelerine erişilebilmektedir.

---

## Static Sınıflar

Bir sınıf `static` olarak işaretlendiğinde:

1. **Nesne oluşturulamaz:** Static sınıfların örneği oluşturulamaz.
2. **Yalnızca static üyeler içerebilir:** Static sınıflar, yalnızca static metotlar, alanlar veya özellikler içerebilir.

### Örnek:

```csharp
static class Yardimci
{
    public static void MesajYaz(string mesaj)
    {
        Console.WriteLine(mesaj);
    }
}

class Program
{
    static void Main()
    {
        Yardimci.MesajYaz("Merhaba, dünya!");
    }
}
```

### Çıktı:
```
Merhaba, dünya!
```

### Neden Static Sınıflar Kullanılır?
- **Yardımcı Metotlar:** Ortak işlevlerin gruplanması.
- **Performans:** Bellekte yalnızca bir kez yer alması nedeniyle daha hızlıdır.

---

## Static Yapıcılar

Static sınıflar veya static üyeler için özel bir yapıcı tanımlanabilir. Static yapıcılar:

1. Sınıf ilk kez erişildiğinde çalıştırılır.
2. Parametre almaz.
3. Yalnızca bir kez çalıştırılır.

### Örnek:

```csharp
class Ayarlar
{
    public static string UygulamaAdi;

    static Ayarlar()
    {
        UygulamaAdi = "Static Örnek Uygulaması";
        Console.WriteLine("Static yapıcı çalıştırıldı.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Ayarlar.UygulamaAdi);
    }
}
```

### Çıktı:
```
Static yapıcı çalıştırıldı.
Static Örnek Uygulaması
```

---

## Static ve Yeni C# Özellikleri

C#'ın son sürümlerinde static üyeler ve sınıflar için aşağıdaki yeni özellikler tanıtılmıştır:

### Soyut Static Üyeler (C# 11)

C# 11 ile birlikte, artık arabirimlerde static metotlar tanımlanabilir. Bu özellik, türlere özgü static davranışların tanımlanmasına olanak tanır.

### Örnek:

```csharp
interface ISekil
{
    static abstract double AlanHesapla(double boyut);
}

class Kare : ISekil
{
    public static double AlanHesapla(double kenar)
    {
        return kenar * kenar;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Kare.AlanHesapla(5)); // Çıktı: 25
    }
}
```

---

## Static ve Thread-Safe Kullanımı

Static üyeler, global erişim sağladıkları için çoklu iş parçacığı (multithreading) ortamında dikkatli kullanılmalıdır. Eğer bir static üye birden fazla iş parçacığı tarafından erişiliyorsa, `lock` anahtar kelimesi ile senkronizasyon sağlanmalıdır.

### Örnek:

```csharp
class Sayaç
{
    private static int sayi;
    private static readonly object kilit = new object();

    public static void Arttir()
    {
        lock (kilit)
        {
            sayi++;
        }
    }

    public static int Deger()
    {
        return sayi;
    }
}
```

---

## Static Kullanımının Avantaj ve Dezavantajları

### Avantajları
1. **Performans:** Static üyeler bellekte yalnızca bir kez yer alır.
2. **Kolay erişim:** Sınıf adı üzerinden doğrudan erişim sağlar.
3. **Kapsülleme:** Yardımcı metotlar ve ortak işlevsellikler için uygundur.

### Dezavantajları
1. **Bağımlılıklar:** Static üyeler global erişilebilir olduğu için bağımlılık yaratabilir.
2. **Unit Test Zorluğu:** Static üyeler test edilmesi zor olan bağımlılıklar yaratabilir.
3. **Thread-Safety:** Çoklu iş parçacığı ortamlarında dikkatli kullanılmalıdır.

---

## Static Ne Zaman Kullanılmalı?

1. **Ortak Davranışlar:** Sık kullanılan yardımcı metotlar için.
2. **Global Durum:** Tüm uygulamada paylaşılacak veriler için.
3. **Bellek Yönetimi:** Birden fazla kopya gerektirmeyen veriler için.

---

## Sonuç

C# static anahtar kelimesi, hem performans hem de kullanım kolaylığı açısından önemli bir araçtır. Static üyeler, global olarak erişilebilir davranışlar ve veriler sağlarken, static sınıflar ortak işlevleri düzenlemek için ideal bir araçtır. Ancak, doğru senkronizasyon ve bağımlılık yönetimiyle kullanılmaları gerekir. Modern C# sürümleriyle birlikte static kullanımına yönelik daha fazla esneklik sağlanmıştır.
