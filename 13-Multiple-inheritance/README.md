# C# Multiple Inheritance (Çoklu Miras)

C# dilinde çoklu miras (multiple inheritance), bir sınıfın birden fazla sınıftan türetilememesi anlamına gelir. Bu, dilin tasarımında bilinçli bir tercih olarak yapılmıştır. Çoklu mirasın karmaşıklık yaratabilecek sorunlarından 
(örneğin, [elmas problemi](../13-Multiple-inheritance/diamond-problem/REAMDME.md) ) kaçınmak için C# dilinde yalnızca tekli sınıf mirası (single inheritance) desteklenir. Ancak, C# dilinde çoklu mirasa benzer davranışlar elde etmek için arabirimler (interfaces) ve bazı tasarım desenleri kullanılabilir.

Bu makalede, C#'ta çoklu mirasın neden desteklenmediğini, arabirimlerin çoklu miras için nasıl bir alternatif sunduğunu ve son sürümlerde gelen yeni özelliklerin bu konuyla ilişkisini ele alacağız.

## Çoklu Miras Nedir?
Çoklu miras, bir sınıfın birden fazla sınıftan türetildiği bir nesne yönelimli programlama (OOP) kavramıdır. Örneğin, aşağıdaki gibi bir yapı çoklu mirası temsil eder:

```plaintext
class A
{
    public void MethodA() { }
}

class B
{
    public void MethodB() { }
}

class C : A, B
{
    // A ve B'nin tüm üyelerini miras alır.
}
```

C#'ta bu yapı desteklenmez. Ancak, aynı sonucu elde etmek için arabirimler kullanılır.

## C#'ta Çoklu Miras Neden Desteklenmez?
C# dilinde çoklu miras desteklenmemesinin başlıca nedenleri şunlardır:

1. [**Elmas Problemi**](../13-Multiple-inheritance/diamond-problem/REAMDME.md): Bir sınıfın birden fazla sınıftan türetilmesi durumunda aynı üyelerin birden fazla türetilmesi sorunlara yol açabilir.
2. **Karmaşıklık**: Çoklu miras, sınıf hiyerarşisini karmaşık hale getirerek kodun okunabilirliğini ve bakımını zorlaştırabilir.
3. **Arabirimler Yoluyla Çözüm**: C# tasarımcıları, çoklu mirasın getirdiği avantajları arabirimlerle sağlamayı tercih etmişlerdir.

## Arabirimlerle Çoklu Miras
Arabirimler, C#'ta çoklu mirasa alternatif olarak kullanılır. Bir sınıf, birden fazla arabirimi uygulayabilir ve bu sayede çoklu mirasın faydalarını karmaşıklık olmadan sunar.

### Örnek: Birden Fazla Arabirim Uygulama

```csharp
using System;

interface IYurume
{
    void Yuru();
}

interface IUcma
{
    void Uc();
}

class Hayvan
{
    public void Yasam()
    {
        Console.WriteLine("Hayvan yaşıyor.");
    }
}

class Kus : Hayvan, IYurume, IUcma
{
    public void Yuru()
    {
        Console.WriteLine("Kuş yürüyor.");
    }

    public void Uc()
    {
        Console.WriteLine("Kuş uçuyor.");
    }
}

class Program
{
    static void Main()
    {
        Kus kus = new Kus();
        kus.Yasam();
        kus.Yuru();
        kus.Uc();
    }
}
```

Bu örnekte, `Kus` sınıfı hem `IYurume` hem de `IUcma` arabirimlerini uygular. Bu sayede bir sınıfa birden fazla yetenek kazandırılabilir.

## Yeni Özellikler ve Çoklu Miras
C#'ın yeni sürümleri, arabirimleri daha güçlü hale getiren özellikler sunmuştur. Bunlar, çoklu mirasın eksikliği hissedilmeksizin daha güçlü ve esnek yapılar oluşturulmasını sağlar.

### Varsayılan Arabirim Metotları (Default Interface Methods)
C# 8.0 ile gelen bu özellik, arabirimlere varsayılan bir metot uygulaması eklenmesini sağlar. Bu, birden fazla arabirimle çalışırken tekrarlayan kodu azaltır.

```csharp
using System;

interface IYurume
{
    void Yuru()
    {
        Console.WriteLine("Varsayılan yürüyüş.");
    }
}

interface IUcma
{
    void Uc()
    {
        Console.WriteLine("Varsayılan uçuş.");
    }
}

class Kus : IYurume, IUcma
{
    // Varsayılan metotları kullanabilir veya kendi uygulamasını yazabilir.
}

class Program
{
    static void Main()
    {
        Kus kus = new Kus();
        ((IYurume)kus).Yuru(); // Çıktı: Varsayılan yürüyüş.
        ((IUcma)kus).Uc();   // Çıktı: Varsayılan uçuş.
    }
}
```

Bu özellik, kodun tekrarını azaltır ve arabirimlerin kullanımını daha esnek hale getirir.

## Sonuç
C# dilinde çoklu miras doğrudan desteklenmemesine rağmen, arabirimler ve son sürümlerde gelen yeni özellikler sayesinde bu eksiklik hissettirilmeden çözümler sunulabilir. Arabirimler, çoklu mirasın avantajlarını karmaşıklık olmaksızın sağlayarak kodun okunabilirliğini ve sürdürülebilirliğini artırır. Yeni özelliklerle birlikte, C# geliştiricileri çok daha esnek ve güçlü kodlar yazabilir.
