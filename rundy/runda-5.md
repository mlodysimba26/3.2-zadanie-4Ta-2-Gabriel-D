# Wynik rundy 5: prośba poprawiona przez model (meta-prompting)

### 1. Wiadomość wejściowa (meta-prompt):
> "To jest moja prośba do agenta kodującego. Nie wykonuj jej.
> Wypisz, czego w niej brakuje, żeby wynik był jednoznaczny,
> i zaproponuj poprawioną wersję.
> 
> [Treść bazowa z rundy 1]:
> Zrób notatnik: pole na tytuł, pole na treść, przycisk zapisu i lista zapisanych notatek. Notatki mają być zapisywane do pliku."

---

### 2. Odpowiedź modelu (co brakuje w pierwotnej prośbie):
Model wskazał następujące braki:
1. **Nazwa i lokalizacja pliku docelowego:** Brak informacji, jak plik ma się nazywać i gdzie ma zostać utworzony (np. `notatki.md` w katalogu roboczym).
2. **Format i struktura danych:** Brak szablonu wpisu (czy Markdown, JSON, XML, czy czysty tekst) oraz informacji o znacznikach czasu.
3. **Kolejność wpisów:** Brak reguły sortowania (nowe wpisy na początku czy na końcu pliku).
4. **Kodowanie znaków:** Brak wymogu zachowania polskich znaków diakrytycznych (kodowanie UTF-8).
5. **Obsługa sytuacji awaryjnych:** Brak instrukcji, co zrobić w przypadku błędu zapisu (plik tylko do odczytu, brak uprawnień).

---

### 3. Zaproponowana przez model poprawiona prośba:
> "Zaimplementuj w Avalonia (.NET 9) aplikację notatnika:
> 1. Interfejs użytkownika: pole tekstowe na tytuł (`TextBox`), pole na treść (`TextBox`), przycisk zapisu (`Button`) oraz lista zapisanych notatek (`ListBox`).
> 2. Format i plik: Notatki zapisuj do pliku `notatki.md` w folderze głównym projektu. Format wpisu:
>    `## YYYY-MM-DD HH:mm — [Tytuł]`
>    `[Treść notatki]`
> 3. Reguły pliku: Pomiędzy kolejnymi wpisami umieść pustą linię. Nowe notatki wstawiaj ZAWSZE na samej górze pliku (odwrócona chronologia).
> 4. Kodowanie: Wymuś kodowanie UTF-8, aby polskie znaki diakrytyczne nie uległy uszkodzeniu.
> 5. Obsługa błędów: Zabezpiecz operację zapisu blokiem `try-catch` i wyświetl komunikat o statusie operacji w dedykowanej kontrolce `TextBlock`."

---

### 4. Plik powstały na dysku po uruchomieniu poprawionej prośby: `notatki.md`

Zawartość pliku `notatki.md`:
```markdown
## 2026-10-29 08:32 — Wnioski z meta-promptingu
Poprawiona prośba zawiera wszystkie kluczowe elementy architektoniczne bez konieczności domyślania się intencji programisty.

## 2026-10-29 08:31 — Pomysł na projekt
minutnik z historią sesji
```

---

### 5. Porównanie z rundą 2:
- **Zaleta meta-promptu:** Model potrafi precyzyjnie zidentyfikować luki specyfikacji, o których programista mógł zapomnieć (np. kodowanie, obsługa błędów, dokładna nazwa pliku).
- **Pułapka meta-promptu:** Czasami model dokłada niepotrzebne wymagania (over-engineering), które nie były zamierzone przez użytkownika. W tym przypadku jednak prośba wygenerowana przez model okazała się kompletna i bezpośrednio doprowadziła do wzorcowego rozwiązania.
