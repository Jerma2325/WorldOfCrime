#World of Crime
Kod źródłowy jest umieszciony na githubie wraz z bazą danych.

Applikacja posiada wszystkie mozliwosci CRUD + logowanie

Testowi użytkownicy:

Admin

    login    “Admin” 
    hasło    “password”
User

     login   “User”
     hasło   “password”

są 4 encji i jeden eunm

eunm: Nationality (mieści w sobie 10 narodowości które można wybrać podczas tworzenia gang membera lub bossa)

Boss

    int BossId 
    string FirstName 
    string LastName 
    int Age 
    Nationality Nationality 
    string OrganizationName 
    IList<Organization> Organizations 

Gang member (ma charakterystyki które będą używane podczas walki z innymi memberami)
 
    int MemberId 
    string FirstName 
    string LastName 
    Nationality Nationality 
    Organization Organization
    int Strength 
    int Endurance 
    int Intelligence 
    int Luck 

Base

     int BaseID 
     string Name 
     string Adress 
     string OrganizationName 
     Organization Organization 

Organization 

     int OgranizationId 
     string Name 
     string CountryOfOrigin 
     string NameOfBoss 
     Boss Boss 
     IList<GangMember> Members 
     IList<Base> Bases 


BaseApiController - web api rest z akcjami Base

