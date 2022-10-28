# .NET_Internet_services - projekt wykładowy

Solucja składa się z 2 projektów:
- SportsAgents
- BlazorServerSportsAgents

W projekcie SportsAgents zrealizowałem:
1. Najpierw z użyciem skryptu "CreateTables.sql" stworzyłem bazę danych i 2 tabele: Athletes i Users.
2. Później stworzyłem projekt Web API, w którym z użyciem Scaffold-DbContext dla EnitityFramework wygenerowałem klasy encyjne dla 2 tabel z bazy danych, czyli zastosowałem podejście Database First.
3. Następnie utworzyłem Controllery obsługujące metody HTTP, pozwalające na pobranie, usuwanie, dodawanie i usuwanie odpowiednich rekordów z bazy danych.
4. Później korzystając z biblioteki Swagger wygenerowałem dokumentację WebAPI.

W projekcie BlazorServerSportsAgents zrealizowałem:
1. Stworzyłem projekt Blazor Server App.
2. Wykorzystując dokumentacje WebAPI utworzoną z użyciem biblioteki Swagger, wygenerowałem kod klienta interfejsu API dla tego projektu.
3. Następnie korzystając z narzędzi udostępnianych w projekcie Blazor Server App, stworzyłem frontend strony.

Ostatecznie nie udało mi się wykonać uwierzytelniania JWT. Podjąłem próby, ale nie zdążyłem tego zrealizować.