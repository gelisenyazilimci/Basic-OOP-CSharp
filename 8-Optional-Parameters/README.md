# C# Dilinde Opsiyonel Parametreler (Optional Parameters)

## Giriş
Opsiyonel parametreler, bir metot çağrılırken bazı parametrelerin belirtilmemesine izin verir. C# dilinde, bir parametreye varsayılan bir değer atayarak, o parametreyi "opsiyonel" hâle getirebilirsiniz. Eğer çağrıda bu parametre belirtilmezse, metot bu parametre için belirtilen varsayılan değeri kullanır.

Bu özellik, metotların daha esnek ve okunabilir olmasını sağlar ve aynı işlevi gören birden fazla aşırı yüklenmiş metot tanımlama ihtiyacını azaltır.

---

## Sözdizimi
Opsiyonel bir parametre tanımlamak için, parametreye bir varsayılan değer atanır:

```csharp
return_type MethodName(parameter1, type parameter2 = default_value)
```

- `parameter2 = default_value`: Varsayılan değer atanan parametre. Bu parametre opsiyonel hâle gelir.

> **Not:** Opsiyonel parametreler, zorunlu (required) parametrelerden sonra tanımlanmalıdır.

---

## Örnekler

### 1. Basit Bir Örnek

```csharp
class Calculator
{
    public int Add(int a, int b = 10)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();

        // İkinci parametre belirtilmez
        Console.WriteLine(calculator.Add(5)); // Çıktı: 15

        // İkinci parametre belirtilir
        Console.WriteLine(calculator.Add(5, 20)); // Çıktı: 25
    }
}
```
Bu örnekte, `b` parametresi için varsayılan değer `10` olarak tanımlanmıştır. Eğer çağrıda `b` belirtilmezse, bu değer kullanılır.

---

### 2. Birden Fazla Opsiyonel Parametre

Birden fazla opsiyonel parametre tanımlanabilir. Ancak, parametrelerin sırası önemlidir.

```csharp
class Printer
{
    public void Print(string message, int repeat = 1, bool uppercase = false)
    {
        for (int i = 0; i < repeat; i++)
        {
            if (uppercase)
            {
                Console.WriteLine(message.ToUpper());
            }
            else
            {
                Console.WriteLine(message);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Printer printer = new Printer();

        // Varsayılan değerlerle çağrılır
        printer.Print("Merhaba"); // Çıktı: Merhaba

        // `repeat` belirtilir, `uppercase` varsayılan
        printer.Print("Merhaba", 3); // Çıktı: Merhaba (3 kez)

        // Tüm parametreler belirtilir
        printer.Print("Merhaba", 2, true); // Çıktı: MERHABA (2 kez)
    }
}
```
Bu örnekte, `repeat` ve `uppercase` parametreleri varsayılan değerlere sahiptir. Çağrı sırasında yalnızca gereken parametreler belirtilir.

---

### 3. Opsiyonel Parametrelerin Sırası
Zorunlu parametreler, opsiyonel parametrelerden önce tanımlanmalıdır. Aksi takdirde derleme hatası alınır.

#### Hatalı Kullanım:
```csharp
// Bu kod derlenmez
public void Method(int optional = 5, string required)
{
    // Kodlar
}
```

#### Doğru Kullanım:
```csharp
public void Method(string required, int optional = 5)
{
    // Kodlar
}
```

---

## Named Arguments ile Birlikte Kullanım
Opsiyonel parametreler, named arguments (isimlendirilmiş argümanlar) ile birlikte kullanıldığında daha esnek hâle gelir.

```csharp
class Greeting
{
    public void SayHello(string name = "Misafir", string greeting = "Merhaba")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }
}

class Program
{
    static void Main()
    {
        Greeting greeting = new Greeting();

        // Varsayılan değerler kullanılır
        greeting.SayHello(); // Çıktı: Merhaba, Misafir!

        // Sadece 'name' belirtilir
        greeting.SayHello(name: "Ahmet"); // Çıktı: Merhaba, Ahmet!

        // Her iki parametre de belirtilir
        greeting.SayHello(name: "Ayşe", greeting: "Selam"); // Çıktı: Selam, Ayşe!
    }
}
```
Named arguments sayesinde, opsiyonel parametrelerin sırasını değiştirmek mümkün olur.

---

## Kullanım Amacı
Opsiyonel parametreler, özellikle aşağıdaki durumlarda faydalıdır:

1. **Aşırı Yükleme Azaltma:** Aynı işlemi gerçekleştiren birden fazla metot yerine tek bir metot ile esneklik sağlanır.
2. **Kodun Okunabilirliğini Artırma:** Varsayılan değerlerle daha az karmaşık metot çağrıları yapılabilir.
3. **Daha Az Kod Tekrarı:** Birden fazla aşırı yükleme (overload) metodu yazma ihtiyacını azaltır.

---

## Kısıtlamalar
1. **Sıralama Önemlidir:** Opsiyonel parametreler, zorunlu parametrelerden sonra tanımlanmalıdır.
2. **Mantıksal Karmaşıklık:** Çok fazla opsiyonel parametre kullanımı, metot çağrılarını kafa karıştırıcı hâle getirebilir.

---

## Özet
Opsiyonel parametreler, metotlara varsayılan değerler tanımlayarak daha esnek ve okunabilir bir kod yazılmasını sağlar. Özellikle birden fazla aşırı yükleme yazmak yerine bu yöntem tercih edilebilir. Ancak, parametre sıralamasına dikkat edilmesi ve gereğinden fazla opsiyonel parametre kullanılmaması önemlidir.
