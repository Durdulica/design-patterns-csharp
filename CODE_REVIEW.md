# Code Review — design-patterns-csharp

**Ultima rundă:** 2026-08-05 · **Commit:** 72c3cbf „ex4" · **Build:** trece · **Rulare:** ex3 + ex4 rulate, output verificat

---

# Runda 3 — ex3 (Strategy solo) + ex4 (Observer solo)

## Rezolvate din runda 2 ✅

| Constatare | Verificat |
|---|---|
| B1 — `Dezaboneaza` dimensiona array-ul din presupuneri | ✅ acum numeri întâi (`Comanda.cs:29-38`), apoi aloci — exact traseul corect |
| B2 — formula `LivrareStandard` avea coeficienții Express | ✅ `5 + 0.5m * g + 0.1m * d` |
| M2 (ex1) — cazul de eroare nedemonstrat | ✅ `Testare1.cs:29-37`, `try/catch (ArgumentException)` cu greutate `0` |
| M2 (ex2) — bonusul `Aboneaza`/`Dezaboneaza` nedemonstrat | ✅ `Testare2.cs` abonează după prima schimbare și dezabonează după a doua |
| M1 — `.vs/` în git | ✅ scos din tracking + `.gitignore` |
| C1 — spațiere `i  <` | ✅ |
| Notă de design — notificare fără schimbare reală | ✅ `Comanda.cs:53` — `if (Stare == stareNoua) return;` |

Șase din șase, plus nota opțională. Asta e prima rundă în care n-ai introdus nicio regresie reparând altceva — exact lecția din Q2 runda 2.

**Rămas nerezolvat:** C1 din ex1 — `ArgumentOutOfRangeException("Discount percent...")` (`LivrareCuReducere.cs:14`) tot trimite mesajul pe poziția lui `paramName`. Rulează-l și uită-te la textul afișat: „Parameter 'Discount percent must be between 0 and 100'". Corect: `new ArgumentOutOfRangeException(nameof(procent), "Discount percent must be between 0 and 100")`.

## Ce e corect în runda asta ✅

- **Ambele pattern-uri aplicate solo, fără pași dați.** `Raport` nu are niciun `if` pe format; `StatieMeteo` nu cunoaște nicio clasă concretă de afișaj. Miezul e prins în amândouă.
- **`AfisajStatistica` cu stare proprie** care chiar se acumulează — media se mișcă 20 → 25 → 30 la rulare. Observatori cu stare, nu doar printere.
- **`minim = decimal.MaxValue` / `maxim = decimal.MinValue`** ca valori de start — idiomul corect, l-ai găsit singur (alternativa naivă, `minim = 0`, ar fi dat minim 0 la temperaturi pozitive).
- **`ArgumentNullException("date")`** (`Raport.cs:12`) — aici primul argument CHIAR e `paramName`, deci e corect. Fix subtilitatea de la C1: `ArgumentException` primește mesajul primul, `ArgumentNullException` și `ArgumentOutOfRangeException` primesc numele parametrului.
- **N-ai portat garda `if (Stare == stareNoua) return;` în `StatieMeteo`.** Bine — vezi Q1, nu e o omisiune, e o decizie corectă.

## 🔴 Critice

### B1 — `ExportCsv` duplică primul rând și pune virgulă în față
`ex3/Models/ExportCsv.cs:11-16`

Adaugi `randuri[0]` înainte de buclă, dar bucla pornește tot de la `0`:

```csharp
rez += randuri[0];

for (int i = 0; i < randuri.Length; i++)
{
    rez += ',' + randuri[i];
}
```

La rulare iese:

```
CSV:
bia,bia,este,o prietena,foarte buna
```

„bia" apare de două ori. La `ExportText:13` și `ExportMarkdown:13` ai scris exact aceeași formă — element zero în afara buclei, buclă de la `1` — și acolo e corect. Doar CSV a rămas cu `i = 0`, probabil pentru că la CSV separatorul e la fel peste tot și nu s-a „simțit" diferența la scris.

| | Acum | Corect |
|---|---|---|
| Cod | `rez += randuri[0];`<br>`for (int i = 0; ...)`<br>`rez += ',' + randuri[i];` | `rez += randuri[0];`<br>`for (int i = 1; ...)`<br>`rez += "," + randuri[i];` |
| Output | `bia,bia,este,o prietena,foarte buna` | `bia,este,o prietena,foarte buna` |

