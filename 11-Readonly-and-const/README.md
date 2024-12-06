# C#'da `readonly` ve `const` Anahtar Kelimeleri

## Giriş
C# dilinde `readonly` ve `const` anahtar kelimeleri, sabit değerler veya değiştirilemeyen veriler tanımlamak için kullanılır. Ancak, her iki anahtar kelimenin kullanımı ve çalışma şekli birbirinden farklıdır. Bu dokümanda, `readonly` ve `const` arasındaki farkları, nasıl kullanıldıklarını ve hangi durumlarda tercih edileceğini ayrıntılı bir şekilde inceleyeceğiz.

---

## `const` Anahtar Kelimesi

### Tanım
`const`, derleme zamanında sabit olan ve bir kez tanımlandıktan sonra değiştirilemeyen değerler oluşturmak için kullanılır.

### Özellikler
- Derleme zamanında sabittir.
- `const` ile tanımlanan değer **mutlak sabittir**, yani derleme sırasında değeri tamamen sabitlenir.
- `const` yalnızca **primitive türler** (int, float, char, vb.) veya `string` gibi basit türlerle kullanılabilir.
- Varsayılan olarak `static` olarak davranır, bu nedenle doğrudan sınıf adı üzerinden erişilir.

### Söz Dizimi
```csharp
class Program
{
    public const double Pi = 3.14159; // Sabit bir değer

    static void Main(string[] args)
    {
        Console.WriteLine($"Pi sayısı: {Pi}");
    }
}
```

### Önemli Notlar
- `const` değişkeni tanımlanırken **değer atanması zorunludur**.
- Değeri derleme zamanında sabitlenir ve çalıştırma sırasında değiştirilemez.
- Çalışma zamanında hesaplanan değerler `const` olarak atanamaz.

#### Hata Örneği
```csharp
public const int MyValue = GetValue(); // HATA: Çalışma zamanında hesaplanan bir değer atanamaz.

public static int GetValue() {
    return 42;
}
```

---

## `readonly` Anahtar Kelimesi

### Tanım
`readonly`, yalnızca bir kez atanabilen, ancak çalışma zamanında bir kez değiştirilebilen değerler oluşturmak için kullanılır.

### Özellikler
- Çalışma zamanında değer atanabilir.
- `readonly` alanına değer yalnızca **sınıfın yapıcısında (constructor)** veya alan tanımında atanabilir.
- `readonly`, hem basit türler hem de karmaşık türler (örneğin, nesneler) ile kullanılabilir.
- Sabit değerler yerine **duruma bağlı** (çalışma zamanı) değerler için uygundur.

### Söz Dizimi
```csharp
class Program
{
    public readonly int MyValue;

    public Program(int value)
    {
        MyValue = value; // Değer constructor'da atanabilir
    }

    static void Main(string[] args)
    {
        Program program = new Program(42);
        Console.WriteLine($"MyValue: {program.MyValue}");
    }
}
```

### Önemli Notlar
- `readonly` değişkeni, **yapıcı dışında değiştirilemez**.
- Bir `readonly` alanı, çalışma zamanında değer alabilir ve bu değer daha sonra değiştirilemez.
- Değeri çalışma zamanında belirlemek gerektiğinde kullanılır.

#### Karmaşık Türlerle Kullanımı
```csharp
class Example
{
    public readonly DateTime CreationDate;

    public Example()
    {
        CreationDate = DateTime.Now; // Çalışma zamanında atanır
    }
}
```

---

## `readonly` ve `const` Karşılaştırması

| Özellik                   | `const`                                 | `readonly`                              |
|---------------------------|-----------------------------------------|-----------------------------------------|
| **Değer Atama Zamanı**   | Derleme zamanında atanır               | Çalışma zamanında atanabilir            |
| **Atanabilirlik**         | Sadece tanımlama sırasında             | Yapıcıda veya tanımlama sırasında       |
| **Kullanıldığı Yerler**   | Basit türler ve `string`               | Basit ve karmaşık türler                |
| **Statiklik**             | Varsayılan olarak `static`             | Varsayılan olarak `instance`            |
| **Hedef Kullanım**        | Sabit, değişmeyecek değerler           | Duruma bağlı, çalışma zamanı değerleri  |

---

## Hangi Durumda Hangi Anahtar Kelime Kullanılmalı?

1. **Sabit Değerler için (`const`):**
    - Eğer bir değerin **hiçbir zaman değişmeyeceğinden** eminsek ve bu değer derleme zamanında biliniyorsa `const` kullanın.
    - Örnek: Matematiksel sabitler, sabit dize değerleri.

   ```csharp
   public const string AppName = "MyApplication";
   public const double Gravity = 9.81;
   ```

2. **Çalışma Zamanı Sabitleri için (`readonly`):**
    - Eğer bir değerin **çalışma zamanında atanması** gerekiyorsa ve sonrasında değişmeyecekse `readonly` kullanın.
    - Örnek: Kullanıcıdan alınan başlangıç değerleri, çalışma zamanında belirlenen tarih ve saat.

   ```csharp
   public readonly DateTime StartTime;

   public Program()
   {
       StartTime = DateTime.Now;
   }
   ```

---

## Özet
- `const`, derleme zamanında sabit değerler için uygundur ve performans açısından daha hızlıdır.
- `readonly`, çalışma zamanında atanabilen ancak bir kez tanımlandıktan sonra değiştirilemeyen değerler için kullanılır.
- Hangi anahtar kelimenin kullanılacağı, değişkenin kullanım amacına ve değer atama zamanına bağlıdır.

Her iki anahtar kelime de kodun okunabilirliğini ve güvenilirliğini artırır. Gereksinimlerinize uygun olanı seçerek daha güvenli ve sürdürülebilir bir kod yazabilirsiniz.

