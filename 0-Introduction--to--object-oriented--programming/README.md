# C# - Nesne Yönelimli Programlamaya (OOP) Giriş

Nesne Yönelimli Programlama (Object-Oriented Programming, OOP), modern yazılım geliştirme süreçlerinde yaygın olarak kullanılan bir programlama paradigmasıdır. OOP, yazılımı daha modüler, okunabilir ve bakım yapılabilir hale getirir. Bu rehberde, C# dilinde OOP'nin temel kavramlarını ve bileşenlerini öğrenmeye başlayacağız.

---

## **1. OOP Nedir?**

Nesne Yönelimli Programlama, gerçek dünyadaki nesneleri yazılımda modellemek için kullanılan bir programlama yaklaşımıdır. Bu yaklaşım, yazılımı şu kavramlar etrafında şekillendirir:

- **Nesneler (Objects):** Veri ve davranışları bir arada tutan yapılardır.
- **Sınıflar (Classes):** Nesnelerin şablonlarıdır. Bir nesnenin nasıl oluşturulacağını ve hangi özelliklere sahip olacağını belirler.

### **OOP'nin Avantajları:**

- **Kodun yeniden kullanılabilirliği:** Aynı kodu farklı projelerde veya bölümlerde yeniden kullanabilirsiniz.
- **Bakımı kolay:** Modüler yapı sayesinde hata ayıklama ve geliştirme süreçleri daha kolaydır.
- **Gerçek dünyayı modelleme:** Gerçek dünya problemlerini yazılımda daha doğal bir şekilde modellemenize olanak tanır.

---

## **2. OOP'nin Temel Kavramları**

### **2.1. Sınıflar (Classes)**

Bir sınıf, nesnelerin oluşturulması için bir şablondur. Örneğin, bir "Araba" sınıfı şu özelliklere ve davranışlara sahip olabilir:

```csharp
class Araba
{
    // Özellikler (Fields)
    public string Marka;
    public string Model;
    public int Yil;

    // Davranışlar (Methods)
    public void BilgiGoster()
    {
        Console.WriteLine($"Marka: {Marka}, Model: {Model}, Yıl: {Yil}");
    }
}
```

### **2.2. Nesneler (Objects)**

Bir sınıftan oluşturulan örneklerdir. Örneğin, yukarıdaki "Araba" sınıfından bir nesne oluşturabilirsiniz:

```csharp
Araba araba1 = new Araba();
araba1.Marka = "Toyota";
araba1.Model = "Corolla";
araba1.Yil = 2020;

araba1.BilgiGoster();
```

### **2.3. Kapsülleme (Encapsulation)**

Kapsülleme, sınıfın iç detaylarını dış dünyadan gizlemeyi amaçlar. Bu, genellikle **özel erişim belirleyicileri (private)** ve **özellikler (properties)** ile sağlanır:

```csharp
class Araba
{
    private string _marka;

    public string Marka
    {
        get { return _marka; }
        set { _marka = value; }
    }
}
```

### **2.4. Kalıtım (Inheritance)**

Kalıtım, bir sınıfın başka bir sınıftan özellikleri ve yöntemleri devralmasını sağlar. Bu, kodun yeniden kullanılabilirliğini artırır.

```csharp
class Arac
{
    public string Renk;
    public void HareketEt()
    {
        Console.WriteLine("Araç hareket ediyor...");
    }
}

class Araba : Arac
{
    public int KapıSayisi;
}
```

### **2.5. Çok Biçimlilik (Polymorphism)**

Çok biçimlilik, aynı yöntemin farklı şekillerde çalışmasını sağlar. Bu genellikle **metot geçersiz kılma (method overriding)** ile gerçekleştirilir.

```csharp
class Hayvan
{
    public virtual void SesCikar()
    {
        Console.WriteLine("Hayvan bir ses çıkarıyor.");
    }
}

class Kopek : Hayvan
{
    public override void SesCikar()
    {
        Console.WriteLine("Hav! Hav!");
    }
}
```

### **2.6. Soyutlama (Abstraction)**

Soyutlama, yalnızca önemli detayları ortaya çıkararak gereksiz detayları gizlemeyi amaçlar. Bu, **soyut sınıflar (abstract classes)** veya **arayüzler (interfaces)** kullanılarak sağlanabilir.

```csharp
abstract class Sekil
{
    public abstract double AlanHesapla();
}

class Dikdortgen : Sekil
{
    public double En;
    public double Boy;

    public override double AlanHesapla()
    {
        return En * Boy;
    }
}
```

---

## **3. Örnek Proje**

Aşağıda, öğrendiğimiz kavramları birleştirerek bir örnek proje oluşturduk:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // Araba nesnesi oluşturma
        Araba araba = new Araba
        {
            Marka = "Honda",
            Model = "Civic",
            Yil = 2018
        };

        araba.BilgiGoster();

        // Kalıtım örneği
        Kopek kopek = new Kopek();
        kopek.SesCikar();
    }
}
```

---

## **4. Sonuç**

Bu rehberde, C# ile Nesne Yönelimli Programlamanın temel kavramlarını öğrendiniz. OOP'yi anlamak, yazılım geliştirme kariyerinizde önemli bir adım olacaktır. Bol bol pratik yapmayı ve öğrendiklerinizi küçük projelerde uygulamayı unutmayın.

**Unutmayın:** OOP, sadece bir başlangıçtır. Daha ileri seviyelere geçmek için bu temelleri sağlam bir şekilde öğrenmelisiniz!
