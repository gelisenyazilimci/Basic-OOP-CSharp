# C#'te `nameof` Anahtar Kelimesi

## Giriş

C#'te `nameof`, bir üye, tür (type), değişken, veya herhangi bir sembolün adını string olarak döndüren bir anahtar kelimedir. `nameof`, hatalardan kaçınmak, daha okunabilir ve sürdürülebilir kod yazmak için kullanışlıdır. Bu anahtar kelime derleme zamanında (compile-time) çalışır ve performans açısından etkili bir yöntemdir.

---

## `nameof` Kullanımının Avantajları

- **Hatalardan Kaçınma:** Kodunuzda sabit stringler yerine `nameof` kullanarak hatalı referanslardan kaçınırsınız.
- **Refactoring Dostu:** Bir sembolün adını değiştirdiğinizde, `nameof` otomatik olarak güncellenir.
- **Okunabilirlik:** Hangi sembole referans verildiği açıkça görülür.
- **Performans:** Derleme zamanında çözülür, çalıştırma zamanında ek bir maliyet oluşturmaz.

---

## Temel Kullanımı

`nameof` ifadesi, bir sembolün adını string olarak döndürür.

**Sözdizimi:**
```csharp
string ad = nameof(sembol);
```

**Örnekler:**
```csharp
class Ornek
{
    public string Ad { get; set; }

    public void Yazdir()
    {
        Console.WriteLine(nameof(Ad)); // "Ad" döner
        Console.WriteLine(nameof(Yazdir)); // "Yazdir" döner
    }
}
```

---

## Detaylı Örnekler

### 1. **Özellik Adlarında Kullanım**
`nameof`, özellik adlarını dinamik olarak almak için kullanılır.

```csharp
class Kisi
{
    public string Isim { get; set; }
}

var kisi = new Kisi();
Console.WriteLine(nameof(kisi.Isim)); // Çıktı: "Isim"
```

### 2. **Metot Adlarında Kullanım**
Bir metot adını döndürmek için kullanılabilir.

```csharp
class Arac
{
    public void Calistir()
    {
        Console.WriteLine(nameof(Calistir)); // Çıktı: "Calistir"
    }
}
```

### 3. **Değişken Adlarında Kullanım**
Bir değişken adını döndürmek için kullanılabilir.

```csharp
int yas = 25;
Console.WriteLine(nameof(yas)); // Çıktı: "yas"
```

### 4. **Sınıf Adlarında Kullanım**
Bir sınıf adını döndürmek için kullanılabilir.

```csharp
Console.WriteLine(nameof(Kisi)); // Çıktı: "Kisi"
```

### 5. **Hata Mesajlarında Kullanım**
`nameof`, hata mesajlarında kullanılarak sabit string kullanma ihtiyacını ortadan kaldırır.

```csharp
if (kisi.Isim == null)
{
    throw new ArgumentNullException(nameof(kisi.Isim), "Isim boş olamaz.");
}
```

---

## `nameof` ve Refactoring Avantajı

Aşağıdaki örnek, `nameof` kullanmanın refactoring sırasında hataları nasıl önlediğini gösterir:

**`nameof` Kullanmadan:**
```csharp
if (kisi.Isim == null)
{
    throw new ArgumentNullException("Isim", "Isim boş olamaz.");
}
```
Bu durumda, "Isim" string'i değiştirilirse güncellenmesi unutulabilir.

**`nameof` Kullanarak:**
```csharp
if (kisi.Isim == null)
{
    throw new ArgumentNullException(nameof(kisi.Isim), "Isim boş olamaz.");
}
```
`Isim` özelliği yeniden adlandırıldığında, `nameof` ifadesi otomatik olarak güncellenir.

---

## `nameof` ile Karşılaştırmalar

| **Özellik**            | **`nameof`**                            | **Sabit String**          |
|-------------------------|-----------------------------------------|---------------------------|
| **Performans**         | Derleme zamanında çözülür.              | Çalışma zamanında kontrol gerekebilir. |
| **Refactoring**        | Otomatik güncellenir.                   | Manuel olarak değiştirilmelidir.       |
| **Okunabilirlik**      | Daha açık ve anlaşılırdır.               | Karmaşıklığa yol açabilir.             |
| **Hata Riski**         | Daha düşüktür.                          | Daha yüksektir.                        |

---

## Özet
- `nameof`, C#'te bir sembolün adını string olarak döndürmek için kullanılır.
- Hatalardan kaçınma, refactoring kolaylığı ve okunabilirlik açısından önemlidir.
- `nameof`, performans açısından sabit stringlere göre daha avantajlıdır.

`nameof` anahtar kelimesi, modern C# uygulamalarında hataları azaltmak ve kodun bakımını kolaylaştırmak için güçlü bir araçtır.

---

Daha fazla bilgi için [Microsoft Docs: nameof](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/nameof) sayfasını inceleyebilirsiniz.

