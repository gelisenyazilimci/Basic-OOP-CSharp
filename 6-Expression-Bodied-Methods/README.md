# C# Dilinde Expression-Bodied Methods

## Giriş
Expression-bodied methods (ifade gövdeli metotlar), C# dilinde bir metot veya özellik için daha kısa ve temiz bir sözdizimi sunar. Bu özellik, genellikle tek bir ifade döndüren veya bir ifade değerlendiren metotlar için kullanılır. Expression-bodied methods, `=>` (lambda operatörü) kullanılarak tanımlanır ve özellikle kodun okunabilirliğini artırır.

---

## Expression-Bodied Methods'un Kullanımı

### Sözdizimi
Bir expression-bodied method şu şekilde tanımlanır:

```csharp
return_type MethodName(parameters) => expression;
```

- `return_type`: Metodun döndürdüğü veri tipi (örneğin, `int`, `string`, `void`).
- `MethodName`: Metodun adı.
- `parameters`: Metodun aldığı parametreler.
- `expression`: Dönüş değeri veya çalıştırılacak tek bir ifade.

---

## Örnekler

### 1. Basit Bir Örnek
```csharp
class Calculator
{
    public int Square(int number) => number * number;
}

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        Console.WriteLine(calculator.Square(5)); // Çıktı: 25
    }
}
```
Bu örnekte, `Square` metodu bir sayının karesini döndürür. Geleneksel yöntemle metodu yazmak yerine, tek satırlık bir ifade olarak tanımlanmıştır.

### 2. Void Dönüşlü Expression-Bodied Method
Bir metot herhangi bir değer döndürmüyorsa (void dönüş türüne sahipse), şu şekilde yazılabilir:

```csharp
class Logger
{
    public void Log(string message) => Console.WriteLine($"Log: {message}");
}

class Program
{
    static void Main()
    {
        Logger logger = new Logger();
        logger.Log("Başarılı bir işlem tamamlandı"); // Çıktı: Log: Başarılı bir işlem tamamlandı
    }
}
```

### 3. Expression-Bodied Properties
Expression-bodied metotlar, özellikler (properties) için de kullanılabilir:

```csharp
class Circle
{
    public double Radius { get; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    // Expression-bodied property
    public double Area => Math.PI * Radius * Radius;
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle(5);
        Console.WriteLine(circle.Area); // Çıktı: 78.53981633974483
    }
}
```
Bu örnekte, `Area` özelliği için expression-bodied bir tanım kullanılmıştır.

### 4. Yapıcılar ve Yıkıcılar
C# 7.0 ve sonrasında, yapıcılar (constructors) ve yıkıcılar (destructors) için de expression-bodied sözdizimi kullanılabilir:

#### Yapıcılar:
```csharp
class Person
{
    public string Name { get; }

    public Person(string name) => Name = name;
}
```

#### Yıkıcılar:
```csharp
class Resource
{
    ~Resource() => Console.WriteLine("Kaynak serbest bırakıldı.");
}
```

---

## Neden Expression-Bodied Methods Kullanılır?
1. **Daha Temiz Kod:** Kısa ve öz ifadeler sayesinde gereksiz sözdiziminden kaçınılır.
2. **Okunabilirlik:** Tek satırlık metodlar için daha okunabilir bir yapı sunar.
3. **Kod Tekrarını Azaltır:** Metodun yalnızca bir ifade içerdiği durumlarda standart metot tanımına göre daha kısa bir yazım sunar.

---

## Geleneksel ve Expression-Bodied Yöntemlerin Karşılaştırması

### Geleneksel Yöntem:
```csharp
class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}
```

### Expression-Bodied Yöntem:
```csharp
class Calculator
{
    public int Add(int a, int b) => a + b;
}
```

Geleneksel yönteme kıyasla, expression-bodied yöntem daha kısa ve anlaşılırdır.

---

## Kısıtlamalar
1. **Tek Bir İfade Olmalı:** Expression-bodied methods yalnızca tek bir ifade içerebilir. Birden fazla işlem gerekiyorsa, geleneksel metot kullanılmalıdır.
2. **Daha Az Esnek:** Kompleks mantıklar için uygun değildir.

---

## Özet
Expression-bodied methods, C# dilinde kısa ve basit metotlar yazmak için kullanılan pratik bir özelliktir. Kodun hem yazılmasını hem de okunmasını kolaylaştırır. Ancak, karmaşık mantıklar gerektiren durumlarda geleneksel metotlar tercih edilmelidir.

---

## En İyi Uygulamalar
- **Sade Tutun:** Expression-bodied methods, yalnızca basit mantıklar için kullanılmalıdır.
- **Kod Standartlarına Uyun:** Projede bir standarda bağlı kalarak hangi durumlarda expression-bodied methods kullanılacağı belirlenmelidir.
- **Okunabilirliği Ön Planda Tutun:** Karmaşıklık arttığında geleneksel metotlara geçin.
