# MYAcademi Portfolio Project

ASP.NET Core MVC kullanılarak geliştirilen dinamik kişisel portfolyo ve yönetim paneli projesidir.

Proje; kişisel bilgilerin, deneyimlerin, projelerin ve yeteneklerin dinamik olarak yönetilmesini sağlayan bir web uygulamasıdır.

## Kullanılan Teknolojiler

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- HTML5
- CSS3
- Bootstrap
- JavaScript
- Bootstrap Icons
- SweetAlert2

---

## Proje Özellikleri

### Kullanıcı Arayüzü

- Dinamik ana sayfa tasarımı
- Hakkımda bilgilerinin görüntülenmesi
- Deneyimlerin listelenmesi
- Projelerin ve kategorilerin görüntülenmesi
- Yeteneklerin listelenmesi
- İletişim bilgilerinin görüntülenmesi
- İletişim formu üzerinden mesaj gönderimi

### Yönetim Paneli (Admin Panel)

- Dashboard üzerinden istatistiklerin görüntülenmesi
- Toplam deneyim, proje ve yetenek sayılarının takibi
- Öne çıkarılan projelerin görüntülenmesi
- Deneyim ekleme, listeleme, güncelleme ve silme (CRUD)
- Proje ekleme, listeleme, güncelleme ve silme (CRUD)
- Kategori yönetimi
- Yetenek ve yetenek detaylarının yönetimi
- Gelen mesajların listelenmesi ve detaylarının görüntülenmesi
- Mesajların okundu / okunmadı durumlarının yönetimi
- Sayfalama (Pagination)
- SweetAlert2 ile silme işlemlerinde onay pencereleri
- Data Annotations ile form doğrulama

---

## Proje Ekran Görüntüleri

### Ana Sayfa

![Ana Sayfa](MYAcademi_PortfolioProject/docs/screenshots/homepage.jpg)

### İletişim Sayfası

![İletişim Sayfası](MYAcademi_PortfolioProject/docs/screenshots/contact.jpg)

### Yönetim Paneli (Dashboard)

![Dashboard](docs/screenshots/dashboard.jpg)

### Deneyim Yönetimi

![Deneyim Listesi](docs/screenshots/experiences.jpg)

### Proje Yönetimi

![Proje Listesi](docs/screenshots/projects.jpg)

### Yetenek Yönetimi

![Yetenek Listesi](docs/screenshots/skills.jpg)

### Mesaj Yönetimi

![Mesaj Listesi](docs/screenshots/messages.jpg)

### Mesaj Detay Modalı

![Mesaj Detayı](docs/screenshots/message-detail.jpg)

---
## Proje Yapısı

```text
MYAcademi_PortfolioProject
│
├── Areas
│   └── Admin
│       ├── Controllers
│       └── Views
│
├── Context
├── Entities
├── Migrations
├── ViewComponents
├── Views
├── wwwroot
│
├── docs
│   └── screenshots
│
├── appsettings.json
└── Program.cs
```

## Kurulum ve Çalıştırma

1. Projeyi GitHub üzerinden bilgisayarınıza indirin veya klonlayın.
2. Projeyi Visual Studio ile açın.
3. `appsettings.json` dosyasındaki SQL Server bağlantı ayarlarını düzenleyin.
4. Gerekli veritabanını oluşturmak için Entity Framework Core migration işlemlerini uygulayın.
5. Projeyi çalıştırın.

## Geliştirici

**Ayşegül Arık**

- GitHub: [github.com/AysegulArik](https://github.com/AysegulArik)
