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
