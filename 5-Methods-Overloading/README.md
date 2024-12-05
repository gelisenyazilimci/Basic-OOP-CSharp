# C# Dilinde Metot Aşırı Yükleme (Method Overloading)

## Giriş
C# dilinde metot aşırı yükleme, aynı sınıf içinde birden fazla metotun aynı ismi paylaşmasına olanak tanır ancak aşağıdaki açılardan farklılık gösterir:

- Parametre sayısı
- Parametre türü
- Parametre sırası

Bu özellik, bir metot ismi için birden fazla davranış tanımlayarak kod okunabilirliğini ve esnekliğini artırır.

---

## Metot Aşırı Yükleme Hakkında Temel Noktalar

### 1. **Aynı Metot İsmi, Farklı Parametreler**
Metotların aynı isme sahip olması gerekir ancak parametre listesinde farklılık göstermelidir.

### 2. **Dönüş Türü Önemli Değil**
Metotların dönüş türü aşırı yükleme için dikkate alınmaz. Parametre listesi belirleyici faktördür.

### 3. **Derleme Zamanında Polimorfizm**
Aşırı yükleme, metot çağrısı sırasında sağlanan argümanlara göre derleme zamanında çözülür.

---

## Sözdizimi ve Örnekler

### Basit Bir Örnek
İşte C# dilinde metot aşırı yükleme örneği:

```csharp
using System;

class Calculator
{
    // İki tamsayıyı toplamak için metot
    public int Add(int a, int b)
    {
        return a + b;
    }

    // Üç tamsayıyı toplamak için aşırı yüklenmiş metot
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    // İki ondalık sayıyı toplamak için aşırı yüklenmiş metot
    public double Add(double a, double b)
    {
        return a + b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();

        // Add(int, int) çağrılır
        Console.WriteLine(calculator.Add(5, 10));  // Çıktı: 15

        // Add(int, int, int) çağrılır
        Console.WriteLine(calculator.Add(5, 10, 15));  // Çıktı: 30

        // Add(double, double) çağrılır
        Console.WriteLine(calculator.Add(5.5, 10.5));  // Çıktı: 16.0
    }
}
```

### Ayrıntılı Açıklama
1. **İki Tamsayı Parametreli Metot:**
   ```csharp
   public int Add(int a, int b)
   {
       return a + b;
   }
   ```
   Bu metot, iki tamsayı alır ve toplamlarını döndürür.

2. **Üç Tamsayı Parametreli Aşırı Yüklenmiş Metot:**
   ```csharp
   public int Add(int a, int b, int c)
   {
       return a + b + c;
   }
   ```
   Bu metot, üç tamsayının toplamını hesaplamak için işlevselliği genişletir.

3. **İki Ondalık Sayı Parametreli Aşırı Yüklenmiş Metot:**
   ```csharp
   public double Add(double a, double b)
   {
       return a + b;
   }
   ```
   Bu metot, parametre türlerini değiştirerek ondalık sayılarla çalışır.

---

### Parametre Sırasına Göre Aşırı Yükleme
Parametrelerin sırası da aşırı yüklenmiş metotları ayırt etmek için kullanılabilir:

```csharp
class Display
{
    public void Show(string message, int number)
    {
        Console.WriteLine($"Mesaj: {message}, Sayı: {number}");
    }

    public void Show(int number, string message)
    {
        Console.WriteLine($"Sayı: {number}, Mesaj: {message}");
    }
}

class Program
{
    static void Main()
    {
        Display display = new Display();

        display.Show("Merhaba", 42);  // Çıktı: Mesaj: Merhaba, Sayı: 42
        display.Show(42, "Merhaba");  // Çıktı: Sayı: 42, Mesaj: Merhaba
    }
}
```

---

### Aşırı Yükleme Sırasındaki Yaygın Hatalar

#### 1. **Belirsiz Metot Çağrısı**
Eğer iki metot benzer parametre listesine sahipse ve yalnızca dönüş türü farklıysa, bu bir derleme hatasına neden olur.

   ```csharp
   public int Multiply(int a, int b) { return a * b; }
   public double Multiply(int a, int b) { return a * b; }  // Hata: Yinelenen tanım
   ```

#### 2. **Varsayılan Parametrelerin Kullanımı**
Varsayılan parametrelerle aşırı yükleme belirsizlik yaratabilir:

   ```csharp
   public void Print(string message, int number = 10) { }
   public void Print(string message) { }  // Hata: Belirsiz
   ```

---

## İleri Konseptler

### Yapıcı Aşırı Yükleme (Constructor Overloading)
C# dilinde yapıcılar da aşırı yüklenebilir:

```csharp
class Person
{
    public string Name;
    public int Age;

    // Varsayılan yapıcı
    public Person()
    {
        Name = "Bilinmiyor";
        Age = 0;
    }

    // Bir parametre alan aşırı yüklenmiş yapıcı
    public Person(string name)
    {
        Name = name;
        Age = 0;
    }

    // İki parametre alan aşırı yüklenmiş yapıcı
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person();
        Person person2 = new Person("Alice");
        Person person3 = new Person("Bob", 30);

        Console.WriteLine(person1.Name);  // Çıktı: Bilinmiyor
        Console.WriteLine(person2.Name);  // Çıktı: Alice
        Console.WriteLine(person3.Name);  // Çıktı: Bob
    }
}
```

---

## Metot Aşırı Yükleme İçin En İyi Uygulamalar

1. **Tutarlılığı Koruyun:** Aşırı yüklenmiş metotların mantıksal olarak benzer bir amaca hizmet ettiğinden emin olun.

2. **Belirsizlikten Kaçının:** Hem derleyici hem de geliştirici için kafa karışıklığını önlemek adına belirgin parametre listeleri kullanın.

3. **Aşırı Yüklemeleri Belgeleyin:** Her aşırı yüklemenin amacını açıkça belgelerle ifade edin.

---

## Özet
Metot aşırı yükleme, aynı isimde ancak farklı parametre listelerine sahip birden fazla metot tanımlamaya olanak tanıyan güçlü bir C# özelliğidir. Kod esnekliğini ve okunabilirliğini artırırken, daha temiz ve yeniden kullanılabilir kod yazmayı sağlar. En iyi uygulamaları izleyerek yaygın hatalardan kaçınabilir ve metot aşırı yüklemenin avantajlarını en üst düzeye çıkarabilirsiniz.