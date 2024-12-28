// Ana program
var numbers = new List<int> { 1, 4, 6, -1, -44, -8, -19 }; // Sayılar listesi oluşturuluyor
bool shallAddPositiveOnly = true; // Sadece pozitif sayılar mı toplanacak? (true/false)

NumbersSumCalculator calculator =
    shallAddPositiveOnly 
        ? new PositiveNumbersSumCalculator() // Eğer true ise pozitif sayılar için özel hesaplayıcı seçilir
        : new NumbersSumCalculator(); // Aksi durumda tüm sayıları toplayan temel hesaplayıcı seçilir

int sum = calculator.Calculate(numbers); // Seçilen hesaplayıcı kullanılarak sayılar toplanır

System.Console.WriteLine($"Sum is: {sum}"); // Sonuç ekrana yazdırılır


// Tüm sayıların toplamını hesaplayan temel sınıf
public class NumbersSumCalculator
{
    // Sayıların toplamını hesaplayan metot
    public int Calculate(List<int> numbers)
    {
        int sum = 0; // Toplam başlangıçta sıfırdır
        foreach (var number in numbers) // Liste içindeki her sayı üzerinde döngü
        {
            if (ShallBeAdded(number)) // Şart kontrol: sayı eklenmeli mi?
            {
                sum += number; // Eğer sayı eklenmeli ise toplama dahil edilir
            }
        }
        return sum; // Toplam döndürülür
    }

    // Hangi sayıların toplama dahil edileceğini belirleyen sanal (virtual) metot
    protected virtual bool ShallBeAdded(int number)
    {
        return true; // Varsayılan olarak her sayı eklenir
    } 
}

// Pozitif sayıların toplamını hesaplayan sınıf
public class PositiveNumbersSumCalculator : NumbersSumCalculator
{
    // Pozitif sayılar için ShallBeAdded metodunu geçersiz kılma (override)
    protected override bool ShallBeAdded(int number)
    {
        return number > 0; // Sadece pozitif sayılar eklenir
    } 
}