**Lecția:** tehnica „primul element în afara buclei" are întotdeauna două jumătăți — scoți elementul 0 ȘI pornești bucla de la 1. Dacă schimbi doar una, se dublează tăcut: nu e nicio eroare de compilare, nicio excepție, doar un rezultat greșit. Când repeți același șablon în trei clase, verifică-le una lângă alta — divergențele de o cifră se văd doar în comparație. (Enunțul îți permitea `string.Join(",", randuri)` la CSV — o singură linie, fără index de greșit.)

### B2 — `,` ca `char` face adunare de numere, nu concatenare
`ex3/Models/ExportCsv.cs:15`

Ascuns în B1, dar e o capcană separată, care te va prinde din nou:

```csharp
rez += ',' + randuri[i];
```

`','` e `char`, nu `string`. C# evaluează întâi `',' + randuri[i]` — și fiindcă `char` e un tip numeric, într-un context unde operandul e `string` se face totuși concatenare, deci aici scapi. Dar scrie `rez += ',' + '-';` și nu mai obții `",-"`, obții `89` (44 + 45, codurile numerice adunate). Regula sigură: separatorii se scriu `","`, cu ghilimele duble, nu `','`.

**Lecția:** `char` e un număr în C#. `+` între două `char`-uri e adunare aritmetică, nu concatenare — devine concatenare doar dacă cel puțin un operand e `string`. Aici te-a salvat `randuri[i]`.

## 🟡 Importante

### M1 — `AfisajStatistica` ține tot istoricul, deși cerința îți spunea să ții doar câmpuri
`ex4/Models/AfisajStatistica.cs:5,12,25-33`

Păstrezi un `decimal[] temperaturi` pe care îl recreezi la fiecare măsurătoare, doar ca să recalculezi suma de la zero:

```csharp
media = 0;
for (int i = 0; i < temperaturi.Length; i++)
{
    tempNoi[i] = temperaturi[i];
    media += temperaturi[i];
}
```

Rezultatul e corect, dar constrângerea din enunț era explicită: *„pentru statistica tine tu campurile (min, max, suma, numar)"*. Cu `suma` și `numar` ca stare, `Actualizeaza` devine trei linii, fără array, fără buclă: `suma += temperatura; numar++; media = suma / numar;`. Diferența practică: acum, la măsurătoarea N faci N copieri și N adunări — după 10.000 de măsurători, o stație meteo reală ar face 50 de milioane de operații pentru o medie care cere una singură.

Al doilea lucru, mai important decât viteza: folosești câmpul `media` pe post de acumulator temporar (`media = 0;` apoi `media += ...`). Câtă vreme bucla merge, `media` conține o sumă parțială, nu o medie — un câmp care minte despre ce ține între două linii de cod. Un acumulator care trăiește doar în interiorul metodei trebuie să fie variabilă locală; câmpurile țin doar starea care are sens și după ce metoda s-a terminat.

**Lecția:** min/max/media sunt agregate *incrementale* — se pot actualiza din valoarea nouă plus starea de dinainte, fără să reții istoricul. Ai văzut deja asta la min și max (le actualizezi corect, cu un `if`); media urmează exact aceeași logică, dacă ții `suma` și `numar` în loc de valori. Reține istoricul doar când chiar ai nevoie de el — de exemplu la un `AfisajGrafic` care desenează evoluția.

### M2 — `StatieMeteo` a rămas cu numele din ex2
`ex4/Models/StatieMeteo.cs:5,6,13`

Ai copiat scheletul din `Comanda` și n-ai schimbat vocabularul: `observatori`, `Stare`, `SchimbaStare`. Enunțul cerea `SeteazaTemperatura(decimal t)`, iar domeniul vorbește despre afișaje și temperatură, nu despre stări și observatori.

```csharp
private IAfisaj[] observatori;
public decimal Stare { get; private set; }
public void SchimbaStare(decimal stareNoua)
```

Contează pentru că `Stare` e acum un `decimal` care se cheamă „stare" — cine citește `statie.SchimbaStare(30)` nu are cum să ghicească dacă 30 e grade, minute sau un cod. Numele corecte (`afisaje`, `Temperatura`, `SeteazaTemperatura`) fac codul auto-explicativ fără niciun comentariu.

