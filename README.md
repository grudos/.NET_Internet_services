# .NET_Internet_services - projekt wykładowy

Solucja składa się z 2 projektów:
- SportsAgents
- BlazorServerSportsAgents

W projekcie SportsAgents zrealizowałem:
1. Najpierw z użyciem skryptu "CreateTables.sql" stworzyłem bazę danych i 2 tabele: Athletes i Users.
2. Później stworzyłem projekt Web API, w którym z użyciem Scaffold-DbContext dla EnitityFramework wygenerowałem klasy encyjne dla 2 tabel z bazy danych, czyli zastosowałem podejście Database First.
3. Następnie utworzyłem Controllery obsługujące metody HTTP pozwalające na pobranie, dodawanie, aktualizowanie i usuwanie odpowiednich rekordów z bazy danych.
4. Umożliwiłem logowanie się do aplikacji użytkowników, poprzez uwierzytelnienie z wykorzystaniem tokenów JWT.
5. Dla metod HTTP użytkownika dodałem adnotacje Authorize, umożliwiającą skorzystanie z metod tylko zalogowanym użytkownikom.
6. Następnie korzystając z biblioteki Swagger wygenerowałem dokumentację WebAPI.

W projekcie BlazorServerSportsAgents zrealizowałem:
1. Stworzyłem projekt Blazor Server App.
2. Wykorzystując bibliotekę HttpClient obsługiwałem metody HTTP udostępniane przez projekt Web API.
3. Następnie korzystając z narzędzi udostępnianych w projekcie Blazor Server App, stworzyłem frontend strony.