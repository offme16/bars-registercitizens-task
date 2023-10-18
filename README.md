# Проект "Реестр граждан"
<p>Проект "Реестр граждан" - это современное веб-приложение, разработанное с использованием стека технологий,
включая C# (.NET Core), ASP.NET Core, Entity Framework Core, SQL (PostgreSQL), и Vue.js.
Это приложение предоставляет возможность управления данными о людях, а также осуществление поиска и фильтрации этих данных.</p>
-----------
## Технологии и стек
+ C# (.NET Core)
+ ASP.NET Core
+ Entity Framework Core
+ SQL (PostgreSQL)
+ Vue.js
-----------
## Установка
1. Склонируйте репозиторий на вашу локальную машину.
2. Откройте проект в вашей IDE.
3. Убедитесь, что у вас установлен .NET SDK версии 7.0 или выше.
   +Node.js
   +Vue CLI
   +PostgreSQL  
4. В корневой директории проекта выполните команду dotnet restore для восстановления необходимых пакетов NuGet.
-----------
## Настройка  базы данных
  + Откройте pg4Admin создайте новый сервер и укажите эти параметры: Server=127.0.0.1;
                                                                     Port=5432; 
                                                                     Database=(ваше название бд);
                                                                     User Id=postgres;
                                                                     Password=(ваш пароль для созданного сервера);
  + Настройте строку подключения в файле appsettings.json строка имеет вид `"DB": "Server=127.0.0.1;Port=5432;Database=(ваше название бд);User Id=postgres;Password=(ваш пароль для созданного сервера);"`


  
