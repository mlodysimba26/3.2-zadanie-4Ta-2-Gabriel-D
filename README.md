# Zadanie 3.2 — Notatnik i cztery rundy próśb

Aplikacja notatnika zrealizowana w technologii **Avalonia (.NET 9)** w ramach Modułu 3 kursu (*Budowa 2: jak prosić, żeby dostać*).

---

## Warunek 1: Czytanie i weryfikacja zmian agenta przed przyjęciem

Zgodnie z zasadą modułu (obowiązkowe dziesięć minut na czytanie i weryfikację zmian agenta przed zatwierdzeniem), każda zmiana w kodzie aplikacji została szczegółowo przeanalizowana przed wdrożeniem i zatwierdzeniem commitem:

1. **Weryfikacja szablonu bazowego (Runda 1):**
   - Sprawdzono strukturę interfejsu XAML w `MainWindow.axaml` (kontrolki `TextBox`, `Button`, `ListBox`).
   - Zauważono i poprawiono ostrzeżenia kompilatora Avalonia 12 dotyczące przestarzałej właściwości `Watermark` na rzecz `PlaceholderText`.
   - Zweryfikowano zachowanie domyślnego zapisu do pliku: model bez specyfikacji wybrał plik `notes.txt` z formatowaniem `Tytuł:... Treść:...` i dopisywaniem na końcu.

2. **Weryfikacja formatu i kodowania znaków (Runda 2):**
   - Przeanalizowano diff zmian pomiędzy rundą 1 a 2.
   - Zweryfikowano implementację kodowania `Encoding.UTF8` przy wywołaniach `File.WriteAllText` oraz `File.ReadAllText`, gwarantującą poprawne wyświetlanie polskich znaków diakrytycznych (`ąćęłńóśźż`).
   - Sprawdzono logikę odwróconej chronologii: odczyt istniejącego pliku `notatki.md` i dołączenie nowej notatki na samym początku pliku.

3. **Weryfikacja techniki one-shot i few-shot (Rundy 3 i 4):**
   - Sprawdzono poprawność formatowania nagłówka `## YYYY-MM-DD HH:mm — Tytuł` oraz odstępów między notatkami (dokładnie jedna pusta linia).
   - Zweryfikowano odporność parsera na wieloliniowe notatki oraz tytuły z dodatkowymi separatorami/myślnikami.

4. **Weryfikacja obsługi błędów („Własną ręką: obsługa błędu”):**
   - Ręcznie zweryfikowano zabezpieczenie zapisu do pliku w klamrach `try ... catch (Exception ex)`.
   - Przetestowano scenariusz awaryjny (plik oznaczony atrybutem „tylko do odczytu”): aplikacja nie wyłącza się, a w kontrolce `StatusText` natychmiast pojawia się czytelny komunikat z treścią wyjątku systemowego.

---

## Warunek 2: Cztery rundy próśb, kopie w `rundy/` i dedykowane commity

Każda runda została utrwalona osobnym commitem w historii repozytorium Git, a dokładny wynik zapisany na dysku po uruchomieniu aplikacji trafił do katalogu `rundy/`:

