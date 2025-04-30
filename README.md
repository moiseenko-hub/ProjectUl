ProjectUL — Справочник туриста

======================= 🚀 Быстрый старт 📦 Требования:

.NET 7 SDK

Visual Studio 2022+ или Rider

SQL Server (используется LocalDB по умолчанию)

======================= 🔧 Как запустить проект: Открой проект через Project.sln

Проверь строку подключения в ProjectDbContext.cs — она должна выглядеть так:

Server=(localdb)\mssqllocaldb;Database=Project;Trusted_Connection=True;

Открой Package Manager Console (PMC) и введи:

Update-Database

Запусти проект через F5 или кнопку "Старт"

После первого запуска база автоматически наполнится тестовыми данными (сидинг).

======================= 🧠 Что внутри проекта: Models/Database — модели таблиц (UserData, TypeData, PlaceData, ReviewData)

Repositories — репозитории для работы с данными

Views — Razor-вьюшки

Controllers — логика контроллеров

DbSeeder.cs — сидинг базы при запуске

======================= 💡 Полезные команды Update-Database — применяет миграции Add-Migration <ИмяМиграции> — создаёт новую миграцию

======================= 🛠 Возможные ошибки Если Add-Migration не распознается — запусти в правильном проекте (Startup Project)

Если сидинг не срабатывает — удали базу вручную в SQL Server Object Explorer и перезапусти проект

======================= 📞 Автор Made with ❤️ by [Андрей Моисеенко] Telegram: [@moiseenkobs] Email: balllagurochka@gmail.com