**Lecția:** pattern-ul se refolosește, vocabularul nu. Structura lui Observer e aceeași în orice domeniu — un subiect, o listă de abonați, o buclă de notificare — dar numele trebuie să vină din domeniul curent. Când numele rămân din exercițiul precedent, e semnul că ai copiat forma fără să retraduci problema.

### M3 — cele 3 strategii crapă pe un array gol
`ex3/Models/ExportCsv.cs:11`, `ExportText.cs:11`, `ExportMarkdown.cs:11`

Toate trei citesc `randuri[0]` înainte de orice verificare. `new Raport(new string[0], new ExportCsv())` trece de validarea din constructor (nu e `null`) și crapă la `Exporta()` cu `IndexOutOfRangeException`. Ai apărat repotul de `null`, dar nu de „gol" — și gol e cazul mult mai probabil în practică (un raport fără rânduri e o situație normală, nu o eroare de programare). Un `if (randuri.Length == 0) return string.Empty;` la începutul fiecărui `Formateaza` închide subiectul.

**Lecția:** `null` și „gol" sunt două lucruri diferite, și se apără diferit. `null` înseamnă „lipsește obiectul" — de obicei un bug al apelantului, deci excepție. Gol înseamnă „obiectul există, dar n-are elemente" — de obicei un caz de business valid, deci un rezultat gol, nu o excepție.

### M4 — `Testare3` ține referințe la strategiile concrete doar ca să afișeze `Nume`
`ex3/Testare3.cs:17,22,27`

```csharp
ExportText text = new();
raport.SchimbaStrategie(text);
Console.WriteLine(text.Nume + ":\n" + raport.Exporta());
```

Declari variabile de tip concret (`ExportCsv`, `ExportText`, `ExportMarkdown`) și le ții în viață după ce le-ai dat raportului, pentru un singur motiv: să citești `.Nume`. Dar cine știe formatul curent e `Raport`-ul — el ține strategia. Cu o proprietate `public string NumeFormat => strategie.Nume;` în `Raport`, testul devine `raport.SchimbaStrategie(new ExportText());` urmat de `raport.NumeFormat` — și nu mai are nevoie de tipuri concrete deloc.

**Lecția:** dacă apelantul trebuie să țină minte ce i-a dat contextului ca să poată descrie starea contextului, informația stă în locul greșit. Un context complet își poate răspunde singur la „cu ce lucrezi acum?". Verificarea rapidă: dacă poți schimba toate variabilele din test din tip concret în tipul interfeței și codul tot compilează, contextul e complet — acum `ExportCsv strategie` nu poate deveni `IExportStrategie strategie` fără să pierzi nimic, ceea ce e semnul că `.Nume` e citit de unde nu trebuie.

## 🟢 Cleanups

- **C1** — `Raport.SchimbaStrategie`/`Exporta` vs. `SchimbaFormat`/`Genereaza` din enunț (`Raport.cs:19,24`). Codul e corect; dar când enunțul fixează un nume, respectă-l — la lucrul în echipă contractul e literă de lege, nu sugestie.
- **C2** — formatul cerut la statistică era `[STATISTICA] Min: a | Max: b | Media: c`; tu afișezi fără separatorii `|` (`AfisajStatistica.cs:35`). Cosmetic, dar output-ul cerut face parte din cerință.
- **C3** — `Raport.Date` e `public` și întoarce chiar array-ul intern (`Raport.cs:6`); oricine îl primește poate schimba conținutul raportului pe la spate. Aici nimeni n-o face, dar câmpul n-are motiv să fie public.
- **C4** — concatenare cu `+=` în buclă (toate cele 3 strategii): fiecare `+=` creează un string nou, fiindcă în C# string-urile sunt imutabile. La 4 rânduri e irelevant; la 10.000 se simte. `StringBuilder` e unealta pentru asta — nu e interzisă de enunț, spre deosebire de LINQ și `List`.
- **C5** — `StatieMeteo` nu verifică `observatori == null` (`StatieMeteo.cs:10`), deși în `Raport` ai pus verificarea. Aceeași grijă, aplicată inconsecvent între cele două exerciții.

## Q&A

