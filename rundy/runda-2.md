# Wynik rundy 2: zadanie, format i ograniczenia

Prośba wysłana do agenta:
> "Notatki zapisuj do jednego pliku notatki.md w folderze projektu.
Format wpisu:
## 2026-09-08 14:32 — Tytuł notatki
treść notatki, może mieć kilka linii
Między wpisami pusta linia. Najnowsza notatka na górze pliku.
Polskie znaki mają zostać polskimi znakami."

Plik powstały na dysku po uruchomieniu aplikacji i zapisaniu tych samych dwóch notatek: `notatki.md`

Zawartość pliku `notatki.md`:
```markdown
## 2026-10-29 08:30 — Projekt Avalonia
Przetestować działanie aplikacji

## 2026-10-29 08:29 — Zakupy
Kupić chleb i masło
```

### Spostrzeżenia:
- Doprecyzowanie formatu wpisu, nazwy pliku (`notatki.md`) i reguły kolejności wpisów (najnowsza na górze) całkowicie wyeliminowało samowolkę modelu.
- Polskie znaki diakrytyczne („ć”, „ł”, „ś”) są poprawnie zapisywane dzięki wymuszeniu kodowania UTF-8.
- Najnowsza notatka znajduje się na samej górze pliku, a pomiędzy wpisami zachowana jest pusta linia.
