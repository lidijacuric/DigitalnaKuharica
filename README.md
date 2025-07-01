
1. Naziv projektnog zadatka:
Digitalna kuharica – Konzolna aplikacija u C# jeziku za upravljanje receptima. 

2. Student: Lidija Ćurić 
Predmet: Viši programski jezici i RAD alati
Godina: ’24/’25.
Datum: 01.07.2025.

 3. Uvod:
Ovaj projekat predstavlja jednostavnu konzolnu aplikaciju za upravljanje bazom recepata, napisanu u programskom jeziku C#. Aplikacija omogućava dodavanje, prikazivanje, brisanje i pretragu recepata, te filtriranje prema težini pripreme. Cilj aplikacije je demonstracija primjene osnovnih koncepata objektno orijentisanog programiranja, kolekcija, unosa podataka i validacije u C# jeziku.

 4. Funkcionalnosti aplikacije:
 - Dodavanje novog recepta 
- Prikaz svih recepata
 - Brisanje recepta 
- Pretraga recepata po nazivu
 - Prikaz recepata po težini
 - Statistički prikaz: broj recepata i kategorija sa najviše unosa

 5. Tehnički opis:
 Recepti se čuvaju u memoriji koristeći generičku kolekciju List . 
Klasa Recept sadrži osnovne informacije: naziv, kategoriju, vrijeme pripreme, težinu i sastojke.
 Glavni meni funkcioniše kroz petlju i omogućava interaktivni unos korisnika. Svaka opcija menija poziva odgovarajuću metodu koja upravlja podacima i ispisuje rezultate u konzolu.

 6. Dijagram toka aplikacije (tekstualni prikaz):
Start → Glavni meni → Unos izbora: - 1 → Unos: naziv → kategorija → vrijeme pripreme → težina → sastojci → spremanje → meni - 2 → Prikaz svih recepata → meni - 3 → Unos naziva → brisanje → meni - 4 → Unos teksta → filtriranje → meni - 5 → Unos težine → filtriranje → meni - 0 → Izlaz → kraj.

7. Objašnjenje koda:
 - Klasa Recept definiše model podataka. 
- Klasa Program sadrži listu recepata i sve logičke metode.
 - Main metoda pokreće beskonačnu petlju sa menijem. 
- Metode DodajRecept , ObrisiRecept , PretraziRecepte , PrikaziPoTezini obrađuju korisničke zahtjeve. 
- Validacije unosa se vrše prije dodavanja recepata. 
- LINQ se koristi za pretragu, filtriranje i grupisanje. 

8. Pokretanje aplikacije:
 1. Instalirati .NET 8.0 SDK 
2. Otvoriti projekat u Visual Studio Code 
3. U terminalu pokrenuti dotnet run 

9. Zaključak:
Aplikacija Digitalna kuharica demonstrira osnovne mogućnosti C# jezika u praktičnoj primjeni. Omogućava studentima rad sa klasama, listama, unosima i logičkim grananjem u okviru realnog problema. Projekt je modularan, jasan i spreman za proširenje sa naprednijim funkcijama poput čuvanja u datoteku ili bazu podataka.

