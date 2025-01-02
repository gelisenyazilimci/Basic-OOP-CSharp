# C# Upcasting ve Downcasting

C# dilinde **upcasting** ve **downcasting**, nesne yönelimli programlamada (OOP) sıklıkla kullanılan tür dönüştürme işlemleridir. Bu işlemler, türetilmiş (derived) sınıflar ile temel (base) sınıflar arasında veri türü dönüşümünü sağlar. Bu makalede, upcasting ve downcasting'in ne olduğunu, nasıl kullanıldığını ve bu işlemlerde dikkat edilmesi gereken noktaları detaylı bir şekilde inceleyeceğiz.

---

## Upcasting Nedir?

**Upcasting**, türetilmiş bir sınıfın örneğinin, temel sınıf türüne dönüştürülmesidir. Bu işlem, veri kaybı olmaksızın güvenli bir şekilde gerçekleşir ve genellikle örtük (implicit) olarak yapılır.

### Örnek:
```csharp
class Hayvan
{
    public void SesCikar()
    {
        Console.WriteLine("Hayvan ses çıkarıyor.");
    }
}

class Kopek : Hayvan
{
    public void Havla()
    {
        Console.WriteLine("Köpek havlıyor.");
    }
}

class Program
{
    static void Main()
    {
        Kopek kopek = new Kopek();
        Hayvan hayvan = kopek; // Upcasting

        hayvan.SesCikar();
        // hayvan.Havla(); // Derleme hatası: Hayvan türünde Havla metodu yok.
    }
}
```

### Açıklama:
- `kopek` örneği, `Hayvan` türüne dönüştürülür.
- Bu dönüşüm sonucunda yalnızca `Hayvan` sınıfının üyelerine erişim sağlanır.

### Avantajları:
1. **Polimorfizm**: Temel sınıf türündeki bir koleksiyonda farklı türetilmiş sınıfların nesneleri tutulabilir.
2. **Basitlik**: Yalnızca temel sınıfın ortak davranışları üzerinde işlem yapılması sağlanır.

---

## Downcasting Nedir?

**Downcasting**, temel sınıf türündeki bir nesnenin türetilmiş sınıf türüne dönüştürülmesidir. Bu işlem açık (explicit) olarak yapılır ve çalışma zamanında hataya yol açma riski taşır.

### Örnek:
```csharp
class Hayvan
{
    public void SesCikar()
    {
        Console.WriteLine("Hayvan ses çıkarıyor.");
    }
}

class Kopek : Hayvan
{
    public void Havla()
    {
        Console.WriteLine("Köpek havlıyor.");
    }
}

class Program
{
    static void Main()
    {
        Hayvan hayvan = new Kopek(); // Upcasting
        Kopek kopek = (Kopek)hayvan; // Downcasting

        kopek.SesCikar();
        kopek.Havla();
    }
}
```

### Açıklama:
- `hayvan` nesnesi, `Kopek` türüne açıkça dönüştürülür.
- Bu işlem, türetilmiş sınıfın üyelerine erişim sağlar.

### Dikkat Edilmesi Gerekenler:
1. **InvalidCastException**: Eğer `hayvan` nesnesi gerçekte `Kopek` türünde değilse, çalışma zamanında `InvalidCastException` hatası oluşur.
2. **Kontrol Gerekliliği**: `is` veya `as` anahtar kelimeleri kullanılarak tür kontrolü yapılması önerilir.

#### Tür Kontrolü ile Güvenli Downcasting:
```csharp
if (hayvan is Kopek kopek)
{
    kopek.Havla();
}
else
{
    Console.WriteLine("Nesne Kopek türünde değil.");
}
```

---

## `is` ve `as` Anahtar Kelimeleri

### `is` Anahtar Kelimesi
Bir nesnenin belirli bir türe sahip olup olmadığını kontrol eder. Dönüştürme işlemi için kullanışlıdır.

```csharp
if (hayvan is Kopek)
{
    Kopek kopek = (Kopek)hayvan;
    kopek.Havla();
}
```

### `as` Anahtar Kelimesi
Bir nesneyi belirtilen türe dönüştürür. Eğer dönüşüm başarısız olursa, `null` döner.

```csharp
Kopek kopek = hayvan as Kopek;
if (kopek != null)
{
    kopek.Havla();
}
else
{
    Console.WriteLine("Dönüştürme başarısız.");
}
```

---

## Upcasting ve Downcasting Arasındaki Farklar

| **Özellik**         | **Upcasting**                          | **Downcasting**                        |
|---------------------|----------------------------------------|----------------------------------------|
| **Yön**             | Türetilmiş sınıftan temel sınıfa        | Temel sınıftan türetilmiş sınıfa        |
| **Güvenlik**        | Güvenlidir (implicit)                  | Çalışma zamanı hatasına yol açabilir (explicit) |
| **Kullanım Kolaylığı** | Örtük olarak yapılabilir              | Açıkça belirtilmelidir                 |

---

## C#'ın Son Özellikleri ve Casting
C# dilinin son sürümleri, tür dönüştürmelerinde daha güvenli ve okunabilir bir yapı sunmayı hedeflemektedir. Bunlardan bazıları şunlardır:

### Pattern Matching (C# 7.0 ve Sonrası)
`is` anahtar kelimesi ile birlikte kullanılan pattern matching, daha kısa ve okunabilir bir tür kontrolü sağlar.

```csharp
if (hayvan is Kopek kopek)
{
    kopek.Havla();
}
```

### Switch Expressions (C# 8.0 ve Sonrası)
Casting işlemleri `switch` ifadeleri ile daha fonksiyonel bir şekilde yapılabilir.

```csharp
switch (hayvan)
{
    case Kopek kopek:
        kopek.Havla();
        break;
    case null:
        Console.WriteLine("Nesne null değerinde.");
        break;
    default:
        Console.WriteLine("Bilinmeyen tür.");
        break;
}
```

---

## Sonuç
Upcasting ve downcasting, nesne yönelimli programlama paradigmasında veri türleri arasında dönüşüm yapmanın temel yöntemleridir. C# dilinde, bu işlemler güvenli ve etkili bir şekilde gerçekleştirilebilir. Ancak, downcasting işlemleri sırasında oluşabilecek hatalara karşı dikkatli olunmalı ve tür kontrolleri yapılmalıdır. Modern C# özellikleri, tür dönüştürmelerini daha okunabilir ve güvenli hale getirmiştir.
