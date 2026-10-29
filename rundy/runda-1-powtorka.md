# Wynik powtórzenia rundy 1: bez zmiany w prośbie (runda-1-powtorka.md)

Prośba wysłana do agenta (dokładnie ta sama co w rundzie 1, bez żadnej zmiany):
> "Zrób notatnik: pole na tytuł, pole na treść, przycisk zapisu i lista zapisanych notatek. Notatki mają być zapisywane do pliku."

Plik powstały na dysku po drugim uruchomieniu: `notes.json` (w pierwszym uruchomieniu powstał `notes.txt`)

Zawartość pliku `notes.json`:
```json
[
  {
    "Title": "Zakupy",
    "Content": "Kupić chleb i masło",
    "Date": "2026-10-29T08:32:00"
  },
  {
    "Title": "Projekt Avalonia",
    "Content": "Przetestować działanie aplikacji",
    "Date": "2026-10-29T08:32:30"
  }
]
```

### Porównanie z pierwszym uruchomieniem rundy 1:
- **Format danych:** Za pierwszym razem model zaimplementował zwykły plik tekstowy `notes.txt` z ręcznym separatorem `---`. Za drugim razem model użył formatu JSON (`System.Text.Json`) i pliku `notes.json`.
- **Metadane:** Za pierwszym razem brakowało daty i godziny utworzenia wpisu; za drugim razem model sam dodał pole `Date` z czasem ISO 8601.
- **Kolejność:** Oba warianty domyślnie dopisywały nowe notatki na koniec listy/pliku zamiast na górę.
- **Przyczyna różnic:** Całkowity brak precyzji w prośbie (zero-shot bez formatu) sprawia, że niedeterminizm generatora tokenów modelu decyduje o kluczowych decyzjach architektonicznych i formacie danych.
