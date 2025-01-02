# C# Abstract Class (Soyut Sınıflar)

C# dilinde **abstract class (soyut sınıf)**, nesne yönelimli programlamanın (OOP) temel kavramlarından biridir. Soyut sınıflar, ortak davranışları tanımlamak ve bu davranışları alt sınıflara aktarmak için kullanılır. Ancak soyut sınıfların kendisi üzerinden nesne oluşturulamaz. Bu yazıda, soyut sınıfların ne olduğunu, nasıl çalıştığını ve C# dilindeki kullanımını detaylı bir şekilde inceleyeceğiz.

---

## Abstract Class Nedir?

Soyut sınıf, diğer sınıflar için bir şablon görevi görür. Bir sınıfı soyut yapmak için `abstract` anahtar kelimesi kullanılır. Soyut sınıflar aşağıdaki özelliklere sahiptir:

1. **Nesnesi oluşturulamaz:** Soyut sınıflardan doğrudan nesne oluşturulamaz. Ancak referans noktası olarak kullanılabilir.
2. **Soyut metotlar içerebilir:** Gövdesiz (implementasyonsuz) metotlar tanımlanabilir ve bu metotlar alt sınıflar tarafından geçersiz kılınmalıdır.
3. **Tamamlanmış metotlar içerebilir:** Soyut sınıflar, gövdesi olan metotlar da içerebilir.
4. **Erişim belirleyicisi esnekliği:** Soyut sınıflardaki üyelerin erişim belirleyicisi, gereksinimlere göre ayarlanabilir. Bu esneklik, alt sınıflara kalıtım yoluyla erişim sağlar.

---

## Neden Abstract Class Nesnesi Oluşturulamaz?

Soyut sınıflar, eksik veya tamamlanmamış bir yapıyı temsil eder. Yani soyut bir sınıfın tüm özellikleri ve davranışları tamamen tanımlanmış değildir. Bu nedenle soyut bir sınıf üzerinden nesne oluşturmak mantıksızdır.

Ancak soyut sınıflar, türetilmiş sınıfların referansı olarak kullanılabilir. Bu, polimorfizm (çok biçimlilik) prensibiyle uyumludur.

### Örnek:
```csharp
abstract class Hayvan
{
    public abstract void SesCikar();
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
        Hayvan hayvan = new Kedi(); // Referans noktası olarak kullanılır
        hayvan.SesCikar(); // Çıktı: Miyav!

        // Hayvan hayvan2 = new Hayvan(); // HATA: Soyut sınıflardan nesne oluşturulamaz
    }
}
```

---

## Erişim Belirleyicisi Soyut Sınıflarda Neden Pek Önemli Değildir?

Soyut sınıflarda erişim belirleyicileri, türetilmiş sınıfların ihtiyaçlarına göre ayarlanabilir. Bir soyut sınıfın yalnızca türetilmiş sınıflar tarafından kullanılmasını istiyorsanız, üyeleri `protected` olarak tanımlayabilirsiniz. Ancak daha geniş erişim gerekiyorsa `public` kullanılabilir.

Soyut sınıfların doğası gereği, bu sınıflar genellikle alt sınıflara hizmet etmek için tasarlandığından, erişim belirleyicisi genellikle esnek bırakılır.

### Örnek:
```csharp
abstract class Sekil
{
    protected abstract double AlanHesapla(); // Alt sınıflar kullanabilir

    public void Yazdir()
    {
        Console.WriteLine($"Alan: {AlanHesapla()}");
    }
}

class Daire : Sekil
{
    private double yaricap;

    public Daire(double yaricap)
    {
        this.yaricap = yaricap;
    }

    protected override double AlanHesapla()
    {
        return Math.PI * yaricap * yaricap;
    }
}
```

---

## Abstract ve Normal Sınıf Karşılaştırması

Normal sınıflar, eksiksiz bir davranışı temsil eder ve doğrudan nesne oluşturmak için kullanılabilir. Ancak soyut sınıflar, yalnızca türetilmiş sınıflar için bir temel sağlar.

### Örnek:

**Normal Sınıf:**
```csharp
class Arac
{
    public void Calistir()
    {
        Console.WriteLine("Araç çalışıyor.");
    }
}

class Program
{
    static void Main()
    {
        Arac arac = new Arac();
        arac.Calistir(); // Çıktı: Araç çalışıyor.
    }
}
```

**Abstract Sınıf:**
```csharp
abstract class Arac
{
    public abstract void Calistir();
}

class Araba : Arac
{
    public override void Calistir()
    {
        Console.WriteLine("Araba çalışıyor.");
    }
}

class Program
{
    static void Main()
    {
        Arac arac = new Araba();
        arac.Calistir(); // Çıktı: Araba çalışıyor.
    }
}
```

---

## Soyut Metot ve Hata Örneği

Eğer bir soyut sınıf, türetilmiş sınıfta geçersiz kılınmazsa derleme hatası alınır. Bu durum, soyut metotların türetilmiş sınıflar tarafından mutlaka uygulanmasını zorunlu kılar.

### Örnek:

```csharp
abstract class Arac
{
    public abstract void Calistir();
}

class Otobus : Arac
{
    // public override void Calistir() eksik, hata alırız
}

class Program
{
    static void Main()
    {
        Otobus otobus = new Otobus(); // HATA: 'Otobus' sınıfı 'Calistir' metodunu uygulamalıdır
    }
}
```

---

## Abstract Class Kullanımı Ne Zaman Tercih Edilmeli?

1. **Ortak Davranışlar Tanımlamak İçin:** Birden fazla sınıfın paylaşacağı ortak özellikler veya metotlar tanımlanmak istendiğinde.
2. **Eksik Metotların Belirlenmesi İçin:** Alt sınıfların mutlaka uygulaması gereken metotları zorunlu kılmak için.
3. **Polimorfizm Sağlamak İçin:** Alt sınıfları tek bir tür altında kullanmak istendiğinde.

---

## Sonuç

C# soyut sınıflar, nesne yönelimli programlama projelerinde kodun yeniden kullanılabilirliğini artırır ve daha iyi bir yapı sağlar. Soyut sınıfların kendisinden nesne oluşturulamaz, ancak referans noktası olarak kullanılabilir. Erişim belirleyicileri esneklik sunar ve türetilmiş sınıfların gereksinimlerine göre ayarlanabilir. Doğru bir şekilde kullanıldığında, soyut sınıflar yazılım tasarımını daha tutarlı ve sürdürülebilir hale getirir.
