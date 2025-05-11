# ☕ Kafe API Projesi

Kafe API, modern yazılım geliştirme prensipleri ve güçlü .NET ekosistemi araçları kullanılarak geliştirilmiş, güvenli, ölçeklenebilir ve sürdürülebilir bir RESTful servis mimarisidir. Bu proje, bir kafe otomasyon sistemine ait temel API ihtiyaçlarını karşılamak üzere tasarlanmıştır.

---

## 🚀 Kullanılan Teknolojiler ve Mimariler

### ✅ .NET Core 9
Projemiz, en güncel ve performanslı .NET sürümü olan **.NET Core 9** ile geliştirilmiştir. Bu sayede yüksek performans, çapraz platform desteği ve uzun vadeli sürdürülebilirlik sağlanmaktadır.

### ✅ Onion Architecture
Projede **Onion Architecture (Soğan Mimarisi)** benimsenmiştir. Bu mimari katmanlı yapısı sayesinde:
- Kodun sürdürülebilirliği artar.
- Bağımlılıklar dış katmanlara doğru izole edilir.
- Domain merkezli bir yapı kurulmuş olur.

### ✅ Serilog ile Loglama
Uygulama içi olayları takip etmek, hataları analiz etmek ve sistem davranışlarını anlamak için **Serilog** kullanılmıştır. Log verileri JSON formatında veya dosyaya, veri tabanına gibi farklı ortamlara yönlendirilebilir.

### ✅ AutoMapper ile Veri Dönüşümü
**AutoMapper**, veri transfer objeleri (DTO) ile domain modelleri arasında otomatik eşleme yapar. Bu sayede manuel dönüşüm ihtiyacı ortadan kalkar ve kod tekrarının önüne geçilir.

### ✅ Scalar UI
API'yi test etmek ve görsel olarak incelemek için entegre **Scalar UI** arayüzü sağlanmıştır. Bu arayüz Swagger benzeri olup, kullanıcı dostu bir deneyim sunar.

### ✅ Postman ile Test
Geliştirme sürecinde API uç noktaları **Postman** üzerinden test edilmiştir. Proje ile birlikte gelen koleksiyonlar sayesinde dış geliştiriciler kolayca test yapabilir.

### ✅ FluentValidation ile Validasyon
İstemciden gelen verilerin doğruluğunu kontrol etmek için **FluentValidation** kullanılmıştır. Bu sayede:
- Okunabilir ve sade validasyon kuralları yazılır.
- Hatalı veri akışının önüne geçilir.

### ✅ Identity ile Kimlik Doğrulama
Kullanıcı yönetimi ve oturum kontrolü için **ASP.NET Core Identity** sistemi entegre edilmiştir. Roller, kullanıcılar ve parola politikaları ile detaylı kimlik doğrulama mekanizması oluşturulmuştur.

### ✅ JWT (JSON Web Token) ile Yetkilendirme
API'ye erişimi sınırlamak ve güvenli iletişimi sağlamak için **JWT tabanlı yetkilendirme** kullanılmıştır. Her kullanıcıya özel token ile erişim kontrolü yapılmaktadır.

### ✅ Rate Limiting ile API Güvenliği
Sistemin kötüye kullanılmasını engellemek için **Rate Limiting** (istek sınırlama) uygulanmıştır. Bu sayede:
- Bot saldırıları azaltılır.
- API'nin stabilitesi korunur.

### ✅ RESTful API Prensipleri
Tüm uç noktalar, **RESTful** standartlarına uygun şekilde tasarlanmıştır:
- Kaynak temelli URL yapısı
- HTTP metodlarına uygun davranış (GET, POST, PUT, DELETE)
- Anlamlı HTTP durum kodları (status codes)
- HATEOAS prensibine açık tasarım

