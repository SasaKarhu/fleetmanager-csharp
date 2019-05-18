# fleetmanager-csharp

<h2>Käytetyt tekniikat/työkalut</h2>

IDE: Visual Studio 2019 (Community Edition)

.NetCore, C#

Tietokanta: SQL Server 2017, Luotu .Net Core EntityFrameworkin Migraatioilla.

Postman kutsut löytyy FleetmanagerCalls.postman_collection.json tiedostosta ja tämän readmen lopusta.

SwaggerUI löytyy ajettaessa osoitteesta: http://localhost:50689/swagger

UnitTestit muutettu käyttämään InMemoryDatabasea ja lisätty muutama testi.

<h2>Asennus</h2>
  
esim. visual studiolla:

Vaihda Startup.cs tietokanta yhteys osoittamaan, johonkin MS sql serveriin.

var connection = @"Server=localhost;Database=fleet_db;Trusted_Connection=True;ConnectRetryCount=0";

Tietokannan voi luoda Solutionin Migraation avulla Package Manager Consolesta komennolla:

Update-Database

<h2>POSTMAN kutsut:</h2>

<h3>Listaus</h3>

GET http://localhost:50689/api/Car

<h3>Haku</h3>

GET http://localhost:50689/api/Car/{{GetID}}

<h3>Lisäys</h3>

POST http://localhost:50689/api/Car/

Body:
{
  "make": "make01",
  "model": "model01",
  "registration": "TST-101",
  "year": 2019,
  "inspectionDate": "2019-01-01T00:00:00",
  "engineSize": 2972,
  "enginePower": 469
}

<h3>Muokkaus</h3>

PUT http://localhost:50689/api/Car/{{PutID}}

Body:
{
    "make": "make6",
    "model": "model6",
    "registration": "NPA-435",
    "year": 2010,
    "inspectionDate": "2018-10-19T00:00:00",
    "engineSize": 2972,
    "enginePower": 469
}

<h3>Poisto</h3>

DELETE http://localhost:50689/api/Car/{{DeleteID}}

<h3>Rajaus</h3>

GET http://localhost:50689/api/Car/Search?YearMin=2005&YearMax=2007&Make=make1&Model=model7
