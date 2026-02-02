# Unit-Testing in C# mit NUnit & Moq (2-Tage Praxis-Seminar)

Dieses Repository begleitet ein 2-tägiges, praxisnahes Seminar rund um **Unit-Tests in C#** mit **NUnit** und **Moq**.
Wir arbeiten in kleinen, überschaubaren Projekten, die wir immer wieder **"from scratch"** neu aufsetzen – inklusive Setup, Design-Entscheidungen und Refactoring.

---

## Lernziele

Nach dem Seminar kannst du:

- Unit-Tests sauber **strukturieren** (Naming, AAA, Arrange/Act/Assert)
- passende **Assertions** wählen und aussagekräftige Fehlerbilder erzeugen
- mit **Moq** Abhängigkeiten isolieren (Stubs/Mocks, Setup/Verify)
- erste Schritte in **test-first / TDD-orientiertem** Arbeiten gehen
- verstehen, wie **Testbarkeit** und **Architektur** zusammenhängen
- **Reqnroll** einordnen und gegenüber **NUnit** abgrenzen

---

## Testarten: Abgrenzung & Zweck

In der Praxis spricht man oft über „Tests“ – gemeint sind aber verschiedene Ebenen.  
Wichtig: **Unit-Tests sind keine Mini-Integrationstests.**

### Unit-Tests
**Ziel:** Verhalten einer *kleinen Einheit* (Methode/Klasse) prüfen, **isoliert** von externen Systemen.  
**Eigenschaften:**
- sehr schnell (Millisekunden)
- deterministisch (keine Netzwerk-/DB-/Dateisystem-Abhängigkeiten)
- fokussiert auf eine Sache (ein Verhalten, ein Grund zu scheitern)
- Abhängigkeiten werden i. d. R. über **Mocks/Fakes** ersetzt

**Typische Beispiele:**
- Berechnungen, Validierung, Entscheidungslogik
- Mapping/Transformation
- Orchestrierung, *wenn* Abhängigkeiten gemockt werden

---

### Integrationstests
**Ziel:** Zusammenspiel mehrerer Komponenten prüfen – *mit echten* Integrationen.  
**Eigenschaften:**
- nutzen häufig echte Infrastruktur (DB, Dateisystem, HTTP, Queue)
- langsamer als Unit-Tests
- prüfen z. B. Konfiguration, Mapping, Datenzugriff, Serialisierung

**Typische Beispiele:**
- Repository gegen echte Datenbank (ggf. Testcontainer)
- API-Endpunkt gegen InMemoryServer / TestHost
- Serialization roundtrips (JSON ↔ DTO)

---

### Systemtests / End-to-End (E2E)
**Ziel:** System als Ganzes testen, wie ein echter Benutzer/Client.  
**Eigenschaften:**
- am langsamsten, am teuersten in Pflege & Laufzeit
- decken viel ab, aber Fehlersuche kann aufwendig sein
- gut für kritische Kernpfade (Happy Path) und Integration realer Umgebungen

**Typische Beispiele:**
- UI-Tests (Playwright/Selenium)
- komplette Journey durch mehrere Services

---

## Setup: Umgebung & NuGet

Wir nutzen .NET (SDK) und erstellen die Projekte bewusst „von Null“.

### Voraussetzungen
- .NET SDK (passende Version je nach Seminar-Rechnern)
- IDE: Visual Studio / Rider / VS Code (mit C# Extensions)

### Pakete (NuGet)
**Testprojekt** (Beispiel-Pakete):
- `NUnit`
- `NUnit3TestAdapter`
- `Microsoft.NET.Test.Sdk`

**Mocking:**
- `Moq`

> Hinweis: Die genauen Versionen halten wir im Seminar bewusst konsistent pro Repo/Tag.

---

## Grundprinzipien: Gute Unit-Tests

### 1) AAA / Triple-A Prinzip
Ein Test folgt (fast immer) dieser Struktur:

- **Arrange:** Testdaten + Abhängigkeiten vorbereiten
- **Act:** Methode/Unit ausführen
- **Assert:** Ergebnis verifizieren

Das macht Tests **lesbar**, **wartbar** und reduziert „Test-Spaghetti“.

---

### 2) Naming-Konvention (Lesbarkeit gewinnt)
Wir verwenden sprechende Testnamen, die *Verhalten + Erwartung* ausdrücken.

Empfehlung (eine von mehreren guten Varianten):

- `MethodName_WhenCondition_ShouldExpectedResult`

Beispiele:
- `CalculateTotal_WhenCartIsEmpty_ShouldReturnZero`
- `CreateUser_WhenEmailIsInvalid_ShouldThrowValidationException`

Wichtig ist Konsistenz im Projekt.

---

### 3) Assertions: Aussagekräftig und präzise
- prüfe genau das, was der Test belegen soll
- lieber klare, kleine Tests als „ein Test prüft alles“
- bei Exceptions: exakt die erwartete Exception (und ggf. Message/Parameter) prüfen

---

## Seminarstruktur (Überblick)

### Tag 1
1. **Einführung NUnit** an einem simplen Beispiel  
   (Naming, AAA, Assertions)
2. **Übung: from scratch** (eigenes Mini-Projekt)
3. **Einführung Mocking** (Warum? Wann? Wie?)

### Tag 2
4. **Übungen Moq (Setup/Returns/Throws/Verify, Argument-Matching)**  
   + Einstieg **test-first** (kleine Iterationen)
5. **Zusammenhang Testen & Architektur**  
   (Abhängigkeiten, Schnittstellen, SOLID, Testbarkeit)
6. **Kurze Vorstellung Reqnroll**  
   + Abgrenzung zu NUnit (BDD-Schicht vs. Testframework)


