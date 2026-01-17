En WPF-applikation i C# som använder Entity Framework Core (Database-First) för att läsa och uppdatera data i en relationsdatabas. Har försökt tänka på MVVM-arkitektur och async/await.

Applikationen används för att lista, lägga till, uppdatera och ta bort böcker i lager för olika butiker i en bokhandel.

**Funktionalitet:** Visar lagersaldo per butik.


**Tabeller som används:** Butiksnamn, Boktitel, Författare, Antal böcker i lager.

<img width="879" height="510" alt="image" src="https://github.com/user-attachments/assets/f410c880-7185-4e71-aab4-502ace8ed8e8" />

   

Finns en header meny för att uppdatera/ladda om databasen samt stänga applikationen för tillfället.

<img width="193" height="90" alt="image" src="https://github.com/user-attachments/assets/1fbe8bc1-ee81-43b8-911e-093b5a132d8f" />



**Krav:**   .NET 8, WPF, SQL Server, Entity Framework Core.

**Databas:** Applikationen använder databasen Bokhandel_labb som skapades i förra databas-labben.

Connectionstring finns i BokhandelContext.cs.


Lägg till eller ta bort böcker ur databasen genom att välja butik samt boktitel i respektive drop-down meny. Välj sedan antal böcker som ska tas bort och klicka sedan på lägg till eller ta bort.
