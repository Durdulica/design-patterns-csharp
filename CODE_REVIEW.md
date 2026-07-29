# Code Review — design-patterns-csharp

**Ultima rundă:** 2026-07-29 · **Commit:** 0d25652 „observer pattern" · **Build:** trece · **Rulare:** ex1 + ex2 rulează

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