**Q1.** În `Comanda` (ex2) ai adăugat `if (Stare == stareNoua) return;` — corect acolo. În `StatieMeteo` nu l-ai pus. Presupune că îl pui: ce se întâmplă cu media din `AfisajStatistica` dacă stația măsoară 30, apoi tot 30? De ce garda e corectă la o comandă și greșită la o stație meteo?

**Q2.** `ExportText` și `ExportMarkdown` funcționează, `ExportCsv` nu — deși toate trei sunt scrise după aceeași schemă. Uită-te la ele una sub alta și spune ce diferență de un singur caracter face separarea. Apoi: ce ai fi putut face la scris ca greșeala să nu fie posibilă deloc? (hint: ce anume trebuie repetat de trei ori, și ce nu)

**Q3.** `AfisajCurent` n-are niciun câmp; `AfisajStatistica` are patru. Amândouă intră în același `IAfisaj[]`. Dacă mâine adaugi `AfisajGrafic` care chiar are nevoie de tot istoricul, câte linii din `StatieMeteo` atingi — și de ce răspunsul ăsta e tot argumentul pentru care Observer merită efortul?

---

# ex2 — Observer (runda 1)

## Ce e corect ✅

- **Observer aplicat corect.** `SchimbaStare` setează `Stare` și parcurge observatorii cu `for`, chemând `Actualizeaza` — fără să cunoască nicio clasă concretă. Exact miezul pattern-ului.
- **Toate cerințele 1-3 îndeplinite** — și output-ul respectă formatul din enunț (`[EMAIL] ...`, `[LOG] ...`, `[DEPOZIT] ...`), grupat câte 3 pe schimbare. Progres clar față de `Testare1` din prima rundă, care era incomplet.
- **Bonus `Aboneaza`** — crești array-ul manual, corect, fără `List`.

## 🔴 Critice

### B1 — `Dezaboneaza` presupune că observatorul există EXACT o dată
`ex2/Models/Comanda.cs:29`

Pre-dimensionezi array-ul nou la `observatori.Length - 1` ÎNAINTE să știi câte apariții scoți:

```csharp
IObservator[] obsNou = new IObservator[observatori.Length - 1];
```

Dacă `vechi` **nu e în listă**, toate cele N elemente trec de `if (observatori[i] != vechi)` și încerci să pui N elemente într-un array de N-1 → `IndexOutOfRangeException` la ultima copiere. Dacă `vechi` apare **de două ori**, rămâne un slot `null` la coadă, iar la următoarea `SchimbaStare` crapă cu `NullReferenceException`. Și fiindcă nu chemi `Dezaboneaza` nicăieri (vezi M2), bug-ul e ascuns — netestat.

| | Acum | Corect |
|---|---|---|
| Idee | dimensionezi întâi, presupui o apariție | numeri întâi câte rămân, apoi dimensionezi |

Un traseu sigur: parcurgi o dată și NUMERI câte sunt `!= vechi`, aloci array-ul de acea mărime, apoi copiezi. Așa merge și când lipsește, și când apare de mai multe ori.

**Lecția:** când mărimea rezultatului depinde de conținut, n-o fixa din presupuneri — calculeaz-o din date. „Sigur e exact unul" e felul în care se nasc `IndexOutOfRange`-urile.

## 🟡 Importante

### M1 — `.vs/` a ajuns în git (15 fișiere)
Repo. `git add .` a măturat folderul ascuns al Visual Studio (`.vs/` — setări locale de IDE, cache, layout de ferestre). Nu e cod, e starea editorului TĂU; pe altă mașină n-are sens. `.gitignore` are doar `bin/` și `obj/`. Adaugă `.vs/` și scoate-l din tracking:
```bash
git rm -r --cached .vs
```
De acum, regula fixă: orice folder pe care NU l-ai scris tu (îl generează IDE-ul sau compilatorul) intră în `.gitignore` ÎNAINTE de primul `git add .`.

### M2 — bonusul e scris dar nedemonstrat în `Testare2`
`ex2/Testare2.cs`

`Aboneaza`/`Dezaboneaza` există, dar `Testare2` nu le cheamă niciodată. Cerința bonus cerea explicit: abonează un observator DUPĂ prima `SchimbaStare` și arată că prinde doar schimbările următoare. Fără scenariul ăsta, bonusul e cod nedovedit — și exact asta a ținut ascuns bug-ul B1. Adaugă: după `SchimbaStare("Expediata")`, un `Aboneaza(...)`, apoi `SchimbaStare("Livrata")`, și un `Dezaboneaza(...)` de probă.

