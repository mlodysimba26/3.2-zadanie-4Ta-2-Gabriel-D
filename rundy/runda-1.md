# Wynik rundy 1: sama prośba (zero-shot, bez formatu)

Prośba wysłana do agenta:
> "Zrób notatnik: pole na tytuł, pole na treść, przycisk zapisu i lista zapisanych notatek. Notatki mają być zapisywane do pliku."

Plik powstały na dysku po uruchomieniu aplikacji i zapisaniu dwóch notatek: `notes.txt`

Zawartość pliku `notes.txt`:
```
Tytuł: Zakupy
Treść: Kupić chleb i masło
---
Tytuł: Projekt Avalonia
Treść: Przetestować działanie aplikacji
---
```

### Spostrzeżenia:
Model sam dopowiedział format i strukturę zapisu:
- Wybrał nazwę pliku `notes.txt`.
- Nowe notatki dopisywane są na końcu pliku (brak odwróconej kolejności chronologicznej).
- Brak standardowego formatowania Markdown oraz brak znaczników czasu (daty i godziny).
- Zastosowano separator `---` oraz etykiety `Tytuł:` i `Treść:`.
