# Görev Yönetim Sistemi

Bu proje, proje ve görev takibini kolaylaştırmak amacıyla ASP.NET Core MVC kullanılarak geliştirilmiştir.

## Özellikler

- Kullanıcı yönetimi
- Proje oluşturma, düzenleme ve silme
- Görev oluşturma, düzenleme ve silme
- Görevlere kullanıcı atama
- Görev durum yönetimi
- Görev arama ve durum filtreleme
- Dashboard üzerinden görev istatistikleri
- Proje detay ekranında projeye ait görevleri görüntüleme
- MySQL veritabanı kullanımı

## Kullanılan Teknolojiler

- ASP.NET Core MVC
- C#
- Entity Framework Core
- MySQL
- Bootstrap
- HTML / CSS
- Git & GitHub

## Veritabanı Yapısı

Projede üç temel veri modeli bulunmaktadır:

### Project
- Id
- Name
- Description
- CreatedDate

### TaskItem
- Id
- Title
- Description
- Status
- Deadline
- ProjectId
- UserId

### User
- Id
- Name
- Surname
- Email
- Password
- Role

## Veritabanı İlişkileri

Project ile TaskItem arasında **bire-çok (1-N)** ilişki bulunmaktadır.

Bir proje birden fazla görev içerebilir.

User ile TaskItem arasında **bire-çok (1-N)** ilişki bulunmaktadır.

Bir kullanıcıya birden fazla görev atanabilir.

Project (1) ---- (N) TaskItem (N) ---- (1) User

## Proje Yapısı

- `Controllers`: Uygulama işlemlerini yöneten controller sınıfları
- `Models`: Veri modelleri
- `Views`: Kullanıcı arayüzleri
- `Data`: Veritabanı bağlantısı ve DbContext
- `Migrations`: Veritabanı migration dosyaları

## Kurulum

Projeyi bilgisayarınıza klonladıktan sonra gerekli veritabanı bağlantı ayarlarını `appsettings.json` dosyasında yapılandırın.

Ardından:

dotnet restore

dotnet ef database update

dotnet run