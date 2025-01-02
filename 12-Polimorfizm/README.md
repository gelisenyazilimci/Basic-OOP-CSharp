# C# Polimorfizm (Çok Biçimlilik)

Polimorfizm (Çok Biçimlilik), nesne yönelimli programlamanın (OOP) temel prensiplerinden biridir ve C# dilinde güçlü bir şekilde desteklenir. Polimorfizm, bir nesnenin farklı şekillerde davranabilmesini ifade eder. Bu kavram, özellikle büyük ve karmaşık yazılım projelerinde kodun esnekliğini, yeniden kullanılabilirliğini ve bakım kolaylığını artırır.

## Polimorfizm Nedir?
Polimorfizm, "çok biçimlilik" anlamına gelir ve bir nesnenin birden fazla biçimde davranabilmesini sağlar. C#'ta bu, genellikle miras (inheritance) ve sanal (virtual) yöntemler kullanılarak uygulanır. Polimorfizmin iki temel türü vardır:

1. **Statik (Derleme Zamanı) Polimorfizm**: Aşırı yükleme ([overloading](../5-Methods-Overloading/README.md)) ile gerçekleştirilir.
2. **Dinamik (Çalışma Zamanı) Polimorfizm**: Geçersiz kılma (overriding) ile gerçekleştirilir.

## Statik Polimorfizm
Statik polimorfizm, derleme zamanında çözülür ve genellikle metot veya operatör aşırı yükleme ile sağlanır.

### Örnek: Metot Aşırı Yükleme
```csharp
using System;

class Matematik
{
    public int Topla(int a, int b)
    {
        return a + b;
    }

    public double Topla(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        Matematik matematik = new Matematik();
        Console.WriteLine(matematik.Topla(5, 10)); // Çıktı: 15
        Console.WriteLine(matematik.Topla(5.5, 10.2)); // Çıktı: 15.7
    }
}
```

## Dinamik Polimorfizm
Dinamik polimorfizm, çalışma zamanında çözülür ve genellikle sanal metotlar (virtual methods) ve arabirimler (interfaces) ile uygulanır.

### Örnek: Virtual ve Override
```csharp
using System;

class Hayvan
{
    public virtual void SesCikar()
    {
        Console.WriteLine("Hayvan ses çıkarıyor.");
    }
}

class Kopek : Hayvan
{
    public override void SesCikar()
    {
        Console.WriteLine("Hav Hav!");
    }
}

class Kedi : Hayvan
{
    public override void SesCikar()
    {
        Console.WriteLine("Miyav!");
    }
}

class Program
{
    static void Main()
    {
        Hayvan hayvan = new Hayvan();
        Hayvan kopek = new Kopek();
        Hayvan kedi = new Kedi();

        hayvan.SesCikar(); // Çıktı: Hayvan ses çıkarıyor.
        kopek.SesCikar();  // Çıktı: Hav Hav!
        kedi.SesCikar();   // Çıktı: Miyav!
    }
}
```

## Polimorfizm ve Arabirimler
Arabirimler, polimorfizmin güçlü bir başka kullanım alanını sağlar. Birden fazla sınıfın aynı arabirimi uygulaması, nesnelerin ortak bir şekilde kullanılabilmesini sağlar.

### Örnek: Arabirim Kullanımı
```csharp
using System;

interface ICalisan
{
    void Calis();
}

class Muhendis : ICalisan
{
    public void Calis()
    {
        Console.WriteLine("Mühendis çalışıyor.");
    }
}

class Isci : ICalisan
{
    public void Calis()
    {
        Console.WriteLine("İşçi çalışıyor.");
    }
}

class Program
{
    static void Main()
    {
        ICalisan calisan1 = new Muhendis();
        ICalisan calisan2 = new Isci();

        calisan1.Calis(); // Çıktı: Mühendis çalışıyor.
        calisan2.Calis(); // Çıktı: İşçi çalışıyor.
    }
}
```

## C# 11 ve Sonrası: Yeni Özellikler
C#'ın son sürümlerinde polimorfizm ile ilgili bazı yenilikler ve geliştirmeler de bulunmaktadır. Bunlardan bazıları şunlardır:

### Soyut Statik Üyeler (Abstract Static Members)
C# 11 ile birlikte, artık arabirimlerde statik üyeler tanımlanabilir. Bu, özellikle polimorfik davranışı artırır.

```csharp
interface ISekil
{
    static abstract double AlanHesapla(double boyut);
}

class Daire : ISekil
{
    public static double AlanHesapla(double yaricap)
    {
        return Math.PI * yaricap * yaricap;
    }
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
        Console.WriteLine(Daire.AlanHesapla(5)); // Çıktı: 78.539...
        Console.WriteLine(Kare.AlanHesapla(4));  // Çıktı: 16
    }
}
```

## Sonuç
Polimorfizm, C#'ta nesne yönelimli programlamanın güçlü ve esnek bir özelliğidir. Statik ve dinamik polimorfizm kullanılarak kodun yeniden kullanılabilirliği ve esnekliği artırılabilir. Yeni C# özellikleri, bu prensibi daha güçlü bir şekilde desteklemektedir. Polimorfizmi etkili bir şekilde kullanmak, yazılım geliştiricilere daha sürdürülebilir ve ölçeklenebilir projeler geliştirme imkânı sunar.