- **[runda-1.md](file:///rundy/runda-1.md) (commit `runda 1`):**
  - *Prośba:* sama prośba bez podania formatu (*zero-shot*).
  - *Wynik:* model samodzielnie zdecydował o nazwie pliku (`notes.txt`), formacie wpisów (`Tytuł: ... Treść: ... ---`) i dopisywaniu na końcu.
- **[runda-2.md](file:///rundy/runda-2.md) (commit `runda 2`):**
  - *Prośba:* dodanie wymogów formatu (plik `notatki.md`, nagłówek `## 2026-09-08 14:32 — Tytuł`, najnowsza na górze, polskie znaki).
  - *Wynik:* ujednolicenie pliku do Markdowna, wymuszenie UTF-8 i odwróconej chronologii.
- **[runda-3.md](file:///rundy/runda-3.md) (commit `runda 3`):**
  - *Prośba:* technika *one-shot* (jeden pełny przykład w prompcie).
  - *Wynik:* precyzyjne odwzorowanie formatowania bez potrzeby formułowania długich opisów reguł.
- **[runda-4.md](file:///rundy/runda-4.md) (commit `runda 4`):**
  - *Prośba:* technika *few-shot* (trzy zróżnicowane przykłady: jednolinijkowy, wielolinijkowy, z polskimi znakami i myślnikiem w tytule).
  - *Wynik:* stabilny, docelowy format aplikacji odporny na przypadki brzegowe.
- **[runda-5.md](file:///rundy/runda-5.md) (commit `runda 5`):**
  - *Prośba:* *meta-prompt* (zapytanie modelu o wady prośby z rundy 1 i wygenerowanie przez model kompletnej, poprawionej wersji prośby).
  - *Wynik:* model wskazał 5 kluczowych braków i sformułował profesjonalny prompt techniczny.
- **Własną ręką: obsługa błędu (commit `wlasna reka: obsluga bledu zapisu`):**
  - Wdrożenie bloku `try ... catch (Exception ex)` wokół operacji `File.WriteAllText` oraz kontrolki `StatusText` pod przyciskiem zapisu.

---

## Warunek 3: Powtórka rundy 1 bez zmiany w prośbie i analiza niedeterminizmu

Runda 1 została uruchomiona po raz drugi z **identyczną prośbą** bez zmiany ani jednego znaku:
> „Zrób notatnik: pole na tytuł, pole na treść, przycisk zapisu i lista zapisanych notatek. Notatki mają być zapisywane do pliku.”

Wynik drugiego uruchomienia został utrwalony w pliku **[rundy/runda-1-powtorka.md](file:///rundy/runda-1-powtorka.md)**.

### Co różni powtórkę od pierwszego uruchomienia:
1. **Format pliku i serializacja:** Za pierwszym razem model zaimplementował zwykły plik tekstowy `notes.txt` z separatorem `---`. Przy powtórzeniu model użył formatu JSON (`notes.json`) z serializacją obiektów klasy `Note`.
2. **Znaczniki czasu:** W pierwszym uruchomieniu wpisy nie posiadały daty ani godziny utworzenia; w powtórce model dodał pole daty w standardzie ISO 8601 (`Date`).
3. **Obsługa listy:** W pierwszym podejściu aplikacja dzieliła tekst po separatorze, natomiast w powtórce deserializowała tablicę obiektów JSON przy starcie programu.

### Wpływ niedeterminizmu modelu na różnice między rundami 1–4:
Znaczna część początkowych różnic w strukturze pliku i formatowaniu między rundami 1 i 2 wynikała właśnie z losowości i braku narzuconych ograniczeń (niedeterminizmu modelu), natomiast stabilizacja i powtarzalność formatu w rundach 3 i 4 były już bezpośrednią zasługą jednoznacznych przykładów (few-shot).

---

## Warunek 4: Rada producenta modelu (Google) dotycząca promptowania

- **Producent modelu:** Google (Google DeepMind / Google AI)
- **Model używany w projekcie:** Gemini 3.8 Flash (High)
- **Źródło zaleceń:** [Google Gemini API — Prompt design strategies](https://ai.google.dev/gemini-api/docs/prompting-strategies)
- **Data odczytania dokumentacji:** 29 października 2026 r. (2026-10-29)

### Rada producenta, której nie było dziś na lekcji:
> **Oddzielanie instrukcji od danych i szablonów za pomocą znaczników strukturalnych (*Structural delimiters*):**
> *„Use delimiters (such as Markdown headers, XML-style tags, or triple quotes) to strictly separate instructions from context, input data, and schema definitions.”*
> Na dzisiejszej lekcji omówiono techniki *zero-shot*, *one-shot*, *few-shot*, *chain-of-thought* oraz *meta-prompting*, jednak nie poruszano techniki izolowania sekcji promptu za pomocą jednoznacznych tagów lub ograniczników blokowych.

### Co ta rada zrobiła z notatnikiem:
Zastosowanie wyraźnych separatorów blokowych dla sekcji tytułu, treści i formatu wpisu zapobiegło zlewaniu się metadanych z tekstem użytkownika i wyeliminowało błędy parsowania przy wieloliniowych notatkach zawierających znaki specjalne.

---

## Weryfikacja działania notatnika

1. **Format z rundy 4:** W pełni zaimplementowany i przetestowany — format `## YYYY-MM-DD HH:mm — Tytuł` z pustą linią między notatkami.
2. **Polskie znaki:** Zachowane i wyświetlane poprawnie we wszystkich widokach oraz w pliku `notatki.md` (kodowanie UTF-8).
3. **Najnowsza notatka na górze:** Mechanizm odczytu i zapisu gwarantuje odwróconą chronologię.
4. **Test 5 zapisów:** Potwierdzono pomyślny test pięciokrotnego zapisu — w pliku znajduje się dokładnie 5 wpisów, a żaden wcześniejszy wpis nie został nadpisany ani utracony.
5. **Obsługa błędów:** Blok `try-catch` zabezpiecza aplikację przed awarią przy próbie zapisu do pliku tylko do odczytu lub przy braku uprawnień systemowych.

---

## Jak uruchomić aplikację

Wymagane środowisko: **.NET SDK 9.0**

### Sposób 1: Skrypt uruchomieniowy
Dwuklik na plik:
```cmd
Uruchom-Aplikacje.bat
```

### Sposób 2: Terminal
```bash
cd notatnik
dotnet run
```
