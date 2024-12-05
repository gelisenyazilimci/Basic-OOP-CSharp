# C# Dilinde Yapıcı (Constructor) Parametrelerinin Doğrulanması

## Giriş
C# dilinde, bir sınıfın yapıcı (constructor) metodu, genellikle bir nesne oluşturulurken gereken başlangıç değerlerini ayarlamak için kullanılır. Ancak, yapıcıya geçilen parametrelerin geçerli ve doğru olduğundan emin olmak gerekir. Yapıcı parametre doğrulaması, hatalı ya da beklenmeyen verilerin sınıfa ulaşmasını engelleyerek güvenli ve kararlı bir kod altyapısı sağlar.

---

## Neden Doğrulama Yapılır?
1. **Hataları Önlemek:** Parametrelerin yanlış ya da beklenmeyen değerlerle kullanılmasını engeller.
2. **Kod Güvenliği:** Sınıfın durumunun (state) tutarlı kalmasını sağlar.
3. **Hata Ayıklama Kolaylığı:** Hataların yapıcı seviyesinde yakalanmasını sağlar ve erken geri bildirim verir.
4. **Daha Anlamlı Hata Mesajları:** Yanlış parametreler için net hata mesajları sağlayarak kullanıcı deneyimini iyileştirir.

---

## Kullanım Yöntemleri

### 1. `if` İfadeleri ile Doğrulama
Yapıcı parametreleri doğrulamak için `if` ifadeleri kullanabilirsiniz. Bu yöntem, küçük ve anlaşılır doğrulama mantıkları için idealdir.

#### Örnek:
```csharp
class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("İsim boş veya yalnızca boşluk olamaz.", nameof(name));
        }

        if (age < 0 || age > 120)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Yaş 0 ile 120 arasında olmalıdır.");
        }

        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Person person = new Person("Ahmet", 25);
            Console.WriteLine($"Kişi: {person.Name}, Yaş: {person.Age}");

            // Geçersiz parametre örneği
            Person invalidPerson = new Person("", -5);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}
```
Bu örnekte, `name` ve `age` parametreleri için doğrulama yapılır. Geçersiz değerler kullanıldığında bir istisna (exception) fırlatılır.

---

### 2. `Guard` Yöntemleri ile Doğrulama
`Guard` terimi, parametre doğrulamasını kolaylaştıran yardımcı yöntemleri ifade eder. Genellikle bu yöntemler, kod tekrarını azaltmak ve doğrulama mantığını daha temiz bir şekilde organize etmek için kullanılır.

#### Örnek:
```csharp
static class Guard
{
    public static void AgainstNullOrWhiteSpace(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} boş veya yalnızca boşluk olamaz.", parameterName);
        }
    }

    public static void AgainstOutOfRange(int value, int min, int max, string parameterName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} {min} ile {max} arasında olmalıdır.");
        }
    }
}

class Person
{
    public string Name { get; }
    public int Age { get; }

    public Person(string name, int age)
    {
        Guard.AgainstNullOrWhiteSpace(name, nameof(name));
        Guard.AgainstOutOfRange(age, 0, 120, nameof(age));

        Name = name;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Person person = new Person("Ayşe", 30);
            Console.WriteLine($"Kişi: {person.Name}, Yaş: {person.Age}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hata: {ex.Message}");
        }
    }
}
```
Bu örnekte, `Guard` sınıfı ile doğrulama işlemi daha okunabilir ve yeniden kullanılabilir hâle getirilmiştir.

---

### 3. Veri Doğrulama Kütüphaneleri Kullanımı
C# projelerinde veri doğrulama için üçüncü taraf kütüphaneler kullanılabilir. Örneğin, [FluentValidation](https://fluentvalidation.net/) popüler bir doğrulama kütüphanesidir.

#### FluentValidation Örneği:
```csharp
using FluentValidation;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.Name)
            .NotEmpty().WithMessage("İsim boş olamaz.")
            .MaximumLength(50).WithMessage("İsim en fazla 50 karakter uzunluğunda olmalıdır.");

        RuleFor(person => person.Age)
            .InclusiveBetween(0, 120).WithMessage("Yaş 0 ile 120 arasında olmalıdır.");
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person { Name = "", Age = 150 };

        PersonValidator validator = new PersonValidator();
        var result = validator.Validate(person);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Hata: {error.ErrorMessage}");
            }
        }
    }
}
```
Bu örnekte, FluentValidation kullanılarak parametre doğrulaması yapılmıştır.

---

## Hangi Yöntem Ne Zaman Kullanılmalı?
1. **Basit Projelerde:** `if` ifadeleri yeterlidir.
2. **Kod Tekrarını Azaltmak:** `Guard` sınıfları kullanılabilir.
3. **Karmaşık Doğrulamalar:** FluentValidation gibi kütüphaneler tercih edilebilir.

---

## Özet
Yapıcı parametre doğrulaması, kodun güvenliğini ve sağlamlığını artırır. Parametrelerin doğru şekilde kontrol edilmesi, sınıfın tutarlılığını sağlar ve potansiyel hataları önler. Doğru yöntemi seçerek, projenizin ihtiyaçlarına uygun bir doğrulama stratejisi oluşturabilirsiniz.
