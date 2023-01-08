# ConfigReader

Solution altında aşağıdaki projeler/klasörler yer almaktadır:
1. **ConfigurationReader**: Sql veritabanından ayarları okuma, cache'leme ve isteğinden değerleri dönme işlerini yapar.
2. **Models**: Database modellerini ve context'i içeren projedir.
3. **ServiceA**: Test için kullanılan Asp.Net Core WebApi projesidir. Servis endpoint'i ile okuduğu config değerlerini döner.
4. **ServiceB**: Test için kullanılan Asp.Net Core Mvc projesidir. Anasayfasında okuyabildiği config değerlerini listeler.
5. **WebEditor**: Database'de tutulan config değerlerinin listelenmesini, düzenlenmesini ve yeni değerlerin eklenmesini sağlayan Asp.Net Core Mvc projesidir.
6. **docker-compose**: ServiceA, ServiceB ve WebEditor projelerini docker-compose ile ayağa kaldırır. Startup projesi olarak set edilmelidir.
7. **DbScripts**: Projede kullanılan database için create ve insert scriptlerini içerir.

## Proje notları

### 1. ConfigurationReader
- Type: **Class Library**
- Framework: **net5.0**
- Dependencies: **Microsoft.EntityFrameworkCore 5.0.17**, **Microsoft.EntityFrameworkCore.SqlServer 5.0.17**

### 2. Models
- Type: **Class Library**
- Framework: **net5.0**
- Dependencies: **Microsoft.EntityFrameworkCore 5.0.17**

### 3. ServiceA
- Type: **Asp.Net Core WebApi**
- Framework: **net5.0**
- Dependencies: **Swashbuckle.AspNetCore 5.6.3**, **Microsoft.VisualStudio.Azure.Containers.Tools.Targets 1.17.0**
- Notes: http://localhost:60077/swagger/index.html adresinden swagger sayfasına ulaşılabilir. Config bilgileri dockerfile içinde env olarak geçilmiştir.

### 4. ServiceB
- Type: **Asp.Net Core MVC**
- Framework: **net5.0**
- Dependencies: **Microsoft.VisualStudio.Azure.Containers.Tools.Targets 1.17.0**, **Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 5.0.17**
- Notes: http://localhost:60079 adresinden ulaşılabilir.  Config bilgileri dockerfile içinde env olarak geçilmiştir.

### 5. WebEditor
- Type: **Asp.Net Core Mvc**
- Framework: **net5.0**
- Dependencies: **Microsoft.VisualStudio.Azure.Containers.Tools.Targets 1.17.0**, **Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation 5.0.17**,  **Microsoft.EntityFrameworkCore 5.0.17**, **Microsoft.EntityFrameworkCore.SqlServer 5.0.17**
- Notes: http://localhost:6778/Configuration adresinden ulaşılabilir. 

### 6. docker-compose
- Notes: Startup project olarak set edilmelidir.

### 7. DbScripts
- Notes: Projeler ayağa kaldırılmadan önce buradaki script'ler çalıştırılarak database oluşturulmalıdır.