## 🟢 Cleanups

- **C1** — spațiere dublă `i  < observatori.Length` (`Comanda.cs:45`). Cosmetic.
- **Notă de design** — `SchimbaStare` anunță chiar dacă starea nouă e identică cu cea veche. Enunțul menționa capcana „notificare fără schimbare reală". Opțional: dacă `stareNoua == Stare`, nu mai anunța.

---

# ex1 — Strategy (runda 2)

## Rezolvate ✅

| Din runda 1 | Verificat |
|---|---|
| M2 (parțial) — `Nume` în output + `LivrareGratuita` testată | ✅ toate 4 strategiile apar etichetate |
| M3 — excepție corectă în `LivrareCuReducere` | ✅ `ArgumentOutOfRangeException` (vezi C1 mai jos) |
| C2 — `using System.Globalization` scos | ✅ |
| C1 — literali `decimal` cu `m` | ✅ ca stil — dar a introdus B2 |

## 🔴 Critice

### B2 (regresie nouă) — formula din `LivrareStandard` e greșită
`ex1/Models/LivrareStandard.cs:9`

Când ai trecut la literali `m`, ai copiat coeficienții de la Express în Standard:

```csharp
return 5 + 1.0m * greutateKg + 0.25m * distantaKm;   // sunt coeficienții Express
```

Enunțul cere pentru Standard `5 + 0.5·greutate + 0.1·distanța`. La rulare iese `Standard: 110.00` în loc de `57.00`, iar Standard și Express au acum practic aceeași formulă (diferă doar prin `5` vs `12`).

| | Acum | Corect |
|---|---|---|
| Standard | `5 + 1.0m * g + 0.25m * d` | `5 + 0.5m * g + 0.1m * d` |

**Lecția** (fix cea de la Q&A runda 1): un cleanup „doar cosmetic" a schimbat comportamentul. După ORICE refactor, chiar și unul care „nu schimbă logica", re-rulează și compară cifrele. O zecimală schimbată din greșeală nu dă eroare de compilare — trece tăcută până o vede cineva în output.

## 🟡 Importante

### M2 (rămas, pct. 3) — cazul de eroare tot nu e demonstrat
`ex1/Testare1.cs`

Validarea greutății există în constructorul `Comanda`, dar `Testare1` n-o pune niciodată la treabă. Cerința 4 cerea o comandă cu greutate `0`, prinsă cu `try/catch (ArgumentException)` și mesajul afișat. Adaug-o la final.

## 🟢 Cleanups

- **C1** — la `ArgumentOutOfRangeException`, primul argument e `paramName`, nu mesajul. Acum mesajul tău ajunge afișat ca nume de parametru („Parameter 'Discount percent...'"). Idiomatic: `new ArgumentOutOfRangeException(nameof(procent), "Discount percent must be between 0 and 100")`. Subtilitatea care te-a prins: la `ArgumentException` primul arg e mesajul, la `ArgumentOutOfRangeException` e numele parametrului — de-aia s-a schimbat sensul când ai schimbat tipul.
- **C3 (rămas)** — `Nume => "Reducere"` tot ascunde ce strategie împachetează. Îl reluăm la lecția Decorator.

---

## Q&A

**Q1.** (ex2) Scrie pe hârtie ce se întâmplă pas cu pas în `Dezaboneaza` dacă array-ul are 3 observatori și-i dai unul care NU e în listă. La ce index se oprește și de ce? Ce mărime ar fi trebuit să aibă `obsNou`?

**Q2.** (ex1) Standard și Express dau acum 110 și 117 — aproape la fel. Dacă N-ai fi avut cifrele din enunț în față, ce te-ar fi făcut să bănuiești că Standard e greșit, doar uitându-te la output? (hint: ce rost mai are „Standard" dacă e cât „Express"?)

**Q3.** (ex2) `Aboneaza` și `Dezaboneaza` refac amândouă array-ul de la zero. De ce în C# nu poți pur și simplu „mări" un array existent, și ce structură din .NET face exact asta pentru tine (pe care noi am interzis-o intenționat aici, ca să vezi mecanismul)?
