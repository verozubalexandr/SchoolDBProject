# System Zarządzania Szkołą
## Oleksandr Veroub, w69953, IID, GL-01

## Opis projektu

Projekt w technologii .NET umożliwia zarządzanie danymi związanymi z funkcjonowaniem szkoły, takimi jak uczniowie, nauczyciele, rodzice, przedmioty, klasy i pracownicy. Aplikacja obsługuje operacje CRUD (tworzenie, odczyt, aktualizacja, usuwanie) na wszystkich głównych obiektach. Dane przechowywane są w plikach JSON, które są automatycznie wczytywane do systemu przy uruchomieniu.

## Funkcjonalności

- Operacje CRUD dla uczniów, nauczycieli, rodziców, przedmiotów, klas i pracowników.
- Walidacja danych oraz obsługa wyjątków, co zapewnia stabilność systemu.
- Modularna architektura z zastosowaniem wzorca Dependency Injection.
- Dane przechowywane w plikach JSON, umożliwiające prostą obsługę i przenośność.

## Struktura projektu

- Controllers: Odpowiadają za obsługę żądań API.
- Services: Logika biznesowa aplikacji.
- Models: Struktury danych, które reprezentują obiekty w systemie.
- DBFiles: Pliki JSON z testowymi danymi dla aplikacji.

## Instalacja

1. Sklonuj repozytorium:
2. Otwórz projekt w Visual Studio.
3. Upewnij się, że pliki JSON z danymi znajdują się w katalogu DBFiles.

## Uruchomienie
Po uruchomieniu dane testowe zostaną automatycznie wczytane z plików JSON.

## Wymagania

- .NET 6.0 lub nowszy.
- Visual Studio 2022 lub nowszy.
- Pliki JSON znajdujące się w katalogu `DBFiles`.
